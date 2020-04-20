<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCAbsences

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gbAbsence = New System.Windows.Forms.GroupBox()
        Me.txtEndTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtEndTimeHours = New System.Windows.Forms.TextBox()
        Me.txtStartTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtStartTimeHours = New System.Windows.Forms.TextBox()
        Me.lblTimeToSpacer = New System.Windows.Forms.Label()
        Me.lblTimeFromSpacer = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboUsers = New System.Windows.Forms.ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.tpRecurring = New System.Windows.Forms.TabPage()
        Me.gpRecurring = New System.Windows.Forms.GroupBox()
        Me.lblRecurringTimeTo = New System.Windows.Forms.Label()
        Me.lblTimeFrom = New System.Windows.Forms.Label()
        Me.cbSunday = New System.Windows.Forms.CheckBox()
        Me.cbSaturday = New System.Windows.Forms.CheckBox()
        Me.cbFriday = New System.Windows.Forms.CheckBox()
        Me.cbThursday = New System.Windows.Forms.CheckBox()
        Me.cbWednesday = New System.Windows.Forms.CheckBox()
        Me.cbTuesday = New System.Windows.Forms.CheckBox()
        Me.txtRecurringTimeToMins = New System.Windows.Forms.TextBox()
        Me.cbMonday = New System.Windows.Forms.CheckBox()
        Me.txtRecurringTimeToHours = New System.Windows.Forms.TextBox()
        Me.txtRecurringTimeFromMins = New System.Windows.Forms.TextBox()
        Me.txtRecurringTimeFromHours = New System.Windows.Forms.TextBox()
        Me.lblRecurringTimeToSpacer = New System.Windows.Forms.Label()
        Me.lblRecurringTimeFromSpacer = New System.Windows.Forms.Label()
        Me.lblRecurringType = New System.Windows.Forms.Label()
        Me.cboRecurringType = New System.Windows.Forms.ComboBox()
        Me.dtRecurringDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtRecurringDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboRecurringUser = New System.Windows.Forms.ComboBox()
        Me.lblRecurringUser = New System.Windows.Forms.Label()
        Me.txtRecurringComments = New System.Windows.Forms.TextBox()
        Me.lblRecurringDateTo = New System.Windows.Forms.Label()
        Me.lblRecurringDateFrom = New System.Windows.Forms.Label()
        Me.lblRecurringComments = New System.Windows.Forms.Label()
        Me.gbAbsence.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tpRecurring.SuspendLayout()
        Me.gpRecurring.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAbsence
        '
        Me.gbAbsence.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbAbsence.Controls.Add(Me.txtEndTimeMinutes)
        Me.gbAbsence.Controls.Add(Me.txtEndTimeHours)
        Me.gbAbsence.Controls.Add(Me.txtStartTimeMinutes)
        Me.gbAbsence.Controls.Add(Me.txtStartTimeHours)
        Me.gbAbsence.Controls.Add(Me.lblTimeToSpacer)
        Me.gbAbsence.Controls.Add(Me.lblTimeFromSpacer)
        Me.gbAbsence.Controls.Add(Me.lblType)
        Me.gbAbsence.Controls.Add(Me.cboType)
        Me.gbAbsence.Controls.Add(Me.dtTo)
        Me.gbAbsence.Controls.Add(Me.dtFrom)
        Me.gbAbsence.Controls.Add(Me.cboUsers)
        Me.gbAbsence.Controls.Add(Me.lblUser)
        Me.gbAbsence.Controls.Add(Me.txtComments)
        Me.gbAbsence.Controls.Add(Me.lblToDate)
        Me.gbAbsence.Controls.Add(Me.lblFromDate)
        Me.gbAbsence.Controls.Add(Me.lblComments)
        Me.gbAbsence.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.gbAbsence.Location = New System.Drawing.Point(3, 6)
        Me.gbAbsence.Name = "gbAbsence"
        Me.gbAbsence.Size = New System.Drawing.Size(613, 156)
        Me.gbAbsence.TabIndex = 26
        Me.gbAbsence.TabStop = False
        Me.gbAbsence.Text = "User Absence"
        '
        'txtEndTimeMinutes
        '
        Me.txtEndTimeMinutes.Location = New System.Drawing.Point(336, 120)
        Me.txtEndTimeMinutes.MaxLength = 2
        Me.txtEndTimeMinutes.Name = "txtEndTimeMinutes"
        Me.txtEndTimeMinutes.Size = New System.Drawing.Size(27, 20)
        Me.txtEndTimeMinutes.TabIndex = 53
        '
        'txtEndTimeHours
        '
        Me.txtEndTimeHours.Location = New System.Drawing.Point(299, 120)
        Me.txtEndTimeHours.MaxLength = 2
        Me.txtEndTimeHours.Name = "txtEndTimeHours"
        Me.txtEndTimeHours.Size = New System.Drawing.Size(27, 20)
        Me.txtEndTimeHours.TabIndex = 46
        '
        'txtStartTimeMinutes
        '
        Me.txtStartTimeMinutes.Location = New System.Drawing.Point(336, 88)
        Me.txtStartTimeMinutes.MaxLength = 2
        Me.txtStartTimeMinutes.Name = "txtStartTimeMinutes"
        Me.txtStartTimeMinutes.Size = New System.Drawing.Size(27, 20)
        Me.txtStartTimeMinutes.TabIndex = 45
        '
        'txtStartTimeHours
        '
        Me.txtStartTimeHours.Location = New System.Drawing.Point(299, 88)
        Me.txtStartTimeHours.MaxLength = 2
        Me.txtStartTimeHours.Name = "txtStartTimeHours"
        Me.txtStartTimeHours.Size = New System.Drawing.Size(27, 20)
        Me.txtStartTimeHours.TabIndex = 44
        '
        'lblTimeToSpacer
        '
        Me.lblTimeToSpacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeToSpacer.Location = New System.Drawing.Point(325, 123)
        Me.lblTimeToSpacer.Name = "lblTimeToSpacer"
        Me.lblTimeToSpacer.Size = New System.Drawing.Size(9, 17)
        Me.lblTimeToSpacer.TabIndex = 43
        Me.lblTimeToSpacer.Text = ":"
        '
        'lblTimeFromSpacer
        '
        Me.lblTimeFromSpacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeFromSpacer.Location = New System.Drawing.Point(325, 91)
        Me.lblTimeFromSpacer.Name = "lblTimeFromSpacer"
        Me.lblTimeFromSpacer.Size = New System.Drawing.Size(9, 17)
        Me.lblTimeFromSpacer.TabIndex = 42
        Me.lblTimeFromSpacer.Text = ":"
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblType.Location = New System.Drawing.Point(9, 56)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(56, 17)
        Me.lblType.TabIndex = 37
        Me.lblType.Text = "Type"
        '
        'cboType
        '
        Me.cboType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboType.ItemHeight = 13
        Me.cboType.Items.AddRange(New Object() {"Holiday", "Sickness", "Other"})
        Me.cboType.Location = New System.Drawing.Point(93, 56)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(270, 21)
        Me.cboType.TabIndex = 2
        '
        'dtTo
        '
        Me.dtTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtTo.Location = New System.Drawing.Point(93, 120)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(201, 20)
        Me.dtTo.TabIndex = 6
        '
        'dtFrom
        '
        Me.dtFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtFrom.Location = New System.Drawing.Point(93, 88)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtFrom.TabIndex = 3
        '
        'cboUsers
        '
        Me.cboUsers.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboUsers.ItemHeight = 13
        Me.cboUsers.Items.AddRange(New Object() {"Holiday", "Sickness", "Other"})
        Me.cboUsers.Location = New System.Drawing.Point(93, 24)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(270, 21)
        Me.cboUsers.TabIndex = 1
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblUser.Location = New System.Drawing.Point(9, 24)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(78, 17)
        Me.lblUser.TabIndex = 18
        Me.lblUser.Text = "User"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtComments.Location = New System.Drawing.Point(373, 48)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComments.Size = New System.Drawing.Size(234, 96)
        Me.txtComments.TabIndex = 9
        '
        'lblToDate
        '
        Me.lblToDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblToDate.Location = New System.Drawing.Point(9, 120)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(54, 18)
        Me.lblToDate.TabIndex = 20
        Me.lblToDate.Text = "To"
        '
        'lblFromDate
        '
        Me.lblFromDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblFromDate.Location = New System.Drawing.Point(9, 88)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(47, 18)
        Me.lblFromDate.TabIndex = 19
        Me.lblFromDate.Text = "From"
        '
        'lblComments
        '
        Me.lblComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblComments.Location = New System.Drawing.Point(373, 24)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(84, 17)
        Me.lblComments.TabIndex = 23
        Me.lblComments.Text = "Comments"
        '
        'tcMain
        '
        Me.tcMain.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tcMain.Controls.Add(Me.tpGeneral)
        Me.tcMain.Controls.Add(Me.tpRecurring)
        Me.tcMain.Location = New System.Drawing.Point(3, 3)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(624, 230)
        Me.tcMain.TabIndex = 27
        '
        'tpGeneral
        '
        Me.tpGeneral.BackColor = System.Drawing.Color.White
        Me.tpGeneral.Controls.Add(Me.gbAbsence)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(616, 204)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        '
        'tpRecurring
        '
        Me.tpRecurring.BackColor = System.Drawing.Color.White
        Me.tpRecurring.Controls.Add(Me.gpRecurring)
        Me.tpRecurring.Location = New System.Drawing.Point(4, 22)
        Me.tpRecurring.Name = "tpRecurring"
        Me.tpRecurring.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRecurring.Size = New System.Drawing.Size(616, 204)
        Me.tpRecurring.TabIndex = 1
        Me.tpRecurring.Text = "Recurring"
        '
        'gpRecurring
        '
        Me.gpRecurring.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpRecurring.Controls.Add(Me.lblRecurringTimeTo)
        Me.gpRecurring.Controls.Add(Me.lblTimeFrom)
        Me.gpRecurring.Controls.Add(Me.cbSunday)
        Me.gpRecurring.Controls.Add(Me.cbSaturday)
        Me.gpRecurring.Controls.Add(Me.cbFriday)
        Me.gpRecurring.Controls.Add(Me.cbThursday)
        Me.gpRecurring.Controls.Add(Me.cbWednesday)
        Me.gpRecurring.Controls.Add(Me.cbTuesday)
        Me.gpRecurring.Controls.Add(Me.txtRecurringTimeToMins)
        Me.gpRecurring.Controls.Add(Me.cbMonday)
        Me.gpRecurring.Controls.Add(Me.txtRecurringTimeToHours)
        Me.gpRecurring.Controls.Add(Me.txtRecurringTimeFromMins)
        Me.gpRecurring.Controls.Add(Me.txtRecurringTimeFromHours)
        Me.gpRecurring.Controls.Add(Me.lblRecurringTimeToSpacer)
        Me.gpRecurring.Controls.Add(Me.lblRecurringTimeFromSpacer)
        Me.gpRecurring.Controls.Add(Me.lblRecurringType)
        Me.gpRecurring.Controls.Add(Me.cboRecurringType)
        Me.gpRecurring.Controls.Add(Me.dtRecurringDateTo)
        Me.gpRecurring.Controls.Add(Me.dtRecurringDateFrom)
        Me.gpRecurring.Controls.Add(Me.cboRecurringUser)
        Me.gpRecurring.Controls.Add(Me.lblRecurringUser)
        Me.gpRecurring.Controls.Add(Me.txtRecurringComments)
        Me.gpRecurring.Controls.Add(Me.lblRecurringDateTo)
        Me.gpRecurring.Controls.Add(Me.lblRecurringDateFrom)
        Me.gpRecurring.Controls.Add(Me.lblRecurringComments)
        Me.gpRecurring.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.gpRecurring.Location = New System.Drawing.Point(6, 6)
        Me.gpRecurring.Name = "gpRecurring"
        Me.gpRecurring.Size = New System.Drawing.Size(610, 192)
        Me.gpRecurring.TabIndex = 27
        Me.gpRecurring.TabStop = False
        Me.gpRecurring.Text = "User Recurring Absence"
        '
        'lblRecurringTimeTo
        '
        Me.lblRecurringTimeTo.AutoSize = True
        Me.lblRecurringTimeTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringTimeTo.Location = New System.Drawing.Point(138, 121)
        Me.lblRecurringTimeTo.Name = "lblRecurringTimeTo"
        Me.lblRecurringTimeTo.Size = New System.Drawing.Size(25, 13)
        Me.lblRecurringTimeTo.TabIndex = 61
        Me.lblRecurringTimeTo.Text = "To:"
        '
        'lblTimeFrom
        '
        Me.lblTimeFrom.AutoSize = True
        Me.lblTimeFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblTimeFrom.Location = New System.Drawing.Point(9, 121)
        Me.lblTimeFrom.Name = "lblTimeFrom"
        Me.lblTimeFrom.Size = New System.Drawing.Size(41, 13)
        Me.lblTimeFrom.TabIndex = 60
        Me.lblTimeFrom.Text = "From:"
        '
        'cbSunday
        '
        Me.cbSunday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbSunday.AutoSize = True
        Me.cbSunday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbSunday.Location = New System.Drawing.Point(514, 167)
        Me.cbSunday.Name = "cbSunday"
        Me.cbSunday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbSunday.Size = New System.Drawing.Size(48, 17)
        Me.cbSunday.TabIndex = 59
        Me.cbSunday.Text = "Sun"
        Me.cbSunday.UseVisualStyleBackColor = True
        '
        'cbSaturday
        '
        Me.cbSaturday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbSaturday.AutoSize = True
        Me.cbSaturday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbSaturday.Location = New System.Drawing.Point(436, 167)
        Me.cbSaturday.Name = "cbSaturday"
        Me.cbSaturday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbSaturday.Size = New System.Drawing.Size(45, 17)
        Me.cbSaturday.TabIndex = 58
        Me.cbSaturday.Text = "Sat"
        Me.cbSaturday.UseVisualStyleBackColor = True
        '
        'cbFriday
        '
        Me.cbFriday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbFriday.AutoSize = True
        Me.cbFriday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbFriday.Location = New System.Drawing.Point(361, 167)
        Me.cbFriday.Name = "cbFriday"
        Me.cbFriday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbFriday.Size = New System.Drawing.Size(40, 17)
        Me.cbFriday.TabIndex = 57
        Me.cbFriday.Text = "Fri"
        Me.cbFriday.UseVisualStyleBackColor = True
        '
        'cbThursday
        '
        Me.cbThursday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbThursday.AutoSize = True
        Me.cbThursday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbThursday.Location = New System.Drawing.Point(269, 167)
        Me.cbThursday.Name = "cbThursday"
        Me.cbThursday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbThursday.Size = New System.Drawing.Size(58, 17)
        Me.cbThursday.TabIndex = 56
        Me.cbThursday.Text = "Thurs"
        Me.cbThursday.UseVisualStyleBackColor = True
        '
        'cbWednesday
        '
        Me.cbWednesday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbWednesday.AutoSize = True
        Me.cbWednesday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbWednesday.Location = New System.Drawing.Point(179, 167)
        Me.cbWednesday.Name = "cbWednesday"
        Me.cbWednesday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbWednesday.Size = New System.Drawing.Size(56, 17)
        Me.cbWednesday.TabIndex = 55
        Me.cbWednesday.Text = "Weds"
        Me.cbWednesday.UseVisualStyleBackColor = True
        '
        'cbTuesday
        '
        Me.cbTuesday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbTuesday.AutoSize = True
        Me.cbTuesday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbTuesday.Location = New System.Drawing.Point(93, 167)
        Me.cbTuesday.Name = "cbTuesday"
        Me.cbTuesday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbTuesday.Size = New System.Drawing.Size(52, 17)
        Me.cbTuesday.TabIndex = 54
        Me.cbTuesday.Text = "Tues"
        Me.cbTuesday.UseVisualStyleBackColor = True
        '
        'txtRecurringTimeToMins
        '
        Me.txtRecurringTimeToMins.Location = New System.Drawing.Point(206, 118)
        Me.txtRecurringTimeToMins.MaxLength = 2
        Me.txtRecurringTimeToMins.Name = "txtRecurringTimeToMins"
        Me.txtRecurringTimeToMins.Size = New System.Drawing.Size(27, 20)
        Me.txtRecurringTimeToMins.TabIndex = 47
        '
        'cbMonday
        '
        Me.cbMonday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbMonday.AutoSize = True
        Me.cbMonday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbMonday.Location = New System.Drawing.Point(10, 167)
        Me.cbMonday.Name = "cbMonday"
        Me.cbMonday.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbMonday.Size = New System.Drawing.Size(49, 17)
        Me.cbMonday.TabIndex = 50
        Me.cbMonday.Text = "Mon"
        Me.cbMonday.UseVisualStyleBackColor = True
        '
        'txtRecurringTimeToHours
        '
        Me.txtRecurringTimeToHours.Location = New System.Drawing.Point(169, 118)
        Me.txtRecurringTimeToHours.MaxLength = 2
        Me.txtRecurringTimeToHours.Name = "txtRecurringTimeToHours"
        Me.txtRecurringTimeToHours.Size = New System.Drawing.Size(27, 20)
        Me.txtRecurringTimeToHours.TabIndex = 46
        '
        'txtRecurringTimeFromMins
        '
        Me.txtRecurringTimeFromMins.Location = New System.Drawing.Point(95, 118)
        Me.txtRecurringTimeFromMins.MaxLength = 2
        Me.txtRecurringTimeFromMins.Name = "txtRecurringTimeFromMins"
        Me.txtRecurringTimeFromMins.Size = New System.Drawing.Size(27, 20)
        Me.txtRecurringTimeFromMins.TabIndex = 45
        '
        'txtRecurringTimeFromHours
        '
        Me.txtRecurringTimeFromHours.Location = New System.Drawing.Point(58, 118)
        Me.txtRecurringTimeFromHours.MaxLength = 2
        Me.txtRecurringTimeFromHours.Name = "txtRecurringTimeFromHours"
        Me.txtRecurringTimeFromHours.Size = New System.Drawing.Size(27, 20)
        Me.txtRecurringTimeFromHours.TabIndex = 44
        '
        'lblRecurringTimeToSpacer
        '
        Me.lblRecurringTimeToSpacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecurringTimeToSpacer.Location = New System.Drawing.Point(195, 120)
        Me.lblRecurringTimeToSpacer.Name = "lblRecurringTimeToSpacer"
        Me.lblRecurringTimeToSpacer.Size = New System.Drawing.Size(9, 17)
        Me.lblRecurringTimeToSpacer.TabIndex = 43
        Me.lblRecurringTimeToSpacer.Text = ":"
        '
        'lblRecurringTimeFromSpacer
        '
        Me.lblRecurringTimeFromSpacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecurringTimeFromSpacer.Location = New System.Drawing.Point(84, 120)
        Me.lblRecurringTimeFromSpacer.Name = "lblRecurringTimeFromSpacer"
        Me.lblRecurringTimeFromSpacer.Size = New System.Drawing.Size(9, 17)
        Me.lblRecurringTimeFromSpacer.TabIndex = 42
        Me.lblRecurringTimeFromSpacer.Text = ":"
        '
        'lblRecurringType
        '
        Me.lblRecurringType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringType.Location = New System.Drawing.Point(9, 56)
        Me.lblRecurringType.Name = "lblRecurringType"
        Me.lblRecurringType.Size = New System.Drawing.Size(37, 17)
        Me.lblRecurringType.TabIndex = 37
        Me.lblRecurringType.Text = "Type"
        '
        'cboRecurringType
        '
        Me.cboRecurringType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboRecurringType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecurringType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboRecurringType.ItemHeight = 13
        Me.cboRecurringType.Items.AddRange(New Object() {"Holiday", "Sickness", "Other"})
        Me.cboRecurringType.Location = New System.Drawing.Point(81, 52)
        Me.cboRecurringType.Name = "cboRecurringType"
        Me.cboRecurringType.Size = New System.Drawing.Size(274, 21)
        Me.cboRecurringType.TabIndex = 2
        '
        'dtRecurringDateTo
        '
        Me.dtRecurringDateTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtRecurringDateTo.Location = New System.Drawing.Point(218, 88)
        Me.dtRecurringDateTo.Name = "dtRecurringDateTo"
        Me.dtRecurringDateTo.Size = New System.Drawing.Size(137, 20)
        Me.dtRecurringDateTo.TabIndex = 6
        '
        'dtRecurringDateFrom
        '
        Me.dtRecurringDateFrom.Checked = False
        Me.dtRecurringDateFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtRecurringDateFrom.Location = New System.Drawing.Point(52, 88)
        Me.dtRecurringDateFrom.Name = "dtRecurringDateFrom"
        Me.dtRecurringDateFrom.Size = New System.Drawing.Size(134, 20)
        Me.dtRecurringDateFrom.TabIndex = 3
        '
        'cboRecurringUser
        '
        Me.cboRecurringUser.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboRecurringUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecurringUser.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboRecurringUser.ItemHeight = 13
        Me.cboRecurringUser.Items.AddRange(New Object() {"Holiday", "Sickness", "Other"})
        Me.cboRecurringUser.Location = New System.Drawing.Point(81, 20)
        Me.cboRecurringUser.Name = "cboRecurringUser"
        Me.cboRecurringUser.Size = New System.Drawing.Size(274, 21)
        Me.cboRecurringUser.TabIndex = 1
        '
        'lblRecurringUser
        '
        Me.lblRecurringUser.AutoSize = True
        Me.lblRecurringUser.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringUser.Location = New System.Drawing.Point(9, 24)
        Me.lblRecurringUser.Name = "lblRecurringUser"
        Me.lblRecurringUser.Size = New System.Drawing.Size(33, 13)
        Me.lblRecurringUser.TabIndex = 18
        Me.lblRecurringUser.Text = "User"
        '
        'txtRecurringComments
        '
        Me.txtRecurringComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtRecurringComments.Location = New System.Drawing.Point(363, 53)
        Me.txtRecurringComments.Multiline = True
        Me.txtRecurringComments.Name = "txtRecurringComments"
        Me.txtRecurringComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRecurringComments.Size = New System.Drawing.Size(233, 96)
        Me.txtRecurringComments.TabIndex = 9
        '
        'lblRecurringDateTo
        '
        Me.lblRecurringDateTo.AutoSize = True
        Me.lblRecurringDateTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringDateTo.Location = New System.Drawing.Point(192, 93)
        Me.lblRecurringDateTo.Name = "lblRecurringDateTo"
        Me.lblRecurringDateTo.Size = New System.Drawing.Size(20, 13)
        Me.lblRecurringDateTo.TabIndex = 20
        Me.lblRecurringDateTo.Text = "To"
        '
        'lblRecurringDateFrom
        '
        Me.lblRecurringDateFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringDateFrom.Location = New System.Drawing.Point(9, 88)
        Me.lblRecurringDateFrom.Name = "lblRecurringDateFrom"
        Me.lblRecurringDateFrom.Size = New System.Drawing.Size(47, 18)
        Me.lblRecurringDateFrom.TabIndex = 19
        Me.lblRecurringDateFrom.Text = "From"
        '
        'lblRecurringComments
        '
        Me.lblRecurringComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblRecurringComments.Location = New System.Drawing.Point(360, 33)
        Me.lblRecurringComments.Name = "lblRecurringComments"
        Me.lblRecurringComments.Size = New System.Drawing.Size(84, 17)
        Me.lblRecurringComments.TabIndex = 23
        Me.lblRecurringComments.Text = "Comments"
        '
        'UCAbsences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcMain)
        Me.Name = "UCAbsences"
        Me.Size = New System.Drawing.Size(632, 238)
        Me.gbAbsence.ResumeLayout(False)
        Me.gbAbsence.PerformLayout()
        Me.tcMain.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpRecurring.ResumeLayout(False)
        Me.gpRecurring.ResumeLayout(False)
        Me.gpRecurring.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbAbsence As GroupBox
    Friend WithEvents txtEndTimeHours As TextBox
    Friend WithEvents txtStartTimeMinutes As TextBox
    Friend WithEvents txtStartTimeHours As TextBox
    Friend WithEvents lblTimeToSpacer As Label
    Friend WithEvents lblTimeFromSpacer As Label
    Friend WithEvents lblType As Label
    Friend WithEvents cboType As ComboBox
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents cboUsers As ComboBox
    Friend WithEvents lblUser As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents lblComments As Label
    Friend WithEvents txtEndTimeMinutes As TextBox
    Friend WithEvents tcMain As TabControl
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents tpRecurring As TabPage
    Friend WithEvents gpRecurring As GroupBox
    Friend WithEvents txtRecurringTimeToMins As TextBox
    Friend WithEvents cbMonday As CheckBox
    Friend WithEvents txtRecurringTimeToHours As TextBox
    Friend WithEvents txtRecurringTimeFromMins As TextBox
    Friend WithEvents txtRecurringTimeFromHours As TextBox
    Friend WithEvents lblRecurringTimeToSpacer As Label
    Friend WithEvents lblRecurringTimeFromSpacer As Label
    Friend WithEvents lblRecurringType As Label
    Friend WithEvents cboRecurringType As ComboBox
    Friend WithEvents dtRecurringDateTo As DateTimePicker
    Friend WithEvents dtRecurringDateFrom As DateTimePicker
    Friend WithEvents cboRecurringUser As ComboBox
    Friend WithEvents lblRecurringUser As Label
    Friend WithEvents txtRecurringComments As TextBox
    Friend WithEvents lblRecurringDateTo As Label
    Friend WithEvents lblRecurringDateFrom As Label
    Friend WithEvents lblRecurringComments As Label
    Friend WithEvents lblRecurringTimeTo As Label
    Friend WithEvents lblTimeFrom As Label
    Friend WithEvents cbSunday As CheckBox
    Friend WithEvents cbSaturday As CheckBox
    Friend WithEvents cbFriday As CheckBox
    Friend WithEvents cbThursday As CheckBox
    Friend WithEvents cbWednesday As CheckBox
    Friend WithEvents cbTuesday As CheckBox
End Class
