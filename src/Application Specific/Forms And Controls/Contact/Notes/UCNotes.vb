Public Class UCNotes : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboCategoryID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.NoteCategory).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboTimeHours, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboTimeMinutes, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboReminderHours, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboReminderMinutes, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboReminderFrequency, DynamicDataTables.ReminderFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetSelectedComboItem_By_Value(Me.cboReminderFrequency, CInt(Entity.Sys.Enums.ReminderFrequencies.Minutes))
        Combo.SetUpCombo(Me.cboReminderFrequencyValue, DynamicDataTables.NumberSelector, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetSelectedComboItem_By_Value(Me.cboReminderFrequencyValue, 1)
        Combo.SetUpCombo(cboUserFor, DB.User.GetAll.Table, "UserID", "Fullname", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(cboUserFor, loggedInUser.UserID)

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Friend WithEvents grpNotes As System.Windows.Forms.GroupBox
    Friend WithEvents cboCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoryID As System.Windows.Forms.Label
    Friend WithEvents dtpNoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNoteDate As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents grpReminderDetails As System.Windows.Forms.GroupBox
    Friend WithEvents chkReminderRequired As System.Windows.Forms.CheckBox
    Friend WithEvents cboReminderFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTimeHours As System.Windows.Forms.ComboBox
    Friend WithEvents cboTimeMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents pnlReminderType As System.Windows.Forms.Panel
    Friend WithEvents radPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents radOther As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpReminderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboReminderHours As System.Windows.Forms.ComboBox
    Friend WithEvents cboReminderMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents cboReminderFrequencyValue As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboUserFor As System.Windows.Forms.ComboBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpNotes = New System.Windows.Forms.GroupBox
        Me.cboTimeMinutes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpReminderDetails = New System.Windows.Forms.GroupBox
        Me.cboReminderFrequencyValue = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlReminderType = New System.Windows.Forms.Panel
        Me.radOther = New System.Windows.Forms.RadioButton
        Me.radPeriod = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboReminderFrequency = New System.Windows.Forms.ComboBox
        Me.chkReminderRequired = New System.Windows.Forms.CheckBox
        Me.dtpReminderDate = New System.Windows.Forms.DateTimePicker
        Me.cboReminderHours = New System.Windows.Forms.ComboBox
        Me.cboReminderMinutes = New System.Windows.Forms.ComboBox
        Me.cboCategoryID = New System.Windows.Forms.ComboBox
        Me.lblCategoryID = New System.Windows.Forms.Label
        Me.dtpNoteDate = New System.Windows.Forms.DateTimePicker
        Me.lblNoteDate = New System.Windows.Forms.Label
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.cboTimeHours = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboUserFor = New System.Windows.Forms.ComboBox
        Me.grpNotes.SuspendLayout()
        Me.grpReminderDetails.SuspendLayout()
        Me.pnlReminderType.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpNotes
        '
        Me.grpNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNotes.Controls.Add(Me.cboUserFor)
        Me.grpNotes.Controls.Add(Me.Label5)
        Me.grpNotes.Controls.Add(Me.cboTimeMinutes)
        Me.grpNotes.Controls.Add(Me.Label2)
        Me.grpNotes.Controls.Add(Me.grpReminderDetails)
        Me.grpNotes.Controls.Add(Me.cboCategoryID)
        Me.grpNotes.Controls.Add(Me.lblCategoryID)
        Me.grpNotes.Controls.Add(Me.dtpNoteDate)
        Me.grpNotes.Controls.Add(Me.lblNoteDate)
        Me.grpNotes.Controls.Add(Me.txtNote)
        Me.grpNotes.Controls.Add(Me.lblNote)
        Me.grpNotes.Controls.Add(Me.cboTimeHours)
        Me.grpNotes.Location = New System.Drawing.Point(8, 8)
        Me.grpNotes.Name = "grpNotes"
        Me.grpNotes.Size = New System.Drawing.Size(732, 308)
        Me.grpNotes.TabIndex = 1
        Me.grpNotes.TabStop = False
        Me.grpNotes.Text = "Note Details"
        '
        'cboTimeMinutes
        '
        Me.cboTimeMinutes.Location = New System.Drawing.Point(432, 24)
        Me.cboTimeMinutes.Name = "cboTimeMinutes"
        Me.cboTimeMinutes.Size = New System.Drawing.Size(104, 21)
        Me.cboTimeMinutes.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(288, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 21)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Time"
        '
        'grpReminderDetails
        '
        Me.grpReminderDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpReminderDetails.Controls.Add(Me.cboReminderFrequencyValue)
        Me.grpReminderDetails.Controls.Add(Me.Label4)
        Me.grpReminderDetails.Controls.Add(Me.Label3)
        Me.grpReminderDetails.Controls.Add(Me.pnlReminderType)
        Me.grpReminderDetails.Controls.Add(Me.Label1)
        Me.grpReminderDetails.Controls.Add(Me.cboReminderFrequency)
        Me.grpReminderDetails.Controls.Add(Me.chkReminderRequired)
        Me.grpReminderDetails.Controls.Add(Me.dtpReminderDate)
        Me.grpReminderDetails.Controls.Add(Me.cboReminderHours)
        Me.grpReminderDetails.Controls.Add(Me.cboReminderMinutes)
        Me.grpReminderDetails.Location = New System.Drawing.Point(8, 208)
        Me.grpReminderDetails.Name = "grpReminderDetails"
        Me.grpReminderDetails.Size = New System.Drawing.Size(715, 88)
        Me.grpReminderDetails.TabIndex = 32
        Me.grpReminderDetails.TabStop = False
        Me.grpReminderDetails.Text = "Reminder Details"
        '
        'cboReminderFrequencyValue
        '
        Me.cboReminderFrequencyValue.Location = New System.Drawing.Point(176, 25)
        Me.cboReminderFrequencyValue.Name = "cboReminderFrequencyValue"
        Me.cboReminderFrequencyValue.Size = New System.Drawing.Size(96, 21)
        Me.cboReminderFrequencyValue.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(456, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Time"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(176, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 20)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Date"
        '
        'pnlReminderType
        '
        Me.pnlReminderType.Controls.Add(Me.radOther)
        Me.pnlReminderType.Controls.Add(Me.radPeriod)
        Me.pnlReminderType.Location = New System.Drawing.Point(96, 24)
        Me.pnlReminderType.Name = "pnlReminderType"
        Me.pnlReminderType.Size = New System.Drawing.Size(72, 56)
        Me.pnlReminderType.TabIndex = 33
        '
        'radOther
        '
        Me.radOther.Location = New System.Drawing.Point(8, 27)
        Me.radOther.Name = "radOther"
        Me.radOther.Size = New System.Drawing.Size(64, 24)
        Me.radOther.TabIndex = 8
        Me.radOther.Text = "Other"
        '
        'radPeriod
        '
        Me.radPeriod.Location = New System.Drawing.Point(8, 2)
        Me.radPeriod.Name = "radPeriod"
        Me.radPeriod.Size = New System.Drawing.Size(64, 24)
        Me.radPeriod.TabIndex = 7
        Me.radPeriod.Text = "Period"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(456, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Prior to due date && time"
        '
        'cboReminderFrequency
        '
        Me.cboReminderFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReminderFrequency.Location = New System.Drawing.Point(272, 26)
        Me.cboReminderFrequency.Name = "cboReminderFrequency"
        Me.cboReminderFrequency.Size = New System.Drawing.Size(176, 21)
        Me.cboReminderFrequency.TabIndex = 10
        '
        'chkReminderRequired
        '
        Me.chkReminderRequired.Location = New System.Drawing.Point(8, 24)
        Me.chkReminderRequired.Name = "chkReminderRequired"
        Me.chkReminderRequired.Size = New System.Drawing.Size(88, 56)
        Me.chkReminderRequired.TabIndex = 6
        Me.chkReminderRequired.Text = "Reminder Required"
        '
        'dtpReminderDate
        '
        Me.dtpReminderDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpReminderDate.Location = New System.Drawing.Point(216, 57)
        Me.dtpReminderDate.Name = "dtpReminderDate"
        Me.dtpReminderDate.Size = New System.Drawing.Size(232, 21)
        Me.dtpReminderDate.TabIndex = 11
        Me.dtpReminderDate.Tag = "Notes.NoteDate"
        '
        'cboReminderHours
        '
        Me.cboReminderHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReminderHours.Location = New System.Drawing.Point(496, 58)
        Me.cboReminderHours.Name = "cboReminderHours"
        Me.cboReminderHours.Size = New System.Drawing.Size(104, 21)
        Me.cboReminderHours.TabIndex = 12
        '
        'cboReminderMinutes
        '
        Me.cboReminderMinutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReminderMinutes.Location = New System.Drawing.Point(600, 58)
        Me.cboReminderMinutes.Name = "cboReminderMinutes"
        Me.cboReminderMinutes.Size = New System.Drawing.Size(104, 21)
        Me.cboReminderMinutes.TabIndex = 13
        '
        'cboCategoryID
        '
        Me.cboCategoryID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategoryID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoryID.Location = New System.Drawing.Point(72, 82)
        Me.cboCategoryID.Name = "cboCategoryID"
        Me.cboCategoryID.Size = New System.Drawing.Size(651, 21)
        Me.cboCategoryID.TabIndex = 4
        Me.cboCategoryID.Tag = "Notes.CategoryID"
        '
        'lblCategoryID
        '
        Me.lblCategoryID.Location = New System.Drawing.Point(8, 82)
        Me.lblCategoryID.Name = "lblCategoryID"
        Me.lblCategoryID.Size = New System.Drawing.Size(64, 20)
        Me.lblCategoryID.TabIndex = 31
        Me.lblCategoryID.Text = "Category"
        '
        'dtpNoteDate
        '
        Me.dtpNoteDate.Location = New System.Drawing.Point(72, 24)
        Me.dtpNoteDate.Name = "dtpNoteDate"
        Me.dtpNoteDate.Size = New System.Drawing.Size(208, 21)
        Me.dtpNoteDate.TabIndex = 1
        Me.dtpNoteDate.Tag = "Notes.NoteDate"
        '
        'lblNoteDate
        '
        Me.lblNoteDate.Location = New System.Drawing.Point(8, 24)
        Me.lblNoteDate.Name = "lblNoteDate"
        Me.lblNoteDate.Size = New System.Drawing.Size(48, 21)
        Me.lblNoteDate.TabIndex = 31
        Me.lblNoteDate.Text = "Date"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(72, 111)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(651, 88)
        Me.txtNote.TabIndex = 5
        Me.txtNote.Tag = "Notes.Note"
        Me.txtNote.Text = ""
        '
        'lblNote
        '
        Me.lblNote.Location = New System.Drawing.Point(8, 111)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(48, 20)
        Me.lblNote.TabIndex = 31
        Me.lblNote.Text = "Note"
        '
        'cboTimeHours
        '
        Me.cboTimeHours.Location = New System.Drawing.Point(328, 24)
        Me.cboTimeHours.Name = "cboTimeHours"
        Me.cboTimeHours.Size = New System.Drawing.Size(104, 21)
        Me.cboTimeHours.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "For User:"
        '
        'cboUserFor
        '
        Me.cboUserFor.Location = New System.Drawing.Point(72, 53)
        Me.cboUserFor.Name = "cboUserFor"
        Me.cboUserFor.Size = New System.Drawing.Size(208, 21)
        Me.cboUserFor.TabIndex = 35
        '
        'UCNotes
        '
        Me.Controls.Add(Me.grpNotes)
        Me.Name = "UCNotes"
        Me.Size = New System.Drawing.Size(747, 325)
        Me.grpNotes.ResumeLayout(False)
        Me.grpReminderDetails.ResumeLayout(False)
        Me.pnlReminderType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentNote
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentNotes As Entity.Notes.Notes
    Public Property CurrentNote() As Entity.Notes.Notes
        Get
            Return _currentNotes
        End Get
        Set(ByVal Value As Entity.Notes.Notes)
            _currentNotes = Value

            If _currentNotes Is Nothing Then
                _currentNotes = New Entity.Notes.Notes
                _currentNotes.Exists = False
            End If

            If CurrentNote.Exists Then
                Populate()
            Else
                Me.chkReminderRequired.Checked = False
            End If

            SetReminderStatus(False)
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCNotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub chkReminderRequired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReminderRequired.CheckedChanged
        SetReminderStatus(False)
    End Sub

    Private Sub radPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPeriod.CheckedChanged
        SetReminderStatus(True)
    End Sub

    Private Sub radOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radOther.CheckedChanged
        SetReminderStatus(True)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentNote = DB.Notes.Notes_Get(ID)
        End If

        Me.dtpNoteDate.Value = CurrentNote.NoteDate.Date
        Combo.SetSelectedComboItem_By_Value(Me.cboTimeHours, CurrentNote.NoteDate.Hour)
        Combo.SetSelectedComboItem_By_Value(Me.cboTimeMinutes, CurrentNote.NoteDate.Minute)
        Combo.SetSelectedComboItem_By_Value(Me.cboCategoryID, CurrentNote.CategoryID)
        Me.txtNote.Text = CurrentNote.Note
        Combo.SetSelectedComboItem_By_Value(cboUserFor, CurrentNote.UserIDFor)

        If CurrentNote.ReminderStatusID = CInt(Entity.Sys.Enums.NoteReminderStatus.Active) Then
            Me.chkReminderRequired.Checked = True
        Else
            Me.chkReminderRequired.Checked = False
        End If
    End Sub

    Private Sub SetReminderStatus(ByVal fromTick As Boolean)
        If Me.chkReminderRequired.Checked = False Then
            Me.radPeriod.Enabled = False
            Me.radOther.Enabled = False
            Me.cboReminderFrequencyValue.Enabled = False
            Me.cboReminderFrequency.Enabled = False
            Me.dtpReminderDate.Enabled = False
            Me.cboReminderHours.Enabled = False
            Me.cboReminderMinutes.Enabled = False
            Me.radOther.Checked = False
            Me.radOther.Checked = False
        Else
            Me.radPeriod.Enabled = True
            Me.radOther.Enabled = True

            If Not fromTick Then
                If CurrentNote.ReminderStatusID = CInt(Entity.Sys.Enums.NoteReminderStatus.Active) Then
                    Me.radPeriod.Checked = False
                    Me.radOther.Checked = True
                    Me.cboReminderFrequencyValue.Enabled = False
                    Me.cboReminderFrequency.Enabled = False
                    Me.dtpReminderDate.Enabled = True
                    Me.cboReminderHours.Enabled = True
                    Me.cboReminderMinutes.Enabled = True
                    Me.dtpReminderDate.Value = CurrentNote.DateTimeOfReminder.Date
                    Combo.SetSelectedComboItem_By_Value(Me.cboReminderHours, CurrentNote.DateTimeOfReminder.Hour)
                    Combo.SetSelectedComboItem_By_Value(Me.cboReminderMinutes, CurrentNote.DateTimeOfReminder.Minute)
                Else
                    If Me.radPeriod.Checked = False And Me.radOther.Checked = False Then
                        Me.radPeriod.Checked = True
                    End If
                End If
            End If

            If Me.radPeriod.Checked = True Then
                Me.cboReminderFrequencyValue.Enabled = True
                Me.cboReminderFrequency.Enabled = True
                Me.dtpReminderDate.Enabled = False
                Me.cboReminderHours.Enabled = False
                Me.cboReminderMinutes.Enabled = False
            Else
                Me.cboReminderFrequencyValue.Enabled = False
                Me.cboReminderFrequency.Enabled = False
                Me.dtpReminderDate.Enabled = True
                Me.cboReminderHours.Enabled = True
                Me.cboReminderMinutes.Enabled = True
            End If
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentNote.IgnoreExceptionsOnSetMethods = True

            CurrentNote.SetCategoryID = Combo.GetSelectedItemValue(Me.cboCategoryID)
            CurrentNote.NoteDate = Me.dtpNoteDate.Value.Date & " " & Combo.GetSelectedItemValue(Me.cboTimeHours) & ":" & Combo.GetSelectedItemValue(Me.cboTimeMinutes) & ":00"
            CurrentNote.SetNote = Me.txtNote.Text.Trim
            CurrentNote.SetUserIDFor = Combo.GetSelectedItemValue(cboUserFor)

            If Not Me.chkReminderRequired.Checked Then
                CurrentNote.SetReminderStatusID = CInt(Entity.Sys.Enums.NoteReminderStatus.Cancelled)
                CurrentNote.DateTimeOfReminder = CurrentNote.NoteDate
            Else
                CurrentNote.SetReminderStatusID = CInt(Entity.Sys.Enums.NoteReminderStatus.Active)

                Dim reminderDate As New DateTime
                If Me.radOther.Checked Then
                    reminderDate = Me.dtpReminderDate.Value.Date & " " & Combo.GetSelectedItemValue(Me.cboReminderHours) & ":" & Combo.GetSelectedItemValue(Me.cboReminderMinutes) & ":00"
                Else
                    reminderDate = CurrentNote.NoteDate
                    Select Case CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequency))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Minutes)
                            reminderDate = reminderDate.AddMinutes(0 - CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Hours)
                            reminderDate = reminderDate.AddHours(0 - CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Days)
                            reminderDate = reminderDate.AddDays(0 - CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Weeks)
                            reminderDate = reminderDate.AddDays(0 - (CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)) * 7))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Months)
                            reminderDate = reminderDate.AddMonths(0 - CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)))
                        Case CInt(Entity.Sys.Enums.ReminderFrequencies.Years)
                            reminderDate = reminderDate.AddYears(0 - CInt(Combo.GetSelectedItemValue(Me.cboReminderFrequencyValue)))
                    End Select
                End If

                CurrentNote.DateTimeOfReminder = reminderDate
            End If

            Dim cV As New Entity.Notes.NotesValidator
            cV.Validate(CurrentNote)

            If CurrentNote.Exists Then
                DB.Notes.Update(CurrentNote)
            Else
                CurrentNote = DB.Notes.Insert(CurrentNote)
            End If

            RaiseEvent StateChanged(CurrentNote.NoteID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

    
End Class

