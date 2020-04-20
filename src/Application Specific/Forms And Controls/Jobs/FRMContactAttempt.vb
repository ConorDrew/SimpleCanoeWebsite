Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.ContactAttempts
Imports FSM.Entity.Engineers
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.JobOfWorks
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys
Imports FSM.Entity.Users

Public Class FRMContactAttempt

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal linkTable As Enums.TableNames, ByVal linkId As Integer)
        MyBase.New()

        InitializeComponent()
        Me.LinkTable = linkTable
        Me.LinkID = linkId
        Combo.SetUpCombo(Me.cboMethod, DB.ContactAttempts.ContactMethod_GetAll.Table, "ContactMethodID", "Name", Enums.ComboValues.Please_Select)
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

    Friend WithEvents btnSave As Button
    Friend WithEvents lblContactMethod As Label
    Friend WithEvents cboMethod As ComboBox
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents lblTime As Label
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents lblNote As Label
    Friend WithEvents txtNote As TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblContactMethod = New System.Windows.Forms.Label()
        Me.cboMethod = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(341, 242)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 23)
        Me.btnSave.TabIndex = 48
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblContactMethod
        '
        Me.lblContactMethod.AutoSize = True
        Me.lblContactMethod.Location = New System.Drawing.Point(12, 18)
        Me.lblContactMethod.Name = "lblContactMethod"
        Me.lblContactMethod.Size = New System.Drawing.Size(46, 13)
        Me.lblContactMethod.TabIndex = 49
        Me.lblContactMethod.Text = "Method:"
        '
        'cboMethod
        '
        Me.cboMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMethod.FormattingEnabled = True
        Me.cboMethod.Location = New System.Drawing.Point(74, 15)
        Me.cboMethod.Name = "cboMethod"
        Me.cboMethod.Size = New System.Drawing.Size(344, 21)
        Me.cboMethod.TabIndex = 50
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(12, 61)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 51
        Me.lblDate.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(74, 58)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(156, 20)
        Me.dtpDate.TabIndex = 52
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(251, 61)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(33, 13)
        Me.lblTime.TabIndex = 53
        Me.lblTime.Text = "Time:"
        '
        'dtpTime
        '
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(290, 58)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.Size = New System.Drawing.Size(69, 20)
        Me.dtpTime.TabIndex = 54
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(12, 105)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(33, 13)
        Me.lblNote.TabIndex = 55
        Me.lblNote.Text = "Note:"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(74, 105)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(344, 112)
        Me.txtNote.TabIndex = 56
        '
        'FRMContactAttempt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(430, 277)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.dtpTime)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cboMethod)
        Me.Controls.Add(Me.lblContactMethod)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.Name = "FRMContactAttempt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contact Attempt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private LinkTable As Enums.TableNames

    Private LinkID As Integer

#End Region

#Region "Events"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

#End Region

#Region "Function"

    Private Function IsFormValid() As Boolean
        If CInt(Combo.GetSelectedItemValue(cboMethod)) = 0 Then
            ShowMessage("Please select a contact method!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If txtNote.Text.Trim.Length = 0 Then
            ShowMessage("Please add a note!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub Save()
        Try
            If Not IsFormValid() Then Exit Sub

            Dim contactAttempt As New ContactAttempt
            With contactAttempt
                .ContactMethedID = CInt(Combo.GetSelectedItemValue(cboMethod))
                .LinkID = CInt(LinkTable)
                .LinkRef = LinkID
                .ContactMade = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second)
                .Notes = txtNote.Text.Trim
                .ContactMadeByUserId = loggedInUser.UserID
            End With
            contactAttempt = DB.ContactAttempts.Insert(contactAttempt)
            If contactAttempt.ContactAttemptID > 0 Then
                ShowMessage("Contact attempt saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.DialogResult = DialogResult.OK
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If
            Else
                ShowMessage("Could not save Contact attempt!, please try re-enter the details.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message & " - " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class