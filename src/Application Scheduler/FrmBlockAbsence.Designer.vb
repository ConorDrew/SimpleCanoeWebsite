<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBlockAbsence
    : Inherits FRMBaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtEndTimeMinutes = New System.Windows.Forms.TextBox
        Me.txtEndTimeHours = New System.Windows.Forms.TextBox
        Me.txtStartTimeMinutes = New System.Windows.Forms.TextBox
        Me.txtStartTimeHours = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.lblToDate = New System.Windows.Forms.Label
        Me.lblFromDate = New System.Windows.Forms.Label
        Me.lblComments = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbEmployees = New System.Windows.Forms.GroupBox
        Me.cboEmployeeGroup = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.btnClearAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.dgEmployees = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        Me.gbEmployees.SuspendLayout()
        CType(Me.dgEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtEndTimeMinutes)
        Me.GroupBox1.Controls.Add(Me.txtEndTimeHours)
        Me.GroupBox1.Controls.Add(Me.txtStartTimeMinutes)
        Me.GroupBox1.Controls.Add(Me.txtStartTimeHours)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblType)
        Me.GroupBox1.Controls.Add(Me.cboType)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.txtComments)
        Me.GroupBox1.Controls.Add(Me.lblToDate)
        Me.GroupBox1.Controls.Add(Me.lblFromDate)
        Me.GroupBox1.Controls.Add(Me.lblComments)

        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 371)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 153)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Absence Details"
        '
        'txtEndTimeMinutes
        '
        Me.txtEndTimeMinutes.Location = New System.Drawing.Point(288, 88)
        Me.txtEndTimeMinutes.Name = "txtEndTimeMinutes"
        Me.txtEndTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeMinutes.TabIndex = 53
        '
        'txtEndTimeHours
        '
        Me.txtEndTimeHours.Location = New System.Drawing.Point(256, 88)
        Me.txtEndTimeHours.Name = "txtEndTimeHours"
        Me.txtEndTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtEndTimeHours.TabIndex = 52
        '
        'txtStartTimeMinutes
        '
        Me.txtStartTimeMinutes.Location = New System.Drawing.Point(288, 56)
        Me.txtStartTimeMinutes.Name = "txtStartTimeMinutes"
        Me.txtStartTimeMinutes.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeMinutes.TabIndex = 51
        '
        'txtStartTimeHours
        '
        Me.txtStartTimeHours.Location = New System.Drawing.Point(256, 56)
        Me.txtStartTimeHours.Name = "txtStartTimeHours"
        Me.txtStartTimeHours.Size = New System.Drawing.Size(24, 20)
        Me.txtStartTimeHours.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(280, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 17)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 17)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = ":"
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblType.Location = New System.Drawing.Point(8, 24)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(70, 17)
        Me.lblType.TabIndex = 37
        Me.lblType.Text = "Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboType.ItemHeight = 13
        Me.cboType.Items.AddRange(New Object() {"Holiday", "Sickness", "Other"})
        Me.cboType.Location = New System.Drawing.Point(80, 24)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(232, 21)
        Me.cboType.TabIndex = 2
        '
        'dtTo
        '
        Me.dtTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtTo.Location = New System.Drawing.Point(80, 88)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(173, 20)
        Me.dtTo.TabIndex = 6
        '
        'dtFrom
        '
        Me.dtFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtFrom.Location = New System.Drawing.Point(80, 56)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(172, 20)
        Me.dtFrom.TabIndex = 3
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtComments.Location = New System.Drawing.Point(320, 43)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComments.Size = New System.Drawing.Size(296, 96)
        Me.txtComments.TabIndex = 9
        '
        'lblToDate
        '
        Me.lblToDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblToDate.Location = New System.Drawing.Point(8, 88)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(46, 18)
        Me.lblToDate.TabIndex = 20
        Me.lblToDate.Text = "To"
        '
        'lblFromDate
        '
        Me.lblFromDate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblFromDate.Location = New System.Drawing.Point(8, 56)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(69, 18)
        Me.lblFromDate.TabIndex = 19
        Me.lblFromDate.Text = "From"
        '
        'lblComments
        '
        Me.lblComments.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblComments.Location = New System.Drawing.Point(320, 22)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(72, 17)
        Me.lblComments.TabIndex = 23
        Me.lblComments.Text = "Comments"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSave.Location = New System.Drawing.Point(572, 529)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 23)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCancel.Location = New System.Drawing.Point(4, 529)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'gbEmployees
        '
        Me.gbEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEmployees.Controls.Add(Me.cboEmployeeGroup)
        Me.gbEmployees.Controls.Add(Me.Label24)
        Me.gbEmployees.Controls.Add(Me.btnClearAll)
        Me.gbEmployees.Controls.Add(Me.btnSelectAll)
        Me.gbEmployees.Controls.Add(Me.dgEmployees)

        Me.gbEmployees.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.gbEmployees.Location = New System.Drawing.Point(12, 38)
        Me.gbEmployees.Name = "gbEmployees"
        Me.gbEmployees.Size = New System.Drawing.Size(624, 327)
        Me.gbEmployees.TabIndex = 29
        Me.gbEmployees.TabStop = False
        Me.gbEmployees.Text = "Employees"
        '
        'cboEmployeeGroup
        '
        Me.cboEmployeeGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEmployeeGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEmployeeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeGroup.Items.AddRange(New Object() {"Engineers", "Users"})
        Me.cboEmployeeGroup.Location = New System.Drawing.Point(118, 14)
        Me.cboEmployeeGroup.Name = "cboEmployeeGroup"
        Me.cboEmployeeGroup.Size = New System.Drawing.Size(322, 21)
        Me.cboEmployeeGroup.TabIndex = 46
        Me.cboEmployeeGroup.Tag = ""
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(6, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 47
        Me.Label24.Text = "Employee Group"
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.UseVisualStyleBackColor = True
        Me.btnClearAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClearAll.Location = New System.Drawing.Point(80, 293)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(64, 23)
        Me.btnClearAll.TabIndex = 3
        Me.btnClearAll.Text = "Clear All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.UseVisualStyleBackColor = True
        Me.btnSelectAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSelectAll.Location = New System.Drawing.Point(10, 293)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(64, 23)
        Me.btnSelectAll.TabIndex = 2
        Me.btnSelectAll.Text = "Select All"
        '
        'dgEmployees
        '
        Me.dgEmployees.AllowNavigation = False
        Me.dgEmployees.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEmployees.BackgroundColor = System.Drawing.Color.White
        Me.dgEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgEmployees.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgEmployees.CaptionForeColor = System.Drawing.Color.White
        Me.dgEmployees.CaptionText = "Engineers"
        Me.dgEmployees.CaptionVisible = False
        Me.dgEmployees.DataMember = ""
        Me.dgEmployees.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dgEmployees.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgEmployees.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgEmployees.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgEmployees.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgEmployees.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgEmployees.LinkColor = System.Drawing.Color.Teal
        Me.dgEmployees.Location = New System.Drawing.Point(10, 41)
        Me.dgEmployees.Name = "dgEmployees"
        Me.dgEmployees.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgEmployees.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgEmployees.ParentRowsVisible = False
        Me.dgEmployees.RowHeadersVisible = False
        Me.dgEmployees.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgEmployees.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgEmployees.Size = New System.Drawing.Size(605, 243)
        Me.dgEmployees.TabIndex = 1
        '
        'FrmBlockAbsence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 558)
        Me.Controls.Add(Me.gbEmployees)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(656, 592)
        Me.Name = "FrmBlockAbsence"
        Me.Text = "Block Absences"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.gbEmployees, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEmployees.ResumeLayout(False)
        CType(Me.dgEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEndTimeMinutes As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTimeHours As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTimeMinutes As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTimeHours As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbEmployees As System.Windows.Forms.GroupBox
    Friend WithEvents cboEmployeeGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents dgEmployees As System.Windows.Forms.DataGrid
End Class
