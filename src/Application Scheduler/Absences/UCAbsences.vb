Imports System.Collections.Generic
Imports FSM.Entity.Sys

Public Class UCAbsences : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal userType As Enums.UserType, ByVal absenceID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.UserType = userType
        Me.AbsenceID = absenceID

        If Me.AbsenceID > 0 Then
            tcMain.TabPages.Remove(tpRecurring)
        End If

        ''''Load either user or engineer datagrid depending on passed param
        If Me.UserType = Enums.UserType.Engineer Then
            LoadEngineer()
        ElseIf Me.UserType = Enums.UserType.User Then
            LoadUser()
        End If

    End Sub

#Region "Properties"

    Private _userType As New Enums.UserType

    Public Property UserType() As Enums.UserType
        Get
            Return _userType
        End Get
        Set(value As Enums.UserType)
            _userType = value
        End Set
    End Property

    Private _absenceID As Integer = 0

    Public Property AbsenceID() As Integer
        Get
            Return _absenceID
        End Get
        Set(value As Integer)
            _absenceID = value
        End Set
    End Property

    Private _userAbsence As New Entity.UserAbsence.UserAbsence

    Public Property CurrentUserAbsence() As Entity.UserAbsence.UserAbsence
        Get
            Return _userAbsence
        End Get
        Set(ByVal Value As Entity.UserAbsence.UserAbsence)
            _userAbsence = Value
            If Helper.MakeIntegerValid(_userAbsence?.UserAbsenceID) > 0 AndAlso AbsenceID > 0 Then
                LoadUserAbsence()
                Me.Text = "Edit User Absence"
            Else
                _userAbsence = New Entity.UserAbsence.UserAbsence With {.Exists = False}
                Me.Text = "Add New User Absence"
            End If
        End Set
    End Property

    Private _engineerAbsence As New Entity.EngineerAbsence.EngineerAbsence

    Public Property CurrentEngineerAbsence() As Entity.EngineerAbsence.EngineerAbsence
        Get
            Return _engineerAbsence
        End Get
        Set(ByVal Value As Entity.EngineerAbsence.EngineerAbsence)
            _engineerAbsence = Value
            If Helper.MakeIntegerValid(_engineerAbsence?.EngineerAbsenceID) > 0 AndAlso AbsenceID > 0 Then
                LoadEngineerAbsence()
                Me.Text = "Edit Engineer Absence"
            Else
                _engineerAbsence = New Entity.EngineerAbsence.EngineerAbsence With {.Exists = False}

                Me.Text = "Add New Engineer Absence"
            End If

        End Set
    End Property

#End Region

    Public ReadOnly Property LoadedItem As Object Implements IUserControl.LoadedItem
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Event RecordsChanged(dv As DataView, pageIn As Enums.PageViewing, FromASave As Boolean, FromADelete As Boolean, extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(newID As Integer) Implements IUserControl.StateChanged

    Public Sub LoadForm(sender As Object, e As EventArgs) Implements IUserControl.LoadForm
        Throw New NotImplementedException()
    End Sub

    Private Sub LoadEngineer()
        LoadEngineerComboBox()
        LoadEngineerAbsencestypeComboBox()
        Me.gbAbsence.Text = "Engineer Absence"
        Me.gpRecurring.Text = "Engineer Recurring Absence"
        Me.lblUser.Text = "Engineer"
        Me.lblRecurringUser.Text = "Engineer"
        CurrentEngineerAbsence = DB.EngineerAbsence.EngineerAbsence_Get(Me.AbsenceID)
    End Sub

    Private Sub LoadUser()
        LoadUserComboBox()
        LoadUserAbsencestypeComboBox()
        CurrentUserAbsence = DB.UserAbsence.UserAbsence_Get(Me.AbsenceID)
    End Sub

    Private Sub LoadUserComboBox()
        Dim dt As New DataTable
        dt = DB.User.GetAll.Table

        Dim pleaseSelect As DataRow = dt.NewRow()
        pleaseSelect("Fullname") = "-- Please Select --"
        pleaseSelect("UserID") = 0
        dt.Rows.InsertAt(pleaseSelect, 0)
        dt.AcceptChanges()

        cboUsers.DataSource = dt

        cboUsers.DisplayMember = "Fullname"
        cboUsers.ValueMember = "UserID"

        cboRecurringUser.DataSource = dt

        cboRecurringUser.DisplayMember = "Fullname"
        cboRecurringUser.ValueMember = "UserID"
    End Sub

    Private Sub LoadEngineerComboBox()
        Dim dt As New DataTable
        dt = DB.Engineer.Engineer_GetAll.Table

        Dim pleaseSelect As DataRow = dt.NewRow()
        pleaseSelect("Name") = "-- Please Select --"
        pleaseSelect("EngineerID") = 0
        dt.Rows.InsertAt(pleaseSelect, 0)
        dt.AcceptChanges()

        cboUsers.DataSource = dt

        cboUsers.DisplayMember = "Name"
        cboUsers.ValueMember = "EngineerID"

        cboRecurringUser.DataSource = dt

        cboRecurringUser.DisplayMember = "Name"
        cboRecurringUser.ValueMember = "EngineerID"

    End Sub

    Private Sub LoadUserAbsencestypeComboBox()
        Dim dt As New DataTable

        '''Add check to swap between User and Engineer
        dt = DB.UserAbsence.UserAbsenceTypes_GetAll

        Dim pleaseSelect As DataRow = dt.NewRow()
        pleaseSelect("Description") = "-- Please Select --"
        pleaseSelect("UserAbsenceTypeID") = 0
        dt.Rows.InsertAt(pleaseSelect, 0)
        dt.AcceptChanges()

        cboType.DataSource = dt

        cboType.DisplayMember = "Description"
        cboType.ValueMember = "UserAbsenceTypeID"

        cboRecurringType.DataSource = dt

        cboRecurringType.DisplayMember = "Description"
        cboRecurringType.ValueMember = "UserAbsenceTypeID"

    End Sub

    Private Sub LoadEngineerAbsencestypeComboBox()
        Dim dt As New DataTable

        '''Add check to swap between User and Engineer
        dt = DB.EngineerAbsence.EngineerAbsenceTypes_GetAll

        Dim pleaseSelect As DataRow = dt.NewRow()
        pleaseSelect("Description") = "-- Please Select --"
        pleaseSelect("EngineerAbsenceTypeID") = 0
        dt.Rows.InsertAt(pleaseSelect, 0)
        dt.AcceptChanges()

        cboType.DataSource = dt

        cboType.DisplayMember = "Description"
        cboType.ValueMember = "EngineerAbsenceTypeID"

        cboRecurringType.DataSource = dt

        cboRecurringType.DisplayMember = "Description"
        cboRecurringType.ValueMember = "EngineerAbsenceTypeID"

    End Sub

    Private Sub LoadUserAbsence()
        txtComments.Text = CurrentUserAbsence.Comments

        dtFrom.Value = CurrentUserAbsence.DateFrom
        dtTo.Value = CurrentUserAbsence.DateTo

        cboUsers.SelectedValue = CurrentUserAbsence.UserID
        cboType.SelectedValue = CurrentUserAbsence.AbsenceTypeID

        txtStartTimeHours.Text = Format(CurrentUserAbsence.DateFrom.Hour, "00")
        txtStartTimeMinutes.Text = Format(CurrentUserAbsence.DateFrom.Minute, "00")

        txtEndTimeHours.Text = Format(CurrentUserAbsence.DateTo.Hour, "00")
        txtEndTimeMinutes.Text = Format(CurrentUserAbsence.DateTo.Minute, "00")

    End Sub

    Private Sub LoadEngineerAbsence()
        txtComments.Text = CurrentEngineerAbsence.Comments

        dtFrom.Value = CurrentEngineerAbsence.DateFrom
        dtTo.Value = CurrentEngineerAbsence.DateTo

        cboUsers.SelectedValue = CurrentEngineerAbsence.EngineerID
        cboType.SelectedValue = CurrentEngineerAbsence.AbsenceTypeID

        txtStartTimeHours.Text = Format(CurrentEngineerAbsence.DateFrom.Hour, "00")
        txtStartTimeMinutes.Text = Format(CurrentEngineerAbsence.DateFrom.Minute, "00")

        txtEndTimeHours.Text = Format(CurrentEngineerAbsence.DateTo.Hour, "00")
        txtEndTimeMinutes.Text = Format(CurrentEngineerAbsence.DateTo.Minute, "00")

    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Throw New NotImplementedException()
    End Sub



    Public Function Save() As Boolean Implements IUserControl.Save
        If tcMain.SelectedIndex = 0 Then
            Try
                If ValidateForm(txtStartTimeHours.Text, txtStartTimeMinutes.Text, txtEndTimeHours.Text, txtEndTimeMinutes.Text, False) Then
                    Dim startTime As DateTime = New DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, CInt(txtStartTimeHours.Text), CInt(txtStartTimeMinutes.Text), 0)
                    Dim endTime As DateTime = New DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, CInt(txtEndTimeHours.Text), CInt(txtEndTimeMinutes.Text), 0)

                    If Me.UserType = Enums.UserType.User Then
                        Dim aV As New UserAbsenceValidator
                        With CurrentUserAbsence
                            .IgnoreExceptionsOnSetMethods = False
                            .SetComments = txtComments.Text
                            .SetAbsenceTypeID = cboType.SelectedValue
                            .SetUserID = cboUsers.SelectedValue
                            .DateFrom = startTime
                            .DateTo = endTime
                        End With

                        aV.Validate(CurrentUserAbsence)

                        If CurrentUserAbsence.Exists Then
                            DB.UserAbsence.Update(CurrentUserAbsence)
                            CurrentUserAbsence = CurrentUserAbsence ' force a reload
                        Else
                            CurrentUserAbsence = DB.UserAbsence.Insert(CurrentUserAbsence)
                        End If
                    ElseIf Me.UserType = Enums.UserType.Engineer Then
                        Dim aV As New EngineerAbsenceValidator
                        With CurrentEngineerAbsence
                            .IgnoreExceptionsOnSetMethods = False
                            .SetComments = txtComments.Text
                            .SetAbsenceTypeID = cboType.SelectedValue
                            .SetEngineerID = cboUsers.SelectedValue
                            .DateFrom = startTime
                            .DateTo = endTime
                        End With

                        aV.Validate(CurrentEngineerAbsence)

                        If CurrentEngineerAbsence.Exists Then
                            DB.EngineerAbsence.Update(CurrentEngineerAbsence)
                            CurrentEngineerAbsence = CurrentEngineerAbsence ' force a reload
                        Else
                            CurrentEngineerAbsence = DB.EngineerAbsence.Insert(CurrentEngineerAbsence)
                        End If
                    End If

                    Me.Dispose()
                    MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2)
                    Return True
                Else : Return False
                End If
            Catch ex As ValidationException
                Dim msg As String = "Please correct the following errors:{0}{1}"
                msg = String.Format(msg, vbNewLine, ex.Validator.CriticalMessagesString())
                MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Catch ex As Exception
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf tcMain.SelectedIndex = 1 Then
            Try
                If ValidateForm(txtRecurringTimeFromHours.Text, txtRecurringTimeFromMins.Text, txtRecurringTimeToHours.Text, txtRecurringTimeToMins.Text, True) Then
                    Dim startTime As DateTime = New DateTime(dtRecurringDateFrom.Value.Year, dtRecurringDateFrom.Value.Month, dtRecurringDateFrom.Value.Day, CInt(txtRecurringTimeFromHours.Text), CInt(txtRecurringTimeFromMins.Text), 0)
                    Dim endTime As DateTime = New DateTime(dtRecurringDateTo.Value.Year, dtRecurringDateTo.Value.Month, dtRecurringDateTo.Value.Day, CInt(txtRecurringTimeToHours.Text), CInt(txtRecurringTimeToMins.Text), 0)

                    Dim absenceDates As List(Of DateTime) = DateHelper.GetDatesBetween(startTime, endTime)
                    If Me.UserType = Enums.UserType.User Then

                        For Each [date] As DateTime In absenceDates


                            If IsDateTicked([date]) Then

                                Dim aV As New UserAbsenceValidator
                                With CurrentUserAbsence
                                    .IgnoreExceptionsOnSetMethods = False
                                    .SetComments = txtRecurringComments.Text
                                    .SetAbsenceTypeID = cboRecurringType.SelectedValue
                                    .SetUserID = cboRecurringUser.SelectedValue
                                    .DateFrom = New DateTime([date].Year, [date].Month, [date].Day, CInt(txtRecurringTimeFromHours.Text), CInt(txtRecurringTimeFromMins.Text), 0)
                                    .DateTo = New DateTime([date].Year, [date].Month, [date].Day, CInt(txtRecurringTimeToHours.Text), CInt(txtRecurringTimeToMins.Text), 0)
                                End With

                                aV.Validate(CurrentUserAbsence)
                                CurrentUserAbsence = DB.UserAbsence.Insert(CurrentUserAbsence)
                            End If
                        Next
                    ElseIf Me.UserType = Enums.UserType.Engineer Then
                        For Each [date] As DateTime In absenceDates
                            If IsDateTicked([date]) Then

                                Dim aV As New EngineerAbsenceValidator
                                With CurrentEngineerAbsence
                                    .IgnoreExceptionsOnSetMethods = False
                                    .SetComments = txtRecurringComments.Text
                                    .SetAbsenceTypeID = cboRecurringType.SelectedValue
                                    .SetEngineerID = cboRecurringUser.SelectedValue
                                    .DateFrom = New DateTime([date].Year, [date].Month, [date].Day, CInt(txtRecurringTimeFromHours.Text), CInt(txtRecurringTimeFromMins.Text), 0)
                                    .DateTo = New DateTime([date].Year, [date].Month, [date].Day, CInt(txtRecurringTimeToHours.Text), CInt(txtRecurringTimeToMins.Text), 0)
                                End With

                                aV.Validate(CurrentEngineerAbsence)
                                CurrentEngineerAbsence = DB.EngineerAbsence.Insert(CurrentEngineerAbsence)
                            End If
                        Next
                    End If

                    Me.Dispose()
                    MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2)
                    Return True
                Else : Return False
                End If
            Catch ex As ValidationException
                Dim msg As String = "Please correct the following errors:{0}{1}"
                msg = String.Format(msg, vbNewLine, ex.Validator.CriticalMessagesString())
                MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Catch ex As Exception
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Private Function IsDateTicked(ByVal dateCheck As DateTime) As Boolean
        Select Case dateCheck.DayOfWeek
            Case 0
                If cbSunday.Checked = True Then
                    Return True
                End If
            Case 1
                If cbMonday.Checked = True Then
                    Return True
                End If
            Case 2
                If cbTuesday.Checked = True Then
                    Return True
                End If
            Case 3
                If cbWednesday.Checked = True Then
                    Return True
                End If
            Case 4
                If cbThursday.Checked = True Then
                    Return True
                End If
            Case 5
                If cbFriday.Checked = True Then
                    Return True
                End If
            Case 6
                If cbSaturday.Checked = True Then
                    Return True
                End If
            Case Else
                Return False
                Exit Select
        End Select
    End Function

    Private Function ValidateForm(ByVal startHour As String, ByVal startMinutes As String, ByVal endHour As String, ByVal endMinutes As String, ByVal isRecurring As Boolean) As Boolean

        If Not (IsNumeric(startHour) AndAlso startHour >= 0 AndAlso startHour <= 23 AndAlso (IsNumeric(startMinutes) AndAlso startMinutes >= 0 AndAlso startMinutes <= 59)) Then
            MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If

        If Not (IsNumeric(endHour) AndAlso endHour >= 0 AndAlso endHour <= 23 AndAlso IsNumeric(endMinutes) AndAlso endMinutes >= 0 AndAlso endMinutes <= 59) Then
            MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If

        Dim startTime As DateTime = New DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, CInt(startHour), CInt(startMinutes), 0)
        Dim endTime As DateTime = New DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, CInt(endHour), CInt(endMinutes), 0)
        If DateTime.Compare(startTime, endTime) > 0 Then
            MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If

        If isRecurring Then
            If cboRecurringType.SelectedValue = 0 Then
                MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Return False
            End If

            If cboRecurringUser.SelectedValue = 0 Then
                MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Return False
            End If

            If cbMonday.Checked = False And cbTuesday.Checked = False And cbWednesday.Checked = False And cbThursday.Checked = False And cbFriday.Checked = False And cbSaturday.Checked = False And cbSunday.Checked = False Then
                MessageBox.Show("No checkboxes ticked!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Function
            End If
        Else
            If cboType.SelectedValue = 0 Then
                MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Return False
            End If

            If cboUsers.SelectedValue = 0 Then
                MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Return False
            End If



        End If

        Return True
    End Function

    Private Sub txtEndTimeHours_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartTimeHours.TextChanged, txtStartTimeMinutes.TextChanged, txtEndTimeHours.TextChanged

        Dim sequence As TextBox() = New TextBox() {txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes}
        Dim currentBox As TextBox = CType(sender, TextBox)

        If currentBox.Text.Length >= 2 AndAlso Array.IndexOf(sequence, currentBox) < sequence.Length - 1 Then
            sequence(Array.IndexOf(sequence, currentBox) + 1).Focus()
        ElseIf currentBox.Text.Length = 0 AndAlso Array.IndexOf(sequence, currentBox) - 1 >= 0 Then
            sequence(Array.IndexOf(sequence, currentBox) - 1).Focus()
        End If
    End Sub

    Private Sub txtEndTimeRecurringHours_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecurringTimeFromHours.TextChanged, txtRecurringTimeFromMins.TextChanged, txtRecurringTimeToHours.TextChanged, txtRecurringTimeToMins.TextChanged

        Dim sequence As TextBox() = New TextBox() {txtRecurringTimeFromHours, txtRecurringTimeFromMins, txtRecurringTimeToHours, txtRecurringTimeToMins}
        Dim currentBox As TextBox = CType(sender, TextBox)

        If currentBox.Text.Length >= 2 AndAlso Array.IndexOf(sequence, currentBox) < sequence.Length - 1 Then
            sequence(Array.IndexOf(sequence, currentBox) + 1).Focus()
        ElseIf currentBox.Text.Length = 0 AndAlso Array.IndexOf(sequence, currentBox) - 1 >= 0 Then
            sequence(Array.IndexOf(sequence, currentBox) - 1).Focus()
        End If
    End Sub
End Class
