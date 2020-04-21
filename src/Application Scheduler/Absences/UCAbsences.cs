using System;
using System.Data;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class UCAbsences : UCBase, IUserControl
    {
        public UCAbsences()
        {
            InitializeComponent();
        }

        public UCAbsences(Enums.UserType userType, int absenceID) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            UserType = userType;
            AbsenceID = absenceID;
            if (AbsenceID > 0)
            {
                tcMain.TabPages.Remove(tpRecurring);
            }

            // '''Load either user or engineer datagrid depending on passed param
            if (UserType == Enums.UserType.Engineer)
            {
                LoadEngineer();
            }
            else if (UserType == Enums.UserType.User)
            {
                LoadUser();
            }
        }

        event IUserControl.RecordsChangedEventHandler IUserControl.RecordsChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event IUserControl.StateChangedEventHandler IUserControl.StateChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Enums.UserType _userType = new Enums.UserType();

        public Enums.UserType UserType
        {
            get
            {
                return _userType;
            }

            set
            {
                _userType = value;
            }
        }

        private int _absenceID = 0;

        public int AbsenceID
        {
            get
            {
                return _absenceID;
            }

            set
            {
                _absenceID = value;
            }
        }

        private Entity.UserAbsence.UserAbsence _userAbsence = new Entity.UserAbsence.UserAbsence();

        public Entity.UserAbsence.UserAbsence CurrentUserAbsence
        {
            get
            {
                return _userAbsence;
            }

            set
            {
                _userAbsence = value;
                if (Helper.MakeIntegerValid(_userAbsence?.UserAbsenceID) > 0 && AbsenceID > 0)
                {
                    LoadUserAbsence();
                    Text = "Edit User Absence";
                }
                else
                {
                    _userAbsence = new Entity.UserAbsence.UserAbsence() { Exists = false };
                    Text = "Add New User Absence";
                }
            }
        }

        private Entity.EngineerAbsence.EngineerAbsence _engineerAbsence = new Entity.EngineerAbsence.EngineerAbsence();

        public Entity.EngineerAbsence.EngineerAbsence CurrentEngineerAbsence
        {
            get
            {
                return _engineerAbsence;
            }

            set
            {
                _engineerAbsence = value;
                if (Helper.MakeIntegerValid(_engineerAbsence?.EngineerAbsenceID) > 0 && AbsenceID > 0)
                {
                    LoadEngineerAbsence();
                    Text = "Edit Engineer Absence";
                }
                else
                {
                    _engineerAbsence = new Entity.EngineerAbsence.EngineerAbsence() { Exists = false };
                    Text = "Add New Engineer Absence";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public object LoadedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public void LoadForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadEngineer()
        {
            LoadEngineerComboBox();
            LoadEngineerAbsencestypeComboBox();
            gbAbsence.Text = "Engineer Absence";
            gpRecurring.Text = "Engineer Recurring Absence";
            lblUser.Text = "Engineer";
            lblRecurringUser.Text = "Engineer";
            CurrentEngineerAbsence = App.DB.EngineerAbsence.EngineerAbsence_Get(AbsenceID);
        }

        private void LoadUser()
        {
            LoadUserComboBox();
            LoadUserAbsencestypeComboBox();
            CurrentUserAbsence = App.DB.UserAbsence.UserAbsence_Get(AbsenceID);
        }

        private void LoadUserComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.User.GetAll().Table;
            var pleaseSelect = dt.NewRow();
            pleaseSelect["Fullname"] = "-- Please Select --";
            pleaseSelect["UserID"] = 0;
            dt.Rows.InsertAt(pleaseSelect, 0);
            dt.AcceptChanges();
            cboUsers.DataSource = dt;
            cboUsers.DisplayMember = "Fullname";
            cboUsers.ValueMember = "UserID";
            cboRecurringUser.DataSource = dt;
            cboRecurringUser.DisplayMember = "Fullname";
            cboRecurringUser.ValueMember = "UserID";
        }

        private void LoadEngineerComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.Engineer.Engineer_GetAll().Table;
            var pleaseSelect = dt.NewRow();
            pleaseSelect["Name"] = "-- Please Select --";
            pleaseSelect["EngineerID"] = 0;
            dt.Rows.InsertAt(pleaseSelect, 0);
            dt.AcceptChanges();
            cboUsers.DataSource = dt;
            cboUsers.DisplayMember = "Name";
            cboUsers.ValueMember = "EngineerID";
            cboRecurringUser.DataSource = dt;
            cboRecurringUser.DisplayMember = "Name";
            cboRecurringUser.ValueMember = "EngineerID";
        }

        private void LoadUserAbsencestypeComboBox()
        {
            var dt = new DataTable();

            /// Add check to swap between User and Engineer
            dt = App.DB.UserAbsence.UserAbsenceTypes_GetAll();
            var pleaseSelect = dt.NewRow();
            pleaseSelect["Description"] = "-- Please Select --";
            pleaseSelect["UserAbsenceTypeID"] = 0;
            dt.Rows.InsertAt(pleaseSelect, 0);
            dt.AcceptChanges();
            cboType.DataSource = dt;
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "UserAbsenceTypeID";
            cboRecurringType.DataSource = dt;
            cboRecurringType.DisplayMember = "Description";
            cboRecurringType.ValueMember = "UserAbsenceTypeID";
        }

        private void LoadEngineerAbsencestypeComboBox()
        {
            var dt = new DataTable();

            /// Add check to swap between User and Engineer
            dt = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
            var pleaseSelect = dt.NewRow();
            pleaseSelect["Description"] = "-- Please Select --";
            pleaseSelect["EngineerAbsenceTypeID"] = 0;
            dt.Rows.InsertAt(pleaseSelect, 0);
            dt.AcceptChanges();
            cboType.DataSource = dt;
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "EngineerAbsenceTypeID";
            cboRecurringType.DataSource = dt;
            cboRecurringType.DisplayMember = "Description";
            cboRecurringType.ValueMember = "EngineerAbsenceTypeID";
        }

        private void LoadUserAbsence()
        {
            txtComments.Text = CurrentUserAbsence.Comments;
            dtFrom.Value = CurrentUserAbsence.DateFrom;
            dtTo.Value = CurrentUserAbsence.DateTo;
            cboUsers.SelectedValue = CurrentUserAbsence.UserID;
            cboType.SelectedValue = CurrentUserAbsence.AbsenceTypeID;
            txtStartTimeHours.Text = Strings.Format(CurrentUserAbsence.DateFrom.Hour, "00");
            txtStartTimeMinutes.Text = Strings.Format(CurrentUserAbsence.DateFrom.Minute, "00");
            txtEndTimeHours.Text = Strings.Format(CurrentUserAbsence.DateTo.Hour, "00");
            txtEndTimeMinutes.Text = Strings.Format(CurrentUserAbsence.DateTo.Minute, "00");
        }

        private void LoadEngineerAbsence()
        {
            txtComments.Text = CurrentEngineerAbsence.Comments;
            dtFrom.Value = CurrentEngineerAbsence.DateFrom;
            dtTo.Value = CurrentEngineerAbsence.DateTo;
            cboUsers.SelectedValue = CurrentEngineerAbsence.EngineerID;
            cboType.SelectedValue = CurrentEngineerAbsence.AbsenceTypeID;
            txtStartTimeHours.Text = Strings.Format(CurrentEngineerAbsence.DateFrom.Hour, "00");
            txtStartTimeMinutes.Text = Strings.Format(CurrentEngineerAbsence.DateFrom.Minute, "00");
            txtEndTimeHours.Text = Strings.Format(CurrentEngineerAbsence.DateTo.Hour, "00");
            txtEndTimeMinutes.Text = Strings.Format(CurrentEngineerAbsence.DateTo.Minute, "00");
        }

        public void Populate(int ID = 0)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            if (tcMain.SelectedIndex == 0)
            {
                try
                {
                    if (ValidateForm(txtStartTimeHours.Text, txtStartTimeMinutes.Text, txtEndTimeHours.Text, txtEndTimeMinutes.Text, false))
                    {
                        var startTime = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, Conversions.ToInteger(txtStartTimeHours.Text), Conversions.ToInteger(txtStartTimeMinutes.Text), 0);
                        var endTime = new DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, Conversions.ToInteger(txtEndTimeHours.Text), Conversions.ToInteger(txtEndTimeMinutes.Text), 0);
                        if (UserType == Enums.UserType.User)
                        {
                            var aV = new UserAbsenceValidator();
                            {
                                var withBlock = CurrentUserAbsence;
                                withBlock.IgnoreExceptionsOnSetMethods = false;
                                withBlock.SetComments = txtComments.Text;
                                withBlock.SetAbsenceTypeID = cboType.SelectedValue;
                                withBlock.SetUserID = cboUsers.SelectedValue;
                                withBlock.DateFrom = startTime;
                                withBlock.DateTo = endTime;
                            }

                            aV.Validate(CurrentUserAbsence);
                            if (CurrentUserAbsence.Exists)
                            {
                                App.DB.UserAbsence.Update(CurrentUserAbsence);
                                CurrentUserAbsence = CurrentUserAbsence; // force a reload
                            }
                            else
                            {
                                CurrentUserAbsence = App.DB.UserAbsence.Insert(CurrentUserAbsence);
                            }
                        }
                        else if (UserType == Enums.UserType.Engineer)
                        {
                            var aV = new EngineerAbsenceValidator();
                            {
                                var withBlock1 = CurrentEngineerAbsence;
                                withBlock1.IgnoreExceptionsOnSetMethods = false;
                                withBlock1.SetComments = txtComments.Text;
                                withBlock1.SetAbsenceTypeID = cboType.SelectedValue;
                                withBlock1.SetEngineerID = cboUsers.SelectedValue;
                                withBlock1.DateFrom = startTime;
                                withBlock1.DateTo = endTime;
                            }

                            aV.Validate(CurrentEngineerAbsence);
                            if (CurrentEngineerAbsence.Exists)
                            {
                                App.DB.EngineerAbsence.Update(CurrentEngineerAbsence);
                                CurrentEngineerAbsence = CurrentEngineerAbsence; // force a reload
                            }
                            else
                            {
                                CurrentEngineerAbsence = App.DB.EngineerAbsence.Insert(CurrentEngineerAbsence);
                            }
                        }

                        Dispose();
                        MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (ValidationException ex)
                {
                    string msg = "Please correct the following errors:{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, ex.Validator.CriticalMessagesString());
                    MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tcMain.SelectedIndex == 1)
            {
                try
                {
                    if (ValidateForm(txtRecurringTimeFromHours.Text, txtRecurringTimeFromMins.Text, txtRecurringTimeToHours.Text, txtRecurringTimeToMins.Text, true))
                    {
                        var startTime = new DateTime(dtRecurringDateFrom.Value.Year, dtRecurringDateFrom.Value.Month, dtRecurringDateFrom.Value.Day, Conversions.ToInteger(txtRecurringTimeFromHours.Text), Conversions.ToInteger(txtRecurringTimeFromMins.Text), 0);
                        var endTime = new DateTime(dtRecurringDateTo.Value.Year, dtRecurringDateTo.Value.Month, dtRecurringDateTo.Value.Day, Conversions.ToInteger(txtRecurringTimeToHours.Text), Conversions.ToInteger(txtRecurringTimeToMins.Text), 0);
                        var absenceDates = DateHelper.GetDatesBetween(startTime, endTime);
                        if (UserType == Enums.UserType.User)
                        {
                            foreach (DateTime date in absenceDates)
                            {
                                if (IsDateTicked(date))
                                {
                                    var aV = new UserAbsenceValidator();
                                    {
                                        var withBlock2 = CurrentUserAbsence;
                                        withBlock2.IgnoreExceptionsOnSetMethods = false;
                                        withBlock2.SetComments = txtRecurringComments.Text;
                                        withBlock2.SetAbsenceTypeID = cboRecurringType.SelectedValue;
                                        withBlock2.SetUserID = cboRecurringUser.SelectedValue;
                                        withBlock2.DateFrom = new DateTime(date.Year, date.Month, date.Day, Conversions.ToInteger(txtRecurringTimeFromHours.Text), Conversions.ToInteger(txtRecurringTimeFromMins.Text), 0);
                                        withBlock2.DateTo = new DateTime(date.Year, date.Month, date.Day, Conversions.ToInteger(txtRecurringTimeToHours.Text), Conversions.ToInteger(txtRecurringTimeToMins.Text), 0);
                                    }

                                    aV.Validate(CurrentUserAbsence);
                                    CurrentUserAbsence = App.DB.UserAbsence.Insert(CurrentUserAbsence);
                                }
                            }
                        }
                        else if (UserType == Enums.UserType.Engineer)
                        {
                            foreach (DateTime date in absenceDates)
                            {
                                if (IsDateTicked(date))
                                {
                                    var aV = new EngineerAbsenceValidator();
                                    {
                                        var withBlock3 = CurrentEngineerAbsence;
                                        withBlock3.IgnoreExceptionsOnSetMethods = false;
                                        withBlock3.SetComments = txtRecurringComments.Text;
                                        withBlock3.SetAbsenceTypeID = cboRecurringType.SelectedValue;
                                        withBlock3.SetEngineerID = cboRecurringUser.SelectedValue;
                                        withBlock3.DateFrom = new DateTime(date.Year, date.Month, date.Day, Conversions.ToInteger(txtRecurringTimeFromHours.Text), Conversions.ToInteger(txtRecurringTimeFromMins.Text), 0);
                                        withBlock3.DateTo = new DateTime(date.Year, date.Month, date.Day, Conversions.ToInteger(txtRecurringTimeToHours.Text), Conversions.ToInteger(txtRecurringTimeToMins.Text), 0);
                                    }

                                    aV.Validate(CurrentEngineerAbsence);
                                    CurrentEngineerAbsence = App.DB.EngineerAbsence.Insert(CurrentEngineerAbsence);
                                }
                            }
                        }

                        Dispose();
                        MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (ValidationException ex)
                {
                    string msg = "Please correct the following errors:{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, ex.Validator.CriticalMessagesString());
                    MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return default;
        }

        private bool IsDateTicked(DateTime dateCheck)
        {
            var switchExpr = dateCheck.DayOfWeek;
            switch (switchExpr)
            {
                case 0:
                    {
                        if (cbSunday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)1:
                    {
                        if (cbMonday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)2:
                    {
                        if (cbTuesday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)3:
                    {
                        if (cbWednesday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)4:
                    {
                        if (cbThursday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)5:
                    {
                        if (cbFriday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                case (DayOfWeek)6:
                    {
                        if (cbSaturday.Checked == true)
                        {
                            return true;
                        }

                        break;
                    }

                default:
                    {
                        return false;
                        break;
                    }
            }

            return default;
        }

        private bool ValidateForm(string startHour, string startMinutes, string endHour, string endMinutes, bool isRecurring)
        {
            if (!(Information.IsNumeric(startHour) && Conversions.ToDouble(startHour) >= 0 && Conversions.ToDouble(startHour) <= 23 && Information.IsNumeric(startMinutes) && Conversions.ToDouble(startMinutes) >= 0 && Conversions.ToDouble(startMinutes) <= 59))
            {
                MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return false;
            }

            if (!(Information.IsNumeric(endHour) && Conversions.ToDouble(endHour) >= 0 && Conversions.ToDouble(endHour) <= 23 && Information.IsNumeric(endMinutes) && Conversions.ToDouble(endMinutes) >= 0 && Conversions.ToDouble(endMinutes) <= 59))
            {
                MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return false;
            }

            var startTime = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, Conversions.ToInteger(startHour), Conversions.ToInteger(startMinutes), 0);
            var endTime = new DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, Conversions.ToInteger(endHour), Conversions.ToInteger(endMinutes), 0);
            if (DateTime.Compare(startTime, endTime) > 0)
            {
                MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return false;
            }

            if (isRecurring)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboRecurringType.SelectedValue, 0, false)))
                {
                    MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return false;
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboRecurringUser.SelectedValue, 0, false)))
                {
                    MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return false;
                }

                if (cbMonday.Checked == false & cbTuesday.Checked == false & cbWednesday.Checked == false & cbThursday.Checked == false & cbFriday.Checked == false & cbSaturday.Checked == false & cbSunday.Checked == false)
                {
                    MessageBox.Show("No checkboxes ticked!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return default;
                }
            }
            else
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboType.SelectedValue, 0, false)))
                {
                    MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return false;
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboUsers.SelectedValue, 0, false)))
                {
                    MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return false;
                }
            }

            return true;
        }

        private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
        {
            var sequence = new TextBox[] { txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes };
            TextBox currentBox = (TextBox)sender;
            if (currentBox.Text.Length >= 2 && Array.IndexOf(sequence, currentBox) < sequence.Length - 1)
            {
                sequence[Array.IndexOf(sequence, currentBox) + 1].Focus();
            }
            else if (currentBox.Text.Length == 0 && Array.IndexOf(sequence, currentBox) - 1 >= 0)
            {
                sequence[Array.IndexOf(sequence, currentBox) - 1].Focus();
            }
        }

        private void txtEndTimeRecurringHours_TextChanged(object sender, EventArgs e)
        {
            var sequence = new TextBox[] { txtRecurringTimeFromHours, txtRecurringTimeFromMins, txtRecurringTimeToHours, txtRecurringTimeToMins };
            TextBox currentBox = (TextBox)sender;
            if (currentBox.Text.Length >= 2 && Array.IndexOf(sequence, currentBox) < sequence.Length - 1)
            {
                sequence[Array.IndexOf(sequence, currentBox) + 1].Focus();
            }
            else if (currentBox.Text.Length == 0 && Array.IndexOf(sequence, currentBox) - 1 >= 0)
            {
                sequence[Array.IndexOf(sequence, currentBox) - 1].Focus();
            }
        }
    }
}