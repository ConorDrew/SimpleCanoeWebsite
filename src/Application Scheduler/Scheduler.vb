Option Strict Off

Imports System.Collections.Generic
Imports System.Runtime.Remoting.Messaging

'Imports FSM.Entity.EngineerTimeSheets

Public Class Scheduler

#Region "Variables"

    Private WithEvents _mdiParent As Form
    Private WithEvents _unscheduledCalls As pnlUnscheduledCalls
    Private WithEvents _mdiClient As MdiClient
    Private _engineerSchedules As New ArrayList
    Private _ScheduleControl As pnlScheduleControl
    Private _engineerScheduleColumnCount = 1
    Private _engineerScheduleHeight = 200
    Public FromDate As DateTime = Now
    Public ToDate As DateTime = Now.AddDays(10)
    Private _OldEngineerVisitID As Integer = 0
    Public DtSummary As DataTable
    Public textsize As Integer

#End Region

#Region "Sub Classes"

    Public Class scheduleComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim scheduleX As frmEngineerSchedule = CType(x, frmEngineerSchedule)
            Dim scheduleY As frmEngineerSchedule = CType(y, frmEngineerSchedule)

            If scheduleX.EngineerID < scheduleY.EngineerID Then
                Return -1
            ElseIf scheduleX.EngineerID = scheduleY.EngineerID Then
                Return 0
            ElseIf scheduleX.EngineerID > scheduleY.EngineerID Then
                Return 1
            End If

        End Function

    End Class

#End Region

    ''This function gets called when a row is dragged and dropped, forEngineer = 0 when it is dragged onto
    ''the unscheduled call grid
    ''Returns true to continue Scheduling row, or false to cancel
    Public Function scheduleRowManipulation(ByRef scheduleRow As DataRowView, ByVal forEngineer As Integer, ByVal forDate As DateTime, ByVal copy As Boolean, Optional ByRef appointment As Integer = 0) As Boolean
        Dim AMPMEngineerVisitID As Integer = scheduleRow.Item("EngineerVisitID")
        Dim [continue] As Boolean
        scheduleRow.BeginEdit()

        If copy = True Then
            _OldEngineerVisitID = scheduleRow.Item("EngineerVisitID")
            scheduleRow.Item("EngineerVisitID") = 0
        End If

        If forEngineer <> 0 Then
            Dim visitDialog As New frmVisit(forEngineer, forDate, Entity.Sys.Helper.MakeIntegerValid(scheduleRow("SummedSOR")), AMPMEngineerVisitID, copy)
            If visitDialog.ShowDialog() = DialogResult.OK Then
                [continue] = True
            Else
                [continue] = False
            End If
            'check if multiple visits were created
            If visitDialog.mulitpleVisits Then
                Dim index As Integer = 0

                'create the visits
                For Each item As List(Of DateTime) In visitDialog.VisitsList
                    'update the first visit like we used to
                    If index = 0 Then
                        scheduleRow.Item("StartDateTime") = item(0)
                        scheduleRow.Item("EndDateTime") = item(1)
                        index += 1
                    Else
                        'create new visit
                        Dim visit As New Entity.EngineerVisits.EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.SetJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(scheduleRow.Item("JobOfWorkID"))
                        visit.SetEngineerID = forEngineer
                        visit.StartDateTime = item(0)
                        visit.EndDateTime = item(1)
                        visit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                        visit.SetNotesToEngineer = scheduleRow.Item("NotesToEngineer")
                        visit.SetAppointmentID = visitDialog.AppointmentType
                        Dim jobId As Integer = Entity.Sys.Helper.MakeIntegerValid(scheduleRow.Item("JobID"))
                        visit = DB.EngineerVisits.Insert(visit, jobId, visitDialog.AppointmentType)
                    End If
                Next
            Else
                scheduleRow.Item("StartDateTime") = visitDialog.StartDate
                scheduleRow.Item("EndDateTime") = visitDialog.EndDate
            End If
            scheduleRow.Item("visitstatusid") = Entity.Sys.Enums.VisitStatus.Scheduled
            scheduleRow.Item("visitstatus") = "Scheduled"
            scheduleRow.Item("engineerID") = forEngineer
            scheduleRow.Item("AppointmentID") = visitDialog.AppointmentType

            appointment = visitDialog.AppointmentType
        Else
            scheduleRow.Item("visitstatusid") = Entity.Sys.Enums.VisitStatus.Ready_For_Schedule
            scheduleRow.Item("visitstatus") = "Ready For Schedule"
            scheduleRow.Item("engineerId") = 0
            scheduleRow.Item("StartDateTime") = DBNull.Value
            scheduleRow.Item("EndDateTime") = DBNull.Value
            [continue] = True
        End If
        scheduleRow.EndEdit()
        Return [continue]
    End Function

    'This function gets called when a row is dragged
    'Returns true to allow the drag, or false to cancel
    Public Function canMoveRow(ByRef scheduleRow As DataRowView, ByRef heartOk As Boolean) As Boolean
        If scheduleRow.Item("visitstatusid") = Entity.Sys.Enums.VisitStatus.Scheduled Or
         scheduleRow.Item("visitstatusid") = Entity.Sys.Enums.VisitStatus.Ready_For_Schedule Then
            Return True
        ElseIf scheduleRow.Item("visitstatusid") = Entity.Sys.Enums.VisitStatus.Downloaded Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "Properties"

    Private _engineers As DataTable = Nothing

    Public Property Engineers() As DataTable
        Get
            Return _engineers
        End Get
        Set(ByVal Value As DataTable)
            _engineers = Value
        End Set
    End Property

    Dim Closing As Boolean = False

    Dim TwoMins As New TimeSpan(0, 2, 0)

#End Region

#Region "functions"

    Public Sub New(ByVal mdiParent As Form)
        For Each ctl As Control In mdiParent.Controls
            If TypeOf ctl Is MdiClient Then
                _mdiClient = DirectCast(ctl, MdiClient)
                Exit For
            End If
        Next ctl

        _mdiParent = mdiParent
        LoadEngineers()
    End Sub

    Public Sub LoadEngineers()
        Dim dt As DataTable = DB.Engineer.Engineer_GetAll_Scheduler().Table
        Dim c As New DataColumn("Include", GetType(System.Boolean))
        c.DefaultValue = True
        dt.Columns.Add(c)
        dt.AcceptChanges()
        For Each r As DataRow In dt.Rows
            r("Include") = False
        Next
        Engineers = dt
    End Sub

    Public Class engineerSchedulerComparerByID
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim xEngineerSchedule As frmEngineerSchedule = CType(x, frmEngineerSchedule)

            Return CInt(xEngineerSchedule.EngineerID).CompareTo(y)

        End Function

    End Class

    Public Class engineerSchedulerComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim xEngineerSchedule As frmEngineerSchedule = CType(x, frmEngineerSchedule)
            Dim yEngineerSchedule As frmEngineerSchedule = CType(y, frmEngineerSchedule)

            Return CInt(xEngineerSchedule.EngineerID).CompareTo(CInt(yEngineerSchedule.EngineerID))

        End Function

    End Class

    Private Function CheckSchedulesAreOpening() As Boolean
        Dim b As Boolean = False
        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules
            If engineerSchedule.opening = True Then
                b = True
            End If
        Next
        Return b
    End Function

    Public Sub loadEngineerSchedules(ByVal dateFrom As Date, ByVal dateTo As Date)
        Try
            RemoveHandler _mdiClient.Resize, AddressOf ControlResize
            RemoveHandler _unscheduledCalls.Resize, AddressOf ControlResize

            FromDate = dateFrom
            ToDate = dateTo

            Cursor.Current = Cursors.WaitCursor
            _mdiClient.Enabled = False
            '_dtSummary = DB.Scheduler.Scheduler_GetWorkLoadForDaysAndEngineers(engineersString, datesString)
            Dim engineerScheduleWidth As Double

            Dim index As Integer = 0
            For Each engineer As DataRow In Engineers.Select("Include")
                Dim newWidth As Double = (_mdiClient.ClientSize.Width) \ _engineerScheduleColumnCount

                If newWidth <> engineerScheduleWidth Then
                    engineerScheduleWidth = (_mdiClient.ClientSize.Width) \ _engineerScheduleColumnCount

                    For Each schedule As frmEngineerSchedule In _engineerSchedules
                        schedule.Width = engineerScheduleWidth
                    Next
                End If

                index += 1

                Dim row As Integer = Math.Ceiling(index / _engineerScheduleColumnCount)
                Dim col As Integer = Math.Floor(index / row)

                Dim engineerSchedule As New frmEngineerSchedule(
                    AddressOf gridMouseDown, AddressOf gridMouseMove, AddressOf gridDragOver,
                    AddressOf gridDragDrop, AddressOf gridMouseUp, engineer, _ScheduleControl.textsize)

                AddHandler engineerSchedule.FormClosing, AddressOf ScheduleClosing

                engineerSchedule.StartPosition = FormStartPosition.Manual
                engineerSchedule.MdiParent = _mdiParent

                engineerSchedule.Left = (engineerScheduleWidth * (col - 1))
                engineerSchedule.Width = engineerScheduleWidth
                engineerSchedule.Top = _engineerScheduleHeight * (row - 1)
                engineerSchedule.Height = _engineerScheduleHeight
                engineerSchedule.Show()
                Application.DoEvents()

                Dim startDate As Date = dateFrom
                _engineerSchedules.Add(engineerSchedule)
            Next

            AddHandler _mdiClient.Resize, AddressOf ControlResize
            AddHandler _unscheduledCalls.Resize, AddressOf ControlResize
            _mdiClient.Enabled = True
            Cursor.Current = Cursors.Default

            refreshScheduler()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ScheduleClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        While CheckSchedulesAreOpening() = True Or refreshPeopleSchedulesAsyncResult.IsCompleted = False
            If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(100)
        End While

        '  Closing = True
        e.Cancel = True
        Dim engineerSchedule As frmEngineerSchedule = CType(sender, frmEngineerSchedule)
        engineerSchedule.Hide()
        _engineerSchedules.Remove(engineerSchedule)
        engineerSchedule.EngineerScheduleTimer.Stop()
        engineerSchedule.EngineerScheduleTimer.Dispose()
        engineerSchedule.Dispose()
        While engineerSchedule.opening = True
            If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(100)
        End While
        orderScheduleWindows()
    End Sub

    Public Sub reset()
        orderScheduleWindows()
        refreshPeopleSchedules()
        loadWork(_ScheduleControl.dateFrom, _ScheduleControl.dateTo)
    End Sub

    Public Sub close()
        While CheckSchedulesAreOpening() = True Or refreshPeopleSchedulesAsyncResult.IsCompleted = False
            If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(100)
        End While

        Closing = True

        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules
            engineerSchedule.Dispose()
        Next

        If Not _unscheduledCalls Is Nothing Then
            _unscheduledCalls.Hide()
            If Not _unscheduledCalls.unscheduledCalls Is Nothing Then
                _unscheduledCalls.unscheduledCalls.Clear()
            End If
        End If

        If Not _engineerSchedules Is Nothing Then
            _engineerSchedules.Clear()

        End If
        _mdiParent.Dispose()
    End Sub

    Public Sub ResizeSchedulingArea()
        _mdiParent.Controls.Remove(_unscheduledCalls)
        _mdiParent.Controls.Remove(_ScheduleControl)

        Closing = False

        Dim ts As Integer = 0
        If loggedInUser.SchedulerTextSize > 0 Then
            ts = loggedInUser.SchedulerTextSize
        Else
            ts = 8
        End If

        _unscheduledCalls = New pnlUnscheduledCalls(
            AddressOf gridMouseDown, AddressOf gridMouseMove, AddressOf gridDragOver,
            AddressOf gridDragDrop, AddressOf gridMouseUp, ts)
        _unscheduledCalls.Dock = DockStyle.Left
        _mdiParent.Controls.Add(_unscheduledCalls)

        _ScheduleControl.Dock = DockStyle.Top
        _mdiParent.Controls.Add(_ScheduleControl)

        LoadUnscheduledWork()

        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
            engineerSchedule.Close()
            engineerSchedule.Dispose()
        Next

        If Closing = False Then
            loadEngineerSchedules(_ScheduleControl.dateFrom, _ScheduleControl.dateTo)
        End If

        Application.DoEvents()
        If loggedInUser.SchedulerDayView Then
            _ScheduleControl.dateFrom = FromDate
            _ScheduleControl.dateTo = FromDate
            _ScheduleControl.btnBack.Visible = True
            _ScheduleControl.btnForward.Visible = True

            For Each dr As DataRow In Engineers.Rows
                If dr("EngineerGroupID") = loggedInUser.DefaultEngineerGroup Then dr("include") = 1
            Next

            If Not refreshPeopleSchedulesAsyncResult Is Nothing Then
                endSummaryRefresh = True
                While refreshPeopleSchedulesAsyncResult.IsCompleted = False
                    If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                    Application.DoEvents()
                End While
            End If

            If Not ScheduleDropIconsAsyncResult Is Nothing Then
                endDropIconsRefresh = True
                While ScheduleDropIconsAsyncResult.IsCompleted = False
                    If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                    Application.DoEvents()
                End While
            End If

            For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
                engineerSchedule.Close()
                engineerSchedule.Dispose()
            Next

            _mdiClient.ResumeLayout(False)
            _mdiClient.Visible = True
            _engineerSchedules.Clear()

            loadEngineerSchedules(FromDate, ToDate)

            Application.DoEvents()
            Cursor.Current = Cursors.Default
        Else
            _ScheduleControl.btnBack.Visible = False
            _ScheduleControl.btnForward.Visible = False
        End If
    End Sub

    Public Sub Open()
        Closing = False

        Dim ts As Integer = 0
        If loggedInUser.SchedulerTextSize > 0 Then
            ts = loggedInUser.SchedulerTextSize
        Else
            ts = 7
        End If

        If _unscheduledCalls Is Nothing Then
            _unscheduledCalls = New pnlUnscheduledCalls(
                AddressOf gridMouseDown, AddressOf gridMouseMove, AddressOf gridDragOver,
                AddressOf gridDragDrop, AddressOf gridMouseUp, ts)
            _unscheduledCalls.Dock = DockStyle.Left
            _mdiParent.Controls.Add(_unscheduledCalls)
        End If

        If _ScheduleControl Is Nothing Then
            _ScheduleControl = New pnlScheduleControl

            _ScheduleControl.dateFrom = FromDate
            _ScheduleControl.dateTo = ToDate

            AddHandler _ScheduleControl.dateRangeChanged, AddressOf loadWork
            AddHandler _ScheduleControl.refreshScheduler, AddressOf refreshScheduler
            AddHandler _ScheduleControl.closeScheduler, AddressOf close
            AddHandler _ScheduleControl.displayEngineers, AddressOf displayEngineers
            AddHandler _ScheduleControl.loadEngineerSchedules, AddressOf loadEngineerSchedules
            AddHandler _ScheduleControl.ResizeSchedulingArea, AddressOf ResizeSchedulingArea

            _ScheduleControl.Dock = DockStyle.Top
            _mdiParent.Controls.Add(_ScheduleControl)
        End If

        If Closing = False Then
            loadEngineerSchedules(_ScheduleControl.dateFrom, _ScheduleControl.dateTo)
        End If

        Application.DoEvents()

        If loggedInUser.SchedulerDayView Then
            _ScheduleControl.dateFrom = FromDate
            _ScheduleControl.dateTo = FromDate

            _ScheduleControl.btnBack.Visible = True
            _ScheduleControl.btnForward.Visible = True

            For Each dr As DataRow In Engineers.Rows
                If dr("EngineerGroupID") = loggedInUser.DefaultEngineerGroup Then dr("include") = 1
            Next

            If Not refreshPeopleSchedulesAsyncResult Is Nothing Then
                endSummaryRefresh = True
                While refreshPeopleSchedulesAsyncResult.IsCompleted = False
                    If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                    Application.DoEvents()
                End While
            End If

            If Not ScheduleDropIconsAsyncResult Is Nothing Then
                endDropIconsRefresh = True
                While ScheduleDropIconsAsyncResult.IsCompleted = False
                    If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                    Application.DoEvents()
                End While
            End If

            For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
                engineerSchedule.Close()
                engineerSchedule.Dispose()
            Next
            _mdiClient.ResumeLayout(False)
            _mdiClient.Visible = True
            _engineerSchedules.Clear()

            loadEngineerSchedules(FromDate, ToDate)

            Application.DoEvents()
            Cursor.Current = Cursors.Default
        Else
            _ScheduleControl.btnBack.Visible = False
            _ScheduleControl.btnForward.Visible = False
        End If
    End Sub

    Public Sub displayEngineers()
        Closing = False
        RemoveHandler _mdiClient.Resize, AddressOf ControlResize
        RemoveHandler _unscheduledCalls.Resize, AddressOf ControlResize

        Dim f As New FrmDisplayEngineers
        f.EngineersDataView = New DataView(Engineers)
        f.ShowDialog()
        _mdiClient.Visible = False
        _mdiClient.SuspendLayout()
        Cursor.Current = Cursors.WaitCursor

        If Not refreshPeopleSchedulesAsyncResult Is Nothing Then
            endSummaryRefresh = True
            While refreshPeopleSchedulesAsyncResult.IsCompleted = False
                If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                Application.DoEvents()
            End While
        End If

        If Not ScheduleDropIconsAsyncResult Is Nothing Then
            endDropIconsRefresh = True
            While ScheduleDropIconsAsyncResult.IsCompleted = False
                If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
                Application.DoEvents()
            End While
        End If

        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))

            engineerSchedule.Close()
            engineerSchedule.Dispose()

        Next

        _mdiClient.ResumeLayout(False)
        _mdiClient.Visible = True
        _engineerSchedules.Clear()

        loadEngineerSchedules(FromDate, ToDate)

        Application.DoEvents()
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub refreshScheduler()
        If Not _ScheduleControl Is Nothing Then
            loadWork(_ScheduleControl.dateFrom, _ScheduleControl.dateTo)
        End If
        LoadUnscheduledWork()
    End Sub

    Public Sub loadWork(ByVal fromDate As Date, ByVal toDate As Date)
        Me.FromDate = fromDate
        Me.ToDate = toDate
        refreshPeopleSchedules()
    End Sub

    Private Delegate Sub refreshPeopleSchedulesDelegate()

    Private endSummaryRefresh As Boolean
    Private refreshPeopleSchedulesAsyncResult As IAsyncResult

    Private Sub refreshPeopleSchedules()
        Cursor.Current = Cursors.WaitCursor

        Dim refreshPeople As New refreshPeopleSchedulesDelegate(AddressOf refreshPeopleSchedulesBegin)
        Dim refreshCallback As New AsyncCallback(AddressOf refreshPeopleScheulesComplete)

        If Not refreshPeopleSchedulesAsyncResult Is Nothing Then
            endSummaryRefresh = True

            While refreshPeopleSchedulesAsyncResult.IsCompleted = False
                Application.DoEvents()
                If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(30)
            End While
            endSummaryRefresh = False
        End If
        refreshPeopleSchedulesAsyncResult = refreshPeople.BeginInvoke(refreshCallback, Nothing)
    End Sub

    Private Sub refreshPeopleSchedulesBegin()
        Dim refreshed As New ArrayList

        Dim currentList As ArrayList = _engineerSchedules

        While refreshed.Count <> currentList.Count And endSummaryRefresh = False
            Try
                For Each engineerSchedule As frmEngineerSchedule In currentList
                    Dim refreshArea As New Rectangle(0, 0, _mdiClient.Width, _mdiClient.Height)
                    If Closing = False Then
                        engineerSchedule.Reset()
                        engineerSchedule.RefreshSummary(_ScheduleControl.dateFrom, _ScheduleControl.dateTo)
                        refreshed.Add(engineerSchedule.EngineerID)
                    End If

                Next
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
            Application.DoEvents()
            If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(75)
        End While
    End Sub

    Private Sub refreshPeopleScheulesComplete(ByVal ar As IAsyncResult)
        Cursor.Current = Cursors.Default
        Dim o_MyDelegate As refreshPeopleSchedulesDelegate =
           CType(CType(ar, AsyncResult).AsyncDelegate, refreshPeopleSchedulesDelegate)
        Try
            For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules
                engineerSchedule.Enabled = True
                engineerSchedule.opening = False
            Next
        Catch ex As Exception
            Dim msg As String = ex.Message
            If Not ex.InnerException Is Nothing Then
                msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
            End If
            LogError(ex.GetType().Name, msg, ex.StackTrace)
        End Try
        endSummaryRefresh = False
        o_MyDelegate.EndInvoke(ar)
    End Sub

    Private Delegate Function loadUnsheduledWorkDelegate() As DataTable

    Public Sub LoadUnscheduledWork()
        Dim loadWork As New loadUnsheduledWorkDelegate(AddressOf LoadUnsheduledWorkBegin)
        Dim loadWorkCallback As New AsyncCallback(AddressOf loadUnsheduledWorkEnd)
        loadWork.BeginInvoke(loadWorkCallback, Nothing)
    End Sub

    Public Function LoadUnsheduledWorkBegin() As DataTable
        Dim dtUnscheduledWork As New DataTable
        Dim viewAll As Boolean = _unscheduledCalls?.chkViewAll.Checked
        If viewAll Then
            viewAll = ShowMessage("Do you wish to continue?" & vbCrLf & vbCrLf & "Viewing all visits in the holding area can cause performance issues. " & vbCrLf & "Please only view all if you need to do so." & vbCrLf & "Thanks", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes
        End If
        dtUnscheduledWork = DB.Scheduler.GetUnscheduledVisits(viewAll)
        dtUnscheduledWork.TableName = "UnscheduledWork"
        Return dtUnscheduledWork
    End Function

    Public Sub loadUnsheduledWorkEnd(ByVal ar As IAsyncResult)
        Dim o_MyDelegate As loadUnsheduledWorkDelegate = CType(CType(ar, AsyncResult).AsyncDelegate, loadUnsheduledWorkDelegate)
        Try
            If Not Me._mdiParent.IsDisposed Then
                Me._mdiParent.Invoke(New setUnsheduledCallsDelegate(AddressOf SetUnsheduledCalls), o_MyDelegate.EndInvoke(ar))
            End If
        Catch

        End Try

    End Sub

    Private Delegate Sub setUnsheduledCallsDelegate(ByVal dtunscheduledCalls As DataTable)

    Private Sub SetUnsheduledCalls(ByVal dtunscheduledCalls As DataTable)
        _unscheduledCalls.unscheduledCalls = dtunscheduledCalls
        _unscheduledCalls.ApplyFilters()
    End Sub

    Public Function loadDay(ByVal EngineerID As String, ByVal [date] As Date) As DataTable
        Dim dtDay As New DataTable
        dtDay = DB.Scheduler.Get_ScheduledJobsDay([date], EngineerID)
        dtDay.TableName = Format([date], "dd/MM/yyyy").ToString
        Return dtDay
    End Function

#End Region

#Region "Drag and drop"

    Private Const radius As Integer = 3
    Private clickedPoint As Point
    Private cellDown As Boolean = False
    Dim mousePos As Point

    Public Class WorkTransport
        Public sourceDatarowView As DataRowView
        Public sourceDataGrid As DataGrid
        Public CanCopy As Boolean

        Public Sub New(ByVal clickedRowView As DataRowView, ByVal ClickedDatagrid As DataGrid, ByVal copy As Boolean)
            sourceDatarowView = clickedRowView
            sourceDataGrid = ClickedDatagrid
            CanCopy = copy
        End Sub

    End Class

    Public Sub gridMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender IsNot Nothing AndAlso e IsNot Nothing Then
            Try
                Dim currentDataGrid As DataGrid = CType(sender, DataGrid)
                Dim hitTestInfo As DataGrid.HitTestInfo = currentDataGrid.HitTest(e.X, e.Y)
                If hitTestInfo.Type = DataGrid.HitTestType.Cell Then
                    cellDown = True
                    clickedPoint = New Point(e.X, e.Y)
                Else
                    cellDown = False
                End If
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub gridMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender IsNot Nothing AndAlso e IsNot Nothing Then
            Try
                Application.DoEvents()

                Dim currentDataGrid As DataGrid = CType(sender, DataGrid)
                Dim hitTestInfo As DataGrid.HitTestInfo = currentDataGrid.HitTest(e.X, e.Y)
                Dim heartIs As Boolean

                If cellDown Then
                    If (Control.MouseButtons = MouseButtons.Left) And compareCoordinates(e.X, e.Y) And (hitTestInfo.Type = DataGrid.HitTestType.Cell) Then
                        'Initalise Drag drop
                        If clickedPoint <> Nothing Then
                            Dim clickHitTest As DataGrid.HitTestInfo = currentDataGrid.HitTest(clickedPoint.X, clickedPoint.Y)

                            If e.Button = MouseButtons.Left AndAlso clickHitTest IsNot Nothing Then
                                setScheduleDropIcons(CType(currentDataGrid.DataSource, DataView).Item(hitTestInfo.Row).Row)
                                Dim engineerSFrom As frmEngineerSchedule

                                If currentDataGrid.Parent.GetType Is GetType(frmEngineerSchedule) Then
                                    engineerSFrom = CType(currentDataGrid.Parent, frmEngineerSchedule)
                                Else
                                    heartIs = False
                                End If

                                Dim dvDataGrid As DataView = CType(currentDataGrid.DataSource, DataView)
                                Dim clickedRow As Integer = clickHitTest.Row
                                If clickedRow > (dvDataGrid.Count - 1) Then
                                    clickedRow = (dvDataGrid.Count - 1)
                                End If

                                If Control.ModifierKeys = Keys.Control Then
                                    currentDataGrid.DoDragDrop(New WorkTransport(dvDataGrid.Item(clickedRow), currentDataGrid, True), DragDropEffects.Copy)
                                ElseIf currentDataGrid.VisibleRowCount > 0 AndAlso (canMoveRow(dvDataGrid.Item(clickedRow), heartIs)) Then ' Index 0 is either negative or above rows count.
                                    currentDataGrid.DoDragDrop(New WorkTransport(dvDataGrid.Item(clickedRow), currentDataGrid, False), DragDropEffects.Move)
                                Else
                                    currentDataGrid.DoDragDrop(New Object, DragDropEffects.None)
                                End If
                                Application.DoEvents()
                            End If
                        End If
                    End If
                End If
                mousePos = New Point(e.X, e.Y)
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub gridDragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If sender IsNot Nothing AndAlso e IsNot Nothing Then
            Try
                If e.Data.GetDataPresent(GetType(WorkTransport)) = True Then
                    Dim dgTo As DataGrid = CType(sender, DataGrid)
                    Dim dgFrom As DataGrid = CType(e.Data.GetData(GetType(WorkTransport)), WorkTransport).sourceDataGrid

                    'Dragged Over Engineer schedule summary
                    If dgTo.Parent.GetType Is GetType(frmEngineerSchedule) Then
                        Dim engineerSchedule As frmEngineerSchedule = CType(dgTo.Parent, frmEngineerSchedule)
                        Dim ptc As Point = engineerSchedule.dgDaySummary.PointToClient(New Point(e.X, e.Y))

                        Dim hitTestInfo As DataGrid.HitTestInfo = engineerSchedule.dgDaySummary.HitTest(ptc.X, ptc.Y)

                        If CType(e.Data.GetData(GetType(WorkTransport)), WorkTransport).CanCopy = False Then
                            e.Effect = DragDropEffects.Move
                        Else
                            e.Effect = DragDropEffects.Copy
                        End If
                    Else
                        If CType(e.Data.GetData(GetType(WorkTransport)), WorkTransport).CanCopy = False Then
                            e.Effect = DragDropEffects.Move
                        Else
                            e.Effect = DragDropEffects.None
                        End If
                    End If
                End If
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
        End If
    End Sub

    Public Function CanMoveDownloadedVisit(ByVal engineerScheduleFrom As frmEngineerSchedule, ByVal EngineerVisitID As Integer, ByVal TabletActionID As Integer) As String
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.MoveDownloadedVisit) Then
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf & vbCrLf &
                "Contact your administrator if you think this is wrong or you need the permissions changing."
            Return msg
        End If

        Dim lastVisitID As Integer = 0
        Dim lastTimesheet As DataView = Nothing
        Dim lastTimesheetCheck As DateTime = Date.MinValue
        '   , ByVal startdatetime As DateTime)  /TODO

        If TabletActionID = 1 Then  'already marked to be removed
            Return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete"
        End If

        If engineerScheduleFrom.HeartLastCheck > Now.AddMinutes(-5) Then 'lets reduce the DB calls.
            'skip
        Else
            Dim Heart As Entity.HeartBeats.HeartBeat = DB.Scheduler.GetLatestHeartBeat(engineerScheduleFrom.EngineerID)
            engineerScheduleFrom.HeartLastCheck = Heart.LastCheck
            engineerScheduleFrom.LastHeartBeat = Heart.LastHeartBeat
            engineerScheduleFrom.LockedVisitId = Heart.LockedVisitID
        End If

        If engineerScheduleFrom.LastHeartBeat <= DateTime.MinValue Then
            Return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete"
        End If

        If engineerScheduleFrom.LastHeartBeat.AddMinutes(5) > DateTime.Now Then ' we are good to go '''  engineerScheduleFrom._lastHeartBeat <= DateTime.MinValue OrElse
            If engineerScheduleFrom.LockedVisitId = EngineerVisitID Then
                Return "The downloaded visit cannot be moved as the engineer currently has this visit open on his device"
            End If

            If Not lastTimesheet Is Nothing AndAlso lastVisitID = EngineerVisitID And lastTimesheetCheck > Now.AddMinutes(-1) Then ' and reduce the number of timesheet calls
                'skip
            Else
                lastTimesheet = DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID)
                lastTimesheetCheck = Now
            End If

            Dim mins As Integer = 0
            For Each row As DataRowView In lastTimesheet
                Dim start As DateTime = row("StartDateTime")
                Dim enddate As DateTime
                If IsDBNull(row("EndDateTime")) Then
                    enddate = DateTime.Now
                Else
                    enddate = row("EndDateTime")
                End If
                mins = DateDiff(DateInterval.Minute, start, enddate)
            Next

            If mins < 2 Then 'Only can be true if we have had signal from the tablet in the last 2 mins'
                Return String.Empty
            Else
                Return "The downloaded visit cannot be moved as the engineer has began traveling or working on this visit"

            End If
        Else
            Return "The downloaded visit cannot be moved as the device has not checked in recently"
        End If

    End Function

    Private Sub gridDragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If sender IsNot Nothing AndAlso e IsNot Nothing Then
            Try
                If e.Data.GetDataPresent(GetType(WorkTransport)) = True Then
                    Dim dgTo As DataGrid = CType(sender, DataGrid)
                    Dim workTransport As WorkTransport = CType(e.Data.GetData(GetType(WorkTransport)), WorkTransport)
                    If workTransport Is Nothing Then Exit Sub
                    Dim dgFrom As DataGrid = workTransport.sourceDataGrid
                    Dim dropOverRow As DataRowView = Nothing

                    Dim JobLock As Entity.JobLock.JobLock = DB.JobLock.Check(workTransport.sourceDatarowView.Item("JobID"))
                    Dim TabletActionID As Integer = DB.EngineerVisits.EngineerVisit_GetActionID(workTransport.sourceDatarowView.Item("EngineerVisitID"))

                    If Not JobLock Is Nothing Then
                        Dim message As String = "This job cannot be scheduled because is it currently locked:" + vbCrLf
                        message += String.Format("Locked by: {0}", JobLock.NameOfUserWhoLocked) + vbCrLf
                        message += String.Format("Date Locked: {0}", JobLock.DateLock) + vbCrLf
                        MessageBox.Show(message, "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If Not dgTo Is dgFrom Then

                        'Physically Move Datarowview to Target datagrid
                        Dim dvTo As DataView = Nothing
                        Dim engineerScheduleTo As frmEngineerSchedule = Nothing
                        Dim engineerScheduleFrom As frmEngineerSchedule = Nothing

                        If dgFrom.Parent.GetType Is GetType(frmEngineerSchedule) Then
                            engineerScheduleFrom = CType(dgFrom.Parent, frmEngineerSchedule)
                        End If

                        'Dragged Over Engineer schedule summary
                        If dgTo.Parent.GetType Is GetType(frmEngineerSchedule) Then

                            engineerScheduleTo = CType(dgTo.Parent, frmEngineerSchedule)

                            engineerScheduleTo.CurrentDate = Nothing

                            Dim ptc As Point = engineerScheduleTo.dgDaySummary.PointToClient(New Point(e.X, e.Y))
                            Dim hitTestInfo As DataGrid.HitTestInfo = engineerScheduleTo.dgDaySummary.HitTest(ptc.X, ptc.Y)

                            If hitTestInfo.Type = DataGrid.HitTestType.Cell Then
                                dropOverRow = CType(engineerScheduleTo.dgDaySummary.DataSource, DataView)(hitTestInfo.Row)

                                If dropOverRow IsNot Nothing Then
                                    engineerScheduleTo.CurrentDate = dropOverRow.Item("dayDate")

                                    dvTo = New DataView(engineerScheduleTo.GetDay(dropOverRow.Item("dayDate")))

                                    For rowindex As Integer = 0 To CType(engineerScheduleTo.dgDaySummary.DataSource, DataView).Table.Rows.Count - 1
                                        engineerScheduleTo.dgDaySummary.UnSelect(rowindex)
                                    Next
                                End If

                                engineerScheduleTo.dgDaySummary.Select(hitTestInfo.Row)
                                engineerScheduleTo.RefreshSummary(FromDate, ToDate)

                            End If
                        Else
                            dvTo = CType(dgTo.DataSource, DataView)
                        End If

                        If dvTo Is Nothing Then Exit Sub
                        Dim newVisitRowView As DataRowView = dvTo.AddNew

                        For Each column As DataColumn In workTransport.sourceDatarowView.Row.Table.Columns
                            Try
                                If Not newVisitRowView.Row.Table.Columns(column.ColumnName) Is Nothing Then

                                    If newVisitRowView.Row.Table.Columns(column.ColumnName).DataType Is workTransport.sourceDatarowView.Row.Table.Columns(column.ColumnName).DataType Then
                                        newVisitRowView.Item(column.ColumnName) = workTransport.sourceDatarowView.Item(column.ColumnName)
                                    End If
                                End If
                            Catch
                            End Try
                        Next

                        Dim [continue] As Boolean = True

                        Dim newVisitForCheck As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(newVisitRowView.Row("EngineerVisitID"))
                        Dim jobOfWorkStatusID As Integer = DB.JobOfWorks.JobOfWork_Get(newVisitForCheck.JobOfWorkID).Status

                        Dim errorMsg As String = String.Empty
                        If dgFrom.Parent.GetType Is GetType(frmEngineerSchedule) And newVisitForCheck.StatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Downloaded) And Not workTransport.CanCopy Then
                            errorMsg = CanMoveDownloadedVisit(engineerScheduleFrom, newVisitRowView.Row("EngineerVisitID"), TabletActionID)
                            [continue] = String.IsNullOrEmpty(errorMsg)
                            If Not [continue] Then ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        If [continue] Then
                            If Not engineerScheduleTo Is Nothing Then
                                If Now.Subtract(newVisitForCheck.Downloading) < TwoMins And workTransport.CanCopy = False Then
                                    ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Complete And workTransport.CanCopy = True Then
                                    ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                    jobOfWorkStatusID = 0
                                ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Closed And workTransport.CanCopy = True Then
                                    ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                    jobOfWorkStatusID = 0
                                Else
                                    If engineerScheduleTo.TestAcceptance(newVisitRowView.Row) = False Then
                                        [continue] = engineerScheduleTo.GetAcceptance(newVisitRowView.Row, workTransport.CanCopy)
                                    Else
                                        [continue] = True
                                    End If
                                End If
                            Else
                                If Now.Subtract(newVisitForCheck.Downloading) < TwoMins And workTransport.CanCopy = False Then
                                    ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Complete And workTransport.CanCopy = True Then
                                    ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                    jobOfWorkStatusID = 0
                                ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Closed And workTransport.CanCopy = True Then
                                    ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    [continue] = False
                                    jobOfWorkStatusID = 0
                                End If
                            End If
                        End If

                        ''Check for where the part is

                        If [continue] = True And Not engineerScheduleTo Is Nothing AndAlso Not engineerScheduleTo.EngineerID = 221 AndAlso Not engineerScheduleTo.EngineerID = 320 AndAlso Not engineerScheduleTo.EngineerID = 314 AndAlso Not engineerScheduleTo.EngineerID = 215 AndAlso Not engineerScheduleTo.EngineerID = 378 AndAlso Not engineerScheduleTo.EngineerID = 386 Then

                            Dim Lastengineer As DataTable = DB.ExecuteWithReturn("select ISNULL(op.ReceivedEngineerID,0) as ReceivedEngineerID,op.OrderID,pa.Quantity, pa.OrderPartID ,e.name as eng, P.Name, p.Number from tblOrderPart op inner join tblEngineerVisitPartAllocated pa ON pa.OrderPartID = op.OrderPartID INNER JOIN tblPart P ON p.PartID = pa.PArtID INNER JOIN tblengineer E ON e.EngineerID = op.ReceivedEngineerID where engineervisitid = " & newVisitForCheck.EngineerVisitID)

                            If Lastengineer Is Nothing OrElse Lastengineer.Rows.Count = 0 OrElse Lastengineer.Rows(0)("ReceivedEngineerID") = engineerScheduleTo.EngineerID OrElse _OldEngineerVisitID > 0 Then

                                'do nothing
                            Else

                                ShowMessage("This Visit has parts attached which have already been picked up by different engineer, only coordinators and above can action this", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Coordinator) Then

                                    For Each d As DataRow In Lastengineer.Rows

                                        DB.ExecuteScalar("DELETE FROM tblAltReturn WHERE OrderPartID = " & d("OrderPartID"))

                                    Next

                                    Dim drs() As DataRow = Lastengineer.Select("ReceivedEngineerID <> 0 AND ReceivedEngineerID <> " & engineerScheduleTo.EngineerID)

                                    If drs.Length = 0 Then

                                        If Lastengineer.Rows(0)("ReceivedEngineerID") = engineerScheduleTo.EngineerID Then

                                            Dim issue As Boolean = False

                                            For Each d As DataRow In Lastengineer.Rows

                                                Dim count As Integer = DB.ExecuteScalar("Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = " & d("OrderPartID"))

                                                If count > 0 Then

                                                    ' Credits have been recieved
                                                    issue = True
                                                    Exit For
                                                Else

                                                End If

                                            Next

                                            If issue = False Then

                                                For Each d As DataRow In Lastengineer.Rows

                                                    DB.ExecuteScalar("Delete From tblPartstobeCredited where OrderPartID = " & d("OrderPartID"))
                                                    DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = " & d("OrderPartID"))

                                                Next

                                            End If

                                        End If

                                        'do nothing
                                    Else

                                        '  Start the choice pick up from Location/ return to supplier and start new pickup *owch* /

                                        Dim s As String = ""
                                        For Each d As DataRow In drs
                                            s += d("Name") & "(" & d("Number") & "), "
                                        Next

                                        Dim f As New FRMItemReturn
                                        f.TextBox1.Text = "This visit contains the parts " & s & " - which have been picked up by " & drs(0)("eng") & ". Please select what action to take."

                                        f.ShowDialog()
                                        Dim out As Integer = Combo.GetSelectedItemValue(f.cboJobType)
                                        Dim location As String = f.TextBox2.Text

                                        Select Case out

                                            Case 0

                                                [continue] = False

                                            Case 1
                                                If ShowMessage("Beware! actioning this return is not reversable, the parts will be marked to be returned to supplier , do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                                                    For Each d As DataRow In drs

                                                        Dim counts As Integer = DB.ExecuteScalar("SELECT COUNT(*) From tblPartsToBeCredited where OrderPArtID = " & d("OrderPartID"))
                                                        If counts = 0 Then

                                                            Dim PartsToBeCreditedID As Integer = 0

                                                            Dim orderdt As DataTable = DB.ExecuteWithReturn("SELECT tblPartSupplier.PartID, tblOrder.OrderReference, " &
                                                       "CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.SupplierID ELSE tblOrderPart.ChildSupplierID END AS SupplierID," &
                                                       "CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.Name ELSE (SELECT Name FROM tblsupplier AS a WHERE supplierID = tblOrderPart.ChildSupplierID) END AS SupplierName " &
                                                       "FROM tblOrderPart LEFT OUTER JOIN tblPartSupplier ON tblOrderPart.PartSupplierID = tblPartSupplier.PartSupplierID " &
                                                       "LEFT OUTER JOIN tblSupplier ON tblSupplier.SupplierID = tblPartSupplier.SupplierID " &
                                                       "INNER JOIN tblOrder ON tblOrderPart.OrderID = tblOrder.OrderID WHERE (tblOrderPart.OrderPartID = " & d("OrderPartID") & ")")

                                                            PartsToBeCreditedID = DB.PartsToBeCredited.PartsToBeCredited_Insert(orderdt.Rows(0).Item("SupplierID"), d("OrderID"), orderdt.Rows(0).Item("PartID"), CInt(d("Quantity")), orderdt.Rows(0).Item("OrderReference"), CInt(d("ReceivedEngineerID")), d("OrderPartID"))

                                                            DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 1, CreditQty = " & CInt(d("Quantity")) & " WHERE ORDERPARTID = " & d("OrderPartID"))
                                                        Else
                                                        End If
                                                    Next

                                                End If
                                            Case 2
                                                For Each d As DataRow In drs

                                                    Dim count As Integer = DB.ExecuteScalar("Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = " & d("OrderPartID"))

                                                    If count > 0 Then

                                                        ShowMessage("One or more of the parts have been returned to the supplier already, you can not have these picked up form a location", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        [continue] = False
                                                        Exit For
                                                    Else

                                                    End If

                                                Next

                                                If [continue] = True Then

                                                    For Each d As DataRow In drs

                                                        DB.ExecuteScalar("Delete From tblPartstobeCredited where OrderPartID = " & d("OrderPartID"))
                                                        DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0 ,CreditQty = 0 WHERE ORDERPARTID = " & d("OrderPartID"))

                                                        DB.ExecuteScalar("Insert INTO tblAltReturn (OrderPartID,Location,ReturningEng,CollectingEng) VALUES(" & d("OrderPartID") & ",'" & location & "'," & d("ReceivedEngineerID") & "," & engineerScheduleTo.EngineerID & ")")

                                                    Next

                                                End If

                                        End Select

                                    End If
                                Else ' override password fail

                                    [continue] = False

                                End If

                            End If

                        End If

                        Dim appointment As Integer = 0
                        If [continue] Then
                            If Not engineerScheduleTo Is Nothing Then
                                [continue] = scheduleRowManipulation(newVisitRowView, engineerScheduleTo.EngineerID, dropOverRow("dayDate"), workTransport.CanCopy, appointment)
                            Else
                                [continue] = scheduleRowManipulation(newVisitRowView, 0, DateTime.MinValue, workTransport.CanCopy, appointment)
                            End If
                        End If

                        If [continue] Then
                            newVisitForCheck = DB.EngineerVisits.EngineerVisits_Get_As_Object(newVisitRowView.Row("EngineerVisitID"))
                            If dgFrom.Parent.GetType Is GetType(frmEngineerSchedule) And newVisitForCheck?.StatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Downloaded) And Not workTransport.CanCopy Then
                                errorMsg = CanMoveDownloadedVisit(engineerScheduleFrom, newVisitRowView.Row("EngineerVisitID"), TabletActionID)
                                [continue] = String.IsNullOrEmpty(errorMsg)
                                If Not [continue] Then ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                        If Not newVisitForCheck Is Nothing And [continue] Then
                            If Now.Subtract(newVisitForCheck.Downloading) < TwoMins And workTransport.CanCopy = False Then
                                ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                [continue] = False
                            ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Complete And workTransport.CanCopy = True Then
                                ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                [continue] = False
                                jobOfWorkStatusID = 0
                            ElseIf jobOfWorkStatusID = Entity.Sys.Enums.JobOfWorkStatus.Closed And workTransport.CanCopy = True Then
                                ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                [continue] = False
                                jobOfWorkStatusID = 0
                            End If
                        End If

                        If [continue] = True Then
                            If workTransport.CanCopy = False Then
                                e.Effect = DragDropEffects.Move
                                workTransport.sourceDatarowView.Delete()

                            ElseIf Not engineerScheduleTo Is Nothing Then
                                e.Effect = DragDropEffects.Copy
                            End If

                            If Not engineerScheduleTo Is Nothing Then
                                DB.Scheduler.ScheduleVisit(newVisitRowView.Row, _OldEngineerVisitID, appointment)
                                _OldEngineerVisitID = 0
                            Else
                                DB.Scheduler.unscheduleVisit(newVisitRowView.Row)
                            End If

                            Application.DoEvents()

                            If Not engineerScheduleTo Is Nothing Then
                                engineerScheduleTo.RefreshSummary(FromDate, ToDate)
                                dvTo.Table.AcceptChanges()
                            Else
                                If dvTo.Table.Select("JobOfWorkID=" & CStr(newVisitRowView("JobOfWorkID"))).Length <= 1 Then
                                    dvTo.Table.AcceptChanges()
                                Else
                                    dvTo.Table.RejectChanges()
                                End If
                            End If

                            If Not engineerScheduleFrom Is Nothing Then
                                engineerScheduleFrom.RefreshSummary(FromDate, ToDate)
                            Else
                                _unscheduledCalls.setOverdueLabel()
                            End If
                        Else
                            dvTo.Table.RejectChanges()
                            e.Effect = DragDropEffects.None
                        End If
                    Else
                        setScheduleDropIcons(Nothing)
                    End If

                    CType(dgFrom.DataSource, DataView).Table.AcceptChanges()
                    CType(dgTo.DataSource, DataView).Table.AcceptChanges()

                End If

                resetHeaders()
                clearSelections()
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub gridMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender IsNot Nothing AndAlso e IsNot Nothing Then
            Try
                Dim dgGrid As DataGrid = CType(sender, DataGrid)
                Dim hitTest As System.Windows.Forms.DataGrid.HitTestInfo = dgGrid.HitTest(e.X, e.Y)

                If hitTest.Type = DataGrid.HitTestType.Cell AndAlso hitTest.Row > -1 Then
                    clearSelections()
                    setScheduleDropIcons(CType(dgGrid.DataSource, DataView).Item(hitTest.Row).Row)
                    dgGrid.CurrentRowIndex = hitTest.Row
                    dgGrid.Select(hitTest.Row)
                End If
            Catch ex As Exception
                Dim msg As String = ex.Message
                If Not ex.InnerException Is Nothing Then
                    msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
                End If
                LogError(ex.GetType().Name, msg, ex.StackTrace)
            End Try
        End If
    End Sub

    'Return true if the co-ords are greater than 10 from the first co-ords
    Private Function compareCoordinates(ByVal x2 As Integer, ByVal y2 As Integer) As Boolean
        If Math.Abs((x2 - clickedPoint.X)) > radius OrElse
        Math.Abs((y2 - clickedPoint.Y)) > radius Then
            Return True
        End If
        Return False
    End Function

#End Region

#Region "Engineer Schedule - Group GUI Changes"

    Private Sub resetHeaders()
        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
            engineerSchedule.ResetHeader()
        Next
    End Sub

    Private Delegate Sub setScheduleDropIconsDelegate(ByVal draggedRow As DataRow)

    Private scheduleDropIcons As setScheduleDropIconsDelegate = New setScheduleDropIconsDelegate(AddressOf SetScheduleDropIconsBegin)

    Private ScheduleDropIconsAsyncResult As IAsyncResult
    Private endDropIconsRefresh As Boolean

    Private Sub setScheduleDropIcons(ByVal draggedRow As DataRow)

        Dim scheduleDropIcons As setScheduleDropIconsDelegate = New setScheduleDropIconsDelegate(AddressOf SetScheduleDropIconsBegin)
        Dim scheduleDropIconsComplete As AsyncCallback = New AsyncCallback(AddressOf SetScheduleDropIconsComplete)

        If Not ScheduleDropIconsAsyncResult Is Nothing Then
            endDropIconsRefresh = True

            While Not ScheduleDropIconsAsyncResult Is Nothing AndAlso ScheduleDropIconsAsyncResult.IsCompleted = False
                Application.DoEvents()
                If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(20)
            End While

            endDropIconsRefresh = False
        End If

        ScheduleDropIconsAsyncResult = scheduleDropIcons.BeginInvoke(draggedRow, scheduleDropIconsComplete, Nothing)
    End Sub

    Private Sub SetScheduleDropIconsBegin(ByVal draggedRow As DataRow)
        Dim refreshed As New ArrayList
        While refreshed.Count <> _engineerSchedules.Count And endDropIconsRefresh = False
            For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
                Dim refreshArea As New Rectangle(0, 0, _mdiClient.Width, _mdiClient.Height)
                If Not refreshed.Contains(engineerSchedule.EngineerID) AndAlso refreshArea.IntersectsWith(engineerSchedule.Bounds) Then
                    engineerSchedule.CurrentDate = Nothing
                    engineerSchedule.RefreshAcceptance(draggedRow)
                    refreshed.Add(engineerSchedule.EngineerID)
                End If
            Next
            Application.DoEvents()
            If refreshed.Count <> _engineerSchedules.Count And endDropIconsRefresh = False Then
                If Not loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(50)
            End If
        End While
    End Sub

    Private Sub SetScheduleDropIconsComplete(ByVal ar As IAsyncResult)
        Dim o_MyDelegate As setScheduleDropIconsDelegate =
        CType(CType(ar, AsyncResult).AsyncDelegate, setScheduleDropIconsDelegate)

        endDropIconsRefresh = False
        o_MyDelegate.EndInvoke(ar)
    End Sub

    Private Sub clearSelections()
        _unscheduledCalls.clearSelections()
        For Each engineerSchedule As frmEngineerSchedule In _engineerSchedules.ToArray(GetType(frmEngineerSchedule))
            engineerSchedule.ClearSelections()
        Next
    End Sub

#End Region

#Region "Resize and postioning"

    Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs)
        orderScheduleWindows()
    End Sub

    Private Sub orderScheduleWindows()
        RemoveHandler _mdiClient.Resize, AddressOf ControlResize
        RemoveHandler _unscheduledCalls.Resize, AddressOf ControlResize

        Dim engineerScheduleWidth As Double
        engineerScheduleWidth = (_mdiClient.ClientSize.Width) \ _engineerScheduleColumnCount

        For index As Integer = 1 To _engineerSchedules.Count
            Dim newWidth As Double = (_mdiClient.ClientSize.Width) \ _engineerScheduleColumnCount
            If newWidth <> engineerScheduleWidth Then
                engineerScheduleWidth = (_mdiClient.ClientSize.Width) \ _engineerScheduleColumnCount

                For Each schedule As frmEngineerSchedule In _engineerSchedules
                    schedule.Width = engineerScheduleWidth
                Next
            End If

            Dim row As Integer = Math.Ceiling(index / _engineerScheduleColumnCount)
            Dim col As Integer = Math.Floor(index / row)

            Dim peopleSchedule As frmEngineerSchedule = _engineerSchedules(index - 1)
            peopleSchedule.Left = (engineerScheduleWidth * (col - 1))
            peopleSchedule.Width = engineerScheduleWidth
            peopleSchedule.Top = _engineerScheduleHeight * (row - 1)
            peopleSchedule.Height = _engineerScheduleHeight
        Next

        AddHandler _mdiClient.Resize, AddressOf ControlResize
        AddHandler _unscheduledCalls.Resize, AddressOf ControlResize
        Application.DoEvents()
    End Sub

#End Region

End Class