Public Class FRMChangeOverridePassword_Service : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents grpNewDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents grpCurrentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.grpNewDetails = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.grpCurrentDetails = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpNewDetails.SuspendLayout()
        Me.grpCurrentDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleDescription = "Update the override password"
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Location = New System.Drawing.Point(336, 208)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(56, 23)
        Me.btnUpdate.TabIndex = 37
        Me.btnUpdate.Text = "Update"
        '
        'grpNewDetails
        '
        Me.grpNewDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNewDetails.Controls.Add(Me.Label2)
        Me.grpNewDetails.Controls.Add(Me.Label3)
        Me.grpNewDetails.Controls.Add(Me.txtNewPassword)
        Me.grpNewDetails.Controls.Add(Me.txtConfirm)
        Me.grpNewDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNewDetails.Location = New System.Drawing.Point(8, 104)
        Me.grpNewDetails.Name = "grpNewDetails"
        Me.grpNewDetails.Size = New System.Drawing.Size(384, 96)
        Me.grpNewDetails.TabIndex = 39
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
        Me.txtNewPassword.Size = New System.Drawing.Size(265, 21)
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
        Me.txtConfirm.Size = New System.Drawing.Size(265, 21)
        Me.txtConfirm.TabIndex = 3
        '
        'grpCurrentDetails
        '
        Me.grpCurrentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCurrentDetails.Controls.Add(Me.txtPassword)
        Me.grpCurrentDetails.Controls.Add(Me.Label1)
        Me.grpCurrentDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCurrentDetails.Location = New System.Drawing.Point(8, 40)
        Me.grpCurrentDetails.Name = "grpCurrentDetails"
        Me.grpCurrentDetails.Size = New System.Drawing.Size(384, 56)
        Me.grpCurrentDetails.TabIndex = 38
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
        Me.txtPassword.Size = New System.Drawing.Size(264, 21)
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
        'FRMChangeOverridePassword_Service
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(392, 233)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.grpNewDetails)
        Me.Controls.Add(Me.grpCurrentDetails)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(408, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(408, 272)
        Me.Name = "FRMChangeOverridePassword_Service"
        Me.Text = "Service Override Password"
        Me.Controls.SetChildIndex(Me.grpCurrentDetails, 0)
        Me.Controls.SetChildIndex(Me.grpNewDetails, 0)
        Me.Controls.SetChildIndex(Me.btnUpdate, 0)
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

#Region "Events"

    Private Sub FRMChangeOverridePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
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
            If Not (Entity.Sys.Helper.HashPassword(Me.txtPassword.Text.Trim) = DB.Manager.Get.OverridePassword_Service) Then
                msg += errorCount & ". Current password incorrect" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Not (Me.txtNewPassword.Text.Trim = Me.txtConfirm.Text.Trim) Then
                msg += errorCount & ". New and confirm password do not match" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Me.txtNewPassword.Text.Trim.Length < 6 Then
                msg += errorCount & ". Password too short (6 - 25 characters)" & vbCrLf
                errorCount += 1
                valid = False
            End If
            If Me.txtNewPassword.Text.Trim.Length > 25 Then
                msg += errorCount & ". Password too long (6 - 25 characters)" & vbCrLf
                errorCount += 1
                valid = False
            End If

            If valid Then
                DB.Manager.UpdateOverridePassword_Service(Me.txtNewPassword.Text.Trim)
                ShowMessage("Service Override Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPassword.Text = ""
                Me.txtNewPassword.Text = ""
                Me.txtConfirm.Text = ""
            Else
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error Saving New Password : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.ActiveControl = Me.txtPassword
            Me.txtPassword.Focus()
        End Try
    End Sub

#End Region

End Class
