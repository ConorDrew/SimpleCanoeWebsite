Public Class pnlScheduleControl
    Inherits UserControl
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnAbsenceLegend As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnForward As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTextSize As System.Windows.Forms.TextBox
    Friend WithEvents btnTextApply As System.Windows.Forms.Button
    Friend WithEvents btnFind As Button
    Friend WithEvents btnNewJob As Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        If loggedInUser.SchedulerTextSize > 0 Then
            txtTextSize.Text = loggedInUser.SchedulerTextSize
            textsize = txtTextSize.Text
        Else
            txtTextSize.Text = 8
            textsize = txtTextSize.Text
        End If
    End Sub

    Public Event dateRangeChanged(ByVal fromDate As Date, ByVal toDate As Date)

    Public Event refreshScheduler()

    Public Event closeScheduler()

    Public Event displayEngineers()

    Public Event loadEngineerSchedules(ByVal fromDate As Date, ByVal toDate As Date)

    Public Event ResizeSchedulingArea()

    Private _datesString As String = String.Empty
    Public textsize As Integer = 0

    Public Property dateFrom() As DateTime
        Get
            Return dtpFromDate.Value
        End Get
        Set(ByVal Value As DateTime)
            dtpFromDate.Value = Value
        End Set
    End Property

    Public Property dateTo() As DateTime
        Get
            Return dtpToDate.Value
        End Get
        Set(ByVal Value As DateTime)
            dtpToDate.Value = Value
        End Set
    End Property

    Public ReadOnly Property datesString() As String
        Get
            If _datesString = String.Empty Then

                'This will always have one iteration
                For dayCount As Integer = 0 To dateTo.Date.Subtract(dateFrom.Date).Days
                    If dayCount = 0 Then
                        _datesString += Format(dateFrom.AddDays(dayCount).Date, "yyyy-MM-dd")
                    Else
                        _datesString += "," & Format(dateFrom.AddDays(dayCount).Date, "yyyy-MM-dd")
                    End If
                Next
            End If
            Return _datesString
        End Get
    End Property

    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents picBoxCal1 As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxCal2 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlControls As System.Windows.Forms.Panel
    Friend WithEvents btnDisplayEngineers As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pnlScheduleControl))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlControls = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.picBoxCal1 = New System.Windows.Forms.PictureBox()
        Me.picBoxCal2 = New System.Windows.Forms.PictureBox()
        Me.btnDisplayEngineers = New System.Windows.Forms.Button()
        Me.btnAbsenceLegend = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTextSize = New System.Windows.Forms.TextBox()
        Me.btnTextApply = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnNewJob = New System.Windows.Forms.Button()
        Me.pnlControls.SuspendLayout()
        CType(Me.picBoxCal1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxCal2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1306, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Location = New System.Drawing.Point(128, 4)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(144, 21)
        Me.dtpFromDate.TabIndex = 1
        '
        'dtpToDate
        '
        Me.dtpToDate.Location = New System.Drawing.Point(296, 4)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(144, 21)
        Me.dtpToDate.TabIndex = 2
        '
        'lblFromDate
        '
        Me.lblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.lblFromDate.Location = New System.Drawing.Point(56, 8)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(76, 14)
        Me.lblFromDate.TabIndex = 3
        Me.lblFromDate.Text = "Diary From"
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.lblTo.Location = New System.Drawing.Point(272, 8)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(24, 16)
        Me.lblTo.TabIndex = 4
        Me.lblTo.Text = "To"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(1244, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(56, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'pnlControls
        '
        Me.pnlControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlControls.Controls.Add(Me.btnBack)
        Me.pnlControls.Controls.Add(Me.btnForward)
        Me.pnlControls.Controls.Add(Me.btnGo)
        Me.pnlControls.Controls.Add(Me.dtpFromDate)
        Me.pnlControls.Controls.Add(Me.dtpToDate)
        Me.pnlControls.Controls.Add(Me.lblFromDate)
        Me.pnlControls.Controls.Add(Me.lblTo)
        Me.pnlControls.Location = New System.Drawing.Point(447, 0)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Size = New System.Drawing.Size(564, 30)
        Me.pnlControls.TabIndex = 7
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(14, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(36, 23)
        Me.btnBack.TabIndex = 7
        Me.btnBack.Text = "<<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(494, 3)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(36, 23)
        Me.btnForward.TabIndex = 6
        Me.btnForward.Text = ">>"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(452, 3)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(36, 23)
        Me.btnGo.TabIndex = 5
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'picBoxCal1
        '
        Me.picBoxCal1.Image = CType(resources.GetObject("picBoxCal1.Image"), System.Drawing.Image)
        Me.picBoxCal1.Location = New System.Drawing.Point(0, 0)
        Me.picBoxCal1.Name = "picBoxCal1"
        Me.picBoxCal1.Size = New System.Drawing.Size(120, 32)
        Me.picBoxCal1.TabIndex = 8
        Me.picBoxCal1.TabStop = False
        '
        'picBoxCal2
        '
        Me.picBoxCal2.Image = CType(resources.GetObject("picBoxCal2.Image"), System.Drawing.Image)
        Me.picBoxCal2.Location = New System.Drawing.Point(117, 0)
        Me.picBoxCal2.Name = "picBoxCal2"
        Me.picBoxCal2.Size = New System.Drawing.Size(267, 30)
        Me.picBoxCal2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxCal2.TabIndex = 9
        Me.picBoxCal2.TabStop = False
        '
        'btnDisplayEngineers
        '
        Me.btnDisplayEngineers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDisplayEngineers.Location = New System.Drawing.Point(1182, 3)
        Me.btnDisplayEngineers.Name = "btnDisplayEngineers"
        Me.btnDisplayEngineers.Size = New System.Drawing.Size(56, 23)
        Me.btnDisplayEngineers.TabIndex = 3
        Me.btnDisplayEngineers.Text = "Display"
        Me.btnDisplayEngineers.UseVisualStyleBackColor = True
        '
        'btnAbsenceLegend
        '
        Me.btnAbsenceLegend.Location = New System.Drawing.Point(3, 3)
        Me.btnAbsenceLegend.Name = "btnAbsenceLegend"
        Me.btnAbsenceLegend.Size = New System.Drawing.Size(135, 23)
        Me.btnAbsenceLegend.TabIndex = 10
        Me.btnAbsenceLegend.Text = "Absence Colour Key"
        Me.btnAbsenceLegend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(162, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Text Size 6-12"
        '
        'txtTextSize
        '
        Me.txtTextSize.Location = New System.Drawing.Point(257, 5)
        Me.txtTextSize.Name = "txtTextSize"
        Me.txtTextSize.Size = New System.Drawing.Size(41, 21)
        Me.txtTextSize.TabIndex = 12
        '
        'btnTextApply
        '
        Me.btnTextApply.Location = New System.Drawing.Point(316, 4)
        Me.btnTextApply.Name = "btnTextApply"
        Me.btnTextApply.Size = New System.Drawing.Size(47, 23)
        Me.btnTextApply.TabIndex = 13
        Me.btnTextApply.Text = "Apply"
        Me.btnTextApply.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(1120, 3)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(56, 23)
        Me.btnFind.TabIndex = 14
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnNewJob
        '
        Me.btnNewJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewJob.Location = New System.Drawing.Point(1052, 3)
        Me.btnNewJob.Name = "btnNewJob"
        Me.btnNewJob.Size = New System.Drawing.Size(62, 23)
        Me.btnNewJob.TabIndex = 15
        Me.btnNewJob.Text = "New Job"
        Me.btnNewJob.UseVisualStyleBackColor = True
        '
        'pnlScheduleControl
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnNewJob)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.btnTextApply)
        Me.Controls.Add(Me.txtTextSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAbsenceLegend)
        Me.Controls.Add(Me.pnlControls)
        Me.Controls.Add(Me.btnDisplayEngineers)
        Me.Controls.Add(Me.picBoxCal2)
        Me.Controls.Add(Me.picBoxCal1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "pnlScheduleControl"
        Me.Size = New System.Drawing.Size(1370, 30)
        Me.pnlControls.ResumeLayout(False)
        CType(Me.picBoxCal1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxCal2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dtpToDate.MinDate = dtpFromDate.Value
        _datesString = String.Empty

        RaiseEvent refreshScheduler()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        RaiseEvent closeScheduler()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        pnlControls.Left = CInt((Me.Width / 2) - (pnlControls.Width / 2))
        picBoxCal2.Width = CInt(Me.Width * 0.21) - picBoxCal1.Width
    End Sub

    Private Sub btnDisplayEngineers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayEngineers.Click
        RaiseEvent displayEngineers()
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub btnWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpFromDate.Value = Now
        dtpToDate.Value = Now.AddDays(7)
    End Sub

    Private Sub btnMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpFromDate.Value = Now
        dtpToDate.Value = Now.AddMonths(1)
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        dtpToDate.MinDate = dtpFromDate.Value
        _datesString = String.Empty

        RaiseEvent dateRangeChanged(dtpFromDate.Value, dtpToDate.Value)
    End Sub

    Private Sub btnAbsenceLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbsenceLegend.Click
        Dim f As New FRMAbsenceColourKey
        f.ShowDialog()
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        dtpFromDate.Value = dtpFromDate.Value.AddDays(1).ToString("dd/MM/yyyy")
        dtpToDate.Value = dtpToDate.Value.AddDays(1).ToString("dd/MM/yyyy")
        _datesString = String.Empty
        RaiseEvent dateRangeChanged(dtpFromDate.Value, dtpToDate.Value)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        dtpFromDate.Value = dtpFromDate.Value.AddDays(-1).ToString("dd/MM/yyyy")
        dtpToDate.Value = dtpToDate.Value.AddDays(-1).ToString("dd/MM/yyyy")
        _datesString = String.Empty
        RaiseEvent dateRangeChanged(dtpFromDate.Value, dtpToDate.Value)
    End Sub

    Private Sub btnTextApply_Click(sender As Object, e As EventArgs) Handles btnTextApply.Click
        If txtTextSize.Text.Length > 0 AndAlso IsNumeric(txtTextSize.Text) AndAlso txtTextSize.Text > 5 And txtTextSize.Text < 13 Then
            DB.User.User_Update_TextSize(loggedInUser.UserID, CInt(txtTextSize.Text))
            loggedInUser.SetSchedulerTextSize = CInt(txtTextSize.Text)
            textsize = txtTextSize.Text
            RaiseEvent ResizeSchedulingArea()
        Else
            ShowMessage("Please enter a valid text Size", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim frmFind As New FRMSchedulerFind
        frmFind.ShowDialog()
    End Sub

    Private Sub btnNewJob_Click(sender As Object, e As EventArgs) Handles btnNewJob.Click
        Using frmNewJob As New FRMNewJob()
            frmNewJob.ShowDialog()
        End Using
        RaiseEvent refreshScheduler()
    End Sub

End Class