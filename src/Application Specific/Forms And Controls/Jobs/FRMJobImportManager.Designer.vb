<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMJobImportManager : Inherits FSM.FRMBaseForm : Implements IForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgJobs = New System.Windows.Forms.DataGrid()
        Me.btnResetFilters = New System.Windows.Forms.Button()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.chkSortPostcode = New System.Windows.Forms.CheckBox()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.txtJobsPerDay = New System.Windows.Forms.TextBox()
        Me.cboLetterNumber = New System.Windows.Forms.ComboBox()
        Me.lblJobsPerDay = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpLetterCreateDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnGenerateLetters = New System.Windows.Forms.Button()
        Me.chkScheduleJobs = New System.Windows.Forms.CheckBox()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.cmsAction = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiDeleteSite = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCreateJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.cmsAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgJobs)
        Me.grpJobs.Location = New System.Drawing.Point(12, 154)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(962, 271)
        Me.grpJobs.TabIndex = 3
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Jobs"
        '
        'dgJobs
        '
        Me.dgJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobs.DataMember = ""
        Me.dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobs.Location = New System.Drawing.Point(8, 20)
        Me.dgJobs.Name = "dgJobs"
        Me.dgJobs.Size = New System.Drawing.Size(946, 243)
        Me.dgJobs.TabIndex = 14
        '
        'btnResetFilters
        '
        Me.btnResetFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnResetFilters.Location = New System.Drawing.Point(20, 431)
        Me.btnResetFilters.Name = "btnResetFilters"
        Me.btnResetFilters.Size = New System.Drawing.Size(111, 23)
        Me.btnResetFilters.TabIndex = 4
        Me.btnResetFilters.Text = "Reset Filters"
        Me.btnResetFilters.UseVisualStyleBackColor = True
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.chkSortPostcode)
        Me.grpFilters.Controls.Add(Me.cboJobType)
        Me.grpFilters.Controls.Add(Me.lblJobType)
        Me.grpFilters.Controls.Add(Me.txtJobsPerDay)
        Me.grpFilters.Controls.Add(Me.cboLetterNumber)
        Me.grpFilters.Controls.Add(Me.lblJobsPerDay)
        Me.grpFilters.Controls.Add(Me.Label14)
        Me.grpFilters.Controls.Add(Me.btnFilter)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.dtpLetterCreateDate)
        Me.grpFilters.Location = New System.Drawing.Point(12, 38)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(962, 81)
        Me.grpFilters.TabIndex = 5
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'chkSortPostcode
        '
        Me.chkSortPostcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSortPostcode.AutoSize = True
        Me.chkSortPostcode.Checked = True
        Me.chkSortPostcode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSortPostcode.Location = New System.Drawing.Point(440, 49)
        Me.chkSortPostcode.Name = "chkSortPostcode"
        Me.chkSortPostcode.Size = New System.Drawing.Size(123, 17)
        Me.chkSortPostcode.TabIndex = 46
        Me.chkSortPostcode.Text = "Sort by postcode"
        Me.chkSortPostcode.UseVisualStyleBackColor = True
        '
        'cboJobType
        '
        Me.cboJobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Location = New System.Drawing.Point(258, 47)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(167, 21)
        Me.cboJobType.TabIndex = 43
        Me.cboJobType.Tag = "Site.RegionID"
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(178, 50)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(62, 13)
        Me.lblJobType.TabIndex = 42
        Me.lblJobType.Text = "Job Type:"
        '
        'txtJobsPerDay
        '
        Me.txtJobsPerDay.Location = New System.Drawing.Point(94, 47)
        Me.txtJobsPerDay.Name = "txtJobsPerDay"
        Me.txtJobsPerDay.Size = New System.Drawing.Size(53, 21)
        Me.txtJobsPerDay.TabIndex = 5
        Me.txtJobsPerDay.Text = "32"
        '
        'cboLetterNumber
        '
        Me.cboLetterNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetterNumber.Location = New System.Drawing.Point(424, 14)
        Me.cboLetterNumber.Name = "cboLetterNumber"
        Me.cboLetterNumber.Size = New System.Drawing.Size(324, 21)
        Me.cboLetterNumber.TabIndex = 41
        '
        'lblJobsPerDay
        '
        Me.lblJobsPerDay.AutoSize = True
        Me.lblJobsPerDay.Location = New System.Drawing.Point(6, 50)
        Me.lblJobsPerDay.Name = "lblJobsPerDay"
        Me.lblJobsPerDay.Size = New System.Drawing.Size(82, 13)
        Me.lblJobsPerDay.TabIndex = 4
        Me.lblJobsPerDay.Text = "Jobs Per Day"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(360, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Letter No."
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(879, 39)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 30
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Letter Create Date"
        '
        'dtpLetterCreateDate
        '
        Me.dtpLetterCreateDate.Location = New System.Drawing.Point(142, 12)
        Me.dtpLetterCreateDate.Name = "dtpLetterCreateDate"
        Me.dtpLetterCreateDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpLetterCreateDate.TabIndex = 28
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(12, 125)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(119, 23)
        Me.btnSelectAll.TabIndex = 6
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnUnselect
        '
        Me.btnUnselect.Location = New System.Drawing.Point(154, 125)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 7
        Me.btnUnselect.Text = "Unselect All"
        Me.btnUnselect.UseVisualStyleBackColor = True
        '
        'btnGenerateLetters
        '
        Me.btnGenerateLetters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateLetters.Location = New System.Drawing.Point(808, 431)
        Me.btnGenerateLetters.Name = "btnGenerateLetters"
        Me.btnGenerateLetters.Size = New System.Drawing.Size(158, 23)
        Me.btnGenerateLetters.TabIndex = 8
        Me.btnGenerateLetters.Text = "Generate Jobs"
        Me.btnGenerateLetters.UseVisualStyleBackColor = True
        '
        'chkScheduleJobs
        '
        Me.chkScheduleJobs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkScheduleJobs.AutoSize = True
        Me.chkScheduleJobs.Checked = True
        Me.chkScheduleJobs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScheduleJobs.Location = New System.Drawing.Point(867, 131)
        Me.chkScheduleJobs.Name = "chkScheduleJobs"
        Me.chkScheduleJobs.Size = New System.Drawing.Size(107, 17)
        Me.chkScheduleJobs.TabIndex = 45
        Me.chkScheduleJobs.Text = "Schedule Jobs"
        Me.chkScheduleJobs.UseVisualStyleBackColor = True
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.Location = New System.Drawing.Point(137, 431)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(111, 23)
        Me.btnFindSite.TabIndex = 46
        Me.btnFindSite.Text = "Find Site"
        Me.btnFindSite.UseVisualStyleBackColor = True
        '
        'cmsAction
        '
        Me.cmsAction.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiDeleteSite, Me.tsmiCreateJob})
        Me.cmsAction.Name = "cmsAction"
        Me.cmsAction.Size = New System.Drawing.Size(130, 48)
        '
        'tsmiDeleteSite
        '
        Me.tsmiDeleteSite.Name = "tsmiDeleteSite"
        Me.tsmiDeleteSite.Size = New System.Drawing.Size(129, 22)
        Me.tsmiDeleteSite.Text = "Delete Site"
        '
        'tsmiCreateJob
        '
        Me.tsmiCreateJob.Name = "tsmiCreateJob"
        Me.tsmiCreateJob.Size = New System.Drawing.Size(129, 22)
        Me.tsmiCreateJob.Text = "Create Job"
        '
        'FRMJobImportManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 466)
        Me.Controls.Add(Me.btnFindSite)
        Me.Controls.Add(Me.chkScheduleJobs)
        Me.Controls.Add(Me.btnGenerateLetters)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.btnResetFilters)
        Me.Controls.Add(Me.grpJobs)
        Me.Name = "FRMJobImportManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Letter Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnResetFilters, 0)
        Me.Controls.SetChildIndex(Me.grpFilters, 0)
        Me.Controls.SetChildIndex(Me.btnSelectAll, 0)
        Me.Controls.SetChildIndex(Me.btnUnselect, 0)
        Me.Controls.SetChildIndex(Me.btnGenerateLetters, 0)
        Me.Controls.SetChildIndex(Me.chkScheduleJobs, 0)
        Me.Controls.SetChildIndex(Me.btnFindSite, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.cmsAction.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dgJobs As System.Windows.Forms.DataGrid
    Friend WithEvents btnResetFilters As System.Windows.Forms.Button
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLetterCreateDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents btnGenerateLetters As System.Windows.Forms.Button
    Friend WithEvents cboLetterNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtJobsPerDay As System.Windows.Forms.TextBox
    Friend WithEvents lblJobsPerDay As System.Windows.Forms.Label
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents chkScheduleJobs As CheckBox
    Friend WithEvents chkSortPostcode As CheckBox
    Friend WithEvents btnFindSite As Button
    Friend WithEvents cmsAction As ContextMenuStrip
    Friend WithEvents tsmiDeleteSite As ToolStripMenuItem
    Friend WithEvents tsmiCreateJob As ToolStripMenuItem
End Class
