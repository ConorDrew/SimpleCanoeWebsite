Option Strict Off

Imports System.Runtime.Remoting.Messaging
Imports FSM.Entity.ContactAttempts
Imports FSM.Entity.Sys

Public Class frmEngineerSchedule
    Inherits System.Windows.Forms.Form
    Implements ISchedulerForm

    Friend WithEvents btnPrintLsr As MenuItem
    Friend WithEvents btnReschedule As MenuItem
    Friend WithEvents btnCreateJob As MenuItem
    Friend WithEvents btnSiteReport As MenuItem
    Friend WithEvents ttStatus As ToolTip
    Friend WithEvents pbInfomation As PictureBox
    Friend WithEvents btnTextMessage As MenuItem
    Friend WithEvents MenuItem1 As MenuItem
    Friend WithEvents btnServiceLetter As MenuItem
    Friend WithEvents btnSolarInstallation As MenuItem
    Friend WithEvents btnElectricalAppointment As MenuItem
    Private TEXTSIZE As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal gridMouseDown As System.Windows.Forms.MouseEventHandler,
                   ByVal gridMouseMove As System.Windows.Forms.MouseEventHandler,
                   ByVal gridDragOver As System.Windows.Forms.DragEventHandler,
                   ByVal gridDragDrop As System.Windows.Forms.DragEventHandler,
                   ByVal gridMouseUp As System.Windows.Forms.MouseEventHandler,
                   ByVal Engineer As DataRow, ByVal textsizes As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AddHandler dgDay.MouseDown, gridMouseDown
        AddHandler dgDay.MouseMove, gridMouseMove
        AddHandler dgDaySummary.DragOver, gridDragOver
        AddHandler dgDaySummary.DragDrop, gridDragDrop
        AddHandler dgDay.MouseUp, gridMouseUp

        Me._engineerID = Engineer.Item("EngineerID")
        Me._engineer = Engineer
        Me.TEXTSIZE = textsizes

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

            detailPopup.Dispose()

            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        Catch ex As Exception

        End Try

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents splitEngineer As System.Windows.Forms.Splitter
    Friend WithEvents dgDaySummary As System.Windows.Forms.DataGrid
    Friend WithEvents imgLstIcons As System.Windows.Forms.ImageList
    Friend WithEvents mnuVisitAction As System.Windows.Forms.ContextMenu
    Friend WithEvents btnSendText As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDayAction As ContextMenu
    Friend WithEvents btnExportJobs As MenuItem
    Friend WithEvents picPlanner As System.Windows.Forms.PictureBox
    Friend WithEvents dgDay As System.Windows.Forms.DataGrid
    Friend WithEvents picRegion As System.Windows.Forms.PictureBox
    Friend WithEvents picPostalRegions As System.Windows.Forms.PictureBox
    Friend WithEvents picVan As System.Windows.Forms.PictureBox
    Friend WithEvents picQuestion As System.Windows.Forms.PictureBox
    Friend WithEvents picSpanner As System.Windows.Forms.PictureBox
    Friend WithEvents pbRed As System.Windows.Forms.PictureBox
    Friend WithEvents pbGreen As System.Windows.Forms.PictureBox
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents picLevels As System.Windows.Forms.PictureBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEngineerSchedule))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.pbGreen = New System.Windows.Forms.PictureBox()
        Me.pbRed = New System.Windows.Forms.PictureBox()
        Me.picVan = New System.Windows.Forms.PictureBox()
        Me.picQuestion = New System.Windows.Forms.PictureBox()
        Me.picSpanner = New System.Windows.Forms.PictureBox()
        Me.picLevels = New System.Windows.Forms.PictureBox()
        Me.picPostalRegions = New System.Windows.Forms.PictureBox()
        Me.picRegion = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbInfomation = New System.Windows.Forms.PictureBox()
        Me.dgDaySummary = New System.Windows.Forms.DataGrid()
        Me.mnuDayAction = New System.Windows.Forms.ContextMenu()
        Me.btnCreateJob = New System.Windows.Forms.MenuItem()
        Me.btnExportJobs = New System.Windows.Forms.MenuItem()
        Me.splitEngineer = New System.Windows.Forms.Splitter()
        Me.mnuVisitAction = New System.Windows.Forms.ContextMenu()
        Me.btnSendText = New System.Windows.Forms.MenuItem()
        Me.btnReschedule = New System.Windows.Forms.MenuItem()
        Me.btnTextMessage = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnSiteReport = New System.Windows.Forms.MenuItem()
        Me.btnPrintLsr = New System.Windows.Forms.MenuItem()
        Me.btnServiceLetter = New System.Windows.Forms.MenuItem()
        Me.btnSolarInstallation = New System.Windows.Forms.MenuItem()
        Me.btnElectricalAppointment = New System.Windows.Forms.MenuItem()
        Me.imgLstIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.dgDay = New System.Windows.Forms.DataGrid()
        Me.picPlanner = New System.Windows.Forms.PictureBox()
        Me.ttStatus = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpanner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPostalRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRegion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInfomation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDaySummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlHeader.Controls.Add(Me.pbClose)
        Me.pnlHeader.Controls.Add(Me.pbGreen)
        Me.pnlHeader.Controls.Add(Me.pbRed)
        Me.pnlHeader.Controls.Add(Me.picVan)
        Me.pnlHeader.Controls.Add(Me.picQuestion)
        Me.pnlHeader.Controls.Add(Me.picSpanner)
        Me.pnlHeader.Controls.Add(Me.picLevels)
        Me.pnlHeader.Controls.Add(Me.picPostalRegions)
        Me.pnlHeader.Controls.Add(Me.picRegion)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.pbInfomation)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(432, 18)
        Me.pnlHeader.TabIndex = 1
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.Transparent
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = Global.FSM.My.Resources.Resources.delete
        Me.pbClose.Location = New System.Drawing.Point(410, 1)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(19, 17)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 9
        Me.pbClose.TabStop = False
        '
        'pbGreen
        '
        Me.pbGreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbGreen.BackColor = System.Drawing.Color.Transparent
        Me.pbGreen.Image = Global.FSM.My.Resources.Resources.green_light
        Me.pbGreen.Location = New System.Drawing.Point(358, 1)
        Me.pbGreen.Name = "pbGreen"
        Me.pbGreen.Size = New System.Drawing.Size(19, 17)
        Me.pbGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGreen.TabIndex = 8
        Me.pbGreen.TabStop = False
        Me.pbGreen.Visible = False
        '
        'pbRed
        '
        Me.pbRed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRed.BackColor = System.Drawing.Color.Transparent
        Me.pbRed.Image = Global.FSM.My.Resources.Resources.red_light
        Me.pbRed.Location = New System.Drawing.Point(358, 1)
        Me.pbRed.Name = "pbRed"
        Me.pbRed.Size = New System.Drawing.Size(19, 17)
        Me.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRed.TabIndex = 7
        Me.pbRed.TabStop = False
        Me.pbRed.Visible = False
        '
        'picVan
        '
        Me.picVan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picVan.BackColor = System.Drawing.Color.Transparent
        Me.picVan.Image = Global.FSM.My.Resources.Resources.Van
        Me.picVan.Location = New System.Drawing.Point(383, 1)
        Me.picVan.Name = "picVan"
        Me.picVan.Size = New System.Drawing.Size(19, 17)
        Me.picVan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVan.TabIndex = 6
        Me.picVan.TabStop = False
        Me.picVan.Visible = False
        '
        'picQuestion
        '
        Me.picQuestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picQuestion.BackColor = System.Drawing.Color.Transparent
        Me.picQuestion.Image = Global.FSM.My.Resources.Resources.Question_mark_icon
        Me.picQuestion.Location = New System.Drawing.Point(383, 0)
        Me.picQuestion.Name = "picQuestion"
        Me.picQuestion.Size = New System.Drawing.Size(15, 18)
        Me.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picQuestion.TabIndex = 5
        Me.picQuestion.TabStop = False
        Me.picQuestion.Visible = False
        '
        'picSpanner
        '
        Me.picSpanner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picSpanner.BackColor = System.Drawing.Color.Transparent
        Me.picSpanner.Image = Global.FSM.My.Resources.Resources.imagesWITCGZO5
        Me.picSpanner.Location = New System.Drawing.Point(383, 1)
        Me.picSpanner.Name = "picSpanner"
        Me.picSpanner.Size = New System.Drawing.Size(16, 16)
        Me.picSpanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSpanner.TabIndex = 4
        Me.picSpanner.TabStop = False
        Me.picSpanner.Visible = False
        '
        'picLevels
        '
        Me.picLevels.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picLevels.BackColor = System.Drawing.Color.Transparent
        Me.picLevels.Image = CType(resources.GetObject("picLevels.Image"), System.Drawing.Image)
        Me.picLevels.Location = New System.Drawing.Point(306, 1)
        Me.picLevels.Name = "picLevels"
        Me.picLevels.Size = New System.Drawing.Size(16, 16)
        Me.picLevels.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLevels.TabIndex = 3
        Me.picLevels.TabStop = False
        Me.picLevels.Visible = False
        '
        'picPostalRegions
        '
        Me.picPostalRegions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPostalRegions.BackColor = System.Drawing.Color.Transparent
        Me.picPostalRegions.Image = CType(resources.GetObject("picPostalRegions.Image"), System.Drawing.Image)
        Me.picPostalRegions.Location = New System.Drawing.Point(286, 2)
        Me.picPostalRegions.Name = "picPostalRegions"
        Me.picPostalRegions.Size = New System.Drawing.Size(16, 16)
        Me.picPostalRegions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPostalRegions.TabIndex = 2
        Me.picPostalRegions.TabStop = False
        Me.picPostalRegions.Visible = False
        '
        'picRegion
        '
        Me.picRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRegion.BackColor = System.Drawing.Color.Transparent
        Me.picRegion.Image = CType(resources.GetObject("picRegion.Image"), System.Drawing.Image)
        Me.picRegion.Location = New System.Drawing.Point(328, 0)
        Me.picRegion.Name = "picRegion"
        Me.picRegion.Size = New System.Drawing.Size(16, 16)
        Me.picRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRegion.TabIndex = 1
        Me.picRegion.TabStop = False
        Me.picRegion.Visible = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(19, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(142, 16)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Engineer Schedule"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbInfomation
        '
        Me.pbInfomation.BackColor = System.Drawing.Color.Transparent
        Me.pbInfomation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbInfomation.Dock = System.Windows.Forms.DockStyle.Left
        Me.pbInfomation.Image = CType(resources.GetObject("pbInfomation.Image"), System.Drawing.Image)
        Me.pbInfomation.Location = New System.Drawing.Point(0, 0)
        Me.pbInfomation.Name = "pbInfomation"
        Me.pbInfomation.Size = New System.Drawing.Size(19, 18)
        Me.pbInfomation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbInfomation.TabIndex = 10
        Me.pbInfomation.TabStop = False
        Me.ttStatus.SetToolTip(Me.pbInfomation, "View Engineer Information")
        '
        'dgDaySummary
        '
        Me.dgDaySummary.AllowDrop = True
        Me.dgDaySummary.ContextMenu = Me.mnuDayAction
        Me.dgDaySummary.DataMember = ""
        Me.dgDaySummary.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgDaySummary.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDaySummary.Location = New System.Drawing.Point(0, 18)
        Me.dgDaySummary.Name = "dgDaySummary"
        Me.dgDaySummary.Size = New System.Drawing.Size(63, 103)
        Me.dgDaySummary.TabIndex = 2
        '
        'mnuDayAction
        '
        Me.mnuDayAction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.btnCreateJob, Me.btnExportJobs})
        '
        'btnCreateJob
        '
        Me.btnCreateJob.Index = 0
        Me.btnCreateJob.Text = "Create Job"
        '
        'btnExportJobs
        '
        Me.btnExportJobs.Index = 1
        Me.btnExportJobs.Text = "&Export Jobs"
        Me.btnExportJobs.Visible = False
        '
        'splitEngineer
        '
        Me.splitEngineer.Location = New System.Drawing.Point(63, 18)
        Me.splitEngineer.Name = "splitEngineer"
        Me.splitEngineer.Size = New System.Drawing.Size(3, 103)
        Me.splitEngineer.TabIndex = 3
        Me.splitEngineer.TabStop = False
        '
        'mnuVisitAction
        '
        Me.mnuVisitAction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.btnSendText, Me.btnReschedule, Me.btnTextMessage, Me.MenuItem1})
        '
        'btnSendText
        '
        Me.btnSendText.Index = 0
        Me.btnSendText.Text = "&Send Text"
        Me.btnSendText.Visible = False
        '
        'btnReschedule
        '
        Me.btnReschedule.Index = 1
        Me.btnReschedule.Text = "Reschedule"
        Me.btnReschedule.Visible = False
        '
        'btnTextMessage
        '
        Me.btnTextMessage.Index = 2
        Me.btnTextMessage.Text = "Include In Message Run"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.btnSiteReport, Me.btnPrintLsr, Me.btnServiceLetter, Me.btnSolarInstallation, Me.btnElectricalAppointment})
        Me.MenuItem1.Text = "Print"
        '
        'btnSiteReport
        '
        Me.btnSiteReport.Index = 0
        Me.btnSiteReport.Text = "Site Report"
        '
        'btnPrintLsr
        '
        Me.btnPrintLsr.Index = 1
        Me.btnPrintLsr.Text = "LSR"
        Me.btnPrintLsr.Visible = False
        '
        'btnServiceLetter
        '
        Me.btnServiceLetter.Index = 2
        Me.btnServiceLetter.Text = "Service Letter"
        '
        'btnSolarInstallation
        '
        Me.btnSolarInstallation.Index = 3
        Me.btnSolarInstallation.Text = "Solar Installation"
        '
        'btnElectricalAppointment
        '
        Me.btnElectricalAppointment.Index = 4
        Me.btnElectricalAppointment.Text = "Electrical Appointment"
        '
        'imgLstIcons
        '
        Me.imgLstIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.imgLstIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLstIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'dgDay
        '
        Me.dgDay.CaptionFont = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDay.ContextMenu = Me.mnuVisitAction
        Me.dgDay.DataMember = ""
        Me.dgDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDay.Font = New System.Drawing.Font("Verdana", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDay.HeaderFont = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDay.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDay.Location = New System.Drawing.Point(66, 18)
        Me.dgDay.Name = "dgDay"
        Me.dgDay.PreferredRowHeight = 12
        Me.dgDay.Size = New System.Drawing.Size(366, 79)
        Me.dgDay.TabIndex = 6
        '
        'picPlanner
        '
        Me.picPlanner.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.picPlanner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPlanner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.picPlanner.Location = New System.Drawing.Point(66, 97)
        Me.picPlanner.Name = "picPlanner"
        Me.picPlanner.Size = New System.Drawing.Size(366, 24)
        Me.picPlanner.TabIndex = 5
        Me.picPlanner.TabStop = False
        '
        'frmEngineerSchedule
        '
        Me.ClientSize = New System.Drawing.Size(432, 121)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgDay)
        Me.Controls.Add(Me.picPlanner)
        Me.Controls.Add(Me.splitEngineer)
        Me.Controls.Add(Me.dgDaySummary)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmEngineerSchedule"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpanner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLevels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPostalRegions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRegion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInfomation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDaySummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Datagrid Column Classes"

    Public Class StatusDependentDataGridCell : Inherits DataGridLabelColumn

        Private _Selected As Boolean = True

        Private Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal Value As Boolean)
                _Selected = Value
            End Set
        End Property

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            Dim Status As Integer = 0
            Dim text As String = String.Empty

            With CType([source].List.Item(rowNum).row, DataRow)
                Status = CInt(.Item("VisitStatusID"))
                text = Helper.MakeStringValid(.Item(Me.MappingName))
            End With

            Dim greenBrush As New SolidBrush(Color.LightGreen)
            Dim blueBrush As New SolidBrush(Color.Blue)

            If Status = CInt(Enums.VisitStatus.Ready_For_Schedule) Then
                Dim rectRed As New Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height)
                If Me.TextBox.Focus Then
                    g.FillRectangle(blueBrush, rectRed)
                Else
                    g.FillRectangle(greenBrush, rectRed)

                    'Selected = False
                End If

                g.DrawString(text, Me.TextBox.Font, foreBrush, bounds.X + 2, bounds.Y + 2)
            End If
        End Sub

        Protected Overrides Sub ConcedeFocus()
            Selected = False
        End Sub

    End Class

    Public Class visitStatusBar : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            Dim brush As Brush

            If CType([source].List.Item(rowNum).row, DataRow).Item("VisitStatusID") <> CInt(Enums.VisitStatus.Scheduled) And
            CType([source].List.Item(rowNum).row, DataRow).Item("VisitStatusID") <> CInt(Enums.VisitStatus.Ready_For_Schedule) Then
                brush = New SolidBrush(Color.LightGreen)
            Else
                brush = backBrush
            End If

            g.FillRectangle(brush, bounds)
        End Sub

    End Class

    Public Class unavailableBar : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

            Dim brush As Brush = Brushes.White
            Dim strBrush As Brush = Brushes.MidnightBlue

            Dim str As String = ""

            Select Case [source].List.Item(rowNum).row.item("AbsenceColumn")
                Case 0
                    brush = Brushes.White
                    str = ""
                Case 1
                    brush = Brushes.Pink
                    str = "HB"
                Case 2
                    brush = Brushes.Red
                    str = "SI"
                Case 3
                    brush = Brushes.White
                    str = "OT"
                Case 4
                    brush = Brushes.Blue
                    str = "UP"
                    strBrush = Brushes.White
                Case 5
                    brush = Brushes.Orange
                    str = "SE"
                Case 6
                    brush = Brushes.Black
                    str = "TR"
                    strBrush = Brushes.White
                Case 7
                    brush = Brushes.Green
                    str = "AP"
                    strBrush = Brushes.White
                Case 8
                    brush = Brushes.Purple
                    str = "HD"
                    strBrush = Brushes.White
                Case 9
                    brush = Brushes.Yellow
                    str = "BH"
                Case 10
                    brush = Brushes.Orange
                    str = "CO"
                Case Else
                    brush = Brushes.White
                    str = ""
            End Select

            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString(str, Me.DataGridTableStyle.DataGrid.Font, strBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
        End Sub

    End Class

#End Region

#Region "Properties"

    Private _currentDays As String
    Private _startDate As String
    Private _endDate As String
    Public WithEvents EngineerScheduleTimer As New System.Windows.Forms.Timer()

    'Dataset to display to user - Dates, snapshot work load
    Private _dsEngineerSchedule As New DataSet

    Public CurrentDate As DateTime
    Public LastHeartBeat As DateTime
    Public LockedVisitId As Integer
    Public HeartLastCheck As DateTime

    'These are the tests to be carried out on a visit row
    Private _tests As ScheduleTest() = New ScheduleTest() {New RegionCheck, New PostcodeRegionCheck, New LevelsCheck, New AbsenceOverlapCheck, New SOROverloadCheck, New DueDateCheck, New PriorityCheck}

    Private _dtday As New DataTable

    Private Property CurrentDayDataTable() As DataTable
        Get
            Return _dtday
        End Get
        Set(ByVal Value As DataTable)
            _dtday = Value
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgDay.CurrentRowIndex = -1 Then
                Return Me.dgDay.DataSource(Me.dgDay.CurrentRowIndex).row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _engineerID As String

    Public Property EngineerID() As String Implements ISchedulerForm.EngineerID
        Get
            Return _engineerID
        End Get
        Set(ByVal Value As String)
            _engineerID = Value
        End Set
    End Property

    Private _engineer As DataRow

    Public Property Engineer() As DataRow
        Get
            Return _engineer
        End Get
        Set(value As DataRow)
            _engineer = value
        End Set

    End Property

    Private _detailPopup As frmDetailsPopup

    Public Property detailPopup() As frmDetailsPopup
        Get
            Return _detailPopup
        End Get
        Set(value As frmDetailsPopup)
            _detailPopup = value
        End Set

    End Property

    Private _opening As Boolean

    Public Property opening() As Boolean
        Get
            Return _opening
        End Get
        Set(ByVal Value As Boolean)
            _opening = Value
        End Set
    End Property

    Private _engineerVisit As Entity.EngineerVisits.EngineerVisit

    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _engineerVisit
        End Get
        Set(value As Entity.EngineerVisits.EngineerVisit)
            _engineerVisit = value
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
            Return "frmEngineerSchedule"
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub setUpDayDg()
        SetUpSchedulerDataGrid(Me.dgDay, False)
        Dim tStyle As DataGridTableStyle = dgDay.TableStyles(0)

        Dim diff As Double = 0.9

        Select Case TEXTSIZE
            Case 7
                diff = 1
            Case 8
                diff = 1.1
            Case 9
                diff = 1.2
            Case 10
                diff = 1.25
            Case 11
                diff = 1.3
            Case 12
                diff = 1.35
        End Select

        tStyle.DataGrid.Font = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        tStyle.DataGrid.HeaderFont = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim jobStatus As New DataGridSchedulerColumn
        jobStatus.Format = ""
        jobStatus.FormatInfo = Nothing
        jobStatus.HeaderText = ""
        jobStatus.MappingName = "JobStatus"
        jobStatus.ReadOnly = True
        jobStatus.Width = CInt(15 * diff)
        jobStatus.NullText = ""
        tStyle.GridColumnStyles.Add(jobStatus)

        Dim JobID As New DataGridSchedulerJobColumn
        JobID.Format = ""
        JobID.FormatInfo = Nothing
        JobID.HeaderText = "Job No"
        JobID.MappingName = "JobNumber"
        JobID.ReadOnly = True
        JobID.Width = CInt(60 * diff)
        JobID.NullText = ""
        tStyle.GridColumnStyles.Add(JobID)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Address 1"
        Site.MappingName = "Address1"
        Site.ReadOnly = True
        Site.Width = CInt(125 * diff)
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim PostCode As New DataGridLabelColumn
        PostCode.Format = ""
        PostCode.FormatInfo = Nothing
        PostCode.HeaderText = "Postcode"
        PostCode.MappingName = "PostCode"
        PostCode.ReadOnly = True
        PostCode.Width = CInt(65 * diff)
        PostCode.NullText = ""
        tStyle.GridColumnStyles.Add(PostCode)

        Dim Items As New DataGridLabelColumn
        Items.Format = ""
        Items.FormatInfo = Nothing
        Items.HeaderText = "Job Summary"
        Items.MappingName = "JobItems"
        Items.ReadOnly = True
        Items.Width = CInt(100 * diff)
        Items.NullText = ""
        tStyle.GridColumnStyles.Add(Items)

        Dim Notes As New DataGridLabelColumn
        Notes.Format = ""
        Notes.FormatInfo = Nothing
        Notes.HeaderText = "Notes"
        Notes.MappingName = "NotesToEngineer"
        Notes.ReadOnly = True
        Notes.Width = CInt(325 * diff)
        Notes.NullText = ""
        tStyle.GridColumnStyles.Add(Notes)

        Dim startTime As New DataGridLabelColumn
        startTime.Format = "HH:mm"
        startTime.FormatInfo = Nothing
        startTime.HeaderText = "Start"
        startTime.MappingName = "StartDateTime"
        startTime.ReadOnly = True
        startTime.Width = CInt(40 * diff)
        startTime.NullText = ""
        tStyle.GridColumnStyles.Add(startTime)

        Dim endTime As New DataGridLabelColumn
        endTime.Format = "HH:mm"
        endTime.FormatInfo = Nothing
        endTime.HeaderText = "End"
        endTime.MappingName = "EndDateTime"
        endTime.ReadOnly = True
        endTime.Width = CInt(40 * diff)
        endTime.NullText = ""
        tStyle.GridColumnStyles.Add(endTime)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = CInt(80 * diff)
        VisitStatus.NullText = ""
        tStyle.GridColumnStyles.Add(VisitStatus)

        Dim CustomerName As New DataGridLabelColumn
        CustomerName.Format = ""
        CustomerName.FormatInfo = Nothing
        CustomerName.HeaderText = "Customer"
        CustomerName.MappingName = "customername"
        CustomerName.ReadOnly = True
        CustomerName.Width = CInt(75 * diff)
        CustomerName.NullText = ""
        tStyle.GridColumnStyles.Add(CustomerName)

        Dim JobType As New DataGridJobTypeColumn
        JobType.Format = ""
        JobType.FormatInfo = Nothing
        JobType.HeaderText = "Type"
        JobType.MappingName = "JobType"
        JobType.ReadOnly = True
        JobType.Width = CInt(150 * diff)
        JobType.NullText = ""
        tStyle.GridColumnStyles.Add(JobType)

        Dim SummedSOR As New DataGridLabelColumn
        SummedSOR.Format = "#"
        SummedSOR.FormatInfo = Nothing
        SummedSOR.HeaderText = "SOR"
        SummedSOR.MappingName = "SummedSOR"
        SummedSOR.ReadOnly = True
        SummedSOR.Width = CInt(50 * diff)

        SummedSOR.NullText = ""

        tStyle.GridColumnStyles.Add(SummedSOR)

        Dim EstimatedVisitDate As New DataGridLabelColumn
        EstimatedVisitDate.Format = "dd/MM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Est Date"
        EstimatedVisitDate.MappingName = "EstimatedVisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = CInt(60 * diff)
        EstimatedVisitDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(EstimatedVisitDate)

        tStyle.MappingName = ""
    End Sub

    Private Sub setUpSummaryDg()
        SetUpSchedulerDataGrid(dgDaySummary, False)

        Dim diff As Double = 0.9

        Select Case TEXTSIZE
            Case 7
                diff = 1
            Case 8
                diff = 1.1
            Case 9
                diff = 1.2
            Case 10
                diff = 1.3
            Case 11
                diff = 1.5
            Case 12
                diff = 1.7
        End Select

        Dim tsSummary As DataGridTableStyle = dgDaySummary.TableStyles(0)

        tsSummary.DataGrid.Font = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        tsSummary.DataGrid.HeaderFont = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim absence As New unavailableBar
        absence.Format = ""
        absence.FormatInfo = Nothing
        absence.HeaderText = ""
        absence.MappingName = "AbsenceColumn"
        absence.ReadOnly = True
        absence.Width = CInt(22 * diff)
        absence.NullText = ""
        tsSummary.GridColumnStyles.Add(absence)

        Dim csDayDate As New DataGridLabelColumn
        csDayDate.MappingName = "dayDate"
        csDayDate.HeaderText = "Date"
        csDayDate.ReadOnly = True
        csDayDate.Width = CInt(70 * diff)
        tsSummary.GridColumnStyles.Add(csDayDate)

        Dim csDay As New DataGridLabelColumn
        csDay.MappingName = "day"
        csDay.HeaderText = "Day"
        csDay.ReadOnly = True
        csDay.Width = CInt(30 * diff)
        tsSummary.GridColumnStyles.Add(csDay)

        Dim csWorkCount As New DataGridLabelColumn
        csWorkCount.MappingName = "workCount"
        csWorkCount.HeaderText = "Work"
        csWorkCount.ReadOnly = True
        csWorkCount.Alignment = HorizontalAlignment.Center
        csWorkCount.Width = CInt(30 * diff)
        tsSummary.GridColumnStyles.Add(csWorkCount)

        Dim csSummedSOR As New DataGridLabelColumn
        csSummedSOR.Format = "#"
        csSummedSOR.FormatInfo = Nothing
        csSummedSOR.HeaderText = "SOR"
        csSummedSOR.MappingName = "SummedSOR"
        csSummedSOR.ReadOnly = True
        csSummedSOR.Width = CInt(30 * diff)
        csSummedSOR.NullText = ""
        tsSummary.GridColumnStyles.Add(csSummedSOR)

        tsSummary.MappingName = "ScheduleSummary"
    End Sub

#End Region

#Region "Events"

    Private Sub frmEngineerSchedule_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not _refreshAsyncResult Is Nothing Then
            While _refreshAsyncResult.IsCompleted = False
                If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(100)
                Application.DoEvents()
            End While
        End If

        If Not _refreshSummary Is Nothing Then
            While _refreshSummary.IsCompleted = False
                If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures) Then Threading.Thread.Sleep(100)
                Application.DoEvents()
            End While
        End If
    End Sub

    Private Sub frmEngineerSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setUpDayDg()
        setUpSummaryDg()

        detailPopup = New frmDetailsPopup(Me)
        SetupHeartBeat()
        DisplayLastLocation()
        EngineerScheduleTimer.Interval = 300000
        EngineerScheduleTimer.Start()
    End Sub

    Private Sub frmEngineerSchedule_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        Dim diff As Double = 0.15 ' 6

        Select Case TEXTSIZE
            Case 7
                diff = 0.16
            Case 8
                diff = 0.17
            Case 9
                diff = 0.18
            Case 10
                diff = 0.19
            Case 11
                diff = 0.22
            Case 12
                diff = 0.25
        End Select

        dgDaySummary.Width = Me.Width * diff
    End Sub

    Private Sub dgDaySummary_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgDaySummary.MouseUp
        Dim hitTest As System.Windows.Forms.DataGrid.HitTestInfo = dgDaySummary.HitTest(e.X, e.Y)

        If hitTest.Type = DataGrid.HitTestType.Cell Then
            dgDaySummary.CurrentRowIndex = hitTest.Row
            ShowDay(SelectedDay)
        End If
    End Sub

    Private Sub dgDay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDay.DoubleClick
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim oSite As Entity.Sites.Site = DB.Sites.Get(SelectedDataRow("SiteID"))

        If oSite Is Nothing OrElse Not oSite.Exists Then
            ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If loggedInUser.UserRegions.Table.Select("RegionID = " & oSite.RegionID).Length < 1 Then
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedDataRow.Item("JobID"), SelectedDataRow.Item("SiteID"), Me, Nothing, SelectedDataRow("EngineerVisitID")})
    End Sub

#End Region

#Region "Functions"

    Public Sub Reset()
        _dsEngineerSchedule = New DataSet
        Try
            dgDay.DataSource = Nothing
            dgDaySummary.DataSource = Nothing
        Catch
        End Try
    End Sub

#Region "Acceptance Async"

    Public Delegate Function refreshAcceptanceDelegate() As Hashtable

    Private _testRow As DataRow
    Private _refreshAsyncResult As IAsyncResult

    Public Sub RefreshAcceptance(ByVal testRow As DataRow)
        _testRow = testRow

        Dim acceptance As refreshAcceptanceDelegate = New refreshAcceptanceDelegate(AddressOf BeginRefreshAcceptance)
        Dim acceptanceComplete As AsyncCallback = New AsyncCallback(AddressOf refreshAccptanceComplete)

        _refreshAsyncResult = acceptance.BeginInvoke(acceptanceComplete, Nothing)

    End Sub

    Public Function BeginRefreshAcceptance() As Hashtable
        Try
            If Not _testRow Is Nothing Then
                Dim results As New Hashtable
                For Each test As ScheduleTest In _tests
                    If Not _testRow Is Nothing Then
                        Dim testResult As ScheduleTest.TestResult = test.Test(_testRow, EngineerID, CurrentDate)
                        results.Add(test, testResult)
                    Else
                        Return Nothing
                    End If
                Next

                Return results
            Else
                Return Nothing
            End If
        Catch
            Return Nothing
        End Try

        'GC.Collect()
        'GC.WaitForPendingFinalizers()

        'GC.Collect()
        'GC.WaitForPendingFinalizers()
    End Function

    Public Sub refreshAccptanceComplete(ByVal ar As IAsyncResult)
        Dim o_MyDelegate As refreshAcceptanceDelegate =
                  CType(CType(ar, AsyncResult).AsyncDelegate, refreshAcceptanceDelegate)

        Dim results As Hashtable = o_MyDelegate.EndInvoke(ar)
        If Not Me.IsFormDisposed Then
            Try
                Me.Invoke(New resultsDisplayDelegate(AddressOf SetResultDisplay), results)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Delegate Sub resultsDisplayDelegate(ByVal results As Hashtable)

    Public Sub SetResultDisplay(ByVal results As Hashtable)
        Try
            _testRow = Nothing

            If Not results Is Nothing Then
                Dim pass As Boolean = True
                For Each test As ScheduleTest In _tests
                    Dim testresult As ScheduleTest.TestResult = results(test)

                    If testresult.pass = False Then
                        pass = False
                    End If

                    Select Case test.GetType.Name.ToLower
                        Case "RegionCheck".ToLower
                            Me.picRegion.Visible = testresult.pass
                        Case "PostcodeRegionCheck".ToLower
                            Me.picPostalRegions.Visible = testresult.pass
                        Case "LevelsCheck".ToLower
                            Me.picLevels.Visible = testresult.pass
                    End Select
                Next

                If pass = True Then
                    pnlHeader.BackColor = Color.LightGreen
                Else
                    pnlHeader.BackColor = Color.Salmon
                End If
            Else
                ResetHeader()
            End If
        Catch ex As Exception
        End Try

        Application.DoEvents()
    End Sub

#End Region

    Public Function TestAcceptance(ByVal testRow As DataRow) As Boolean
        Dim pass As Boolean = True
        For Each test As ScheduleTest In _tests
            Dim testResult As ScheduleTest.TestResult = test.Test(testRow, EngineerID, CurrentDate)
            If testResult.pass = False Then
                pass = False
            End If

            Select Case test.GetType.Name.ToLower
                Case "RegionCheck".ToLower
                    Me.picRegion.Visible = testResult.pass
                Case "PostcodeRegionCheck".ToLower
                    Me.picPostalRegions.Visible = testResult.pass
                Case "LevelsCheck".ToLower
                    Me.picLevels.Visible = testResult.pass
            End Select
        Next

        If pass = True Then
            pnlHeader.BackColor = Color.LightGreen
            Return True
        Else
            pnlHeader.BackColor = Color.Salmon
            Return False
        End If

    End Function

    Public Function GetAcceptance(ByVal testRow As DataRow, ByVal isCopy As Boolean) As Boolean
        Dim pass As Boolean = True
        Dim cancelSchedule As Boolean = False
        Dim passwordPrompt As Boolean = False
        Dim failureString As New ArrayList
        For Each test As ScheduleTest In _tests
            Dim testResult As ScheduleTest.TestResult = test.Test(testRow, EngineerID, CurrentDate)
            If testResult.pass = False Then
                If testResult.failMessages.Count = 0 Then
                    failureString.Add(testResult.failMessage)
                Else
                    For Each message As String In testResult.failMessages
                        failureString.Add(message)
                    Next
                End If
                pass = False
            End If
            If testResult.CancelSchedule Then
                cancelSchedule = testResult.CancelSchedule
                Exit For
            End If
            If testResult.PasswordPrompt Then
                passwordPrompt = testResult.PasswordPrompt
                Exit For
            End If
        Next

        Dim override As New FrmOverride(failureString, testRow("EngineerVisitID"), isCopy, cancelSchedule, passwordPrompt)

        If override.ShowDialog = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ResetHeader()
        pnlHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.picRegion.Visible = False
        Me.picPostalRegions.Visible = False
        Me.picLevels.Visible = False
        _testRow = Nothing
    End Sub

    Public Function GetDay(ByVal [date] As String) As DataTable
        If _dsEngineerSchedule.Tables([date]) Is Nothing Then
            Dim loadedDay As DataTable
            loadedDay = DB.Scheduler.Get_ScheduledJobsDay([date], EngineerID)
            loadedDay.TableName = [date]
            _dsEngineerSchedule.Tables.Add(loadedDay)
        End If

        DtTimeSlot = DB.Scheduler.Scheduler_DayTimeSlots(SelectedDay, EngineerID)
        picPlanner.Image = Scheduler_DayTimeSlots_Bitmap()

        SetupTimeSheetStatus()

        Dim scheduledVisits As DataRow() = _dsEngineerSchedule.Tables([date]).Select("VisitStatusID = " & Enums.VisitStatus.Scheduled)
        If IsGasway Then btnSendText.Visible = scheduledVisits.Length > 0

        Dim rescheduleVisits As DataRow() = _dsEngineerSchedule.Tables([date]).Select("VisitStatusID IN ( " & Enums.VisitStatus.Scheduled & " , " & Enums.VisitStatus.Downloaded & ")")
        btnReschedule.Visible = rescheduleVisits.Length > 0

        Dim serviceList As DataRow() = _dsEngineerSchedule.Tables([date]).Select("OutcomeEnumID = " & Enums.EngineerVisitOutcomes.Complete & " AND JobTypeID In (" & Enums.JobTypes.Service & ", " & Enums.JobTypes.ServiceCertificate & ", " & Enums.JobTypes.Commission & ")")
        btnPrintLsr.Visible = serviceList.Length > 0

        Return AddJobStatus(_dsEngineerSchedule.Tables([date]), CDate([date]))
    End Function

    Private Function AddJobStatus(ByVal dt As DataTable, ByVal [date] As DateTime) As DataTable
        If Not dt.Columns.Contains("JobStatus") Then
            Dim dcServiceOverDue As New DataColumn("JobStatus", GetType(Integer))
            dcServiceOverDue.DefaultValue = False
            dt.Columns.Add(dcServiceOverDue)
        End If

        If Not dt.Columns.Contains("IsServiceOverDue") Then
            Dim dcServiceOverDue As New DataColumn("IsServiceOverDue", GetType(Boolean))
            dcServiceOverDue.DefaultValue = False
            dt.Columns.Add(dcServiceOverDue)
        End If

        For Each row As DataRow In dt.Rows
            row("IsServiceOverDue") = DB.Scheduler.IsSiteOverdue(Helper.MakeIntegerValid(row("SiteID")))
        Next

        If [date].Date <> Date.Today Then Return dt

        If Not dt.Columns.Contains("IsJobLate") Then
            Dim dcJobLate As New DataColumn("IsJobLate", GetType(Boolean))
            dcJobLate.DefaultValue = False
            dt.Columns.Add(dcJobLate)
        End If

        For Each row As DataRow In dt.Rows
            If row.Table.Columns.Contains("Declined") Then
                If Helper.MakeBooleanValid(row("Declined")) Then Continue For
            End If

            row("IsJobLate") = DB.Scheduler.IsVisitLate(Helper.MakeIntegerValid(row("EngineerVisitID")))
        Next

        Return dt
    End Function

    Public Sub Timer_tick(myObject As Object, ByVal myEventArgs As EventArgs) Handles EngineerScheduleTimer.Tick
        SetupHeartBeat()
        RefreshDay()
        DisplayLastLocation()
    End Sub

#Region "Refresh Summary Async"

    Private Delegate Function refreshSummaryDelegate() As DataTable

    Private _refreshSummary As IAsyncResult

    Public Sub RefreshSummary(ByVal start As String, ByVal endin As String)

        _startDate = start
        _endDate = endin

        Dim summaryRefresh As refreshSummaryDelegate = New refreshSummaryDelegate(AddressOf BeginRefreshSummary)
        Dim summaryRefreshComplete As AsyncCallback = New AsyncCallback(AddressOf RefreshSummaryComplete)

        _refreshSummary = summaryRefresh.BeginInvoke(summaryRefreshComplete, Nothing)
    End Sub

    Public Function BeginRefreshSummary() As DataTable
        Try
            Dim dtSummary As DataTable = DB.Scheduler.getSummaryNEW(EngineerID, _startDate, _endDate)
            dtSummary.TableName = "ScheduleSummary"
            Return dtSummary
        Catch
            Return Nothing
        End Try
    End Function

    Public Sub RefreshSummaryComplete(ByVal ar As IAsyncResult)
        Try
            Dim o_MyDelegate As refreshSummaryDelegate =
                  CType(CType(ar, AsyncResult).AsyncDelegate, refreshSummaryDelegate)

            Dim result As DataTable = o_MyDelegate.EndInvoke(ar)
            If Not result Is Nothing And Not Me.IsFormDisposed Then
                Me.Invoke(New setSummaryDelegate(AddressOf SetSummary), result)
            End If
            opening = False
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisplayLastLocation()
        Dim engineer As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerID)
        If engineer IsNot Nothing Then
            Dim u As Entity.Users.User = DB.User.GetAsync(engineer.ManagerUserID)
            Dim manager As String = "N/A"
            If u IsNot Nothing Then manager = u.Fullname

            Dim dvEngineerLocation As DataView = DB.Scheduler.Get_EngineerLocation(EngineerID)
            Dim lastAppointment As String = " : Last update N/A"
            If dvEngineerLocation.Count > 0 Then
                Dim timesheetType As String = Helper.MakeStringValid(dvEngineerLocation(0)("TimeSheetType"))
                If timesheetType = "Working" Then
                    timesheetType += " at"
                ElseIf timesheetType = "Travelling" Then
                    timesheetType += " to"
                End If

                Dim address As String
                If loggedInUser IsNot Nothing AndAlso loggedInUser.UserRegions.Table.Select("RegionID = " & Helper.MakeIntegerValid(dvEngineerLocation(0)("RegionID"))).Length < 1 Then
                    address = "xxx, " & Helper.MakeStringValid(dvEngineerLocation(0)("Postcode")).Substring(0, Helper.MakeStringValid(dvEngineerLocation(0)("Postcode")).IndexOf("-")) & "-xxx"
                Else
                    address = Helper.MakeStringValid(dvEngineerLocation(0)("Address1")) & ", " & Helper.MakeStringValid(dvEngineerLocation(0)("Postcode"))
                End If
                lastAppointment = " : Last update " & Helper.MakeStringValid(dvEngineerLocation(0)("ArrivalTime")) & " - " & timesheetType & " " & Helper.MakeStringValid(dvEngineerLocation(0)("JobNumber")) & ", " & address

            End If

            Me.lblTitle.Text = engineer.Name & " :  Manager: " & manager & lastAppointment
        End If
    End Sub

    Public Sub RefreshDay()

        'update the day schedules that are opened at 11:30 and 13:00
        Dim refreshTime1 As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day, 11, 30, 0)
        Dim refreshTime2 As DateTime = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day, 13, 0, 0)

        If Date.Now.Hour = refreshTime1.Hour And (Date.Now.Minute >=
            refreshTime1.Minute And Date.Now.Minute <=
            refreshTime1.AddMinutes(5).Minute) Then
            ShowDay(SelectedDay)
        End If

        If Date.Now.Hour = refreshTime2.Hour And (Date.Now.Minute >=
            refreshTime2.Minute And Date.Now.Minute <=
            refreshTime1.AddMinutes(5).Minute) Then
            ShowDay(SelectedDay)
        End If
    End Sub

    Public Delegate Sub setSummaryDelegate(ByVal dtSummary As DataTable)

    Public Sub SetSummary(ByVal dtSummary As DataTable)
        Try
            Dim currentTable As DataTable
            If Not dgDaySummary.DataSource Is Nothing Then
                currentTable = CType(dgDaySummary.DataSource, DataView).Table

                Dim dvSummary As New DataView(dtSummary)
                Dim dvCurrentTable As New DataView(currentTable)
                dvCurrentTable.Sort = "dayDate"

                For Each newRow As DataRow In dtSummary.Rows
                    Dim foundIndex As Integer = dvCurrentTable.Find(newRow("dayDate"))
                    If foundIndex <> -1 Then
                        Dim dayDate As DataRow = currentTable.Rows(foundIndex)
                        dayDate("workCount") = newRow("workCount")
                        dayDate("SummedSOR") = newRow("SummedSOR")
                    Else
                        currentTable.ImportRow(newRow)
                    End If
                Next
                DtTimeSlot = DB.Scheduler.Scheduler_DayTimeSlots(SelectedDay, EngineerID)
                picPlanner.Image = Scheduler_DayTimeSlots_Bitmap()
            Else
                dgDaySummary.DataSource = New DataView(dtSummary)
                Application.DoEvents()
            End If

            If loggedInUser.SchedulerDayView Then
                Dim selectedIndex As Integer = dgDaySummary.CurrentRowIndex
                dgDaySummary.DataSource = New DataView(dtSummary)

                If selectedIndex <> -1 Then
                    dgDaySummary.Select(selectedIndex)
                    ShowDay(SelectedDay)
                    Application.DoEvents()
                End If
            End If

            Dim daysWithWork As DataRow() = dtSummary.Select("workCount > 0")
            btnExportJobs.Visible = daysWithWork.Length > 0
        Catch ex As Exception
        End Try

    End Sub

#End Region

    Public Sub ShowDay(ByVal [date] As String)
        dgDay.TableStyles(0).MappingName = [date]
        dgDay.DataSource = New DataView(GetDay([date]))
    End Sub

    Public Function SelectedDay() As String Implements ISchedulerForm.selectedDay
        If dgDaySummary IsNot Nothing Then
            Dim dvSummary As DataView = CType(dgDaySummary.DataSource, DataView)
            dgDaySummary.Select(dgDaySummary.CurrentRowIndex)
            Return dvSummary(dgDaySummary.CurrentRowIndex).Item("dayDate")
        Else
            Return Now.ToString()
        End If
    End Function

    Public Sub ClearSelections()
        If Not dgDay.DataSource Is Nothing Then
            For rowCount As Integer = 0 To CType(dgDay.DataSource, DataView).Count - 1
                dgDay.UnSelect(rowCount)
            Next
        End If
    End Sub

#End Region

#Region "Planner"

    Private timeSlotDt As DataTable

    Public Property DtTimeSlot() As DataTable Implements ISchedulerForm.TimeSlotDt
        Get
            Return timeSlotDt
        End Get
        Set(ByVal Value As DataTable)
            timeSlotDt = Value
        End Set
    End Property

    Private Function Scheduler_DayTimeSlots_Bitmap() As Bitmap
        If Not DtTimeSlot Is Nothing AndAlso picPlanner.Height > 0 AndAlso picPlanner.Width > 0 Then
            Dim timeSlots As New Bitmap(picPlanner.Width, picPlanner.Height)
            Dim timeSlotGfx As Graphics = Graphics.FromImage(timeSlots)

            Dim slotWidth As Single = CSng(timeSlots.Width - 9) / CSng(DtTimeSlot.Columns.Count - 1)

            Dim currentHour As String = ""

            timeSlotGfx.FillRectangle(New SolidBrush(Color.WhiteSmoke), 0, picPlanner.Height - 15, picPlanner.Width, 15)

            For Each time As DataColumn In DtTimeSlot.Columns

                If DtTimeSlot.Rows.Count > 0 AndAlso DtTimeSlot.Rows(0)(time) = 1 Then
                    timeSlotGfx.FillRectangle(New SolidBrush(Color.LightSteelBlue), New RectangleF(slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth, CSng(picPlanner.Height - 15)))
                End If

                If time.ColumnName.Substring(1, 2) <> currentHour Then
                    currentHour = time.ColumnName.Substring(1, 2)
                    timeSlotGfx.DrawLine(New Pen(Color.RoyalBlue), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), CSng(picPlanner.Height - 12))

                    Dim hourFont As New Font(dgDay.Font.Name, 6, FontStyle.Regular)

                    timeSlotGfx.DrawString(currentHour, hourFont, New SolidBrush(Color.Black), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)) - (timeSlotGfx.MeasureString(currentHour, hourFont).Width / 2), CSng(picPlanner.Height - timeSlotGfx.MeasureString(currentHour, hourFont).Height - 1))
                Else
                    timeSlotGfx.DrawLine(New Pen(Color.RoyalBlue), slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * CSng(DtTimeSlot.Columns.IndexOf(time)), CSng(picPlanner.Height - 13))
                End If

            Next

            Return timeSlots
        Else
            Return Nothing
        End If
    End Function

    Private Sub frmVisit_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        picPlanner.Image = Scheduler_DayTimeSlots_Bitmap()
    End Sub

    Private Sub splitEngineer_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitEngineer.SplitterMoved
        picPlanner.Image = Scheduler_DayTimeSlots_Bitmap()
    End Sub

    Public Sub SendToPrint(Optional ByVal fileName As String = "")
        Dim dr As DataRow = Nothing
        Dim lm As DataView = DB.LetterManager.MakeServiceLetter(EngineerVisit.EngineerVisitID)
        lm.Table.Columns.Add("FileName")
        If lm.Count > 0 And String.IsNullOrEmpty(fileName) Then
            dr = lm.Table.Rows(0)
        Else
            Dim site As Entity.Sites.Site = DB.Sites.Get(SelectedDataRow("SiteID"))
            Dim dt As DataTable = lm.Table.Clone
            dr = dt.NewRow()
            dr("Name") = site.Name
            dr("Address1") = site.Address1
            dr("Address2") = site.Address2
            dr("Address3") = site.Address3
            dr("Address4") = site.Address4
            dr("Address5") = site.Address5
            dr("Postcode") = site.Postcode
            dr("SiteID") = site.SiteID
            dr("CustomerID") = site.CustomerID
            dr("SolidFuel") = site.SolidFuel
            dr("PropertyVoid") = site.PropertyVoid
            dr("LastServiceDate") = site.LastServiceDate
            dr("CommercialDistrict") = site.CommercialDistrict
            dr("SiteFuel") = site.SiteFuel
            dr("Type") = "Generic"
            dr("NextVisitDate") = SelectedDataRow("StartDateTime")
            dr("StartDateTime") = SelectedDataRow("StartDateTime")
            dr("AMPM") = ""
            dr("JobID") = SelectedDataRow("JobID")
            dr("JobNumber") = SelectedDataRow("JobNumber")
            dr("FileName") = fileName
            dt.Rows.Add(dr)

            dr = dt.Rows(0)
        End If
        Dim details As New ArrayList
        details.Add(dr)

        Dim oPrint As New Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters)
    End Sub

#End Region

    Private Sub SetupTimeSheetStatus()
        Dim i As Integer = DB.Scheduler.getTimesheetStatus(EngineerID)
        Select Case i
            Case 1 'Engineer Working
                picQuestion.Visible = False
                picSpanner.Visible = True
                picVan.Visible = False

            Case 2 'Engineer Travelling
                picQuestion.Visible = False
                picSpanner.Visible = False
                picVan.Visible = True

            Case 3 'No idea
                picQuestion.Visible = True
                picSpanner.Visible = False
                picVan.Visible = False
        End Select
    End Sub

    Public Sub SetupHeartBeat()
        Dim hb As Entity.HeartBeats.HeartBeat = DB.Scheduler.GetLatestHeartBeat(EngineerID)

        If IsDBNull(hb.LastHeartBeat) Then
            pbGreen.Visible = False
            pbRed.Visible = False
        End If

        LastHeartBeat = hb.LastHeartBeat
        LockedVisitId = hb.LockedVisitID
        HeartLastCheck = hb.LastCheck

        If Date.Now.AddMinutes(-2) > LastHeartBeat Then

            pbGreen.Visible = False
            pbRed.Visible = True
        Else
            pbGreen.Visible = True
            pbRed.Visible = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Close()
    End Sub

    Private Sub btnSendText_Click(sender As Object, e As EventArgs) Handles btnSendText.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            If SelectedDataRow("VisitStatusID") = Enums.VisitStatus.Scheduled Then
                Dim oSite As Entity.Sites.Site = DB.Sites.Get(SelectedDataRow("SiteID"))
                If oSite Is Nothing OrElse Not oSite.Exists Then Throw New Exception("Site missing")
                Dim mobNum As String = oSite.FaxNum.Trim

                If Not Helper.ValidatePhoneNumber(mobNum) Then
                    ShowMessage("Mobile number invalid, please update!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Using frmContactInfo As New FRMContactInfo(oSite)
                        frmContactInfo.ShowDialog()
                        mobNum = frmContactInfo.CurrentSite.FaxNum.Trim
                        If Not frmContactInfo.DialogResult = DialogResult.Yes Or Not Helper.ValidatePhoneNumber(mobNum) Then
                            Throw New Exception("Mobile Number invalid!")
                        End If
                    End Using
                End If

                Dim timePeriod As String = String.Empty
                Dim visitDate As Date = CDate(SelectedDataRow("StartDateTime"))
                Dim appointmentId As Integer = Helper.MakeIntegerValid(SelectedDataRow("AppointmentID"))

                Select Case appointmentId
                    Case Enums.Appointments.FirstCall,
                         Enums.AppointmentsPicklist.FirstCall
                        timePeriod = "8:00am - 9:00am"
                    Case Enums.Appointments.EightAmTillTwelvePm,
                         Enums.AppointmentsPicklist.EightAmTillTwelvePm
                        timePeriod = "8:00am - 12:00pm"
                    Case Enums.Appointments.TenAmTillTwoPm,
                         Enums.AppointmentsPicklist.TenAmTillTwoPm
                        timePeriod = "10:00am - 2:00pm"
                    Case Enums.Appointments.TwelvePmTillFourPm,
                         Enums.AppointmentsPicklist.TwelvePmTillFourPm
                        timePeriod = "12:00pm - 4:00pm"
                    Case Enums.Appointments.TwoPmTillSixPm,
                         Enums.AppointmentsPicklist.TwoPmTillSixPm
                        timePeriod = "2:00pm - 6:00pm"
                    Case Enums.Appointments.Am,
                         Enums.AppointmentsPicklist.Am
                        timePeriod = "8:00am - 1:00pm"
                    Case Enums.Appointments.Pm,
                         Enums.AppointmentsPicklist.Pm
                        timePeriod = "12:00pm - 6:00pm"
                    Case Enums.Appointments.Anytime,
                         Enums.AppointmentsPicklist.Anytime
                        timePeriod = "08:00am - 6:00pm"
                    Case Else
                        timePeriod = If(visitDate.Hour < 12, "8:00am - 1:00pm", "12:00pm - 6:00pm")
                End Select

                Dim mb As New MessageBird.TextClient
                Dim textMessage As String = "CONFIRMATION - Hello, we are happy to confirm that your appointment has been booked for " & visitDate.DayOfWeek.ToString() & " " & visitDate.ToLongDateString & ". The engineer will arrive between " & timePeriod & "."

                mb.MakeCall(textMessage, mobNum, TheSystem.Configuration.CompanyName)
                DB.ExecuteScalar("INSERT INTO tblText VALUES (0, GETDATE(),'" & mobNum & "'," & SelectedDataRow("EngineerVisitID") & ") ")

                Dim contactAttempt As New ContactAttempt
                With contactAttempt
                    .ContactMethedID = 7
                    .LinkID = CInt(Enums.TableNames.tblEngineerVisit)
                    .LinkRef = Helper.MakeIntegerValid(SelectedDataRow("EngineerVisitID"))
                    .ContactMade = Now
                    .Notes = textMessage
                    .ContactMadeByUserId = loggedInUser.UserID
                End With
                contactAttempt = DB.ContactAttempts.Insert(contactAttempt)

                ShowMessage("Text message sent!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportJobs_Click(sender As Object, e As EventArgs) Handles btnExportJobs.Click
        If SelectedDay() Is Nothing Then
            ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim dtDayJobs As DataTable = GetDay(Helper.MakeDateTimeValid(SelectedDay()))
        If dtDayJobs.Rows.Count = 0 Then
            ShowMessage("No Jobs to Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim engineer As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerID)
        Dim enginnerName As String = String.Empty
        If engineer IsNot Nothing Then enginnerName = engineer.Name & "_"

        Dim exportData As New DataTable
        exportData.Columns.Add("Job Number", GetType(String))
        exportData.Columns.Add("Address 1", GetType(String))
        exportData.Columns.Add("Postcode", GetType(String))
        exportData.Columns.Add("Job Summary", GetType(String))
        exportData.Columns.Add("Notes", GetType(String))
        exportData.Columns.Add("Start", GetType(Date))
        exportData.Columns.Add("End", GetType(Date))
        exportData.Columns.Add("Status", GetType(String))
        exportData.Columns.Add("Customer", GetType(String))
        exportData.Columns.Add("Type", GetType(String))
        exportData.Columns.Add("SOR", GetType(String))
        exportData.Columns.Add("Est Date", GetType(String))

        For Each dr As DataRow In dtDayJobs.Rows
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Job Number") = dr("JobNumber")
            newRw("Address 1") = dr("Address1")
            newRw("Postcode") = dr("PostCode")
            newRw("Job Summary") = dr("JobItems")
            newRw("Notes") = dr("NotesToEngineer")
            newRw("Start") = Helper.MakeDateTimeValid(dr("StartDateTime"))
            newRw("End") = Helper.MakeDateTimeValid(dr("EndDateTime"))
            newRw("Status") = dr("VisitStatus")
            newRw("Customer") = dr("CustomerName")
            newRw("Type") = dr("JobType")
            newRw("SOR") = dr("SummedSOR")
            newRw("Est Date") = dr("EstimatedVisitDate")

            exportData.Rows.Add(newRw)
        Next
        ExportHelper.Export(exportData, enginnerName & SelectedDay() & "_Jobs", Enums.ExportType.XLS)
    End Sub

    Private Sub picPlanner_MouseUp(sender As Object, e As MouseEventArgs) Handles picPlanner.MouseUp
        Dim point As Point = Cursor.Position
        detailPopup.MoveMoved(point)
    End Sub

    Private Sub btnPrintLsr_Click(sender As Object, e As EventArgs) Handles btnPrintLsr.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            If Helper.MakeIntegerValid(SelectedDataRow("JobTypeID")) = Enums.JobTypes.ServiceCertificate Or
                Helper.MakeIntegerValid(SelectedDataRow("JobTypeID")) = Enums.JobTypes.Service Or
                 Helper.MakeIntegerValid(SelectedDataRow("JobTypeID")) = Enums.JobTypes.Commission Then
            Else
                ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Helper.MakeIntegerValid(SelectedDataRow("OutcomeEnumID")) = Enums.EngineerVisitOutcomes.Complete Then
                Dim evId As Integer = Helper.MakeIntegerValid(SelectedDataRow("EngineerVisitId"))
                Dim details As New ArrayList
                details.Add(evId)
                details.Add(SelectedDataRow("CustomerID"))
                Dim oPrint As New Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR)
            Else
                ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReschedule_Click(sender As Object, e As EventArgs) Handles btnReschedule.Click
        Dim jobId As Integer = Helper.MakeIntegerValid(SelectedDataRow?.Item("JobID"))
        Dim engineerVisitId As Integer = Helper.MakeIntegerValid(SelectedDataRow?.Item("EngineerVisitID"))
        Dim statusId As Integer = Helper.MakeIntegerValid(SelectedDataRow?.Item("StatusEnumID"))
        If engineerVisitId = 0 Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Select Case statusId
            Case Enums.VisitStatus.Scheduled, Enums.VisitStatus.Downloaded
            Case Else
                ShowMessage("This visit cannot be rescheduled!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
        End Select

        Dim JobLock As Entity.JobLock.JobLock = DB.JobLock.Check(jobId)
        If Not JobLock Is Nothing Then
            Dim message As String = "This visit cannot be rescheduled because is it currently locked:" + vbCrLf
            message += String.Format("Locked by: {0}", JobLock.NameOfUserWhoLocked) + vbCrLf
            message += String.Format("Date Locked: {0}", JobLock.DateLock) + vbCrLf
            MessageBox.Show(message, "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim frmSm As frmSchedulerMain = Nothing
        For Each form As Form In Application.OpenForms
            If form.GetType Is GetType(frmSchedulerMain) Then
                frmSm = CType(form, frmSchedulerMain)
            End If
        Next

        Dim tabletActionId As Integer = DB.EngineerVisits.EngineerVisit_GetActionID(engineerVisitId)
        Dim errorMsg As String = frmSm?.scheduler.CanMoveDownloadedVisit(Me, engineerVisitId, tabletActionId)
        If statusId = Enums.VisitStatus.Scheduled Or String.IsNullOrEmpty(errorMsg) Then
            Using frmRescheduleVisit As New FRMRescheduleVisit(engineerVisitId)
                frmRescheduleVisit.ShowDialog()
            End Using
            frmSm?.scheduler.refreshScheduler()
        Else
            ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCreateJob_Click(sender As Object, e As EventArgs) Handles btnCreateJob.Click
        If SelectedDay() Is Nothing Then
            ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim frmSm As frmSchedulerMain = Nothing
        For Each form As Form In Application.OpenForms
            If form.GetType Is GetType(frmSchedulerMain) Then
                frmSm = CType(form, frmSchedulerMain)
            End If
        Next
        Using frmNewJob As New FRMNewJob(Helper.MakeDateTimeValid(SelectedDay()), EngineerID)
            frmNewJob.ShowDialog()
            frmSm?.scheduler.refreshScheduler()
        End Using
    End Sub

    Private Sub btnSiteReport_Click(sender As Object, e As EventArgs) Handles btnSiteReport.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit to open the site report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim oSite As Entity.Sites.Site = DB.Sites.Get(SelectedDataRow("SiteID"))

        If oSite Is Nothing OrElse Not oSite.Exists Then
            ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If loggedInUser.UserRegions.Table.Select("RegionID = " & oSite.RegionID).Length < 1 Then
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        PdfFactory.GenerateSiteHistoryReport(oSite)
    End Sub

    Private Sub dgDay_MouseUp(sender As Object, e As MouseEventArgs) Handles dgDay.MouseUp
        Me.ttStatus.Hide(Me.dgDay)
        If SelectedDataRow Is Nothing Then
            Exit Sub
        End If
        Dim msg As String = ""

        If SelectedDataRow.Table.Columns.Contains("IsJobLate") Then
            If Helper.MakeBooleanValid(SelectedDataRow("IsJobLate")) Then
                msg = "Engineer is running late to visit!"
            End If
        End If

        If SelectedDataRow.Table.Columns.Contains("IsServiceOverDue") Then
            If Helper.MakeBooleanValid(SelectedDataRow("IsServiceOverDue")) Then
                msg = "Service is overdue on site!"
            End If
        End If

        If SelectedDataRow.Table.Columns.Contains("Declined") Then
            If Helper.MakeBooleanValid(SelectedDataRow("Declined")) Then
                msg = "Visit has been declined!"
            End If
        End If

        If String.IsNullOrWhiteSpace(msg) Then Exit Sub

        Dim hittest As DataGrid.HitTestInfo = dgDay.HitTest(e.X, e.Y)
        If hittest.Type = DataGrid.HitTestType.Cell Then
            If hittest.Column = 0 Or hittest.Column = 1 Then
                Me.ttStatus.Show(msg, Me.dgDay, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub dgDay_MouseMove(sender As Object, e As MouseEventArgs) Handles dgDay.MouseMove
        Dim hittest As DataGrid.HitTestInfo = dgDay.HitTest(e.X, e.Y)
        If hittest.Type = DataGrid.HitTestType.Cell Then
            If hittest.Column <> 0 AndAlso hittest.Column <> 1 Then
                Me.ttStatus.Hide(Me.dgDay)
            End If
        Else
            Me.ttStatus.Hide(Me.dgDay)
        End If
    End Sub

    Private Sub imgEye_Click(sender As Object, e As EventArgs) Handles pbInfomation.Click
        If Engineer IsNot Nothing Then
            Dim dtEngineer As DataTable = Engineer.Table.Clone
            dtEngineer.Rows.Add(Engineer.ItemArray)

            Using frmViewEngineer As New FRMViewEngineer(dtEngineer)
                frmViewEngineer.ShowDialog()
            End Using
        End If

    End Sub

    Private Sub mnuVisitAction_Popup(sender As Object, e As EventArgs) Handles mnuVisitAction.Popup
        Dim visitStatus As Enums.VisitStatus = CType(Helper.MakeIntegerValid(SelectedDataRow("VisitStatusID")), Enums.VisitStatus)
        If visitStatus = Enums.VisitStatus.Scheduled Or visitStatus = Enums.VisitStatus.Downloaded Then
            btnTextMessage.Visible = True
            btnSolarInstallation.Visible = True
            btnElectricalAppointment.Visible = True
            EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(Helper.MakeIntegerValid(SelectedDataRow("EngineerVisitID")), False)

            If EngineerVisit?.ExcludeFromTextMessage Then
                btnTextMessage.Text = "Include in auto-messages"
            Else
                btnTextMessage.Text = "Exclude from auto-messages"
            End If

            If EngineerVisit.VisitNumber > 0 Or SelectedDataRow("JobTypeID") = CInt(Enums.JobTypes.ServiceCertificate) Or SelectedDataRow("JobTypeID") = CInt(Enums.JobTypes.Service) Then
                Me.btnServiceLetter.Visible = True
            Else
                Me.btnServiceLetter.Visible = False

            End If
        Else
            btnTextMessage.Visible = False
            btnServiceLetter.Visible = False
            btnSolarInstallation.Visible = False
            btnElectricalAppointment.Visible = False
        End If
    End Sub

    Private Sub btnTextMessage_Click(sender As Object, e As EventArgs) Handles btnTextMessage.Click
        If EngineerVisit IsNot Nothing Then
            EngineerVisit.SetExcludeFromTextMessage = Not EngineerVisit.ExcludeFromTextMessage
            DB.EngineerVisits.Update(EngineerVisit, 0, True)
        End If
    End Sub

    Private Sub btnServiceLetter_Click(sender As Object, e As EventArgs) Handles btnServiceLetter.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SendToPrint()
    End Sub

    Private Sub btnSolarInstallation_Click(sender As Object, e As EventArgs) Handles btnSolarInstallation.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SendToPrint("\ServiceLetters\SolarAppointment.docx")

    End Sub

    Private Sub btnElectricalAppointment_Click(sender As Object, e As EventArgs) Handles btnElectricalAppointment.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SendToPrint("\ServiceLetters\ElectricalTestingLetter.docx")

    End Sub

End Class