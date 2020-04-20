Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Engineers
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.JobOfWorks
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys
Imports FSM.Entity.Users

Public Class FRMNewJob

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal visitDate As DateTime = Nothing, Optional ByVal engineerId As Integer = 0)
        MyBase.New()

        InitializeComponent()
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAppointment, DB.Appointments.GetAll.Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(Me.cboAppointment, Enums.Appointments.Anytime)
        If visitDate <> Nothing Then dtpVisitDate.Value = visitDate
        Engineer = DB.Engineer.Engineer_Get(engineerId)
        Me.txtStartTimeHours.Text = Now.ToString("HH")
        Me.txtStartTimeMinutes.Text = Now.ToString("mm")
        Me.txtEndTimeHours.Text = Now.AddHours(1).ToString("HH")
        Me.txtEndTimeMinutes.Text = Now.ToString("mm")
        grpPaymentType.Visible = Not IsRFT
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
    Friend WithEvents grpVisit As GroupBox
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents cboAppointment As ComboBox
    Friend WithEvents lblAppointment As Label
    Friend WithEvents dtpVisitDate As DateTimePicker
    Friend WithEvents btnCreate As Button
    Friend WithEvents grpSite As GroupBox
    Friend WithEvents btnFindSite As Button
    Friend WithEvents txtSite As TextBox
    Friend WithEvents grpJob As GroupBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents dgJobs As DataGrid
    Friend WithEvents txtNotesToEngineer As TextBox
    Friend WithEvents cbNewJob As CheckBox
    Friend WithEvents rbtnFoc As RadioButton
    Friend WithEvents grpPaymentType As GroupBox
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents rbtnOti As RadioButton
    Friend WithEvents rbtnPoc As RadioButton
    Friend WithEvents grpSaleRep As GroupBox
    Friend WithEvents grpJobType As GroupBox
    Friend WithEvents btnFindSalesRep As Button
    Friend WithEvents txtSalesRep As TextBox
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
        Me.grpVisit = New System.Windows.Forms.GroupBox()
        Me.txtEndTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtEndTimeHours = New System.Windows.Forms.TextBox()
        Me.txtStartTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtStartTimeHours = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.txtNotesToEngineer = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.cboAppointment = New System.Windows.Forms.ComboBox()
        Me.lblAppointment = New System.Windows.Forms.Label()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.grpSite = New System.Windows.Forms.GroupBox()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.grpJob = New System.Windows.Forms.GroupBox()
        Me.grpSaleRep = New System.Windows.Forms.GroupBox()
        Me.btnFindSalesRep = New System.Windows.Forms.Button()
        Me.txtSalesRep = New System.Windows.Forms.TextBox()
        Me.grpJobType = New System.Windows.Forms.GroupBox()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.grpPaymentType = New System.Windows.Forms.GroupBox()
        Me.rbtnOti = New System.Windows.Forms.RadioButton()
        Me.rbtnPoc = New System.Windows.Forms.RadioButton()
        Me.rbtnFoc = New System.Windows.Forms.RadioButton()
        Me.cbNewJob = New System.Windows.Forms.CheckBox()
        Me.dgJobs = New System.Windows.Forms.DataGrid()
        Me.grpEngineer.SuspendLayout()
        Me.grpVisit.SuspendLayout()
        Me.grpSite.SuspendLayout()
        Me.grpJob.SuspendLayout()
        Me.grpSaleRep.SuspendLayout()
        Me.grpJobType.SuspendLayout()
        Me.grpPaymentType.SuspendLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpEngineer
        '
        Me.grpEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineer.Controls.Add(Me.btnfindEngineer)
        Me.grpEngineer.Controls.Add(Me.txtEngineer)
        Me.grpEngineer.Location = New System.Drawing.Point(12, 428)
        Me.grpEngineer.Name = "grpEngineer"
        Me.grpEngineer.Size = New System.Drawing.Size(658, 57)
        Me.grpEngineer.TabIndex = 46
        Me.grpEngineer.TabStop = False
        Me.grpEngineer.Text = "Engineer"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(620, 18)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 18
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(7, 19)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(607, 21)
        Me.txtEngineer.TabIndex = 17
        '
        'grpVisit
        '
        Me.grpVisit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisit.Controls.Add(Me.txtEndTimeMinutes)
        Me.grpVisit.Controls.Add(Me.txtEndTimeHours)
        Me.grpVisit.Controls.Add(Me.txtStartTimeMinutes)
        Me.grpVisit.Controls.Add(Me.txtStartTimeHours)
        Me.grpVisit.Controls.Add(Me.Label4)
        Me.grpVisit.Controls.Add(Me.Label3)
        Me.grpVisit.Controls.Add(Me.lblEndTime)
        Me.grpVisit.Controls.Add(Me.lblStartTime)
        Me.grpVisit.Controls.Add(Me.txtNotesToEngineer)
        Me.grpVisit.Controls.Add(Me.lblNotes)
        Me.grpVisit.Controls.Add(Me.cboAppointment)
        Me.grpVisit.Controls.Add(Me.lblAppointment)
        Me.grpVisit.Controls.Add(Me.dtpVisitDate)
        Me.grpVisit.Controls.Add(Me.lblVisitDate)
        Me.grpVisit.Location = New System.Drawing.Point(12, 293)
        Me.grpVisit.Name = "grpVisit"
        Me.grpVisit.Size = New System.Drawing.Size(658, 129)
        Me.grpVisit.TabIndex = 47
        Me.grpVisit.TabStop = False
        Me.grpVisit.Text = "Visit"
        '
        'txtEndTimeMinutes
        '
        Me.txtEndTimeMinutes.Location = New System.Drawing.Point(304, 58)
        Me.txtEndTimeMinutes.Name = "txtEndTimeMinutes"
        Me.txtEndTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeMinutes.TabIndex = 70
        '
        'txtEndTimeHours
        '
        Me.txtEndTimeHours.Location = New System.Drawing.Point(273, 58)
        Me.txtEndTimeHours.Name = "txtEndTimeHours"
        Me.txtEndTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeHours.TabIndex = 71
        '
        'txtStartTimeMinutes
        '
        Me.txtStartTimeMinutes.Location = New System.Drawing.Point(124, 58)
        Me.txtStartTimeMinutes.Name = "txtStartTimeMinutes"
        Me.txtStartTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeMinutes.TabIndex = 69
        '
        'txtStartTimeHours
        '
        Me.txtStartTimeHours.Location = New System.Drawing.Point(93, 58)
        Me.txtStartTimeHours.Name = "txtStartTimeHours"
        Me.txtStartTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeHours.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(296, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 17)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 17)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = ":"
        '
        'lblEndTime
        '
        Me.lblEndTime.Location = New System.Drawing.Point(203, 61)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(55, 17)
        Me.lblEndTime.TabIndex = 68
        Me.lblEndTime.Text = "End Time"
        '
        'lblStartTime
        '
        Me.lblStartTime.Location = New System.Drawing.Point(10, 61)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(60, 17)
        Me.lblStartTime.TabIndex = 66
        Me.lblStartTime.Text = "Start Time"
        '
        'txtNotesToEngineer
        '
        Me.txtNotesToEngineer.AcceptsReturn = True
        Me.txtNotesToEngineer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotesToEngineer.Location = New System.Drawing.Point(403, 19)
        Me.txtNotesToEngineer.Multiline = True
        Me.txtNotesToEngineer.Name = "txtNotesToEngineer"
        Me.txtNotesToEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotesToEngineer.Size = New System.Drawing.Size(247, 95)
        Me.txtNotesToEngineer.TabIndex = 65
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(351, 24)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(59, 15)
        Me.lblNotes.TabIndex = 64
        Me.lblNotes.Text = "Notes"
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
        Me.lblAppointment.Location = New System.Drawing.Point(10, 97)
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
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.Location = New System.Drawing.Point(595, 494)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(77, 23)
        Me.btnCreate.TabIndex = 48
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'grpSite
        '
        Me.grpSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSite.Controls.Add(Me.btnFindSite)
        Me.grpSite.Controls.Add(Me.txtSite)
        Me.grpSite.Location = New System.Drawing.Point(12, 12)
        Me.grpSite.Name = "grpSite"
        Me.grpSite.Size = New System.Drawing.Size(658, 55)
        Me.grpSite.TabIndex = 49
        Me.grpSite.TabStop = False
        Me.grpSite.Text = "Site"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(620, 16)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 18
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(6, 17)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(605, 21)
        Me.txtSite.TabIndex = 17
        '
        'grpJob
        '
        Me.grpJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJob.Controls.Add(Me.grpSaleRep)
        Me.grpJob.Controls.Add(Me.grpJobType)
        Me.grpJob.Controls.Add(Me.grpPaymentType)
        Me.grpJob.Controls.Add(Me.cbNewJob)
        Me.grpJob.Controls.Add(Me.dgJobs)
        Me.grpJob.Location = New System.Drawing.Point(12, 73)
        Me.grpJob.Name = "grpJob"
        Me.grpJob.Size = New System.Drawing.Size(658, 214)
        Me.grpJob.TabIndex = 64
        Me.grpJob.TabStop = False
        Me.grpJob.Text = "Job"
        '
        'grpSaleRep
        '
        Me.grpSaleRep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSaleRep.Controls.Add(Me.btnFindSalesRep)
        Me.grpSaleRep.Controls.Add(Me.txtSalesRep)
        Me.grpSaleRep.Location = New System.Drawing.Point(375, 164)
        Me.grpSaleRep.Name = "grpSaleRep"
        Me.grpSaleRep.Size = New System.Drawing.Size(274, 44)
        Me.grpSaleRep.TabIndex = 72
        Me.grpSaleRep.TabStop = False
        Me.grpSaleRep.Text = "Sales Rep"
        '
        'btnFindSalesRep
        '
        Me.btnFindSalesRep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSalesRep.BackColor = System.Drawing.Color.White
        Me.btnFindSalesRep.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSalesRep.Location = New System.Drawing.Point(236, 16)
        Me.btnFindSalesRep.Name = "btnFindSalesRep"
        Me.btnFindSalesRep.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSalesRep.TabIndex = 66
        Me.btnFindSalesRep.Text = "..."
        Me.btnFindSalesRep.UseVisualStyleBackColor = False
        '
        'txtSalesRep
        '
        Me.txtSalesRep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalesRep.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesRep.Location = New System.Drawing.Point(6, 17)
        Me.txtSalesRep.Name = "txtSalesRep"
        Me.txtSalesRep.ReadOnly = True
        Me.txtSalesRep.Size = New System.Drawing.Size(224, 21)
        Me.txtSalesRep.TabIndex = 65
        '
        'grpJobType
        '
        Me.grpJobType.Controls.Add(Me.cboJobType)
        Me.grpJobType.Location = New System.Drawing.Point(176, 164)
        Me.grpJobType.Name = "grpJobType"
        Me.grpJobType.Size = New System.Drawing.Size(193, 44)
        Me.grpJobType.TabIndex = 71
        Me.grpJobType.TabStop = False
        Me.grpJobType.Text = "Job Type"
        '
        'cboJobType
        '
        Me.cboJobType.Location = New System.Drawing.Point(6, 17)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(181, 21)
        Me.cboJobType.TabIndex = 65
        '
        'grpPaymentType
        '
        Me.grpPaymentType.Controls.Add(Me.rbtnOti)
        Me.grpPaymentType.Controls.Add(Me.rbtnPoc)
        Me.grpPaymentType.Controls.Add(Me.rbtnFoc)
        Me.grpPaymentType.Location = New System.Drawing.Point(6, 164)
        Me.grpPaymentType.Name = "grpPaymentType"
        Me.grpPaymentType.Size = New System.Drawing.Size(164, 44)
        Me.grpPaymentType.TabIndex = 67
        Me.grpPaymentType.TabStop = False
        Me.grpPaymentType.Text = "Payment Type"
        '
        'rbtnOti
        '
        Me.rbtnOti.AutoSize = True
        Me.rbtnOti.Location = New System.Drawing.Point(113, 19)
        Me.rbtnOti.Name = "rbtnOti"
        Me.rbtnOti.Size = New System.Drawing.Size(43, 17)
        Me.rbtnOti.TabIndex = 70
        Me.rbtnOti.TabStop = True
        Me.rbtnOti.Text = "OTI"
        Me.rbtnOti.UseVisualStyleBackColor = True
        '
        'rbtnPoc
        '
        Me.rbtnPoc.AutoSize = True
        Me.rbtnPoc.Location = New System.Drawing.Point(59, 19)
        Me.rbtnPoc.Name = "rbtnPoc"
        Me.rbtnPoc.Size = New System.Drawing.Size(47, 17)
        Me.rbtnPoc.TabIndex = 69
        Me.rbtnPoc.TabStop = True
        Me.rbtnPoc.Text = "POC"
        Me.rbtnPoc.UseVisualStyleBackColor = True
        '
        'rbtnFoc
        '
        Me.rbtnFoc.AutoSize = True
        Me.rbtnFoc.Location = New System.Drawing.Point(7, 19)
        Me.rbtnFoc.Name = "rbtnFoc"
        Me.rbtnFoc.Size = New System.Drawing.Size(46, 17)
        Me.rbtnFoc.TabIndex = 68
        Me.rbtnFoc.TabStop = True
        Me.rbtnFoc.Text = "FOC"
        Me.rbtnFoc.UseVisualStyleBackColor = True
        '
        'cbNewJob
        '
        Me.cbNewJob.AutoCheck = False
        Me.cbNewJob.AutoSize = True
        Me.cbNewJob.Checked = True
        Me.cbNewJob.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNewJob.Location = New System.Drawing.Point(7, 19)
        Me.cbNewJob.Name = "cbNewJob"
        Me.cbNewJob.Size = New System.Drawing.Size(68, 17)
        Me.cbNewJob.TabIndex = 14
        Me.cbNewJob.Text = "New Job"
        Me.cbNewJob.UseVisualStyleBackColor = True
        '
        'dgJobs
        '
        Me.dgJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobs.DataMember = ""
        Me.dgJobs.Enabled = False
        Me.dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobs.Location = New System.Drawing.Point(6, 42)
        Me.dgJobs.Name = "dgJobs"
        Me.dgJobs.Size = New System.Drawing.Size(641, 116)
        Me.dgJobs.TabIndex = 13
        '
        'FRMNewJob
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 529)
        Me.Controls.Add(Me.grpJob)
        Me.Controls.Add(Me.grpSite)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.grpVisit)
        Me.Controls.Add(Me.grpEngineer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.Name = "FRMNewJob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Job"
        Me.grpEngineer.ResumeLayout(False)
        Me.grpEngineer.PerformLayout()
        Me.grpVisit.ResumeLayout(False)
        Me.grpVisit.PerformLayout()
        Me.grpSite.ResumeLayout(False)
        Me.grpSite.PerformLayout()
        Me.grpJob.ResumeLayout(False)
        Me.grpJob.PerformLayout()
        Me.grpSaleRep.ResumeLayout(False)
        Me.grpSaleRep.PerformLayout()
        Me.grpJobType.ResumeLayout(False)
        Me.grpPaymentType.ResumeLayout(False)
        Me.grpPaymentType.PerformLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private _site As Site

    Private Property Site() As Site
        Get
            Return _site
        End Get
        Set
            _site = Value
            If Not _site Is Nothing Then
                Dim siteInfo As String = String.Empty
                If Not String.IsNullOrEmpty(_site.Name) Then siteInfo += _site.Name & ", "
                If Not String.IsNullOrEmpty(_site.Address1) Then siteInfo += _site.Address1 & ", "
                If Not String.IsNullOrEmpty(_site.Address2) Then siteInfo += _site.Address2 & ", "
                If Not String.IsNullOrEmpty(_site.Postcode) Then siteInfo += _site.Postcode
                Me.txtSite.Text = siteInfo
                If Not String.IsNullOrEmpty(_site.ContactAlerts) Then txtNotesToEngineer.Text = _site.ContactAlerts & " - "
            Else
                Me.txtSite.Text = "<Not set>"
                Me.txtNotesToEngineer.Text = ""
            End If
        End Set
    End Property

    Private _dvJobs As DataView

    Private Property DvJobs() As DataView
        Get
            Return _dvJobs
        End Get
        Set
            _dvJobs = Value
            _dvJobs.Table.TableName = Enums.TableNames.NO_TABLE.ToString
            Me.dgJobs.DataSource = DvJobs
        End Set
    End Property

    Private ReadOnly Property DrSelectedJob() As DataRow
        Get
            If Not Me.dgJobs.CurrentRowIndex = -1 Then
                Return DvJobs(Me.dgJobs.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _engineer As Engineer

    Public Property Engineer() As Engineer
        Get
            Return _engineer
        End Get
        Set
            _engineer = Value
            If Not _engineer Is Nothing Then
                Me.txtEngineer.Text = Engineer.Name
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End Set
    End Property

    Private _salesRep As User

    Private Property SalesRep() As User
        Get
            Return _salesRep
        End Get
        Set
            _salesRep = Value
            If Not _salesRep Is Nothing Then
                Me.txtSalesRep.Text = SalesRep.Fullname
            Else
                Me.txtSalesRep.Text = "<Not Set>"
            End If
        End Set
    End Property

    Private Property Job() As Job
    Private Property EngineerVisit() As EngineerVisit
    Private Property VisitStartDate As DateTime
    Private Property VisitEndDate As DateTime

#End Region

#Region "Events"

    Private Sub btnFindSite_Click(sender As Object, e As EventArgs) Handles btnFindSite.Click
        FindSite()
    End Sub

    Private Sub cbNewJob_Click(sender As Object, e As EventArgs) Handles cbNewJob.Click
        cbNewJob.Checked = Not cbNewJob.Checked
        CbNewJobClicked()
    End Sub

    Private Sub dgJobs_Click(sender As Object, e As EventArgs) Handles dgJobs.Click
        DgJobsClicked()
    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        FindEngineer()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        CreateJob()
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

    Private Sub btnFindSalesRep_Click(sender As Object, e As EventArgs) Handles btnFindSalesRep.Click
        FindUser()
    End Sub

#End Region

#Region "Function"

    Private Sub FindSite()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblSite)
        If Not ID = 0 Then
            Site = DB.Sites.Get(ID)
            If Site.OnStop Then
                ShowMessage("This site is ON STOP!" & vbCrLf & vbCrLf &
                            "Cannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Site = Nothing
                Exit Sub
            End If
            Dim customerStatus As Integer = DB.Customer.Customer_Get(Site.CustomerID)?.Status
            If customerStatus = CInt(Enums.CustomerStatus.OnHold) Then
                ShowMessage("The customer is ON HOLD!" & vbCrLf & vbCrLf &
                            "Cannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Site = Nothing
                Exit Sub
            End If
            cbNewJob.Checked = True
            CbNewJobClicked()
        End If
    End Sub

    Private Sub FindJobs()
        If Site Is Nothing Then Exit Sub
        Dim dtJobs As New DataTable
        dtJobs = DB.Job.Job_GetTop100_For_Site(Site.SiteID, Site.CustomerID)?.Table
        If dtJobs.Rows?.Count > 0 Then
            dtJobs = dtJobs.AsEnumerable().Take(10)?.CopyToDataTable()
        End If
        DvJobs = New DataView(dtJobs)
        ResetJob()
    End Sub

    Private Sub CbNewJobClicked()
        If Not cbNewJob.Checked Then
            SetupDgJobs()
            FindJobs()
            Me.grpPaymentType.Enabled = False
            Me.grpJobType.Enabled = False
            Me.grpSaleRep.Enabled = False
        Else
            DvJobs = New DataView(New DataTable)
            ClearDgJobs()
            Me.grpPaymentType.Enabled = True
            Me.grpJobType.Enabled = True
            Me.grpSaleRep.Enabled = True
            ResetJob()
        End If
    End Sub

    Private Sub FindUser()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblUser)
        If Not ID = 0 Then
            SalesRep = DB.User.Get(ID)
        End If
    End Sub

    Private Sub FindEngineer()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub DgJobsClicked()
        If DrSelectedJob Is Nothing Then Exit Sub
        Job = DB.Job.Job_Get(Helper.MakeIntegerValid(DrSelectedJob("JobID")))
        rbtnFoc.Checked = Job?.FOC
        rbtnPoc.Checked = Job?.POC
        rbtnOti.Checked = Job?.OTI
        Combo.SetSelectedComboItem_By_Value(cboJobType, Job?.JobTypeID)
        SalesRep = DB.User.Get(Job?.SalesRepUserID)
    End Sub

    Private Sub ResetJob()
        rbtnFoc.Checked = If(IsRFT, True, False)
        rbtnPoc.Checked = False
        rbtnOti.Checked = False
        Combo.SetSelectedComboItem_By_Value(cboJobType, 0)
        SalesRep = Nothing
    End Sub

    Private Function IsFormValid() As Boolean
        If Site Is Nothing Then
            ShowMessage("Please select a site!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not rbtnFoc.Checked And Not rbtnPoc.Checked And Not rbtnOti.Checked Then
            ShowMessage("Please select a payment type!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboJobType) = 0) Then
            ShowMessage("Please select a job type!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim startHour As Integer = Helper.MakeIntegerValid(txtStartTimeHours.Text)
        Dim startMin As Integer = Helper.MakeIntegerValid(txtStartTimeMinutes.Text)
        Dim endHour As Integer = Helper.MakeIntegerValid(txtEndTimeHours.Text)
        Dim endMin As Integer = Helper.MakeIntegerValid(txtEndTimeMinutes.Text)

        If Not IsHourAndMinValid(startHour, startMin) Then
            ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not IsHourAndMinValid(endHour, endMin) Then
            ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        VisitStartDate = New DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, startHour, startMin, 0)
        VisitEndDate = New DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, endHour, endMin, 0)
        If VisitStartDate > VisitEndDate Then
            ShowMessage("Start time can not be greater than end time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf VisitStartDate = VisitEndDate Then
            ShowMessage("Start time can not be equal to end time!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If txtNotesToEngineer.Text.Trim.Length = 0 Then
            ShowMessage("Please enter notes for the visit!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If Engineer Is Nothing Then
            ShowMessage("Please select an engineer!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If Not IsEngineerQualified(Engineer.EngineerID) Then
            ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

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

    Private Function IsHourAndMinValid(ByVal hour As Integer, ByVal min As Integer) As Boolean
        Return (hour >= 0 AndAlso hour <= 23) AndAlso (min >= 0 AndAlso min <= 59)
    End Function

    Private Sub CreateJob()
        Try
            If Not IsFormValid() Then Exit Sub
            Dim msg As String = If(Job?.JobID > 0, "Generate new visit?", "Create new job?")
            Dim successMsg As String = If(Job?.JobID > 0, "New visit generated!", " New job created!")
            If ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim ev As New EngineerVisit With {
                        .IgnoreExceptionsOnSetMethods = True,
                        .StartDateTime = VisitStartDate,
                        .EndDateTime = VisitEndDate,
                        .SetEngineerID = Engineer?.EngineerID,
                        .SetStatusEnumID = CInt(Enums.VisitStatus.Scheduled),
                        .SetAppointmentID = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboAppointment)),
                        .SetNotesToEngineer = txtNotesToEngineer.Text.Trim}

                If Job?.JobID > 0 Then
                    Job.JobOfWorks(Job.JobOfWorks.Count - 1)?.EngineerVisits.Add(ev)
                    Job = DB.Job.Update(Job)
                Else
                    Job = New Job
                    With Job
                        .IgnoreExceptionsOnSetMethods = True
                        .SetPropertyID = Site.SiteID
                        .SetJobTypeID = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboJobType))
                        .SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)
                        .SetStatusEnumID = CInt(Enums.JobStatus.Open)
                        .SetCreatedByUserID = loggedInUser.UserID
                        .SetFOC = rbtnFoc.Checked
                        .SetPOC = rbtnPoc.Checked
                        .SetOTI = rbtnOti.Checked
                        .SetJobCreationType = CInt(Enums.JobCreationType.Manual)
                        Dim JobNumber As JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout)
                        .SetJobNumber = JobNumber?.Prefix & JobNumber?.JobNumber
                        .SetSalesRepUserID = SalesRep?.UserID
                        .SetPONumber = ""
                    End With

                    Dim jow As New JobOfWork With {.SetPONumber = "", .PriorityDateSet = Now}
                    jow.EngineerVisits.Add(ev)
                    Job.JobOfWorks.Add(jow)
                    Job = DB.Job.Insert(Job)
                End If
                If ShowMessage(successMsg & vbCrLf & vbCrLf & "Do you want to open the job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {Job.JobID, Job.PropertyID})
                End If
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If
            End If
        Catch ex As Exception
            ShowMessage(ex.Message & " - " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "DataGrid Setup"

    Public Sub SetupDgJobs()
        Me.dgJobs.Enabled = True
        Helper.SetUpDataGrid(Me.dgJobs)
        Dim dgts As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        Dim dateCreated As New DataGridLabelColumn
        dateCreated.Format = "dd/MM/yyyy"
        dateCreated.FormatInfo = Nothing
        dateCreated.HeaderText = "Created"
        dateCreated.MappingName = "DateCreated"
        dateCreated.ReadOnly = True
        dateCreated.Width = 100
        dateCreated.NullText = ""
        dgts.GridColumnStyles.Add(dateCreated)

        Dim jobNumber As New DataGridLabelColumn
        jobNumber.Format = ""
        jobNumber.FormatInfo = Nothing
        jobNumber.HeaderText = "Job No"
        jobNumber.MappingName = "JobNumber"
        jobNumber.ReadOnly = True
        jobNumber.Width = 120
        jobNumber.NullText = ""
        dgts.GridColumnStyles.Add(jobNumber)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "Type"
        type.ReadOnly = True
        type.Width = 250
        type.NullText = Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        dgts.GridColumnStyles.Add(type)

        Dim lastVisitDate As New DataGridLabelColumn
        lastVisitDate.Format = "dd/MM/yyyy"
        lastVisitDate.FormatInfo = Nothing
        lastVisitDate.HeaderText = "Last Visit's Date"
        lastVisitDate.MappingName = "LastVisitDate"
        lastVisitDate.ReadOnly = True
        lastVisitDate.Width = 120
        lastVisitDate.NullText = ""
        dgts.GridColumnStyles.Add(lastVisitDate)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgJobs.TableStyles.Add(dgts)
    End Sub

    Private Sub ClearDgJobs()
        Helper.SetUpDataGrid(Me.dgJobs)
        Dim dgts As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgJobs.TableStyles.Add(dgts)
        Me.dgJobs.Enabled = False
    End Sub

#End Region

End Class