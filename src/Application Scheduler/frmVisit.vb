Imports System.Collections.Generic
Imports System.Linq

Public Class frmVisit
    Inherits FRMBaseForm
    Implements ISchedulerForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal EngineerIDIn As Integer, ByVal [Date] As DateTime, ByVal SORTotal As Integer, ByVal EngineerVisitID As Integer, ByVal isCopyIn As Boolean)
        MyBase.New()

        engineerID = EngineerIDIn

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Initialise our dynamic controls
        Me.lblStarts = New List(Of Label)
        Me.dtpMulitpleVisitsStart = New List(Of DateTimePicker)
        Me.lblEnds = New List(Of Label)
        Me.dtpMulitpleVisitsEnd = New List(Of DateTimePicker)
        Me.btnAddVisits = New List(Of Button)
        Me.btnRemoveVisits = New List(Of Button)

        'Add any initialization after the InitializeComponent() call

        theSelectedDay = [Date]
        DtTimeSlot = DB.Scheduler.Scheduler_DayTimeSlots([Date], engineerID)
        picPlanner.Image = scheduler_DayTimeSlots_bitmap()
        SORMinutes = SORTotal
        AMPM = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID).AMPM
        Combo.SetUpCombo(Me.cboAppointment, DB.Appointments.GetAll.Table, "AppointmentID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        'initialise mulitple visits tab
        InitComplexVisits()

        isCopy = isCopyIn

        _detailPopup = New frmDetailsPopup(Me)
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

    Friend WithEvents tabCtrlVisits As TabControl
    Friend WithEvents tabStandardVisit As TabPage
    Friend WithEvents tabComplexVisit As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboAppointment As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblAMPM As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEndTimeMinutes As TextBox
    Friend WithEvents txtEndTimeHours As TextBox
    Friend WithEvents txtStartTimeMinutes As TextBox
    Friend WithEvents txtStartTimeHours As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picPlanner As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents calComplexVisit As Pabo.Calendar.MonthCalendar
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnSaveComplex As Button
    Friend WithEvents btnCancel2 As Button
    Friend WithEvents btnAdditionalVisit As Button

    Private lblStarts As List(Of Label)
    Private dtpMulitpleVisitsStart As List(Of DateTimePicker)
    Private lblEnds As List(Of Label)
    Private dtpMulitpleVisitsEnd As List(Of DateTimePicker)
    Private btnAddVisits As List(Of Button)
    Private btnRemoveVisits As List(Of Button)
    Friend WithEvents pnlLayout As TableLayoutPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents ttComplexVisits As ToolTip

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tabCtrlVisits = New System.Windows.Forms.TabControl()
        Me.tabStandardVisit = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboAppointment = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblAMPM = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEndTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtEndTimeHours = New System.Windows.Forms.TextBox()
        Me.txtStartTimeMinutes = New System.Windows.Forms.TextBox()
        Me.txtStartTimeHours = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picPlanner = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabComplexVisit = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.calComplexVisit = New Pabo.Calendar.MonthCalendar()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSaveComplex = New System.Windows.Forms.Button()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAdditionalVisit = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.pnlLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ttComplexVisits = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabCtrlVisits.SuspendLayout()
        Me.tabStandardVisit.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picPlanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComplexVisit.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCtrlVisits
        '
        Me.tabCtrlVisits.Controls.Add(Me.tabStandardVisit)
        Me.tabCtrlVisits.Controls.Add(Me.tabComplexVisit)
        Me.tabCtrlVisits.Location = New System.Drawing.Point(0, 33)
        Me.tabCtrlVisits.Name = "tabCtrlVisits"
        Me.tabCtrlVisits.SelectedIndex = 0
        Me.tabCtrlVisits.Size = New System.Drawing.Size(569, 450)
        Me.tabCtrlVisits.TabIndex = 2
        '
        'tabStandardVisit
        '
        Me.tabStandardVisit.Controls.Add(Me.GroupBox2)
        Me.tabStandardVisit.Controls.Add(Me.GroupBox1)
        Me.tabStandardVisit.Location = New System.Drawing.Point(4, 22)
        Me.tabStandardVisit.Name = "tabStandardVisit"
        Me.tabStandardVisit.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStandardVisit.Size = New System.Drawing.Size(561, 424)
        Me.tabStandardVisit.TabIndex = 0
        Me.tabStandardVisit.Text = "Standard Visit"
        Me.tabStandardVisit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cboAppointment)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblAMPM)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtEndTimeMinutes)
        Me.GroupBox2.Controls.Add(Me.txtEndTimeHours)
        Me.GroupBox2.Controls.Add(Me.txtStartTimeMinutes)
        Me.GroupBox2.Controls.Add(Me.txtStartTimeHours)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 298)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 120)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Schedule Visit For"
        '
        'cboAppointment
        '
        Me.cboAppointment.FormattingEnabled = True
        Me.cboAppointment.Location = New System.Drawing.Point(150, 86)
        Me.cboAppointment.Name = "cboAppointment"
        Me.cboAppointment.Size = New System.Drawing.Size(210, 21)
        Me.cboAppointment.TabIndex = 59
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(10, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 18)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = "Appointment Type:"
        '
        'lblAMPM
        '
        Me.lblAMPM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMPM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMPM.ForeColor = System.Drawing.Color.Red
        Me.lblAMPM.Location = New System.Drawing.Point(410, 35)
        Me.lblAMPM.Name = "lblAMPM"
        Me.lblAMPM.Size = New System.Drawing.Size(136, 17)
        Me.lblAMPM.TabIndex = 57
        Me.lblAMPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Blank assumes ""start of day"""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(200, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 17)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Blank assumes ""end of day"""
        '
        'txtEndTimeMinutes
        '
        Me.txtEndTimeMinutes.Location = New System.Drawing.Point(336, 21)
        Me.txtEndTimeMinutes.Name = "txtEndTimeMinutes"
        Me.txtEndTimeMinutes.Size = New System.Drawing.Size(24, 21)
        Me.txtEndTimeMinutes.TabIndex = 3
        '
        'txtEndTimeHours
        '
        Me.txtEndTimeHours.Location = New System.Drawing.Point(288, 21)
        Me.txtEndTimeHours.Name = "txtEndTimeHours"
        Me.txtEndTimeHours.Size = New System.Drawing.Size(24, 21)
        Me.txtEndTimeHours.TabIndex = 3
        '
        'txtStartTimeMinutes
        '
        Me.txtStartTimeMinutes.Location = New System.Drawing.Point(150, 21)
        Me.txtStartTimeMinutes.Name = "txtStartTimeMinutes"
        Me.txtStartTimeMinutes.Size = New System.Drawing.Size(24, 21)
        Me.txtStartTimeMinutes.TabIndex = 2
        '
        'txtStartTimeHours
        '
        Me.txtStartTimeHours.Location = New System.Drawing.Point(104, 21)
        Me.txtStartTimeHours.Name = "txtStartTimeHours"
        Me.txtStartTimeHours.Size = New System.Drawing.Size(24, 21)
        Me.txtStartTimeHours.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(200, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "End Time"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Start Time"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(396, 86)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(482, 86)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.picPlanner)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 289)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Planner"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(8, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(533, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Hold Shift and LEFT click period for START time or RIGHT click period for END tim" &
    "e"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(240, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(248, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "NOT OK - Job or Absence overlap"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "OK - No overlap"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Salmon
        Me.Panel2.Location = New System.Drawing.Point(216, 265)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 16)
        Me.Panel2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Location = New System.Drawing.Point(8, 265)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 16)
        Me.Panel1.TabIndex = 12
        '
        'picPlanner
        '
        Me.picPlanner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPlanner.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.picPlanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPlanner.Location = New System.Drawing.Point(8, 23)
        Me.picPlanner.Name = "picPlanner"
        Me.picPlanner.Size = New System.Drawing.Size(541, 181)
        Me.picPlanner.TabIndex = 0
        Me.picPlanner.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Booked Schedule Period"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.Location = New System.Drawing.Point(8, 241)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(16, 16)
        Me.Panel3.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(216, 241)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 16)
        Me.Panel4.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(240, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Free Schedule Period"
        '
        'tabComplexVisit
        '
        Me.tabComplexVisit.Controls.Add(Me.GroupBox3)
        Me.tabComplexVisit.Controls.Add(Me.btnSaveComplex)
        Me.tabComplexVisit.Controls.Add(Me.btnCancel2)
        Me.tabComplexVisit.Controls.Add(Me.GroupBox4)
        Me.tabComplexVisit.Location = New System.Drawing.Point(4, 22)
        Me.tabComplexVisit.Name = "tabComplexVisit"
        Me.tabComplexVisit.Padding = New System.Windows.Forms.Padding(3)
        Me.tabComplexVisit.Size = New System.Drawing.Size(561, 424)
        Me.tabComplexVisit.TabIndex = 1
        Me.tabComplexVisit.Text = "Complex Visit"
        Me.tabComplexVisit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.calComplexVisit)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Panel7)
        Me.GroupBox3.Controls.Add(Me.Panel8)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 228)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Planner"
        '
        'calComplexVisit
        '
        Me.calComplexVisit.ActiveMonth.Month = 1
        Me.calComplexVisit.ActiveMonth.Year = 2018
        Me.calComplexVisit.BorderColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.calComplexVisit.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.calComplexVisit.ExtendedSelectionKey = Pabo.Calendar.mcExtendedSelectionKey.Shift
        Me.calComplexVisit.Footer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.calComplexVisit.Header.BackColor1 = System.Drawing.Color.Blue
        Me.calComplexVisit.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.calComplexVisit.Header.TextColor = System.Drawing.Color.White
        Me.calComplexVisit.ImageList = Nothing
        Me.calComplexVisit.Location = New System.Drawing.Point(7, 23)
        Me.calComplexVisit.MaxDate = New Date(2027, 5, 10, 12, 28, 13, 983)
        Me.calComplexVisit.MinDate = New Date(2018, 1, 11, 0, 0, 0, 0)
        Me.calComplexVisit.Month.BackgroundImage = Nothing
        Me.calComplexVisit.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.calComplexVisit.Month.Colors.Focus.Border = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.calComplexVisit.Month.Colors.Selected.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.calComplexVisit.Month.Colors.Selected.Border = System.Drawing.Color.Black
        Me.calComplexVisit.Month.Colors.Trailing.BackColor1 = System.Drawing.Color.WhiteSmoke
        Me.calComplexVisit.Month.Colors.Trailing.Date = System.Drawing.Color.DimGray
        Me.calComplexVisit.Month.Colors.Trailing.Text = System.Drawing.Color.Transparent
        Me.calComplexVisit.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.DarkOrange
        Me.calComplexVisit.Month.DateFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.calComplexVisit.Month.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.calComplexVisit.Name = "calComplexVisit"
        Me.calComplexVisit.SelectionMode = Pabo.Calendar.mcSelectionMode.None
        Me.calComplexVisit.ShowFooter = False
        Me.calComplexVisit.Size = New System.Drawing.Size(541, 168)
        Me.calComplexVisit.TabIndex = 16
        Me.calComplexVisit.Weekdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.calComplexVisit.Weekdays.TextColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.calComplexVisit.Weeknumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.calComplexVisit.Weeknumbers.TextColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(200, Byte), Integer))
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(288, 199)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(248, 16)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "NOT OK - Job or Absence overlap"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Salmon
        Me.Panel5.Location = New System.Drawing.Point(264, 199)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(16, 16)
        Me.Panel5.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(40, 199)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 14)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Selected Dates"
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel7.Location = New System.Drawing.Point(17, 197)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(16, 16)
        Me.Panel7.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel8.Location = New System.Drawing.Point(160, 199)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(16, 16)
        Me.Panel8.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(184, 199)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 16)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Weekend"
        '
        'btnSaveComplex
        '
        Me.btnSaveComplex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveComplex.Location = New System.Drawing.Point(397, 389)
        Me.btnSaveComplex.Name = "btnSaveComplex"
        Me.btnSaveComplex.Size = New System.Drawing.Size(64, 23)
        Me.btnSaveComplex.TabIndex = 4
        Me.btnSaveComplex.Text = "Ok"
        '
        'btnCancel2
        '
        Me.btnCancel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel2.Location = New System.Drawing.Point(490, 389)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel2.TabIndex = 5
        Me.btnCancel2.Text = "Cancel"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnAdditionalVisit)
        Me.GroupBox4.Controls.Add(Me.Panel9)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 237)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(555, 138)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Schedule Visit For"
        '
        'btnAdditionalVisit
        '
        Me.btnAdditionalVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdditionalVisit.Location = New System.Drawing.Point(505, 20)
        Me.btnAdditionalVisit.Name = "btnAdditionalVisit"
        Me.btnAdditionalVisit.Size = New System.Drawing.Size(20, 22)
        Me.btnAdditionalVisit.TabIndex = 66
        Me.btnAdditionalVisit.Tag = ""
        Me.btnAdditionalVisit.Text = "+"
        Me.ttComplexVisits.SetToolTip(Me.btnAdditionalVisit, "Add new visit")
        '
        'Panel9
        '
        Me.Panel9.AutoScroll = True
        Me.Panel9.Controls.Add(Me.pnlLayout)
        Me.Panel9.Controls.Add(Me.Label13)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 17)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(549, 118)
        Me.Panel9.TabIndex = 67
        '
        'pnlLayout
        '
        Me.pnlLayout.AutoSize = True
        Me.pnlLayout.ColumnCount = 6
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.85714!))
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.14286!))
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.pnlLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.pnlLayout.Location = New System.Drawing.Point(12, 28)
        Me.pnlLayout.Name = "pnlLayout"
        Me.pnlLayout.RowCount = 1
        Me.pnlLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlLayout.Size = New System.Drawing.Size(371, 30)
        Me.pnlLayout.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(11, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(421, 21)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "CLICK + TO ADD VISIT"
        '
        'frmVisit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(570, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabCtrlVisits)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(560, 450)
        Me.Name = "frmVisit"
        Me.Text = "Schedule Visit"
        Me.Controls.SetChildIndex(Me.tabCtrlVisits, 0)
        Me.tabCtrlVisits.ResumeLayout(False)
        Me.tabStandardVisit.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picPlanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComplexVisit.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private isCopy As Boolean = False
    Private _detailPopup As frmDetailsPopup

    Private timeSlotDt As DataTable

    Public Property DtTimeSlot() As DataTable Implements ISchedulerForm.TimeSlotDt
        Get
            Return timeSlotDt
        End Get
        Set(ByVal Value As DataTable)
            timeSlotDt = Value
        End Set
    End Property

    Private _engineerID As String

    Public Property engineerID() As String Implements ISchedulerForm.EngineerID
        Get
            Return _engineerID
        End Get
        Set(ByVal Value As String)
            _engineerID = Value
        End Set
    End Property

    Private _AMPM As String = ""

    Public Property AMPM() As String
        Get
            Return _AMPM
        End Get
        Set(ByVal Value As String)
            _AMPM = Value

            Select Case AMPM
                Case "AM"
                    Me.lblAMPM.Text = "Due for AM arrival"
                Case "PM"
                    Me.lblAMPM.Text = "Due for PM arrival"
                Case Else
                    Me.lblAMPM.Text = ""
            End Select
        End Set
    End Property

    Private _theSelectedDay As DateTime

    Public Property theSelectedDay() As DateTime
        Get
            Return _theSelectedDay
        End Get
        Set(ByVal Value As DateTime)
            _theSelectedDay = Value
        End Set
    End Property

    Private _StartDate As DateTime

    Public Property StartDate() As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal Value As DateTime)
            _StartDate = Value
        End Set
    End Property

    Private _EndDate As DateTime

    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal Value As DateTime)
            _EndDate = Value
        End Set
    End Property

    Private _AppointmentType As Integer

    Public Property AppointmentType() As Integer
        Get
            Return _AppointmentType
        End Get
        Set(ByVal Value As Integer)
            _AppointmentType = Value
        End Set
    End Property

    Private _SORMinutes As Integer

    Private Property SORMinutes() As Integer
        Get
            Return _SORMinutes
        End Get
        Set(ByVal value As Integer)
            _SORMinutes = value
        End Set
    End Property

    Public ReadOnly Property IsFormDisposed() As Boolean Implements ISchedulerForm.IsDisposed
        Get
            Return Me.IsDisposed
        End Get
    End Property

    Public ReadOnly Property ThePlanner() As PictureBox Implements ISchedulerForm.PicPlanner
        Get
            Return Me.picPlanner
        End Get
    End Property

    Public ReadOnly Property TheHandle() As IntPtr Implements ISchedulerForm.Handle
        Get
            Return Me.Handle
        End Get
    End Property

    Public ReadOnly Property MyName() As String Implements ISchedulerForm.Name
        Get
            Return "frmVisit"
        End Get
    End Property

    Public Function selectedDay() As String Implements ISchedulerForm.selectedDay
        Return theSelectedDay
    End Function

    Public mulitpleVisits As Boolean = False

    Private _visitsList As New List(Of List(Of DateTime))

    Public ReadOnly Property VisitsList() As List(Of List(Of DateTime))
        Get
            Return _visitsList
        End Get
    End Property

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim startTime As DateTime
        Dim endTime As DateTime

        Dim settings As Entity.Management.Settings = DB.Manager.Get()

        If Combo.GetSelectedItemValue(cboAppointment) < 1 Then
            MessageBox.Show("You must select an Appointment Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Exit Sub
        End If

        If Me.txtStartTimeHours.Text.Trim.Length = 0 And Me.txtStartTimeMinutes.Text.Trim.Length = 0 Then
            startTime = New DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, settings.WorkingHoursStart.Substring(0, 2), settings.WorkingHoursStart.Substring(3, 2), 0)
        Else
            If Not ((IsNumeric(txtStartTimeHours.Text) AndAlso txtStartTimeHours.Text >= 0 AndAlso txtStartTimeHours.Text <= 23) AndAlso
                        (IsNumeric(txtStartTimeMinutes.Text) AndAlso txtStartTimeMinutes.Text >= 0 AndAlso txtStartTimeMinutes.Text <= 59)) Then

                MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            startTime = New DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day,
                                                               CInt(txtStartTimeHours.Text),
                                                                CInt(txtStartTimeMinutes.Text), 0)
        End If

        If Me.txtEndTimeHours.Text.Trim.Length = 0 And Me.txtEndTimeMinutes.Text.Trim.Length = 0 Then
            endTime = New DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, settings.WorkingHoursEnd.Substring(0, 2), settings.WorkingHoursEnd.Substring(3, 2), 0)
        Else
            If Not ((IsNumeric(txtEndTimeHours.Text) AndAlso txtEndTimeHours.Text >= 0 AndAlso txtEndTimeHours.Text <= 23) AndAlso
                      (IsNumeric(txtEndTimeMinutes.Text) AndAlso txtEndTimeMinutes.Text >= 0 AndAlso txtEndTimeMinutes.Text <= 59)) Then

                MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            endTime = New DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day,
                                                                   CInt(txtEndTimeHours.Text),
                                                                   CInt(txtEndTimeMinutes.Text), 0)
        End If

        If DateTime.Compare(startTime, endTime) > 0 Then
            MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Exit Sub
        End If

        If Not CheckDateAndContinue(startTime) Then
            Exit Sub
        End If

        StartDate = startTime
        EndDate = endTime
        AppointmentType = Combo.GetSelectedItemValue(cboAppointment)

        Me.DialogResult = DialogResult.OK
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Function CheckDateAndContinue(ByVal startTime As DateTime) As Boolean
        Select Case AMPM
            Case ""
                Return True

            Case "AM"
                If startTime > New DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0) Then
                    If ShowMessage("The visit is due for an AM start, (before 12:30)." & vbCrLf & "Do you wish to continue with " & Format(startTime, "HH:mm") & "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Return False
                    Else
                        If isCopy Then
                            Return True
                        End If

                        'Dim dialogue As DLGPasswordOverride
                        'dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
                        'If dialogue Is Nothing Then
                        '    dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
                        'End If
                        'dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                        'dialogue.ShowInTaskbar = False

                        'dialogue.ShowDialog()

                        'If dialogue.DialogResult = DialogResult.OK Then
                        '    DialogResult = DialogResult.OK
                        Return True
                        'Else
                        '    Me.DialogResult = DialogResult.No
                        '    ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    Return False
                        'End If

                    End If
                Else
                    Return True
                End If

            Case "PM"
                If startTime < New DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0) Then
                    If ShowMessage("The visit is due for a PM start, (after 12:30)." & vbCrLf & "Do you wish to continue with " & Format(startTime, "HH:mm") & "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Return False
                    Else
                        If isCopy Then
                            Return True
                        End If

                        'Dim dialogue As DLGPasswordOverride
                        'dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
                        'If dialogue Is Nothing Then
                        '    dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
                        'End If
                        'dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                        'dialogue.ShowInTaskbar = False

                        'dialogue.ShowDialog()

                        'If dialogue.DialogResult = DialogResult.OK Then
                        '    DialogResult = DialogResult.OK
                        Return True
                        'Else
                        '    Me.DialogResult = DialogResult.No
                        '    ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    Return False
                        'End If

                    End If
                Else
                    Return True
                End If
        End Select
    End Function

    Private Function scheduler_DayTimeSlots_bitmap() As Bitmap
        Try
            If Not DtTimeSlot Is Nothing AndAlso picPlanner.Height > 0 AndAlso picPlanner.Width > 0 Then
                Dim timeSlots As New Bitmap(picPlanner.Width, picPlanner.Height)
                Dim timeSlotGfx As Graphics = Graphics.FromImage(timeSlots)

                Dim slotWidth As Single = CSng(timeSlots.Width - 9) / CSng(DtTimeSlot.Columns.Count - 1)

                Dim currentHour As String

                For Each time As DataColumn In DtTimeSlot.Columns

                    Dim theDateTimeColumn As DateTime = Nothing
                    Dim theTimeEnteredStart As DateTime = Nothing
                    Dim theTimeEnteredEnd As DateTime = Nothing
                    If txtStartTimeHours.Text <> "" AndAlso txtStartTimeMinutes.Text <> "" AndAlso txtEndTimeHours.Text <> "" AndAlso txtEndTimeMinutes.Text <> "" Then
                        theDateTimeColumn = Now.Date & " " & time.ColumnName.Substring(1, 2) & ":" & time.ColumnName.Substring(3, 2) & ":00"
                        theTimeEnteredStart = Now.Date & " " & Me.txtStartTimeHours.Text.Trim & ":" & Me.txtStartTimeMinutes.Text.Trim & ":00"
                        theTimeEnteredEnd = Now.Date & " " & Me.txtEndTimeHours.Text.Trim & ":" & Me.txtEndTimeMinutes.Text.Trim & ":00"
                    End If

                    Dim TheColour As Color
                    TheColour = Color.WhiteSmoke

                    If DtTimeSlot.Rows.Count > 0 AndAlso DtTimeSlot.Rows(0)(time) = 1 Then
                        Try
                            If (theTimeEnteredStart <= theDateTimeColumn) And (theTimeEnteredEnd >= theDateTimeColumn.AddMinutes(DB.Manager.Get.TimeSlot)) Then
                                TheColour = Color.Salmon
                            Else
                                TheColour = Color.LightSteelBlue
                            End If
                        Catch ex As Exception
                            TheColour = Color.LightSteelBlue
                        End Try
                    End If

                    Try
                        If TheColour.Name = Color.WhiteSmoke.Name Then
                            If (theDateTimeColumn >= theTimeEnteredStart) And (theDateTimeColumn < theTimeEnteredEnd) Then
                                TheColour = Color.LightGreen
                            End If
                        End If
                    Catch ex As Exception
                        'DO NOTHING
                    End Try

                    timeSlotGfx.FillRectangle(New SolidBrush(TheColour), New RectangleF(slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth, CSng(picPlanner.Height - 15)))

                    If time.ColumnName.Substring(1, 2) <> currentHour Then
                        currentHour = time.ColumnName.Substring(1, 2)
                        timeSlotGfx.DrawLine(New Pen(Color.RoyalBlue), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), CSng(picPlanner.Height - 12))

                        Dim hourFont As New Font(Font.Name, 6, FontStyle.Regular)

                        timeSlotGfx.DrawString(currentHour, hourFont, New SolidBrush(Color.Black), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)) - (timeSlotGfx.MeasureString(currentHour, hourFont).Width / 2), CSng(picPlanner.Height - timeSlotGfx.MeasureString(currentHour, hourFont).Height - 1))
                    Else
                        timeSlotGfx.DrawLine(New Pen(Color.RoyalBlue), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), CSng(picPlanner.Height - 13))
                    End If

                Next

                Return timeSlots
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub frmVisit_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        picPlanner.Image = scheduler_DayTimeSlots_bitmap()
    End Sub

    Private Sub frmVisit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)

        Me.ActiveControl = txtStartTimeHours
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnCancel.Click, btnCancel2.Click
        Me.DialogResult = DialogResult.Cancel
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub txtEndTimeHours_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtStartTimeHours.TextChanged, txtStartTimeMinutes.TextChanged,
        txtEndTimeHours.TextChanged, txtEndTimeMinutes.TextChanged

        Dim sequence As TextBox() = New TextBox() {txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes}
        Dim currentBox As TextBox = CType(sender, TextBox)

        If currentBox.Text.Length >= 2 AndAlso Array.IndexOf(sequence, currentBox) < sequence.Length - 1 Then
            sequence(Array.IndexOf(sequence, currentBox) + 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) + 1).SelectAll()

        ElseIf currentBox.Text.Length = 0 AndAlso Array.IndexOf(sequence, currentBox) - 1 >= 0 Then
            sequence(Array.IndexOf(sequence, currentBox) - 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) - 1).SelectAll()
        End If

        If SORMinutes > 0 Then

            If (currentBox.Name = "txtStartTimeMinutes" Or currentBox.Name = "txtStartTimeHours") _
                And txtStartTimeMinutes.Text.Length >= 2 And txtStartTimeHours.Text.Length >= 2 Then

                Try
                    Dim enteredStartTime As DateTime = "01/01/1980 " & txtStartTimeHours.Text & ":" & txtStartTimeMinutes.Text
                    Dim calculatedEndTime As DateTime
                    'ADD SOR Minutes
                    calculatedEndTime = enteredStartTime.AddMinutes(SORMinutes)
                    If calculatedEndTime.Hour.ToString.Length = 1 Then
                        Me.txtEndTimeHours.Text = "0" & calculatedEndTime.Hour
                    Else
                        Me.txtEndTimeHours.Text = calculatedEndTime.Hour
                    End If
                    If calculatedEndTime.Minute.ToString.Length = 1 Then
                        Me.txtEndTimeMinutes.Text = "0" & calculatedEndTime.Minute
                    Else
                        Me.txtEndTimeMinutes.Text = calculatedEndTime.Minute
                    End If

                    Me.btnSave.Focus()
                Catch ex As Exception
                    'EMPTY
                End Try
            End If

        End If
        picPlanner.Image = scheduler_DayTimeSlots_bitmap()
    End Sub

    Private Sub picPlanner_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPlanner.MouseUp

        Dim timeSlots As New Bitmap(picPlanner.Width, picPlanner.Height)
        Dim slotWidth As Single = CSng(timeSlots.Width - 9) / CSng(DtTimeSlot.Columns.Count - 1)

        If e.Button = MouseButtons.Left Then
            Dim columnNumber As Integer = CInt(Math.Ceiling(e.X / slotWidth)) - 1
            If columnNumber < 0 Then
                columnNumber = 0
            End If
            If columnNumber > (DtTimeSlot.Columns.Count - 1) Then
                columnNumber = DtTimeSlot.Columns.Count - 1
            End If

            Dim columnName As String = DtTimeSlot.Columns(columnNumber).ColumnName
            Dim hours As String = columnName.Substring(1, 2)
            Dim minutes As String = columnName.Substring(3, 2)

            Me.txtStartTimeHours.Text = hours
            Me.txtStartTimeMinutes.Text = minutes
        ElseIf e.Button = MouseButtons.Right Then
            Dim columnNumber As Integer = CInt(Math.Ceiling(e.X / slotWidth))
            If columnNumber < 0 Then
                columnNumber = 0
            End If
            If columnNumber > (DtTimeSlot.Columns.Count - 1) Then
                columnNumber = DtTimeSlot.Columns.Count - 1
            End If

            Dim columnName As String = DtTimeSlot.Columns(columnNumber).ColumnName
            Dim hours As String = columnName.Substring(1, 2)
            Dim minutes As String = columnName.Substring(3, 2)

            Me.txtEndTimeHours.Text = hours
            Me.txtEndTimeMinutes.Text = minutes
        End If
    End Sub

    ''' <summary>
    ''' Initialises the mulitple visits tab
    ''' </summary>
    Private Sub InitComplexVisits()
        'set the default properites for calendar
        calComplexVisit.MinDate = DateTime.Now.AddMonths(-1)
        calComplexVisit.SelectDate(DateTime.Today)
        calComplexVisit.ActiveMonth.Month = DateTime.Now.Month
        calComplexVisit.ActiveMonth.Year = DateTime.Now.Year
        calComplexVisit.ExtendedSelectionKey = Keys.ControlKey

        UpdateEngineerSchedule()
    End Sub

    ''' <summary>
    ''' Gets the engineer's schedule for the selected month and highlights the days they are unavailable
    ''' </summary>
    Private Sub UpdateEngineerSchedule()
        'get the month shown and set start and end dates
        Dim startDate As DateTime =
            New DateTime(calComplexVisit.ActiveMonth.Year, calComplexVisit.ActiveMonth.Month, 1)
        Dim endDate As DateTime = startDate.AddMonths(1)

        'get the engineer's status
        Dim dtEngineerJobs As DataTable =
            DB.Scheduler.getSummaryNEW(engineerID, startDate, endDate)

        'check datatable is not empty
        If dtEngineerJobs IsNot Nothing Then
            Dim index As Integer = 0
            For Each row As DataRow In dtEngineerJobs.Rows

                Dim workLoad As Integer = Entity.Sys.Helper.MakeIntegerValid(row("workCount"))
                Dim absence As Integer = Entity.Sys.Helper.MakeIntegerValid(row("AbsenceColumn"))
                Dim busyDate As Date = Entity.Sys.Helper.MakeDateTimeValid(row("dayDate"))
                'if the engineer has work that day then they're busy
                If workLoad > 0 Or absence > 0 Then
                    'set date to midnight for calendar control
                    busyDate = New DateTime(busyDate.Year, busyDate.Month, busyDate.Day, 0, 0, 0)
                    Dim item() As Pabo.Calendar.DateItem = calComplexVisit.GetDateInfo(busyDate)
                    If item.Length > 0 Then
                        'do nothing
                    Else
                        'engineer is busy so highlight red
                        Dim dateItem As New Pabo.Calendar.DateItem
                        dateItem.Date = busyDate
                        dateItem.BackColor1 = Color.Salmon
                        calComplexVisit.AddDateInfo(dateItem)
                    End If
                End If
                index += 1
            Next
        End If

    End Sub

    ''' <summary>
    ''' Check to see if engineer is busy or absent
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns>Boolean</returns>
    Private Function IsEngineerWorkingOrAbsent(ByVal startDate As Date, ByVal endDate As Date) As Boolean
        'get the engineer's status
        Dim isBusy As Boolean = False
        Dim dtEngineerJobs As DataTable =
            DB.Scheduler.getSummaryNEW(engineerID, startDate, endDate)

        'checks if datatable is not empty
        If dtEngineerJobs IsNot Nothing Then
            For Each row As DataRow In dtEngineerJobs.Rows

                Dim workLoad As Integer = Entity.Sys.Helper.MakeIntegerValid(row("workCount"))
                Dim absence As Integer = Entity.Sys.Helper.MakeIntegerValid(row("AbsenceColumn"))
                'if the engineer has work that day then they're busy
                If workLoad > 0 Or absence > 0 Then
                    isBusy = True
                End If
            Next
        End If
        Return isBusy
    End Function

    Private Sub btnAddVisit_Click(sender As Object, e As EventArgs)
        'get settings for default start and end times
        Dim senderButton As Button = DirectCast(sender, Button)
        Dim index As Integer = btnAddVisits.IndexOf(senderButton)
        'get start and end from datepickers
        Dim dtpStart As DateTimePicker = dtpMulitpleVisitsStart(index)
        Dim dtpEnd As DateTimePicker = dtpMulitpleVisitsEnd(index)

        Dim startDate As DateTime = dtpStart.Value
        Dim endDate As DateTime = dtpEnd.Value

        If Not ValidateSelection(startDate, endDate) Then
            ShowMessage("Dates selected overlap other dates, please check your selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'display engineer may busy on selected dates
        If IsEngineerWorkingOrAbsent(startDate, endDate) Then
            ShowMessage("Engineer might be unavailable on the dates selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'set current date as we need it for highlighting calender
        Dim currentDate As DateTime =
            New DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)

        Dim settings As Entity.Management.Settings = DB.Manager.Get()

        'add visit to list
        _visitsList.Add(New List(Of DateTime))

        _visitsList(index).Add(New DateTime(startDate.Year, startDate.Month,
                                 startDate.Day, settings.WorkingHoursStart.Substring(0, 2),
                                 settings.WorkingHoursStart.Substring(3, 2), 0))
        _visitsList(index).Add(New DateTime(endDate.Year, endDate.Month,
                                 endDate.Day, settings.WorkingHoursEnd.Substring(0, 2),
                                 settings.WorkingHoursEnd.Substring(3, 2), 0))

        'loop through each day between the dates and highlight them as selected in the calender
        Do While (currentDate <= endDate)
            'if the date is already highlight then we override it
            Dim item() As Pabo.Calendar.DateItem = calComplexVisit.GetDateInfo(currentDate)
            If item.Length > 0 Then
                For Each _item As Pabo.Calendar.DateItem In item
                    _item.BackColor1 = Color.LightSteelBlue
                    calComplexVisit.AddDateInfo(_item)
                Next
            Else  ' create new highlight
                Dim dateItem As New Pabo.Calendar.DateItem
                dateItem.Date = currentDate
                dateItem.BackColor1 = Color.LightSteelBlue
                calComplexVisit.AddDateInfo(dateItem)
            End If
            currentDate = currentDate.AddDays(1)
        Loop

        'disable the datepickers and the save button
        dtpStart.Enabled = False
        dtpEnd.Enabled = False
        senderButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Validates the user's selection doesn't overlap with dates they have previously selected
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns>Boolean</returns>
    Private Function ValidateSelection(ByVal startDate As Date, ByVal endDate As Date) As Boolean
        Dim overlap As Boolean = False
        For Each [dates] As List(Of Date) In _visitsList
            If Not overlap Then
                overlap = dates(0) <= endDate And startDate <= dates(1)
            End If
        Next
        Return IIf(overlap, False, True)
    End Function

    Private Sub DtpComplexVisit_MonthChanged(sender As Object, e As Pabo.Calendar.MonthChangedEventArgs) Handles calComplexVisit.MonthChanged
        UpdateEngineerSchedule()
    End Sub

    Private Sub BtnSaveComplex_Click(sender As Object, e As EventArgs) Handles btnSaveComplex.Click
        'check we have visits saved
        If _visitsList.Count = 0 Then
            ShowMessage("No visits created, please create and save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'check if any dates have not been saved
        For Each datepicker As DateTimePicker In dtpMulitpleVisitsStart
            If datepicker.Enabled Then
                ShowMessage("Visits not saved, please save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Next

        'set muliplevisits to true for scheduler
        mulitpleVisits = True

        'order visit list in date order
        _visitsList = _visitsList.OrderBy(Function(i) i.OrderBy(Function(x) x.Date).First()).ToList()
        AppointmentType = Entity.Sys.Enums.Appointments.FirstCall

        ShowMessage("You have successfully created " & _visitsList.Count & " visits",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub dtpMultipleStart_ValueChanged(sender As Object, e As EventArgs)
        Dim senderDtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        Dim dtpEnd As DateTimePicker = dtpMulitpleVisitsEnd(dtpMulitpleVisitsStart.IndexOf(senderDtp))

        'update datepicker so dates are valid
        If senderDtp.Value > dtpEnd.Value Then
            dtpEnd.Value = senderDtp.Value
        End If
    End Sub

    Private Sub dtpMultipleEnd_ValueChanged(sender As Object, e As EventArgs)
        Dim senderDtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        Dim dtpStart As DateTimePicker = dtpMulitpleVisitsStart(dtpMulitpleVisitsEnd.IndexOf(senderDtp))

        'update datepicker so dates are valid
        If senderDtp.Value < dtpStart.Value Then
            senderDtp.Value = dtpStart.Value
        End If
    End Sub

    Private Sub btnAdditionalVisit_Click(sender As Object, e As EventArgs) Handles btnAdditionalVisit.Click
        'we create all visit buttons add datepickers dynamically to ensure a nice ux
        Dim elementCount As Integer = btnRemoveVisits.Count

        'define start label
        Dim lblStart As New Label
        lblStart.Size = New System.Drawing.Size(36, 17)
        lblStart.Text = "Start"
        lblStart.Name = "lblStart" & elementCount
        lblStart.Anchor = System.Windows.Forms.AnchorStyles.None
        lblStarts.Add(lblStart)

        'define start datepicker
        Dim dtpStart As New DateTimePicker
        dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        dtpStart.Size = New System.Drawing.Size(87, 21)
        dtpStart.Name = "dtpStart" & elementCount
        dtpStart.Anchor = System.Windows.Forms.AnchorStyles.None
        AddHandler dtpStart.ValueChanged, AddressOf dtpMultipleStart_ValueChanged
        dtpMulitpleVisitsStart.Add(dtpStart)

        'define end label
        Dim lblEnd As New Label
        lblEnd.Size = New System.Drawing.Size(36, 17)
        lblEnd.Text = "End"
        lblEnd.Name = "lblEnd" & elementCount
        lblEnd.Anchor = System.Windows.Forms.AnchorStyles.None
        lblEnds.Add(lblEnd)

        'define end datepicker
        Dim dtpEnd As New DateTimePicker
        dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        dtpEnd.Size = New System.Drawing.Size(87, 21)
        dtpEnd.Name = "dtpEnd" & elementCount
        dtpEnd.Anchor = System.Windows.Forms.AnchorStyles.None
        AddHandler dtpEnd.ValueChanged, AddressOf dtpMultipleEnd_ValueChanged
        dtpMulitpleVisitsEnd.Add(dtpEnd)

        'define add visit button
        Dim btnNewVisit As New Button
        btnNewVisit.ForeColor = System.Drawing.Color.Green
        btnNewVisit.Name = "btnAddVisit" & elementCount.ToString
        btnNewVisit.Size = New System.Drawing.Size(20, 22)
        btnNewVisit.Text = "✓"
        btnNewVisit.Anchor = System.Windows.Forms.AnchorStyles.None
        btnNewVisit.FlatStyle = FlatStyle.Standard
        AddHandler btnNewVisit.Click, AddressOf btnAddVisit_Click
        btnAddVisits.Add(btnNewVisit)

        'define remove visit button
        Dim btnDeleteVisit As New Button
        btnDeleteVisit.ForeColor = System.Drawing.Color.Red
        btnDeleteVisit.Name = "btnRemoveVisit" & elementCount.ToString
        btnDeleteVisit.Size = New System.Drawing.Size(20, 22)
        btnDeleteVisit.Anchor = System.Windows.Forms.AnchorStyles.None
        btnDeleteVisit.FlatStyle = FlatStyle.Standard
        btnDeleteVisit.Text = "X"
        AddHandler btnDeleteVisit.Click, AddressOf btnRemoveVisit_Click
        btnRemoveVisits.Add(btnDeleteVisit)

        'add tooltips
        Me.ttComplexVisits.SetToolTip(btnNewVisit, "Save selected dates")
        Me.ttComplexVisits.SetToolTip(btnDeleteVisit, "Remove selected visit")

        'define the grid position of the controls
        If elementCount > 0 Then
            Dim ctrlPos As New List(Of Integer)
            For i As Integer = 0 To pnlLayout.RowCount
                For Each lbl As Label In lblStarts
                    ctrlPos.Add(pnlLayout.GetCellPosition(lbl).Row)
                Next
            Next
            ctrlPos.Sort()
            If ctrlPos.Contains(elementCount) Then elementCount = (ctrlPos(ctrlPos.Count - 1) + 1)
        End If

        'position controls
        pnlLayout.SetCellPosition(lblStart, New TableLayoutPanelCellPosition(0, elementCount))
        pnlLayout.SetCellPosition(dtpStart, New TableLayoutPanelCellPosition(1, elementCount))
        pnlLayout.SetCellPosition(lblEnd, New TableLayoutPanelCellPosition(2, elementCount))
        pnlLayout.SetCellPosition(dtpEnd, New TableLayoutPanelCellPosition(3, elementCount))
        pnlLayout.SetCellPosition(btnNewVisit, New TableLayoutPanelCellPosition(4, elementCount))
        pnlLayout.SetCellPosition(btnDeleteVisit, New TableLayoutPanelCellPosition(5, elementCount))

        'add all new controls to grid
        pnlLayout.Controls.Add(lblStart)
        pnlLayout.Controls.Add(dtpStart)
        pnlLayout.Controls.Add(lblEnd)
        pnlLayout.Controls.Add(dtpEnd)
        pnlLayout.Controls.Add(btnNewVisit)
        pnlLayout.Controls.Add(btnDeleteVisit)
    End Sub

    Private Sub btnRemoveVisit_Click(sender As Object, e As EventArgs)
        'need to remove dates from form
        'get the relevant controls to delete
        Dim senderButton As Button = DirectCast(sender, Button)
        Dim index As Integer = btnRemoveVisits.IndexOf(senderButton)
        Dim dtpStart As DateTimePicker = dtpMulitpleVisitsStart(index)
        Dim dtpEnd As DateTimePicker = dtpMulitpleVisitsEnd(index)
        Dim lblStart As Label = lblStarts(index)
        Dim lblEnd As Label = lblEnds(index)
        Dim btnAdd As Button = btnAddVisits(index)

        'remove controls from panel
        pnlLayout.Controls.Remove(senderButton)
        pnlLayout.Controls.Remove(lblStart)
        pnlLayout.Controls.Remove(dtpStart)
        pnlLayout.Controls.Remove(lblEnd)
        pnlLayout.Controls.Remove(dtpEnd)
        pnlLayout.Controls.Remove(btnAdd)

        'remove controls from list
        dtpMulitpleVisitsStart.Remove(dtpStart)
        dtpMulitpleVisitsEnd.Remove(dtpEnd)
        btnRemoveVisits.Remove(senderButton)
        lblStarts.Remove(lblStart)
        lblEnds.Remove(lblEnd)
        btnAddVisits.Remove(btnAdd)

        'remove dates from list
        If _visitsList.Count > 0 And (_visitsList.Count - 1) >= index Then
            Dim startDate As Date = _visitsList(index)(0)
            Dim endDate As Date = _visitsList(index)(1)
            Dim currentDate As DateTime =
                New DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)
            _visitsList.RemoveAt(index)

            'update selection on calendar
            Do While (currentDate <= endDate)
                Dim item() As Pabo.Calendar.DateItem = calComplexVisit.GetDateInfo(currentDate)
                If item.Length > 0 Then
                    For Each _item As Pabo.Calendar.DateItem In item
                        calComplexVisit.RemoveDateInfo(_item.Date)
                    Next
                End If
                currentDate = currentDate.AddDays(1)
            Loop

            UpdateEngineerSchedule()
        End If
    End Sub

End Class