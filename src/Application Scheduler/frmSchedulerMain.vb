Option Strict Off

Public Class frmSchedulerMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CheckForIllegalCrossThreadCalls = False
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu

    Friend WithEvents mnuScheduler As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpenSchedule As System.Windows.Forms.MenuItem
    Friend WithEvents mnuResetScheduler As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCloseScheduler As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDividerScheduler As System.Windows.Forms.MenuItem
    Friend WithEvents mnuWeekSchedule As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrintWeek As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbsences As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchedulerMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuScheduler = New System.Windows.Forms.MenuItem()
        Me.mnuOpenSchedule = New System.Windows.Forms.MenuItem()
        Me.mnuResetScheduler = New System.Windows.Forms.MenuItem()
        Me.mnuDividerScheduler = New System.Windows.Forms.MenuItem()
        Me.mnuCloseScheduler = New System.Windows.Forms.MenuItem()
        Me.mnuAbsences = New System.Windows.Forms.MenuItem()
        Me.mnuWeekSchedule = New System.Windows.Forms.MenuItem()
        Me.mnuPrintWeek = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuScheduler, Me.mnuAbsences, Me.mnuWeekSchedule, Me.MenuItem2})
        '
        'mnuScheduler
        '
        Me.mnuScheduler.Index = 0
        Me.mnuScheduler.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOpenSchedule, Me.mnuResetScheduler, Me.mnuDividerScheduler, Me.mnuCloseScheduler})
        Me.mnuScheduler.Text = "&Scheduler"
        '
        'mnuOpenSchedule
        '
        Me.mnuOpenSchedule.Index = 0
        Me.mnuOpenSchedule.Shortcut = System.Windows.Forms.Shortcut.F2
        Me.mnuOpenSchedule.Text = "&Open"
        '
        'mnuResetScheduler
        '
        Me.mnuResetScheduler.Index = 1
        Me.mnuResetScheduler.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.mnuResetScheduler.Text = "&Reset"
        '
        'mnuDividerScheduler
        '
        Me.mnuDividerScheduler.Index = 2
        Me.mnuDividerScheduler.Text = "-"
        '
        'mnuCloseScheduler
        '
        Me.mnuCloseScheduler.Index = 3
        Me.mnuCloseScheduler.Text = "&Close"
        '
        'mnuAbsences
        '
        Me.mnuAbsences.Index = 1
        Me.mnuAbsences.Text = "&Absences"
        '
        'mnuWeekSchedule
        '
        Me.mnuWeekSchedule.Index = 2
        Me.mnuWeekSchedule.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPrintWeek, Me.MenuItem1})
        Me.mnuWeekSchedule.Text = "&Week Schedule"
        Me.mnuWeekSchedule.Visible = False
        '
        'mnuPrintWeek
        '
        Me.mnuPrintWeek.Index = 0
        Me.mnuPrintWeek.Text = "&Print"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "frmVisit"
        Me.MenuItem1.Visible = False
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "Development"
        Me.MenuItem2.Visible = False
        '
        'frmSchedulerMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(744, 371)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(752, 405)
        Me.Name = "frmSchedulerMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scheduler"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public scheduler As Scheduler
    'Private _fromDate As DateTime
    'Private _toDate As DateTime

    Public Event OnVScroll(ByVal position As Integer)

    Private Sub mnuOpenSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenSchedule.Click
        scheduler.Open()
    End Sub

    Private Sub frmSchedulerMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        scheduler = New Scheduler(Me)
        scheduler.Open()
    End Sub

    Private Sub mnuResetScheduler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetScheduler.Click
        scheduler.reset()
    End Sub

    Private Sub mnuCloseScheduler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseScheduler.Click
        scheduler.close()
        Me.Dispose()
    End Sub

    Private Sub mnuPrintWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintWeek.Click

    End Sub

    Private Sub mnuAbsences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbsences.Click
        Dim frm As New frmAbsences
        AddHandler frm.Closing, AddressOf FrmEngineerAbsenceClosing
        frm.ShowDialog()
    End Sub

    Private Sub FrmEngineerAbsenceClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        scheduler.refreshScheduler()
    End Sub

    Private Sub frmSchedulerMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        scheduler.close()
    End Sub

End Class