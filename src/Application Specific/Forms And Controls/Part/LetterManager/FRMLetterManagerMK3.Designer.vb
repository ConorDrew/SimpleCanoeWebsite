<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMLetterManagerMK3 : Inherits FSM.FRMBaseForm : Implements IForm

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
        Me.grpServices = New System.Windows.Forms.GroupBox()
        Me.dgServicesDue = New System.Windows.Forms.DataGrid()
        Me.btnResetFilters = New System.Windows.Forms.Button()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.chkIncludePatchChecks = New System.Windows.Forms.CheckBox()
        Me.chkVoidProperty = New System.Windows.Forms.CheckBox()
        Me.chkLastService = New System.Windows.Forms.CheckBox()
        Me.txtTravelBetween = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMaxTravel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLettersOnly = New System.Windows.Forms.CheckBox()
        Me.tbMinsPerDay = New System.Windows.Forms.TextBox()
        Me.cboLetterNumber = New System.Windows.Forms.ComboBox()
        Me.lbMinsPerDay = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpLetterCreateDate = New System.Windows.Forms.DateTimePicker()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnGenerateLetters = New System.Windows.Forms.Button()
        Me.btnReleaseLockedSites = New System.Windows.Forms.Button()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.grpServices.SuspendLayout()
        CType(Me.dgServicesDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpServices
        '
        Me.grpServices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpServices.Controls.Add(Me.dgServicesDue)
        Me.grpServices.Location = New System.Drawing.Point(12, 180)
        Me.grpServices.Name = "grpServices"
        Me.grpServices.Size = New System.Drawing.Size(1264, 383)
        Me.grpServices.TabIndex = 3
        Me.grpServices.TabStop = False
        Me.grpServices.Text = "Services Due"
        '
        'dgServicesDue
        '
        Me.dgServicesDue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgServicesDue.DataMember = ""
        Me.dgServicesDue.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgServicesDue.Location = New System.Drawing.Point(16, 20)
        Me.dgServicesDue.Name = "dgServicesDue"
        Me.dgServicesDue.Size = New System.Drawing.Size(1248, 355)
        Me.dgServicesDue.TabIndex = 14
        '
        'btnResetFilters
        '
        Me.btnResetFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnResetFilters.Location = New System.Drawing.Point(20, 569)
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
        Me.grpFilters.Controls.Add(Me.chkIncludePatchChecks)
        Me.grpFilters.Controls.Add(Me.chkVoidProperty)
        Me.grpFilters.Controls.Add(Me.chkLastService)
        Me.grpFilters.Controls.Add(Me.txtTravelBetween)
        Me.grpFilters.Controls.Add(Me.Label3)
        Me.grpFilters.Controls.Add(Me.txtMaxTravel)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.chkLettersOnly)
        Me.grpFilters.Controls.Add(Me.tbMinsPerDay)
        Me.grpFilters.Controls.Add(Me.cboLetterNumber)
        Me.grpFilters.Controls.Add(Me.lbMinsPerDay)
        Me.grpFilters.Controls.Add(Me.Label14)
        Me.grpFilters.Controls.Add(Me.btnFilter)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.dtpLetterCreateDate)
        Me.grpFilters.Controls.Add(Me.btnFindCustomer)
        Me.grpFilters.Controls.Add(Me.txtCustomer)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Location = New System.Drawing.Point(12, 38)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(1264, 107)
        Me.grpFilters.TabIndex = 5
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'chkIncludePatchChecks
        '
        Me.chkIncludePatchChecks.AutoSize = True
        Me.chkIncludePatchChecks.Location = New System.Drawing.Point(911, 78)
        Me.chkIncludePatchChecks.Name = "chkIncludePatchChecks"
        Me.chkIncludePatchChecks.Size = New System.Drawing.Size(149, 17)
        Me.chkIncludePatchChecks.TabIndex = 50
        Me.chkIncludePatchChecks.Text = "Include Patch Checks"
        Me.chkIncludePatchChecks.UseVisualStyleBackColor = True
        '
        'chkVoidProperty
        '
        Me.chkVoidProperty.AutoSize = True
        Me.chkVoidProperty.Checked = True
        Me.chkVoidProperty.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVoidProperty.Location = New System.Drawing.Point(755, 78)
        Me.chkVoidProperty.Name = "chkVoidProperty"
        Me.chkVoidProperty.Size = New System.Drawing.Size(147, 17)
        Me.chkVoidProperty.TabIndex = 49
        Me.chkVoidProperty.Text = "Show Void Properties"
        Me.chkVoidProperty.UseVisualStyleBackColor = True
        '
        'chkLastService
        '
        Me.chkLastService.AutoSize = True
        Me.chkLastService.Location = New System.Drawing.Point(755, 51)
        Me.chkLastService.Name = "chkLastService"
        Me.chkLastService.Size = New System.Drawing.Size(150, 17)
        Me.chkLastService.TabIndex = 48
        Me.chkLastService.Text = "Prioritise Last Service"
        Me.chkLastService.UseVisualStyleBackColor = True
        '
        'txtTravelBetween
        '
        Me.txtTravelBetween.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtTravelBetween.Location = New System.Drawing.Point(686, 76)
        Me.txtTravelBetween.Name = "txtTravelBetween"
        Me.txtTravelBetween.Size = New System.Drawing.Size(53, 21)
        Me.txtTravelBetween.TabIndex = 46
        Me.txtTravelBetween.Text = "10"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(465, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(206, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Max Travel Between AM/PM (Miles)"
        '
        'txtMaxTravel
        '
        Me.txtMaxTravel.Location = New System.Drawing.Point(390, 76)
        Me.txtMaxTravel.Name = "txtMaxTravel"
        Me.txtMaxTravel.Size = New System.Drawing.Size(53, 21)
        Me.txtMaxTravel.TabIndex = 44
        Me.txtMaxTravel.Text = "5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Max Travel Per Period (Miles)"
        '
        'chkLettersOnly
        '
        Me.chkLettersOnly.AutoSize = True
        Me.chkLettersOnly.Location = New System.Drawing.Point(911, 51)
        Me.chkLettersOnly.Name = "chkLettersOnly"
        Me.chkLettersOnly.Size = New System.Drawing.Size(161, 17)
        Me.chkLettersOnly.TabIndex = 42
        Me.chkLettersOnly.Text = "Print Booked Visits only"
        Me.chkLettersOnly.UseVisualStyleBackColor = True
        '
        'tbMinsPerDay
        '
        Me.tbMinsPerDay.Location = New System.Drawing.Point(142, 76)
        Me.tbMinsPerDay.Name = "tbMinsPerDay"
        Me.tbMinsPerDay.Size = New System.Drawing.Size(53, 21)
        Me.tbMinsPerDay.TabIndex = 5
        Me.tbMinsPerDay.Text = "275"
        '
        'cboLetterNumber
        '
        Me.cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetterNumber.Location = New System.Drawing.Point(368, 50)
        Me.cboLetterNumber.Name = "cboLetterNumber"
        Me.cboLetterNumber.Size = New System.Drawing.Size(371, 21)
        Me.cboLetterNumber.TabIndex = 41
        '
        'lbMinsPerDay
        '
        Me.lbMinsPerDay.AutoSize = True
        Me.lbMinsPerDay.Location = New System.Drawing.Point(6, 79)
        Me.lbMinsPerDay.Name = "lbMinsPerDay"
        Me.lbMinsPerDay.Size = New System.Drawing.Size(132, 13)
        Me.lbMinsPerDay.TabIndex = 4
        Me.lbMinsPerDay.Text = "Working Mins Per Day"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(296, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 16)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Letter No."
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(1181, 74)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 30
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Letter Create Date"
        '
        'dtpLetterCreateDate
        '
        Me.dtpLetterCreateDate.Location = New System.Drawing.Point(142, 50)
        Me.dtpLetterCreateDate.Name = "dtpLetterCreateDate"
        Me.dtpLetterCreateDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpLetterCreateDate.TabIndex = 28
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(1224, 20)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 26
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(142, 22)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(1076, 21)
        Me.txtCustomer.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Customer"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(12, 151)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(119, 23)
        Me.btnSelectAll.TabIndex = 6
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnUnselect
        '
        Me.btnUnselect.Location = New System.Drawing.Point(154, 151)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 7
        Me.btnUnselect.Text = "Unselect All"
        Me.btnUnselect.UseVisualStyleBackColor = True
        '
        'btnGenerateLetters
        '
        Me.btnGenerateLetters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateLetters.Location = New System.Drawing.Point(1110, 569)
        Me.btnGenerateLetters.Name = "btnGenerateLetters"
        Me.btnGenerateLetters.Size = New System.Drawing.Size(158, 23)
        Me.btnGenerateLetters.TabIndex = 8
        Me.btnGenerateLetters.Text = "Generate Letters"
        Me.btnGenerateLetters.UseVisualStyleBackColor = True
        '
        'btnReleaseLockedSites
        '
        Me.btnReleaseLockedSites.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReleaseLockedSites.Location = New System.Drawing.Point(137, 569)
        Me.btnReleaseLockedSites.Name = "btnReleaseLockedSites"
        Me.btnReleaseLockedSites.Size = New System.Drawing.Size(139, 23)
        Me.btnReleaseLockedSites.TabIndex = 9
        Me.btnReleaseLockedSites.Text = "Release Locked Sites"
        Me.btnReleaseLockedSites.UseVisualStyleBackColor = True
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.Location = New System.Drawing.Point(285, 569)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(111, 23)
        Me.btnFindSite.TabIndex = 47
        Me.btnFindSite.Text = "Find Site"
        Me.btnFindSite.UseVisualStyleBackColor = True
        '
        'FRMLetterManagerMK3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1288, 604)
        Me.Controls.Add(Me.btnFindSite)
        Me.Controls.Add(Me.btnReleaseLockedSites)
        Me.Controls.Add(Me.btnGenerateLetters)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.btnResetFilters)
        Me.Controls.Add(Me.grpServices)
        Me.Name = "FRMLetterManagerMK3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Letter Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpServices, 0)
        Me.Controls.SetChildIndex(Me.btnResetFilters, 0)
        Me.Controls.SetChildIndex(Me.grpFilters, 0)
        Me.Controls.SetChildIndex(Me.btnSelectAll, 0)
        Me.Controls.SetChildIndex(Me.btnUnselect, 0)
        Me.Controls.SetChildIndex(Me.btnGenerateLetters, 0)
        Me.Controls.SetChildIndex(Me.btnReleaseLockedSites, 0)
        Me.Controls.SetChildIndex(Me.btnFindSite, 0)
        Me.grpServices.ResumeLayout(False)
        CType(Me.dgServicesDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServices As System.Windows.Forms.GroupBox
    Friend WithEvents dgServicesDue As System.Windows.Forms.DataGrid
    Friend WithEvents btnResetFilters As System.Windows.Forms.Button
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLetterCreateDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents btnGenerateLetters As System.Windows.Forms.Button
    Friend WithEvents cboLetterNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbMinsPerDay As System.Windows.Forms.TextBox
    Friend WithEvents lbMinsPerDay As System.Windows.Forms.Label
    Friend WithEvents chkLettersOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnReleaseLockedSites As System.Windows.Forms.Button
    Friend WithEvents txtMaxTravel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTravelBetween As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkLastService As CheckBox
    Friend WithEvents btnFindSite As Button
    Friend WithEvents chkVoidProperty As CheckBox
    Friend WithEvents chkIncludePatchChecks As CheckBox
End Class
