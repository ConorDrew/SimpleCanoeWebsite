Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Engineers
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sys

Public Class FRMRescheduleVisit
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal engineerVisitId As Integer)
        MyBase.New()

        InitializeComponent()
        Combo.SetUpCombo(Me.cboAppointment, DB.Appointments.GetAll.Table, "AppointmentID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId)
        Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisitId)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents grpEngineer As GroupBox
    Friend WithEvents btnfindEngineer As Button
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents lblEngineer As Label
    Friend WithEvents grpVisit As GroupBox
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents cboAppointment As ComboBox
    Friend WithEvents lblAppointment As Label
    Friend WithEvents dtpVisitDate As DateTimePicker
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtEndTimeMinutes As TextBox
    Friend WithEvents txtEndTimeHours As TextBox
    Friend WithEvents txtStartTimeMinutes As TextBox
    Friend WithEvents txtStartTimeHours As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblEndTime As Label
    Friend WithEvents lblStartTime As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineer = New System.Windows.Forms.GroupBox()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.grpVisit = New System.Windows.Forms.GroupBox()
        Me.cboAppointment = New System.Windows.Forms.ComboBox()
        Me.lblAppointment = New System.Windows.Forms.Label()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtEndTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtEndTimeHours = New System.Windows.Forms.TextBox()
        Me.txtStartTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtStartTimeHours = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.grpEngineer.SuspendLayout()
        Me.grpVisit.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineer
        '
        Me.grpEngineer.Controls.Add(Me.btnfindEngineer)
        Me.grpEngineer.Controls.Add(Me.txtEngineer)
        Me.grpEngineer.Controls.Add(Me.lblEngineer)
        Me.grpEngineer.Location = New System.Drawing.Point(14, 158)
        Me.grpEngineer.Name = "grpEngineer"
        Me.grpEngineer.Size = New System.Drawing.Size(381, 66)
        Me.grpEngineer.TabIndex = 46
        Me.grpEngineer.TabStop = False
        Me.grpEngineer.Text = "Engineer"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(336, 18)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 18
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(93, 19)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(235, 21)
        Me.txtEngineer.TabIndex = 17
        '
        'lblEngineer
        '
        Me.lblEngineer.Location = New System.Drawing.Point(8, 23)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(85, 13)
        Me.lblEngineer.TabIndex = 31
        Me.lblEngineer.Text = "Engineer"
        '
        'grpVisit
        '
        Me.grpVisit.Controls.Add(Me.txtEndTimeMinutes)
        Me.grpVisit.Controls.Add(Me.txtEndTimeHours)
        Me.grpVisit.Controls.Add(Me.txtStartTimeMinutes)
        Me.grpVisit.Controls.Add(Me.txtStartTimeHours)
        Me.grpVisit.Controls.Add(Me.Label4)
        Me.grpVisit.Controls.Add(Me.Label3)
        Me.grpVisit.Controls.Add(Me.lblEndTime)
        Me.grpVisit.Controls.Add(Me.lblStartTime)
        Me.grpVisit.Controls.Add(Me.cboAppointment)
        Me.grpVisit.Controls.Add(Me.lblAppointment)
        Me.grpVisit.Controls.Add(Me.dtpVisitDate)
        Me.grpVisit.Controls.Add(Me.lblVisitDate)
        Me.grpVisit.Location = New System.Drawing.Point(14, 12)
        Me.grpVisit.Name = "grpVisit"
        Me.grpVisit.Size = New System.Drawing.Size(381, 140)
        Me.grpVisit.TabIndex = 47
        Me.grpVisit.TabStop = False
        Me.grpVisit.Text = "Visit"
        '
        'cboAppointment
        '
        Me.cboAppointment.FormattingEnabled = True
        Me.cboAppointment.Location = New System.Drawing.Point(92, 93)
        Me.cboAppointment.Name = "cboAppointment"
        Me.cboAppointment.Size = New System.Drawing.Size(236, 21)
        Me.cboAppointment.TabIndex = 61
        '
        'lblAppointment
        '
        Me.lblAppointment.Location = New System.Drawing.Point(8, 96)
        Me.lblAppointment.Name = "lblAppointment"
        Me.lblAppointment.Size = New System.Drawing.Size(76, 17)
        Me.lblAppointment.TabIndex = 60
        Me.lblAppointment.Text = "Appointment:"
        '
        'dtpVisitDate
        '
        Me.dtpVisitDate.Location = New System.Drawing.Point(93, 21)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.Size = New System.Drawing.Size(235, 20)
        Me.dtpVisitDate.TabIndex = 32
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(8, 24)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(59, 15)
        Me.lblVisitDate.TabIndex = 31
        Me.lblVisitDate.Text = "Visit Date"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(318, 233)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 48
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtEndTimeMinutes
        '
        Me.txtEndTimeMinutes.Location = New System.Drawing.Point(304, 59)
        Me.txtEndTimeMinutes.Name = "txtEndTimeMinutes"
        Me.txtEndTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeMinutes.TabIndex = 78
        '
        'txtEndTimeHours
        '
        Me.txtEndTimeHours.Location = New System.Drawing.Point(273, 59)
        Me.txtEndTimeHours.Name = "txtEndTimeHours"
        Me.txtEndTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeHours.TabIndex = 79
        '
        'txtStartTimeMinutes
        '
        Me.txtStartTimeMinutes.Location = New System.Drawing.Point(123, 59)
        Me.txtStartTimeMinutes.Name = "txtStartTimeMinutes"
        Me.txtStartTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeMinutes.TabIndex = 77
        '
        'txtStartTimeHours
        '
        Me.txtStartTimeHours.Location = New System.Drawing.Point(92, 59)
        Me.txtStartTimeHours.Name = "txtStartTimeHours"
        Me.txtStartTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeHours.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(296, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 17)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 17)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = ":"
        '
        'lblEndTime
        '
        Me.lblEndTime.Location = New System.Drawing.Point(203, 62)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(55, 17)
        Me.lblEndTime.TabIndex = 76
        Me.lblEndTime.Text = "End Time"
        '
        'lblStartTime
        '
        Me.lblStartTime.Location = New System.Drawing.Point(8, 62)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(60, 17)
        Me.lblStartTime.TabIndex = 74
        Me.lblStartTime.Text = "Start Time"
        '
        'FRMRescheduleVisit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(406, 268)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.grpVisit)
        Me.Controls.Add(Me.grpEngineer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.Name = "FRMRescheduleVisit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reschedule Visit"
        Me.grpEngineer.ResumeLayout(False)
        Me.grpEngineer.PerformLayout()
        Me.grpVisit.ResumeLayout(False)
        Me.grpVisit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _engineer As Engineer

    Public Property Engineer() As Engineer
        Get
            Return _engineer
        End Get
        Set(ByVal value As Engineer)
            _engineer = value
            If Not _engineer Is Nothing Then

                Me.txtEngineer.Text = Engineer.Name
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End Set
    End Property

    Private _engineerVisit As EngineerVisit

    Private Property EngineerVisit() As EngineerVisit
        Get
            Return _engineerVisit
        End Get
        Set(ByVal value As EngineerVisit)
            _engineerVisit = value
        End Set
    End Property

    Private _job As Job

    Private Property Job() As Job
        Get
            Return _job
        End Get
        Set(ByVal Value As Job)
            _job = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMSchedulerFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        FindEngineer()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateVisit()
    End Sub

    Private Sub txtTime_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStartTimeHours.TextChanged,
        txtStartTimeMinutes.TextChanged, txtEndTimeHours.TextChanged, txtEndTimeMinutes.TextChanged

        Dim sequence As TextBox() = New TextBox() {txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes}
        Dim currentBox As TextBox = CType(sender, TextBox)

        If currentBox.Text.Length >= 2 AndAlso Array.IndexOf(sequence, currentBox) < sequence.Length - 1 Then
            sequence(Array.IndexOf(sequence, currentBox) + 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) + 1).SelectAll()

        ElseIf currentBox.Text.Length = 0 AndAlso Array.IndexOf(sequence, currentBox) - 1 >= 0 Then
            sequence(Array.IndexOf(sequence, currentBox) - 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) - 1).SelectAll()
        End If
    End Sub

#End Region

#Region "Function"

    Private Sub Populate()
        Dim appointmentId As Integer = If(EngineerVisit.AppointmentID = 0, CInt(Enums.Appointments.Anytime), EngineerVisit.AppointmentID)
        Combo.SetSelectedComboItem_By_Value(cboAppointment, appointmentId)
        Me.dtpVisitDate.Value = EngineerVisit.StartDateTime
        Me.txtStartTimeHours.Text = EngineerVisit.StartDateTime.ToString("HH")
        Me.txtStartTimeMinutes.Text = EngineerVisit.StartDateTime.ToString("mm")
        Me.txtEndTimeHours.Text = EngineerVisit.EndDateTime.ToString("HH")
        Me.txtEndTimeMinutes.Text = EngineerVisit.EndDateTime.ToString("mm")
        Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)
    End Sub

    Private Sub FindEngineer()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
            If Not IsEngineerQualified(Engineer.EngineerID) Then
                ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Engineer = Nothing
            End If
        End If
    End Sub

    Private Function IsEngineerQualified(ByVal engineerId As Integer) As Boolean

        Dim skills As DataTable = DB.EngineerLevel.Get(Engineer.EngineerID)?.Table
        Dim mandatorySkills As List(Of DataRow) = skills?.Select("Tick = 1 AND Mandatory = 1").ToList()

        If Job?.JobTypeID = Enums.JobTypes.QualityControl Then
            Dim levelAuditor As DataRow = skills.Select("ManagerID =" & CInt(Enums.EngineerQual.AUDITOR) & " AND Tick = 1").FirstOrDefault()
            If levelAuditor Is Nothing Then
                Return False
            End If
        End If

        For Each mandatorySkill As DataRow In mandatorySkills
            Dim expDate As Date = IIf(IsDBNull(mandatorySkill("DateExpires")), Now.AddMinutes(1), CDate(mandatorySkill("DateExpires")))
            If expDate < CDate(Today) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub UpdateVisit()
        If ShowMessage("Reschedule visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Engineer?.EngineerID = 0 Then
                ShowMessage("Please select an engineer?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim startHour As Integer = Helper.MakeIntegerValid(txtStartTimeHours.Text)
            Dim startMin As Integer = Helper.MakeIntegerValid(txtStartTimeMinutes.Text)
            Dim endHour As Integer = Helper.MakeIntegerValid(txtEndTimeHours.Text)
            Dim endMin As Integer = Helper.MakeIntegerValid(txtEndTimeMinutes.Text)

            If Not IsHourAndMinValid(startHour, startMin) Then
                ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Not IsHourAndMinValid(endHour, endMin) Then
                ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim startDate As DateTime = New DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, startHour, startMin, 0)
            Dim endDate As DateTime = New DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, endHour, endMin, 0)
            If startDate > endDate Then
                ShowMessage("Start time can not be greater than end time", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf startDate = endDate Then
                ShowMessage("Start time can not be equal to end time", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            EngineerVisit.StartDateTime = startDate
            EngineerVisit.EndDateTime = endDate
            EngineerVisit.SetAppointmentID = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboAppointment))
            EngineerVisit.SetEngineerID = Engineer.EngineerID
            DB.Scheduler.ScheduleVisit(EngineerVisit)
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Function IsHourAndMinValid(ByVal hour As Integer, ByVal min As Integer) As Boolean
        Return (hour >= 0 AndAlso hour <= 23) AndAlso (min >= 0 AndAlso min <= 59)
    End Function

#End Region

End Class