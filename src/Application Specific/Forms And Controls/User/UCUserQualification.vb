Imports Newtonsoft.Json.Linq

Public Class UCUserQualification : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpComboQual(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents grpUserQualifications As GroupBox
    Friend WithEvents pnlQualifications As Panel
    Friend WithEvents cboQualificationType As ComboBox
    Friend WithEvents lblQualificationType As Label
    Friend WithEvents dtpQualificationBooked As DateTimePicker
    Friend WithEvents lblBooked As Label
    Friend WithEvents cboQualification As ComboBox
    Friend WithEvents lblQualification As Label
    Friend WithEvents txtQualificatioNote As TextBox
    Friend WithEvents lblNote As Label
    Friend WithEvents dtpQualificationExpires As DateTimePicker
    Friend WithEvents lblExpiry As Label
    Friend WithEvents dtpQualificationPassed As DateTimePicker
    Friend WithEvents lblPassed As Label
    Friend WithEvents btnRemoveTrainingQualifications As Button
    Friend WithEvents dgTrainingQualifications As DataGrid
    Friend WithEvents btnSaveQualification As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.grpUserQualifications = New System.Windows.Forms.GroupBox()
        Me.pnlQualifications = New System.Windows.Forms.Panel()
        Me.btnSaveQualification = New System.Windows.Forms.Button()
        Me.cboQualificationType = New System.Windows.Forms.ComboBox()
        Me.lblQualificationType = New System.Windows.Forms.Label()
        Me.dtpQualificationBooked = New System.Windows.Forms.DateTimePicker()
        Me.lblBooked = New System.Windows.Forms.Label()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.txtQualificatioNote = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.dtpQualificationExpires = New System.Windows.Forms.DateTimePicker()
        Me.lblExpiry = New System.Windows.Forms.Label()
        Me.dtpQualificationPassed = New System.Windows.Forms.DateTimePicker()
        Me.lblPassed = New System.Windows.Forms.Label()
        Me.btnRemoveTrainingQualifications = New System.Windows.Forms.Button()
        Me.dgTrainingQualifications = New System.Windows.Forms.DataGrid()
        Me.grpDetails.SuspendLayout()
        Me.grpUserQualifications.SuspendLayout()
        Me.pnlQualifications.SuspendLayout()
        CType(Me.dgTrainingQualifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.lblEmail)
        Me.grpDetails.Controls.Add(Me.txtEmailAddress)
        Me.grpDetails.Controls.Add(Me.txtFullName)
        Me.grpDetails.Controls.Add(Me.lblFullName)
        Me.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpDetails.Location = New System.Drawing.Point(12, 19)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(606, 95)
        Me.grpDetails.TabIndex = 37
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(9, 54)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(38, 13)
        Me.lblEmail.TabIndex = 16
        Me.lblEmail.Text = "Email"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(127, 51)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(454, 21)
        Me.txtEmailAddress.TabIndex = 15
        '
        'txtFullName
        '
        Me.txtFullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFullName.Location = New System.Drawing.Point(127, 24)
        Me.txtFullName.MaxLength = 255
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(454, 21)
        Me.txtFullName.TabIndex = 4
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(8, 24)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(64, 16)
        Me.lblFullName.TabIndex = 5
        Me.lblFullName.Text = "Full Name"
        '
        'grpUserQualifications
        '
        Me.grpUserQualifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUserQualifications.Controls.Add(Me.pnlQualifications)
        Me.grpUserQualifications.Controls.Add(Me.btnRemoveTrainingQualifications)
        Me.grpUserQualifications.Controls.Add(Me.dgTrainingQualifications)
        Me.grpUserQualifications.Location = New System.Drawing.Point(12, 128)
        Me.grpUserQualifications.Name = "grpUserQualifications"
        Me.grpUserQualifications.Size = New System.Drawing.Size(606, 538)
        Me.grpUserQualifications.TabIndex = 38
        Me.grpUserQualifications.TabStop = False
        Me.grpUserQualifications.Text = "Training && Qualifications"
        '
        'pnlQualifications
        '
        Me.pnlQualifications.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlQualifications.Controls.Add(Me.btnSaveQualification)
        Me.pnlQualifications.Controls.Add(Me.cboQualificationType)
        Me.pnlQualifications.Controls.Add(Me.lblQualificationType)
        Me.pnlQualifications.Controls.Add(Me.dtpQualificationBooked)
        Me.pnlQualifications.Controls.Add(Me.lblBooked)
        Me.pnlQualifications.Controls.Add(Me.cboQualification)
        Me.pnlQualifications.Controls.Add(Me.lblQualification)
        Me.pnlQualifications.Controls.Add(Me.txtQualificatioNote)
        Me.pnlQualifications.Controls.Add(Me.lblNote)
        Me.pnlQualifications.Controls.Add(Me.dtpQualificationExpires)
        Me.pnlQualifications.Controls.Add(Me.lblExpiry)
        Me.pnlQualifications.Controls.Add(Me.dtpQualificationPassed)
        Me.pnlQualifications.Controls.Add(Me.lblPassed)
        Me.pnlQualifications.Location = New System.Drawing.Point(5, 20)
        Me.pnlQualifications.Name = "pnlQualifications"
        Me.pnlQualifications.Size = New System.Drawing.Size(593, 222)
        Me.pnlQualifications.TabIndex = 42
        '
        'btnSaveQualification
        '
        Me.btnSaveQualification.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveQualification.Location = New System.Drawing.Point(445, 196)
        Me.btnSaveQualification.Name = "btnSaveQualification"
        Me.btnSaveQualification.Size = New System.Drawing.Size(137, 23)
        Me.btnSaveQualification.TabIndex = 56
        Me.btnSaveQualification.Text = "Add / Update"
        '
        'cboQualificationType
        '
        Me.cboQualificationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualificationType.Location = New System.Drawing.Point(139, 5)
        Me.cboQualificationType.Name = "cboQualificationType"
        Me.cboQualificationType.Size = New System.Drawing.Size(443, 21)
        Me.cboQualificationType.TabIndex = 54
        Me.cboQualificationType.Text = "ComboBox1"
        '
        'lblQualificationType
        '
        Me.lblQualificationType.Location = New System.Drawing.Point(7, 5)
        Me.lblQualificationType.Name = "lblQualificationType"
        Me.lblQualificationType.Size = New System.Drawing.Size(126, 23)
        Me.lblQualificationType.TabIndex = 55
        Me.lblQualificationType.Text = "Qualification Type"
        '
        'dtpQualificationBooked
        '
        Me.dtpQualificationBooked.Checked = False
        Me.dtpQualificationBooked.Location = New System.Drawing.Point(332, 68)
        Me.dtpQualificationBooked.Name = "dtpQualificationBooked"
        Me.dtpQualificationBooked.ShowCheckBox = True
        Me.dtpQualificationBooked.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationBooked.TabIndex = 52
        '
        'lblBooked
        '
        Me.lblBooked.Location = New System.Drawing.Point(269, 74)
        Me.lblBooked.Name = "lblBooked"
        Me.lblBooked.Size = New System.Drawing.Size(57, 23)
        Me.lblBooked.TabIndex = 53
        Me.lblBooked.Text = "Booked"
        '
        'cboQualification
        '
        Me.cboQualification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualification.Location = New System.Drawing.Point(96, 36)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(486, 21)
        Me.cboQualification.TabIndex = 1
        Me.cboQualification.Text = "ComboBox1"
        '
        'lblQualification
        '
        Me.lblQualification.Location = New System.Drawing.Point(8, 36)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(100, 23)
        Me.lblQualification.TabIndex = 48
        Me.lblQualification.Text = "Qualification"
        '
        'txtQualificatioNote
        '
        Me.txtQualificatioNote.AcceptsReturn = True
        Me.txtQualificatioNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQualificatioNote.Location = New System.Drawing.Point(96, 132)
        Me.txtQualificatioNote.Multiline = True
        Me.txtQualificatioNote.Name = "txtQualificatioNote"
        Me.txtQualificatioNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQualificatioNote.Size = New System.Drawing.Size(486, 55)
        Me.txtQualificatioNote.TabIndex = 4
        '
        'lblNote
        '
        Me.lblNote.Location = New System.Drawing.Point(8, 132)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(67, 20)
        Me.lblNote.TabIndex = 47
        Me.lblNote.Text = "Note"
        '
        'dtpQualificationExpires
        '
        Me.dtpQualificationExpires.Checked = False
        Me.dtpQualificationExpires.Location = New System.Drawing.Point(96, 99)
        Me.dtpQualificationExpires.Name = "dtpQualificationExpires"
        Me.dtpQualificationExpires.ShowCheckBox = True
        Me.dtpQualificationExpires.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationExpires.TabIndex = 3
        '
        'lblExpiry
        '
        Me.lblExpiry.Location = New System.Drawing.Point(8, 105)
        Me.lblExpiry.Name = "lblExpiry"
        Me.lblExpiry.Size = New System.Drawing.Size(80, 23)
        Me.lblExpiry.TabIndex = 43
        Me.lblExpiry.Text = "Expires"
        '
        'dtpQualificationPassed
        '
        Me.dtpQualificationPassed.Checked = False
        Me.dtpQualificationPassed.Location = New System.Drawing.Point(96, 68)
        Me.dtpQualificationPassed.Name = "dtpQualificationPassed"
        Me.dtpQualificationPassed.ShowCheckBox = True
        Me.dtpQualificationPassed.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationPassed.TabIndex = 2
        '
        'lblPassed
        '
        Me.lblPassed.Location = New System.Drawing.Point(8, 74)
        Me.lblPassed.Name = "lblPassed"
        Me.lblPassed.Size = New System.Drawing.Size(80, 23)
        Me.lblPassed.TabIndex = 41
        Me.lblPassed.Text = "Date Passed"
        '
        'btnRemoveTrainingQualifications
        '
        Me.btnRemoveTrainingQualifications.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTrainingQualifications.Location = New System.Drawing.Point(10, 506)
        Me.btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications"
        Me.btnRemoveTrainingQualifications.Size = New System.Drawing.Size(75, 21)
        Me.btnRemoveTrainingQualifications.TabIndex = 7
        Me.btnRemoveTrainingQualifications.Text = "Delete"
        '
        'dgTrainingQualifications
        '
        Me.dgTrainingQualifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTrainingQualifications.DataMember = ""
        Me.dgTrainingQualifications.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTrainingQualifications.Location = New System.Drawing.Point(8, 248)
        Me.dgTrainingQualifications.Name = "dgTrainingQualifications"
        Me.dgTrainingQualifications.Size = New System.Drawing.Size(590, 250)
        Me.dgTrainingQualifications.TabIndex = 6
        '
        'UCUserQualification
        '
        Me.Controls.Add(Me.grpUserQualifications)
        Me.Controls.Add(Me.grpDetails)
        Me.Name = "UCUserQualification"
        Me.Size = New System.Drawing.Size(630, 679)
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.grpUserQualifications.ResumeLayout(False)
        Me.pnlQualifications.ResumeLayout(False)
        Me.pnlQualifications.PerformLayout()
        CType(Me.dgTrainingQualifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupTrainingQualificationsDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentUser
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentUser As Entity.Users.User

    Public Property CurrentUser() As Entity.Users.User
        Get
            Return _currentUser
        End Get
        Set(ByVal Value As Entity.Users.User)
            _currentUser = Value

            If CurrentUser Is Nothing Then
                CurrentUser = New Entity.Users.User With {
                    .Exists = False
                }
            End If

            If CurrentUser.Exists Then
                Populate()
                PopulateTrainingQualifications()
            End If
        End Set
    End Property

    Private _dvTrainingQualifications As DataView

    Private Property TrainingQualificationsDataView() As DataView
        Get
            Return _dvTrainingQualifications
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then
                _dvTrainingQualifications = Value
                _dvTrainingQualifications.Table.TableName =
                    Entity.Sys.Enums.TableNames.tblUserQualification.ToString
            End If
            dgTrainingQualifications.DataSource = _dvTrainingQualifications
        End Set
    End Property

    Public ReadOnly Property SelectedTrainingQualificationsRow() As DataRow
        Get
            If Not TrainingQualificationsDataView Is Nothing Then
                If TrainingQualificationsDataView.Table.Rows.Count > 0 Then
                    Return TrainingQualificationsDataView(Me.dgTrainingQualifications.CurrentRowIndex).Row
                Else
                    Return Nothing
                End If
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupTrainingQualificationsDataGrid()
        Try
            dgTrainingQualifications.TableStyles.Add(New DataGridTableStyle)
            Entity.Sys.Helper.SetUpDataGrid(Me.dgTrainingQualifications)

            Dim tStyle As DataGridTableStyle = dgTrainingQualifications.TableStyles(0)

            Dim Qualification As New DataGridTextBoxColumn
            Qualification.HeaderText = "Level\Qualification"
            Qualification.MappingName = "Level"
            Qualification.NullText = ""
            Qualification.Width = 150
            tStyle.GridColumnStyles.Add(Qualification)

            Dim Description As New DataGridTextBoxColumn
            Description.HeaderText = "Description"
            Description.MappingName = "Description"
            Description.NullText = ""
            Description.Width = 200
            tStyle.GridColumnStyles.Add(Description)

            Dim Notes As New DataGridTextBoxColumn
            Notes.HeaderText = "Notes"
            Notes.MappingName = "Notes"
            Notes.NullText = ""
            Notes.Width = 400
            tStyle.GridColumnStyles.Add(Notes)

            Dim DatePassed As New DataGridTextBoxColumn
            DatePassed.HeaderText = "Passed"
            DatePassed.MappingName = "DatePassed"
            DatePassed.Format = "dd/MM/yyyy"
            DatePassed.NullText = ""
            DatePassed.Width = 80
            tStyle.GridColumnStyles.Add(DatePassed)

            Dim DateExpires As New DataGridTextBoxColumn
            DateExpires.HeaderText = "Expires"
            DateExpires.MappingName = "DateExpires"
            DateExpires.Format = "dd/MM/yyyy"
            DateExpires.NullText = ""
            DateExpires.Width = 80
            tStyle.GridColumnStyles.Add(DateExpires)

            Dim DateBooked As New DataGridTextBoxColumn
            DateBooked.HeaderText = "Booked"
            DateBooked.MappingName = "DateBooked"
            DateBooked.Format = "dd/MM/yyyy"
            DateBooked.NullText = ""
            DateBooked.Width = 80
            tStyle.GridColumnStyles.Add(DateBooked)

            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblUserQualification.ToString
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub UCUserQualification_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnSaveQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveQualification.Click
        Try
            Dim UpdateFlag As Boolean
            Dim r As DataRow
            r = TrainingQualificationsDataView.Table.NewRow()

            Dim v As BaseValidator = New BaseValidator

            Dim check() As DataRow = TrainingQualificationsDataView.Table.Select("LevelID = " & Combo.GetSelectedItemValue(cboQualification))

            If check.Length > 0 Then
                Dim msg As String = "This will update the qualification. "
                msg += "Do you wish to Procceed."
                If ShowMessage(msg, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then

                    Exit Sub
                Else
                    UpdateFlag = True
                End If

            End If

            If cboQualification.SelectedIndex = 0 Then
                v.AddCriticalMessage("'Qualification' is required")
            End If
            If dtpQualificationPassed.Checked = False Then
                v.AddCriticalMessage("'Date Passed' must be specified.")
            End If

            If v.ValidatorMessages.CriticalMessages.Count > 0 Then
                Throw New ValidationException(v)
            End If

            Dim hasDescription As String = False
            hasDescription = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*").Length > 1

            r("LevelID") = CInt(Combo.GetSelectedItemValue(cboQualification))
            r("Level") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(1).Trim()
            If hasDescription Then r("Description") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(0).Trim()
            r("Notes") = txtQualificatioNote.Text
            If dtpQualificationPassed.Checked Then
                r("DatePassed") = dtpQualificationPassed.Value
            End If
            If dtpQualificationExpires.Checked Then
                r("DateExpires") = dtpQualificationExpires.Value
            End If

            If dtpQualificationBooked.Checked Then
                r("DateBooked") = dtpQualificationBooked.Value
            End If
            If UpdateFlag Then
                Dim dr As DataRow = TrainingQualificationsDataView.Table.Rows(Me.dgTrainingQualifications.CurrentRowIndex)
                For Each dc As DataColumn In dr.Table.Columns
                    dr(dc) = r(dc)
                Next
            Else
                TrainingQualificationsDataView.Table.Rows.Add(r)
            End If
            ClearQualificationDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveTrainingQualifications_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTrainingQualifications.Click
        Try
            Dim r As DataRow = SelectedTrainingQualificationsRow
            If Not r Is Nothing Then
                If MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    TrainingQualificationsDataView.Table.Rows.Remove(r)
                End If
            End If

            ClearQualificationDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboQualificationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQualificationType.SelectedIndexChanged
        Try
            Dim skillTypeId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboQualificationType))
            If skillTypeId > 0 Then
                Combo.SetUpCombo(cboQualification, DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Entity.Sys.Enums.ComboValues.Please_Select)
            Else
                Combo.SetUpComboQual(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentUser = DB.User.Get(ID)
        End If
        txtFullName.Text = CurrentUser.Fullname
        txtEmailAddress.Text = CurrentUser.EmailAddress

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not CurrentUser.Exists Then Return False
            DB.UserLevels.Insert(CurrentUser.UserID, TrainingQualificationsDataView.Table)
            Return True
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub PopulateTrainingQualifications()
        Try
            'TODO - ADD USER QUALIFICATION SQL
            TrainingQualificationsDataView = DB.UserLevels.GetForSetup(CurrentUser.UserID)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearQualificationDetailPanel()
        Combo.SetSelectedComboItem_By_Value(Me.cboQualification, 0)
        txtQualificatioNote.Text = ""
        dtpQualificationPassed.Checked = False
        dtpQualificationExpires.Checked = False
    End Sub

    Private Sub dgTrainingQualifications_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTrainingQualifications.Click, dgTrainingQualifications.CurrentCellChanged
        Try
            Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboQualification, SelectedTrainingQualificationsRow.Item(0).ToString)
            txtQualificatioNote.Text = SelectedTrainingQualificationsRow.Item(3)
            dtpQualificationPassed.Value = SelectedTrainingQualificationsRow.Item(4)
            dtpQualificationExpires.Value = SelectedTrainingQualificationsRow.Item(5)
            dtpQualificationBooked.Value = SelectedTrainingQualificationsRow.Item(6)
        Catch
        End Try
    End Sub

#End Region

End Class