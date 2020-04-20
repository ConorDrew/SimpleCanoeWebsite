Imports System.Runtime.InteropServices

Public Class frmDetailsPopup
    Inherits System.Windows.Forms.Form

    Private _scheduleOwner As ISchedulerForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal scheduleOwner As frmEngineerSchedule)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CheckForIllegalCrossThreadCalls = False

        SetUpDg()
        _timer.Interval = 3000
        _timer.Start()

        'Add any initialization after the InitializeComponent() call
        _scheduleOwner = scheduleOwner

    End Sub

    Public Sub New(ByVal scheduleOwner As frmVisit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        SetUpDg()
        _timer.Interval = 3000
        _timer.Start()

        'Add any initialization after the InitializeComponent() call
        _scheduleOwner = scheduleOwner
        AddHandler scheduleOwner.Closed, AddressOf frmVisitClosed

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()

                End If
                _timer.Stop()
                _timer.Dispose()
            End If
        Catch ex As Exception

        End Try

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents lblPeriod As System.Windows.Forms.Label

    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dgSchedule As System.Windows.Forms.DataGrid
    Friend WithEvents lblFreePeriod As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblFreePeriod = New System.Windows.Forms.Label()
        Me.dgSchedule = New System.Windows.Forms.DataGrid()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPeriod
        '
        Me.lblPeriod.BackColor = System.Drawing.Color.SteelBlue
        Me.lblPeriod.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.ForeColor = System.Drawing.Color.White
        Me.lblPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPeriod.Location = New System.Drawing.Point(0, 0)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(550, 30)
        Me.lblPeriod.TabIndex = 1
        Me.lblPeriod.Text = "Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.lblFreePeriod)
        Me.pnlPeriod.Controls.Add(Me.dgSchedule)
        Me.pnlPeriod.Controls.Add(Me.lblPeriod)
        Me.pnlPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPeriod.Location = New System.Drawing.Point(0, 0)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(550, 112)
        Me.pnlPeriod.TabIndex = 2
        '
        'lblFreePeriod
        '
        Me.lblFreePeriod.BackColor = System.Drawing.Color.Transparent
        Me.lblFreePeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreePeriod.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFreePeriod.Location = New System.Drawing.Point(442, 111)
        Me.lblFreePeriod.Name = "lblFreePeriod"
        Me.lblFreePeriod.Size = New System.Drawing.Size(256, 42)
        Me.lblFreePeriod.TabIndex = 3
        Me.lblFreePeriod.Text = "Free Period"
        Me.lblFreePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFreePeriod.Visible = False
        '
        'dgSchedule
        '
        Me.dgSchedule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSchedule.ColumnHeadersVisible = False
        Me.dgSchedule.DataMember = ""
        Me.dgSchedule.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSchedule.Location = New System.Drawing.Point(16, 44)
        Me.dgSchedule.Name = "dgSchedule"
        Me.dgSchedule.RowHeadersVisible = False
        Me.dgSchedule.Size = New System.Drawing.Size(520, 57)
        Me.dgSchedule.TabIndex = 2
        '
        'frmDetailsPopup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(550, 112)
        Me.Controls.Add(Me.pnlPeriod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDetailsPopup"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDetailsPopup"
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ReadOnly Property shiftIsHeldDown() As Boolean
        Get
            If Control.ModifierKeys = Keys.Shift Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Private _CurrentPeriod As DateTime
    Public WithEvents _timer As New System.Windows.Forms.Timer()

#Region "Other Functions"

    Public Sub Timer_tick(myObject As Object, ByVal myEventArgs As EventArgs) Handles _timer.Tick
        Hide()
    End Sub

    Public Sub LoadInfo()

        Dim dtSchedule As DataTable = DB.Scheduler.Scheduler_PlannerPopUp(_CurrentPeriod, _scheduleOwner.EngineerID)
        dtSchedule.TableName = "Schedule"

        Dim dvSchedule As New DataView(dtSchedule)

        dvSchedule.AllowDelete = False
        dvSchedule.AllowEdit = False
        dvSchedule.AllowNew = False

        dgSchedule.DataSource = dvSchedule

        If lblPeriod.Height + 25 * dtSchedule.Rows.Count > 112 Then
            Height = lblPeriod.Height + 25 * dtSchedule.Rows.Count
        End If

        If dtSchedule.Rows.Count = 0 Then
            Height = 112
            lblFreePeriod.Visible = True
        Else
            lblFreePeriod.Visible = False
        End If
    End Sub

    Public Function GetPosition(ByVal handle As Integer) As Rectangle
        Dim rect As New Rectangle
        GetWindowRect(handle, rect)
        Return rect
    End Function

    Private Sub frmVisitClosed(ByVal sender As Object, ByVal e As System.EventArgs)
        _scheduleOwner = Nothing
    End Sub

    Private Sub SetUpDg()
        SetUpSchedulerDataGrid(dgSchedule, False)

        Dim tsSummary As DataGridTableStyle = dgSchedule.TableStyles(0)

        tsSummary.RowHeadersVisible = False
        tsSummary.ColumnHeadersVisible = False

        Dim type As New DataGridLabelColumn
        type.MappingName = "type"
        type.HeaderText = "type"
        type.ReadOnly = True
        type.Width = 55

        tsSummary.GridColumnStyles.Add(type)

        Dim subType As New DataGridLabelColumn
        subType.MappingName = "subType"
        subType.HeaderText = "subType"
        subType.ReadOnly = True
        subType.Width = 75

        tsSummary.GridColumnStyles.Add(subType)

        Dim startTime As New DataGridLabelColumn
        startTime.MappingName = "startTime"
        startTime.HeaderText = "Start"
        startTime.ReadOnly = True
        startTime.Alignment = HorizontalAlignment.Left
        startTime.Width = 40

        tsSummary.GridColumnStyles.Add(startTime)

        Dim endTime As New DataGridLabelColumn
        endTime.MappingName = "endTime"
        endTime.HeaderText = "End"
        endTime.ReadOnly = True
        endTime.Alignment = HorizontalAlignment.Left
        endTime.Width = 40

        tsSummary.GridColumnStyles.Add(endTime)

        Dim Comments As New DataGridLabelColumn
        Comments.MappingName = "Comments"
        Comments.HeaderText = "Comments"
        Comments.ReadOnly = True
        Comments.Alignment = HorizontalAlignment.Left
        Comments.Width = 300

        tsSummary.GridColumnStyles.Add(Comments)

        tsSummary.MappingName = "Schedule"

    End Sub

    Public Sub MoveMoved(ByVal ptLocat As System.Drawing.Point)
        'Exit Sub 'affects the second tab, after discussion with RobD discussed it was not necessary
        Dim activeForm As Form = Form.ActiveForm
        Dim activeControl As Control = If(activeForm IsNot Nothing, activeForm.ActiveControl, Nothing)
        If activeControl IsNot Nothing AndAlso activeControl.Name <> "frmEngineerSchedule" Then
            Hide()
            Exit Sub
        End If
        If Not _scheduleOwner Is Nothing AndAlso Not _scheduleOwner.IsDisposed = True Then
            If Not _scheduleOwner.TimeSlotDt Is Nothing Then
                For Each frm As Form In Application.OpenForms
                    If frm.Modal = True Then
                        Hide()
                        Exit Sub
                    End If
                Next

                Dim picPlannerPos As System.Drawing.Rectangle = GetPosition(_scheduleOwner.PicPlanner.Handle.ToInt64)
                Dim picPlannerLocation As New System.Drawing.Rectangle(picPlannerPos.X, picPlannerPos.Y, _scheduleOwner.PicPlanner.Width, _scheduleOwner.PicPlanner.Height)

                If picPlannerLocation.IntersectsWith(New Rectangle(ptLocat.X, ptLocat.Y, 1, 1)) Then

                    Dim parentHandle As Integer

                    If _scheduleOwner.Name.ToLower = "frmVisit".ToLower Then
                        Hide()
                        Exit Sub
                    End If
                    If _scheduleOwner.Name.ToLower = "frmVisit".ToLower Then
                        If shiftIsHeldDown Then
                            'FORCE IT NOT TO POP UP
                            parentHandle = _scheduleOwner.Handle.ToInt64 + 1
                        Else
                            'FORCE IT TO POP UP
                            parentHandle = _scheduleOwner.Handle.ToInt64
                        End If
                    ElseIf _scheduleOwner.Name.ToLower = "frmEngineerSchedule".ToLower Then
                        parentHandle = _scheduleOwner.Handle.ToInt64 'GetParent(WindowFromPoint(x, y))
                    Else
                        Exit Sub
                    End If

                    If parentHandle = Handle.ToInt64 Or parentHandle = _scheduleOwner.Handle.ToInt64 Or parentHandle = pnlPeriod.Handle.ToInt64 Then
                        Hide()
                        Show()
                        Dim slotWidth As Integer = CSng(_scheduleOwner.PicPlanner.Width - 9) / CSng(_scheduleOwner.TimeSlotDt.Columns.Count - 1)

                        Dim posInPlanner As Integer = Math.Abs(picPlannerLocation.X - ptLocat.X)

                        If Not CInt(posInPlanner \ slotWidth) = _scheduleOwner.TimeSlotDt.Columns.Count - 1 Then
                            Dim timeColumnFrom As String = _scheduleOwner.TimeSlotDt.Columns(CInt(posInPlanner \ slotWidth)).ColumnName()
                            timeColumnFrom = timeColumnFrom.Substring(1, 2) + ":" + timeColumnFrom.Substring(3, 2)

                            Dim timeColumnTo As String = _scheduleOwner.TimeSlotDt.Columns(CInt(posInPlanner \ slotWidth) + 1).ColumnName()
                            timeColumnTo = timeColumnTo.Substring(1, 2) + ":" + timeColumnTo.Substring(3, 2)
                            lblPeriod.Text = "Period: " + timeColumnFrom + " - " + timeColumnTo

                            Dim dateTimefrom As DateTime = New DateTime(CDate(_scheduleOwner.selectedDay).Year, CDate(_scheduleOwner.selectedDay).Month, CDate(_scheduleOwner.selectedDay).Day, CInt(timeColumnFrom.Substring(0, 2)), CInt(timeColumnFrom.Substring(3, 2)), 0)

                            If DateTime.Compare(_CurrentPeriod, dateTimefrom) <> 0 Then
                                _CurrentPeriod = dateTimefrom
                                LoadInfo()
                            End If
                        Else
                            Hide()
                        End If
                    Else
                        Hide()
                    End If
                Else
                    Hide()
                End If
            End If
        Else
        End If
    End Sub

#End Region

#Region "Mouse Hook"

    Declare Function WindowFromPoint Lib "user32" (ByVal xPoint As Integer, ByVal yPoint As Integer) As Integer

    Declare Function GetWindowRect Lib "user32" (ByVal hwnd As Integer, ByRef lpRect As System.Drawing.Rectangle) As Integer

    Declare Function GetParent Lib "user32" (ByVal hwnd As Integer) As Integer

#End Region

#Region "Window Fading"

    Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Boolean
    Declare Function BringWindowToTop Lib "user32" (ByVal hwnd As Integer) As Integer

    Private _fadeIn As Boolean
    Private _fadeThread As Threading.Thread

    Private Sub fade()

        If _fadeIn = True And Opacity = 0D Then
            _fadeThread.Sleep(250)
        End If

        While _fadeIn = True And Opacity <> 100D
            Opacity += 0.1D
            _fadeThread.Sleep(50)
        End While

        While _fadeIn = False And Opacity <> 0D
            Opacity -= 0.1D
            _fadeThread.Sleep(50)
        End While
    End Sub

    Public Shadows Sub Show()
        If Control.MousePosition.X < Screen.PrimaryScreen.WorkingArea.Width - Me.Width Then
            Location = New System.Drawing.Point(Control.MousePosition.X + 1, Control.MousePosition.Y + 1)
        Else
            Location = New System.Drawing.Point(Control.MousePosition.X - Me.Width - 1, Control.MousePosition.Y - 1)
        End If

        ShowWindow(Me.Handle, 4) 'SW_SHOWNOACTIVATE
        BringWindowToTop(Me.Handle.ToInt32)

        If _fadeThread Is Nothing OrElse _fadeThread.ThreadState = Threading.ThreadState.Stopped Then
            _fadeIn = True
            _fadeThread = New Threading.Thread(AddressOf fade)
            _fadeThread.Start()
        End If

    End Sub

    Public Shadows Sub Move()
        If Control.MousePosition.X < Screen.PrimaryScreen.WorkingArea.Width - Me.Width Then
            Location = New System.Drawing.Point(Control.MousePosition.X + 1, Control.MousePosition.Y + 1)
        Else
            Location = New System.Drawing.Point(Control.MousePosition.X - Me.Width - 1, Control.MousePosition.Y - 1)
        End If
    End Sub

    Public Shadows Sub Hide()
        If _fadeIn = True Then
            _fadeIn = False

            If _fadeThread Is Nothing OrElse _fadeThread.ThreadState = Threading.ThreadState.Stopped Then
                _fadeThread = New Threading.Thread(AddressOf fade)
                _fadeThread.Start()
            End If
        End If
    End Sub

#End Region

End Class