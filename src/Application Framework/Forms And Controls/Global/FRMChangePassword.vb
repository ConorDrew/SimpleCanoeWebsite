Imports System.Text.RegularExpressions

Public Class FRMChangePassword : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents grpNewDetails As System.Windows.Forms.GroupBox

    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents grpCurrentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpNewDetails = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.grpCurrentDetails = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpNewDetails.SuspendLayout()
        Me.grpCurrentDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpNewDetails
        '
        Me.grpNewDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNewDetails.Controls.Add(Me.Label2)
        Me.grpNewDetails.Controls.Add(Me.Label3)
        Me.grpNewDetails.Controls.Add(Me.txtNewPassword)
        Me.grpNewDetails.Controls.Add(Me.txtConfirm)
        Me.grpNewDetails.Controls.Add(Me.btnUpdate)
        Me.grpNewDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNewDetails.Location = New System.Drawing.Point(9, 104)
        Me.grpNewDetails.Name = "grpNewDetails"
        Me.grpNewDetails.Size = New System.Drawing.Size(391, 128)
        Me.grpNewDetails.TabIndex = 36
        Me.grpNewDetails.TabStop = False
        Me.grpNewDetails.Text = "New Details"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Password "
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Confirm "
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPassword.Location = New System.Drawing.Point(112, 32)
        Me.txtNewPassword.MaxLength = 50
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(272, 21)
        Me.txtNewPassword.TabIndex = 2
        '
        'txtConfirm
        '
        Me.txtConfirm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConfirm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(112, 64)
        Me.txtConfirm.MaxLength = 50
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(272, 21)
        Me.txtConfirm.TabIndex = 3
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleDescription = "Update your password"
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Location = New System.Drawing.Point(327, 96)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(56, 23)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'grpCurrentDetails
        '
        Me.grpCurrentDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCurrentDetails.Controls.Add(Me.txtPassword)
        Me.grpCurrentDetails.Controls.Add(Me.Label1)
        Me.grpCurrentDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCurrentDetails.Location = New System.Drawing.Point(9, 40)
        Me.grpCurrentDetails.Name = "grpCurrentDetails"
        Me.grpCurrentDetails.Size = New System.Drawing.Size(391, 61)
        Me.grpCurrentDetails.TabIndex = 35
        Me.grpCurrentDetails.TabStop = False
        Me.grpCurrentDetails.Text = "Current Details"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(112, 24)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(271, 21)
        Me.txtPassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Password "
        '
        'FRMChangePassword
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(412, 242)
        Me.Controls.Add(Me.grpNewDetails)
        Me.Controls.Add(Me.grpCurrentDetails)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(428, 281)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(428, 281)
        Me.Name = "FRMChangePassword"
        Me.Text = "Your Password"
        Me.Controls.SetChildIndex(Me.grpCurrentDetails, 0)
        Me.Controls.SetChildIndex(Me.grpNewDetails, 0)
        Me.grpNewDetails.ResumeLayout(False)
        Me.grpNewDetails.PerformLayout()
        Me.grpCurrentDetails.ResumeLayout(False)
        Me.grpCurrentDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Me.ActiveControl = Me.txtPassword
        Me.txtPassword.Focus()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private isLoading As Boolean = True

#End Region

#Region "Events"

    Private Sub FRMChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isLoading = True
        LoadMe(sender, e)
        isLoading = False
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim msg As String = "Please correct the following errors : " & vbCrLf & vbCrLf
            Dim errorCount As Integer = 1
            Dim valid As Boolean = True

            If Me.txtPassword.Text.Trim.Length = 0 Then
                msg += errorCount & ". Current password not entered" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Me.txtNewPassword.Text.Trim.Length = 0 Then
                msg += errorCount & ". New password not entered" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Me.txtConfirm.Text.Trim.Length = 0 Then
                msg += errorCount & ". Confirmation password not entered" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Not (Me.txtNewPassword.Text.Trim = Me.txtConfirm.Text.Trim) Then
                msg += errorCount & ". Confirmation does not match new password" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Not String.IsNullOrEmpty(loggedInUser.Password) AndAlso Not (Entity.Sys.Helper.HashPassword(Me.txtPassword.Text.Trim) = loggedInUser.Password()) Then
                msg += errorCount & ". Incorrect current password entered" & vbCrLf
                errorCount += 1
                valid = False
            End If

            Dim minLength As Integer = 8
            Dim upper As New Regex("[A-Z]")
            Dim lower As New Regex("[a-z]")
            Dim number As New Regex("[0-9]")
            Dim special As New Regex("[^a-zA-Z0-9]")
            Dim pwd As String = Me.txtNewPassword.Text

            If Len(pwd) < minLength Then
                msg += errorCount & ". Password must have a minimum length of 8 characters" & vbCrLf
                errorCount += 1
                valid = False
            End If

            If upper.Matches(pwd).Count < 1 Then
                msg += errorCount & ". Password must contain a upper case character" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If lower.Matches(pwd).Count < 1 Then
                msg += errorCount & ". Password must contain a lower case character" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If number.Matches(pwd).Count < 1 And special.Matches(pwd).Count < 1 Then
                msg += errorCount & ". Password must contain a number and/or a special character" & vbCrLf
                errorCount += 1
                valid = False
            End If

            If loggedInUser.UserID = TheSystem.Configuration.SuperAdminID Then
                msg += errorCount & ". System Administrator's details cannot be changed" & vbCrLf
                errorCount += 1
                valid = False
            End If

            Dim fullName As String() = loggedInUser.Fullname.Split(New Char() {" "c})
            If fullName.Length > 0 AndAlso pwd.ToLower().Contains(fullName(0).ToLower()) Then
                msg += errorCount & ". Password cannot contain your name" & vbCrLf
                errorCount += 1
                valid = False
            End If

            If pwd.ToLower().Contains("password") Then
                msg += errorCount & ". Password cannot contain 'password'" & vbCrLf
                errorCount += 1
                valid = False
            End If

            Dim dtPasswords As DataTable = DB.User.Get_Passwords(loggedInUser.UserID).Table
            For Each row As DataRow In dtPasswords.Rows
                Dim pass As String = Entity.Sys.Helper.HashPassword(pwd)
                If (Not IsDBNull(row("CurrentPassword")) AndAlso pass = row("CurrentPassword")) Or
                    (Not IsDBNull(row("LastPassword")) AndAlso pass = row("LastPassword")) Or
                    (Not IsDBNull(row("EarliestPassword")) AndAlso pass = row("EarliestPassword")) Then
                    msg += errorCount & ". Password does not match historic requirement" & vbCrLf
                    errorCount += 1
                    valid = False
                    Exit For
                End If
            Next

            If valid Then
                DB.User.UpdatePassword(loggedInUser.UserID, Me.txtNewPassword.Text.Trim)
                loggedInUser.SetPassword = Entity.Sys.Helper.HashPassword(Me.txtNewPassword.Text.Trim)
                ShowMessage("Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.Yes
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If
            Else
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNewPassword.Text = String.Empty
                txtConfirm.Text = String.Empty
                txtNewPassword.Focus()
            End If
        Catch ex As Exception
            ShowMessage("Unable to save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.ActiveControl = Me.txtPassword
            Me.txtPassword.Focus()
        End Try
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNewPassword.Focus()
        End If
    End Sub

    Private Sub TxtNewPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtConfirm.Focus()
        End If
    End Sub

    Private Sub TxtConfirm_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfirm.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnUpdate_Click(sender, e)
        End If
    End Sub

#End Region

End Class