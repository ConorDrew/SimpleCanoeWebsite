using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class UCAbsences
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _gbAbsence = new GroupBox();
            _txtEndTimeMinutes = new TextBox();
            _txtEndTimeHours = new TextBox();
            _txtEndTimeHours.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _txtStartTimeMinutes = new TextBox();
            _txtStartTimeMinutes.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _txtStartTimeHours = new TextBox();
            _txtStartTimeHours.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _lblTimeToSpacer = new Label();
            _lblTimeFromSpacer = new Label();
            _lblType = new Label();
            _cboType = new ComboBox();
            _dtTo = new DateTimePicker();
            _dtFrom = new DateTimePicker();
            _cboUsers = new ComboBox();
            _lblUser = new Label();
            _txtComments = new TextBox();
            _lblToDate = new Label();
            _lblFromDate = new Label();
            _lblComments = new Label();
            _tcMain = new TabControl();
            _tpGeneral = new TabPage();
            _tpRecurring = new TabPage();
            _gpRecurring = new GroupBox();
            _lblRecurringTimeTo = new Label();
            _lblTimeFrom = new Label();
            _cbSunday = new CheckBox();
            _cbSaturday = new CheckBox();
            _cbFriday = new CheckBox();
            _cbThursday = new CheckBox();
            _cbWednesday = new CheckBox();
            _cbTuesday = new CheckBox();
            _txtRecurringTimeToMins = new TextBox();
            _txtRecurringTimeToMins.TextChanged += new EventHandler(txtEndTimeRecurringHours_TextChanged);
            _cbMonday = new CheckBox();
            _txtRecurringTimeToHours = new TextBox();
            _txtRecurringTimeToHours.TextChanged += new EventHandler(txtEndTimeRecurringHours_TextChanged);
            _txtRecurringTimeFromMins = new TextBox();
            _txtRecurringTimeFromMins.TextChanged += new EventHandler(txtEndTimeRecurringHours_TextChanged);
            _txtRecurringTimeFromHours = new TextBox();
            _txtRecurringTimeFromHours.TextChanged += new EventHandler(txtEndTimeRecurringHours_TextChanged);
            _lblRecurringTimeToSpacer = new Label();
            _lblRecurringTimeFromSpacer = new Label();
            _lblRecurringType = new Label();
            _cboRecurringType = new ComboBox();
            _dtRecurringDateTo = new DateTimePicker();
            _dtRecurringDateFrom = new DateTimePicker();
            _cboRecurringUser = new ComboBox();
            _lblRecurringUser = new Label();
            _txtRecurringComments = new TextBox();
            _lblRecurringDateTo = new Label();
            _lblRecurringDateFrom = new Label();
            _lblRecurringComments = new Label();
            _gbAbsence.SuspendLayout();
            _tcMain.SuspendLayout();
            _tpGeneral.SuspendLayout();
            _tpRecurring.SuspendLayout();
            _gpRecurring.SuspendLayout();
            SuspendLayout();
            // 
            // gbAbsence
            // 
            _gbAbsence.Anchor = AnchorStyles.Top;
            _gbAbsence.Controls.Add(_txtEndTimeMinutes);
            _gbAbsence.Controls.Add(_txtEndTimeHours);
            _gbAbsence.Controls.Add(_txtStartTimeMinutes);
            _gbAbsence.Controls.Add(_txtStartTimeHours);
            _gbAbsence.Controls.Add(_lblTimeToSpacer);
            _gbAbsence.Controls.Add(_lblTimeFromSpacer);
            _gbAbsence.Controls.Add(_lblType);
            _gbAbsence.Controls.Add(_cboType);
            _gbAbsence.Controls.Add(_dtTo);
            _gbAbsence.Controls.Add(_dtFrom);
            _gbAbsence.Controls.Add(_cboUsers);
            _gbAbsence.Controls.Add(_lblUser);
            _gbAbsence.Controls.Add(_txtComments);
            _gbAbsence.Controls.Add(_lblToDate);
            _gbAbsence.Controls.Add(_lblFromDate);
            _gbAbsence.Controls.Add(_lblComments);
            _gbAbsence.Font = new Font("Verdana", 8.0F);
            _gbAbsence.Location = new Point(3, 6);
            _gbAbsence.Name = "gbAbsence";
            _gbAbsence.Size = new Size(613, 156);
            _gbAbsence.TabIndex = 26;
            _gbAbsence.TabStop = false;
            _gbAbsence.Text = "User Absence";
            // 
            // txtEndTimeMinutes
            // 
            _txtEndTimeMinutes.Location = new Point(336, 120);
            _txtEndTimeMinutes.MaxLength = 2;
            _txtEndTimeMinutes.Name = "txtEndTimeMinutes";
            _txtEndTimeMinutes.Size = new Size(27, 20);
            _txtEndTimeMinutes.TabIndex = 53;
            // 
            // txtEndTimeHours
            // 
            _txtEndTimeHours.Location = new Point(299, 120);
            _txtEndTimeHours.MaxLength = 2;
            _txtEndTimeHours.Name = "txtEndTimeHours";
            _txtEndTimeHours.Size = new Size(27, 20);
            _txtEndTimeHours.TabIndex = 46;
            // 
            // txtStartTimeMinutes
            // 
            _txtStartTimeMinutes.Location = new Point(336, 88);
            _txtStartTimeMinutes.MaxLength = 2;
            _txtStartTimeMinutes.Name = "txtStartTimeMinutes";
            _txtStartTimeMinutes.Size = new Size(27, 20);
            _txtStartTimeMinutes.TabIndex = 45;
            // 
            // txtStartTimeHours
            // 
            _txtStartTimeHours.Location = new Point(299, 88);
            _txtStartTimeHours.MaxLength = 2;
            _txtStartTimeHours.Name = "txtStartTimeHours";
            _txtStartTimeHours.Size = new Size(27, 20);
            _txtStartTimeHours.TabIndex = 44;
            // 
            // lblTimeToSpacer
            // 
            _lblTimeToSpacer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTimeToSpacer.Location = new Point(325, 123);
            _lblTimeToSpacer.Name = "lblTimeToSpacer";
            _lblTimeToSpacer.Size = new Size(9, 17);
            _lblTimeToSpacer.TabIndex = 43;
            _lblTimeToSpacer.Text = ":";
            // 
            // lblTimeFromSpacer
            // 
            _lblTimeFromSpacer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTimeFromSpacer.Location = new Point(325, 91);
            _lblTimeFromSpacer.Name = "lblTimeFromSpacer";
            _lblTimeFromSpacer.Size = new Size(9, 17);
            _lblTimeFromSpacer.TabIndex = 42;
            _lblTimeFromSpacer.Text = ":";
            // 
            // lblType
            // 
            _lblType.Font = new Font("Verdana", 8.0F);
            _lblType.Location = new Point(9, 56);
            _lblType.Name = "lblType";
            _lblType.Size = new Size(56, 17);
            _lblType.TabIndex = 37;
            _lblType.Text = "Type";
            // 
            // cboType
            // 
            _cboType.Anchor = AnchorStyles.Top;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Font = new Font("Verdana", 8.0F);
            _cboType.ItemHeight = 13;
            _cboType.Items.AddRange(new object[] { "Holiday", "Sickness", "Other" });
            _cboType.Location = new Point(93, 56);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(270, 21);
            _cboType.TabIndex = 2;
            // 
            // dtTo
            // 
            _dtTo.Font = new Font("Verdana", 8.0F);
            _dtTo.Location = new Point(93, 120);
            _dtTo.Name = "dtTo";
            _dtTo.Size = new Size(201, 20);
            _dtTo.TabIndex = 6;
            // 
            // dtFrom
            // 
            _dtFrom.Font = new Font("Verdana", 8.0F);
            _dtFrom.Location = new Point(93, 88);
            _dtFrom.Name = "dtFrom";
            _dtFrom.Size = new Size(200, 20);
            _dtFrom.TabIndex = 3;
            // 
            // cboUsers
            // 
            _cboUsers.Anchor = AnchorStyles.Top;
            _cboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUsers.Font = new Font("Verdana", 8.0F);
            _cboUsers.ItemHeight = 13;
            _cboUsers.Items.AddRange(new object[] { "Holiday", "Sickness", "Other" });
            _cboUsers.Location = new Point(93, 24);
            _cboUsers.Name = "cboUsers";
            _cboUsers.Size = new Size(270, 21);
            _cboUsers.TabIndex = 1;
            // 
            // lblUser
            // 
            _lblUser.Font = new Font("Verdana", 8.0F);
            _lblUser.Location = new Point(9, 24);
            _lblUser.Name = "lblUser";
            _lblUser.Size = new Size(78, 17);
            _lblUser.TabIndex = 18;
            _lblUser.Text = "User";
            // 
            // txtComments
            // 
            _txtComments.Font = new Font("Verdana", 8.0F);
            _txtComments.Location = new Point(373, 48);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Both;
            _txtComments.Size = new Size(234, 96);
            _txtComments.TabIndex = 9;
            // 
            // lblToDate
            // 
            _lblToDate.Font = new Font("Verdana", 8.0F);
            _lblToDate.Location = new Point(9, 120);
            _lblToDate.Name = "lblToDate";
            _lblToDate.Size = new Size(54, 18);
            _lblToDate.TabIndex = 20;
            _lblToDate.Text = "To";
            // 
            // lblFromDate
            // 
            _lblFromDate.Font = new Font("Verdana", 8.0F);
            _lblFromDate.Location = new Point(9, 88);
            _lblFromDate.Name = "lblFromDate";
            _lblFromDate.Size = new Size(47, 18);
            _lblFromDate.TabIndex = 19;
            _lblFromDate.Text = "From";
            // 
            // lblComments
            // 
            _lblComments.Font = new Font("Verdana", 8.0F);
            _lblComments.Location = new Point(373, 24);
            _lblComments.Name = "lblComments";
            _lblComments.Size = new Size(84, 17);
            _lblComments.TabIndex = 23;
            _lblComments.Text = "Comments";
            // 
            // tcMain
            // 
            _tcMain.Anchor = AnchorStyles.Top;
            _tcMain.Controls.Add(_tpGeneral);
            _tcMain.Controls.Add(_tpRecurring);
            _tcMain.Location = new Point(3, 3);
            _tcMain.Name = "tcMain";
            _tcMain.SelectedIndex = 0;
            _tcMain.Size = new Size(624, 230);
            _tcMain.TabIndex = 27;
            // 
            // tpGeneral
            // 
            _tpGeneral.BackColor = Color.White;
            _tpGeneral.Controls.Add(_gbAbsence);
            _tpGeneral.Location = new Point(4, 22);
            _tpGeneral.Name = "tpGeneral";
            _tpGeneral.Padding = new Padding(3);
            _tpGeneral.Size = new Size(616, 204);
            _tpGeneral.TabIndex = 0;
            _tpGeneral.Text = "General";
            // 
            // tpRecurring
            // 
            _tpRecurring.BackColor = Color.White;
            _tpRecurring.Controls.Add(_gpRecurring);
            _tpRecurring.Location = new Point(4, 22);
            _tpRecurring.Name = "tpRecurring";
            _tpRecurring.Padding = new Padding(3);
            _tpRecurring.Size = new Size(616, 204);
            _tpRecurring.TabIndex = 1;
            _tpRecurring.Text = "Recurring";
            // 
            // gpRecurring
            // 
            _gpRecurring.Anchor = AnchorStyles.Top;
            _gpRecurring.Controls.Add(_lblRecurringTimeTo);
            _gpRecurring.Controls.Add(_lblTimeFrom);
            _gpRecurring.Controls.Add(_cbSunday);
            _gpRecurring.Controls.Add(_cbSaturday);
            _gpRecurring.Controls.Add(_cbFriday);
            _gpRecurring.Controls.Add(_cbThursday);
            _gpRecurring.Controls.Add(_cbWednesday);
            _gpRecurring.Controls.Add(_cbTuesday);
            _gpRecurring.Controls.Add(_txtRecurringTimeToMins);
            _gpRecurring.Controls.Add(_cbMonday);
            _gpRecurring.Controls.Add(_txtRecurringTimeToHours);
            _gpRecurring.Controls.Add(_txtRecurringTimeFromMins);
            _gpRecurring.Controls.Add(_txtRecurringTimeFromHours);
            _gpRecurring.Controls.Add(_lblRecurringTimeToSpacer);
            _gpRecurring.Controls.Add(_lblRecurringTimeFromSpacer);
            _gpRecurring.Controls.Add(_lblRecurringType);
            _gpRecurring.Controls.Add(_cboRecurringType);
            _gpRecurring.Controls.Add(_dtRecurringDateTo);
            _gpRecurring.Controls.Add(_dtRecurringDateFrom);
            _gpRecurring.Controls.Add(_cboRecurringUser);
            _gpRecurring.Controls.Add(_lblRecurringUser);
            _gpRecurring.Controls.Add(_txtRecurringComments);
            _gpRecurring.Controls.Add(_lblRecurringDateTo);
            _gpRecurring.Controls.Add(_lblRecurringDateFrom);
            _gpRecurring.Controls.Add(_lblRecurringComments);
            _gpRecurring.Font = new Font("Verdana", 8.0F);
            _gpRecurring.Location = new Point(6, 6);
            _gpRecurring.Name = "gpRecurring";
            _gpRecurring.Size = new Size(610, 192);
            _gpRecurring.TabIndex = 27;
            _gpRecurring.TabStop = false;
            _gpRecurring.Text = "User Recurring Absence";
            // 
            // lblRecurringTimeTo
            // 
            _lblRecurringTimeTo.AutoSize = true;
            _lblRecurringTimeTo.Font = new Font("Verdana", 8.0F);
            _lblRecurringTimeTo.Location = new Point(138, 121);
            _lblRecurringTimeTo.Name = "lblRecurringTimeTo";
            _lblRecurringTimeTo.Size = new Size(25, 13);
            _lblRecurringTimeTo.TabIndex = 61;
            _lblRecurringTimeTo.Text = "To:";
            // 
            // lblTimeFrom
            // 
            _lblTimeFrom.AutoSize = true;
            _lblTimeFrom.Font = new Font("Verdana", 8.0F);
            _lblTimeFrom.Location = new Point(9, 121);
            _lblTimeFrom.Name = "lblTimeFrom";
            _lblTimeFrom.Size = new Size(41, 13);
            _lblTimeFrom.TabIndex = 60;
            _lblTimeFrom.Text = "From:";
            // 
            // cbSunday
            // 
            _cbSunday.Anchor = AnchorStyles.Top;
            _cbSunday.AutoSize = true;
            _cbSunday.Cursor = Cursors.Hand;
            _cbSunday.Location = new Point(514, 167);
            _cbSunday.Name = "cbSunday";
            _cbSunday.RightToLeft = RightToLeft.Yes;
            _cbSunday.Size = new Size(48, 17);
            _cbSunday.TabIndex = 59;
            _cbSunday.Text = "Sun";
            _cbSunday.UseVisualStyleBackColor = true;
            // 
            // cbSaturday
            // 
            _cbSaturday.Anchor = AnchorStyles.Top;
            _cbSaturday.AutoSize = true;
            _cbSaturday.Cursor = Cursors.Hand;
            _cbSaturday.Location = new Point(436, 167);
            _cbSaturday.Name = "cbSaturday";
            _cbSaturday.RightToLeft = RightToLeft.Yes;
            _cbSaturday.Size = new Size(45, 17);
            _cbSaturday.TabIndex = 58;
            _cbSaturday.Text = "Sat";
            _cbSaturday.UseVisualStyleBackColor = true;
            // 
            // cbFriday
            // 
            _cbFriday.Anchor = AnchorStyles.Top;
            _cbFriday.AutoSize = true;
            _cbFriday.Cursor = Cursors.Hand;
            _cbFriday.Location = new Point(361, 167);
            _cbFriday.Name = "cbFriday";
            _cbFriday.RightToLeft = RightToLeft.Yes;
            _cbFriday.Size = new Size(40, 17);
            _cbFriday.TabIndex = 57;
            _cbFriday.Text = "Fri";
            _cbFriday.UseVisualStyleBackColor = true;
            // 
            // cbThursday
            // 
            _cbThursday.Anchor = AnchorStyles.Top;
            _cbThursday.AutoSize = true;
            _cbThursday.Cursor = Cursors.Hand;
            _cbThursday.Location = new Point(269, 167);
            _cbThursday.Name = "cbThursday";
            _cbThursday.RightToLeft = RightToLeft.Yes;
            _cbThursday.Size = new Size(58, 17);
            _cbThursday.TabIndex = 56;
            _cbThursday.Text = "Thurs";
            _cbThursday.UseVisualStyleBackColor = true;
            // 
            // cbWednesday
            // 
            _cbWednesday.Anchor = AnchorStyles.Top;
            _cbWednesday.AutoSize = true;
            _cbWednesday.Cursor = Cursors.Hand;
            _cbWednesday.Location = new Point(179, 167);
            _cbWednesday.Name = "cbWednesday";
            _cbWednesday.RightToLeft = RightToLeft.Yes;
            _cbWednesday.Size = new Size(56, 17);
            _cbWednesday.TabIndex = 55;
            _cbWednesday.Text = "Weds";
            _cbWednesday.UseVisualStyleBackColor = true;
            // 
            // cbTuesday
            // 
            _cbTuesday.Anchor = AnchorStyles.Top;
            _cbTuesday.AutoSize = true;
            _cbTuesday.Cursor = Cursors.Hand;
            _cbTuesday.Location = new Point(93, 167);
            _cbTuesday.Name = "cbTuesday";
            _cbTuesday.RightToLeft = RightToLeft.Yes;
            _cbTuesday.Size = new Size(52, 17);
            _cbTuesday.TabIndex = 54;
            _cbTuesday.Text = "Tues";
            _cbTuesday.UseVisualStyleBackColor = true;
            // 
            // txtRecurringTimeToMins
            // 
            _txtRecurringTimeToMins.Location = new Point(206, 118);
            _txtRecurringTimeToMins.MaxLength = 2;
            _txtRecurringTimeToMins.Name = "txtRecurringTimeToMins";
            _txtRecurringTimeToMins.Size = new Size(27, 20);
            _txtRecurringTimeToMins.TabIndex = 47;
            // 
            // cbMonday
            // 
            _cbMonday.Anchor = AnchorStyles.Top;
            _cbMonday.AutoSize = true;
            _cbMonday.Cursor = Cursors.Hand;
            _cbMonday.Location = new Point(10, 167);
            _cbMonday.Name = "cbMonday";
            _cbMonday.RightToLeft = RightToLeft.Yes;
            _cbMonday.Size = new Size(49, 17);
            _cbMonday.TabIndex = 50;
            _cbMonday.Text = "Mon";
            _cbMonday.UseVisualStyleBackColor = true;
            // 
            // txtRecurringTimeToHours
            // 
            _txtRecurringTimeToHours.Location = new Point(169, 118);
            _txtRecurringTimeToHours.MaxLength = 2;
            _txtRecurringTimeToHours.Name = "txtRecurringTimeToHours";
            _txtRecurringTimeToHours.Size = new Size(27, 20);
            _txtRecurringTimeToHours.TabIndex = 46;
            // 
            // txtRecurringTimeFromMins
            // 
            _txtRecurringTimeFromMins.Location = new Point(95, 118);
            _txtRecurringTimeFromMins.MaxLength = 2;
            _txtRecurringTimeFromMins.Name = "txtRecurringTimeFromMins";
            _txtRecurringTimeFromMins.Size = new Size(27, 20);
            _txtRecurringTimeFromMins.TabIndex = 45;
            // 
            // txtRecurringTimeFromHours
            // 
            _txtRecurringTimeFromHours.Location = new Point(58, 118);
            _txtRecurringTimeFromHours.MaxLength = 2;
            _txtRecurringTimeFromHours.Name = "txtRecurringTimeFromHours";
            _txtRecurringTimeFromHours.Size = new Size(27, 20);
            _txtRecurringTimeFromHours.TabIndex = 44;
            // 
            // lblRecurringTimeToSpacer
            // 
            _lblRecurringTimeToSpacer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblRecurringTimeToSpacer.Location = new Point(195, 120);
            _lblRecurringTimeToSpacer.Name = "lblRecurringTimeToSpacer";
            _lblRecurringTimeToSpacer.Size = new Size(9, 17);
            _lblRecurringTimeToSpacer.TabIndex = 43;
            _lblRecurringTimeToSpacer.Text = ":";
            // 
            // lblRecurringTimeFromSpacer
            // 
            _lblRecurringTimeFromSpacer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblRecurringTimeFromSpacer.Location = new Point(84, 120);
            _lblRecurringTimeFromSpacer.Name = "lblRecurringTimeFromSpacer";
            _lblRecurringTimeFromSpacer.Size = new Size(9, 17);
            _lblRecurringTimeFromSpacer.TabIndex = 42;
            _lblRecurringTimeFromSpacer.Text = ":";
            // 
            // lblRecurringType
            // 
            _lblRecurringType.Font = new Font("Verdana", 8.0F);
            _lblRecurringType.Location = new Point(9, 56);
            _lblRecurringType.Name = "lblRecurringType";
            _lblRecurringType.Size = new Size(37, 17);
            _lblRecurringType.TabIndex = 37;
            _lblRecurringType.Text = "Type";
            // 
            // cboRecurringType
            // 
            _cboRecurringType.Anchor = AnchorStyles.Top;
            _cboRecurringType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRecurringType.Font = new Font("Verdana", 8.0F);
            _cboRecurringType.ItemHeight = 13;
            _cboRecurringType.Items.AddRange(new object[] { "Holiday", "Sickness", "Other" });
            _cboRecurringType.Location = new Point(81, 52);
            _cboRecurringType.Name = "cboRecurringType";
            _cboRecurringType.Size = new Size(274, 21);
            _cboRecurringType.TabIndex = 2;
            // 
            // dtRecurringDateTo
            // 
            _dtRecurringDateTo.Font = new Font("Verdana", 8.0F);
            _dtRecurringDateTo.Location = new Point(218, 88);
            _dtRecurringDateTo.Name = "dtRecurringDateTo";
            _dtRecurringDateTo.Size = new Size(137, 20);
            _dtRecurringDateTo.TabIndex = 6;
            // 
            // dtRecurringDateFrom
            // 
            _dtRecurringDateFrom.Checked = false;
            _dtRecurringDateFrom.Font = new Font("Verdana", 8.0F);
            _dtRecurringDateFrom.Location = new Point(52, 88);
            _dtRecurringDateFrom.Name = "dtRecurringDateFrom";
            _dtRecurringDateFrom.Size = new Size(134, 20);
            _dtRecurringDateFrom.TabIndex = 3;
            // 
            // cboRecurringUser
            // 
            _cboRecurringUser.Anchor = AnchorStyles.Top;
            _cboRecurringUser.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRecurringUser.Font = new Font("Verdana", 8.0F);
            _cboRecurringUser.ItemHeight = 13;
            _cboRecurringUser.Items.AddRange(new object[] { "Holiday", "Sickness", "Other" });
            _cboRecurringUser.Location = new Point(81, 20);
            _cboRecurringUser.Name = "cboRecurringUser";
            _cboRecurringUser.Size = new Size(274, 21);
            _cboRecurringUser.TabIndex = 1;
            // 
            // lblRecurringUser
            // 
            _lblRecurringUser.AutoSize = true;
            _lblRecurringUser.Font = new Font("Verdana", 8.0F);
            _lblRecurringUser.Location = new Point(9, 24);
            _lblRecurringUser.Name = "lblRecurringUser";
            _lblRecurringUser.Size = new Size(33, 13);
            _lblRecurringUser.TabIndex = 18;
            _lblRecurringUser.Text = "User";
            // 
            // txtRecurringComments
            // 
            _txtRecurringComments.Font = new Font("Verdana", 8.0F);
            _txtRecurringComments.Location = new Point(363, 53);
            _txtRecurringComments.Multiline = true;
            _txtRecurringComments.Name = "txtRecurringComments";
            _txtRecurringComments.ScrollBars = ScrollBars.Both;
            _txtRecurringComments.Size = new Size(233, 96);
            _txtRecurringComments.TabIndex = 9;
            // 
            // lblRecurringDateTo
            // 
            _lblRecurringDateTo.AutoSize = true;
            _lblRecurringDateTo.Font = new Font("Verdana", 8.0F);
            _lblRecurringDateTo.Location = new Point(192, 93);
            _lblRecurringDateTo.Name = "lblRecurringDateTo";
            _lblRecurringDateTo.Size = new Size(20, 13);
            _lblRecurringDateTo.TabIndex = 20;
            _lblRecurringDateTo.Text = "To";
            // 
            // lblRecurringDateFrom
            // 
            _lblRecurringDateFrom.Font = new Font("Verdana", 8.0F);
            _lblRecurringDateFrom.Location = new Point(9, 88);
            _lblRecurringDateFrom.Name = "lblRecurringDateFrom";
            _lblRecurringDateFrom.Size = new Size(47, 18);
            _lblRecurringDateFrom.TabIndex = 19;
            _lblRecurringDateFrom.Text = "From";
            // 
            // lblRecurringComments
            // 
            _lblRecurringComments.Font = new Font("Verdana", 8.0F);
            _lblRecurringComments.Location = new Point(360, 33);
            _lblRecurringComments.Name = "lblRecurringComments";
            _lblRecurringComments.Size = new Size(84, 17);
            _lblRecurringComments.TabIndex = 23;
            _lblRecurringComments.Text = "Comments";
            // 
            // UCAbsences
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_tcMain);
            Name = "UCAbsences";
            Size = new Size(632, 238);
            _gbAbsence.ResumeLayout(false);
            _gbAbsence.PerformLayout();
            _tcMain.ResumeLayout(false);
            _tpGeneral.ResumeLayout(false);
            _tpRecurring.ResumeLayout(false);
            _gpRecurring.ResumeLayout(false);
            _gpRecurring.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox _gbAbsence;

        internal GroupBox gbAbsence
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gbAbsence;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gbAbsence != null)
                {
                }

                _gbAbsence = value;
                if (_gbAbsence != null)
                {
                }
            }
        }

        private TextBox _txtEndTimeHours;

        internal TextBox txtEndTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeHours != null)
                {
                    _txtEndTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtEndTimeHours = value;
                if (_txtEndTimeHours != null)
                {
                    _txtEndTimeHours.TextChanged += txtEndTimeHours_TextChanged;
                }
            }
        }

        private TextBox _txtStartTimeMinutes;

        internal TextBox txtStartTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeMinutes != null)
                {
                    _txtStartTimeMinutes.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtStartTimeMinutes = value;
                if (_txtStartTimeMinutes != null)
                {
                    _txtStartTimeMinutes.TextChanged += txtEndTimeHours_TextChanged;
                }
            }
        }

        private TextBox _txtStartTimeHours;

        internal TextBox txtStartTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtStartTimeHours = value;
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged += txtEndTimeHours_TextChanged;
                }
            }
        }

        private Label _lblTimeToSpacer;

        internal Label lblTimeToSpacer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTimeToSpacer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTimeToSpacer != null)
                {
                }

                _lblTimeToSpacer = value;
                if (_lblTimeToSpacer != null)
                {
                }
            }
        }

        private Label _lblTimeFromSpacer;

        internal Label lblTimeFromSpacer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTimeFromSpacer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTimeFromSpacer != null)
                {
                }

                _lblTimeFromSpacer = value;
                if (_lblTimeFromSpacer != null)
                {
                }
            }
        }

        private Label _lblType;

        internal Label lblType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblType != null)
                {
                }

                _lblType = value;
                if (_lblType != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        private DateTimePicker _dtTo;

        internal DateTimePicker dtTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtTo != null)
                {
                }

                _dtTo = value;
                if (_dtTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtFrom;

        internal DateTimePicker dtFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtFrom != null)
                {
                }

                _dtFrom = value;
                if (_dtFrom != null)
                {
                }
            }
        }

        private ComboBox _cboUsers;

        internal ComboBox cboUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUsers != null)
                {
                }

                _cboUsers = value;
                if (_cboUsers != null)
                {
                }
            }
        }

        private Label _lblUser;

        internal Label lblUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblUser != null)
                {
                }

                _lblUser = value;
                if (_lblUser != null)
                {
                }
            }
        }

        private TextBox _txtComments;

        internal TextBox txtComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtComments != null)
                {
                }

                _txtComments = value;
                if (_txtComments != null)
                {
                }
            }
        }

        private Label _lblToDate;

        internal Label lblToDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblToDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblToDate != null)
                {
                }

                _lblToDate = value;
                if (_lblToDate != null)
                {
                }
            }
        }

        private Label _lblFromDate;

        internal Label lblFromDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFromDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFromDate != null)
                {
                }

                _lblFromDate = value;
                if (_lblFromDate != null)
                {
                }
            }
        }

        private Label _lblComments;

        internal Label lblComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblComments != null)
                {
                }

                _lblComments = value;
                if (_lblComments != null)
                {
                }
            }
        }

        private TextBox _txtEndTimeMinutes;

        internal TextBox txtEndTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeMinutes != null)
                {
                }

                _txtEndTimeMinutes = value;
                if (_txtEndTimeMinutes != null)
                {
                }
            }
        }

        private TabControl _tcMain;

        internal TabControl tcMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcMain != null)
                {
                }

                _tcMain = value;
                if (_tcMain != null)
                {
                }
            }
        }

        private TabPage _tpGeneral;

        internal TabPage tpGeneral
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpGeneral;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpGeneral != null)
                {
                }

                _tpGeneral = value;
                if (_tpGeneral != null)
                {
                }
            }
        }

        private TabPage _tpRecurring;

        internal TabPage tpRecurring
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpRecurring;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpRecurring != null)
                {
                }

                _tpRecurring = value;
                if (_tpRecurring != null)
                {
                }
            }
        }

        private GroupBox _gpRecurring;

        internal GroupBox gpRecurring
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpRecurring;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpRecurring != null)
                {
                }

                _gpRecurring = value;
                if (_gpRecurring != null)
                {
                }
            }
        }

        private TextBox _txtRecurringTimeToMins;

        internal TextBox txtRecurringTimeToMins
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecurringTimeToMins;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecurringTimeToMins != null)
                {
                    _txtRecurringTimeToMins.TextChanged -= txtEndTimeRecurringHours_TextChanged;
                }

                _txtRecurringTimeToMins = value;
                if (_txtRecurringTimeToMins != null)
                {
                    _txtRecurringTimeToMins.TextChanged += txtEndTimeRecurringHours_TextChanged;
                }
            }
        }

        private CheckBox _cbMonday;

        internal CheckBox cbMonday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbMonday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbMonday != null)
                {
                }

                _cbMonday = value;
                if (_cbMonday != null)
                {
                }
            }
        }

        private TextBox _txtRecurringTimeToHours;

        internal TextBox txtRecurringTimeToHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecurringTimeToHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecurringTimeToHours != null)
                {
                    _txtRecurringTimeToHours.TextChanged -= txtEndTimeRecurringHours_TextChanged;
                }

                _txtRecurringTimeToHours = value;
                if (_txtRecurringTimeToHours != null)
                {
                    _txtRecurringTimeToHours.TextChanged += txtEndTimeRecurringHours_TextChanged;
                }
            }
        }

        private TextBox _txtRecurringTimeFromMins;

        internal TextBox txtRecurringTimeFromMins
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecurringTimeFromMins;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecurringTimeFromMins != null)
                {
                    _txtRecurringTimeFromMins.TextChanged -= txtEndTimeRecurringHours_TextChanged;
                }

                _txtRecurringTimeFromMins = value;
                if (_txtRecurringTimeFromMins != null)
                {
                    _txtRecurringTimeFromMins.TextChanged += txtEndTimeRecurringHours_TextChanged;
                }
            }
        }

        private TextBox _txtRecurringTimeFromHours;

        internal TextBox txtRecurringTimeFromHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecurringTimeFromHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecurringTimeFromHours != null)
                {
                    _txtRecurringTimeFromHours.TextChanged -= txtEndTimeRecurringHours_TextChanged;
                }

                _txtRecurringTimeFromHours = value;
                if (_txtRecurringTimeFromHours != null)
                {
                    _txtRecurringTimeFromHours.TextChanged += txtEndTimeRecurringHours_TextChanged;
                }
            }
        }

        private Label _lblRecurringTimeToSpacer;

        internal Label lblRecurringTimeToSpacer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringTimeToSpacer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringTimeToSpacer != null)
                {
                }

                _lblRecurringTimeToSpacer = value;
                if (_lblRecurringTimeToSpacer != null)
                {
                }
            }
        }

        private Label _lblRecurringTimeFromSpacer;

        internal Label lblRecurringTimeFromSpacer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringTimeFromSpacer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringTimeFromSpacer != null)
                {
                }

                _lblRecurringTimeFromSpacer = value;
                if (_lblRecurringTimeFromSpacer != null)
                {
                }
            }
        }

        private Label _lblRecurringType;

        internal Label lblRecurringType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringType != null)
                {
                }

                _lblRecurringType = value;
                if (_lblRecurringType != null)
                {
                }
            }
        }

        private ComboBox _cboRecurringType;

        internal ComboBox cboRecurringType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRecurringType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRecurringType != null)
                {
                }

                _cboRecurringType = value;
                if (_cboRecurringType != null)
                {
                }
            }
        }

        private DateTimePicker _dtRecurringDateTo;

        internal DateTimePicker dtRecurringDateTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtRecurringDateTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtRecurringDateTo != null)
                {
                }

                _dtRecurringDateTo = value;
                if (_dtRecurringDateTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtRecurringDateFrom;

        internal DateTimePicker dtRecurringDateFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtRecurringDateFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtRecurringDateFrom != null)
                {
                }

                _dtRecurringDateFrom = value;
                if (_dtRecurringDateFrom != null)
                {
                }
            }
        }

        private ComboBox _cboRecurringUser;

        internal ComboBox cboRecurringUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRecurringUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRecurringUser != null)
                {
                }

                _cboRecurringUser = value;
                if (_cboRecurringUser != null)
                {
                }
            }
        }

        private Label _lblRecurringUser;

        internal Label lblRecurringUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringUser != null)
                {
                }

                _lblRecurringUser = value;
                if (_lblRecurringUser != null)
                {
                }
            }
        }

        private TextBox _txtRecurringComments;

        internal TextBox txtRecurringComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecurringComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecurringComments != null)
                {
                }

                _txtRecurringComments = value;
                if (_txtRecurringComments != null)
                {
                }
            }
        }

        private Label _lblRecurringDateTo;

        internal Label lblRecurringDateTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringDateTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringDateTo != null)
                {
                }

                _lblRecurringDateTo = value;
                if (_lblRecurringDateTo != null)
                {
                }
            }
        }

        private Label _lblRecurringDateFrom;

        internal Label lblRecurringDateFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringDateFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringDateFrom != null)
                {
                }

                _lblRecurringDateFrom = value;
                if (_lblRecurringDateFrom != null)
                {
                }
            }
        }

        private Label _lblRecurringComments;

        internal Label lblRecurringComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringComments != null)
                {
                }

                _lblRecurringComments = value;
                if (_lblRecurringComments != null)
                {
                }
            }
        }

        private Label _lblRecurringTimeTo;

        internal Label lblRecurringTimeTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRecurringTimeTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRecurringTimeTo != null)
                {
                }

                _lblRecurringTimeTo = value;
                if (_lblRecurringTimeTo != null)
                {
                }
            }
        }

        private Label _lblTimeFrom;

        internal Label lblTimeFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTimeFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTimeFrom != null)
                {
                }

                _lblTimeFrom = value;
                if (_lblTimeFrom != null)
                {
                }
            }
        }

        private CheckBox _cbSunday;

        internal CheckBox cbSunday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbSunday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbSunday != null)
                {
                }

                _cbSunday = value;
                if (_cbSunday != null)
                {
                }
            }
        }

        private CheckBox _cbSaturday;

        internal CheckBox cbSaturday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbSaturday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbSaturday != null)
                {
                }

                _cbSaturday = value;
                if (_cbSaturday != null)
                {
                }
            }
        }

        private CheckBox _cbFriday;

        internal CheckBox cbFriday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbFriday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbFriday != null)
                {
                }

                _cbFriday = value;
                if (_cbFriday != null)
                {
                }
            }
        }

        private CheckBox _cbThursday;

        internal CheckBox cbThursday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbThursday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbThursday != null)
                {
                }

                _cbThursday = value;
                if (_cbThursday != null)
                {
                }
            }
        }

        private CheckBox _cbWednesday;

        internal CheckBox cbWednesday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbWednesday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbWednesday != null)
                {
                }

                _cbWednesday = value;
                if (_cbWednesday != null)
                {
                }
            }
        }

        private CheckBox _cbTuesday;

        internal CheckBox cbTuesday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbTuesday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbTuesday != null)
                {
                }

                _cbTuesday = value;
                if (_cbTuesday != null)
                {
                }
            }
        }
    }
}