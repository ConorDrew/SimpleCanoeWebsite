Public Class FRMLogin : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpLoginDetails As System.Windows.Forms.GroupBox

    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMLogin))
        Me.grpLoginDetails = New System.Windows.Forms.GroupBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.grpLoginDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLoginDetails
        '
        Me.grpLoginDetails.Controls.Add(Me.btnLogin)
        Me.grpLoginDetails.Controls.Add(Me.Label2)
        Me.grpLoginDetails.Controls.Add(Me.Label3)
        Me.grpLoginDetails.Controls.Add(Me.txtUserName)
        Me.grpLoginDetails.Controls.Add(Me.txtPassword)
        Me.grpLoginDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoginDetails.Location = New System.Drawing.Point(8, 40)
        Me.grpLoginDetails.Name = "grpLoginDetails"
        Me.grpLoginDetails.Size = New System.Drawing.Size(392, 128)
        Me.grpLoginDetails.TabIndex = 12
        Me.grpLoginDetails.TabStop = False
        Me.grpLoginDetails.Text = "Enter Login Details"
        '
        'btnLogin
        '
        Me.btnLogin.AccessibleDescription = "Login to application"
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Location = New System.Drawing.Point(96, 96)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(56, 23)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password"
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(96, 22)
        Me.txtUserName.MaxLength = 50
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(288, 21)
        Me.txtUserName.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(96, 62)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(288, 21)
        Me.txtPassword.TabIndex = 2
        '
        'FRMLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(400, 169)
        Me.Controls.Add(Me.grpLoginDetails)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(416, 208)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(416, 208)
        Me.Name = "FRMLogin"
        Me.Controls.SetChildIndex(Me.grpLoginDetails, 0)
        Me.grpLoginDetails.ResumeLayout(False)
        Me.grpLoginDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

#If DEBUG Then
        Me.txtUserName.Text = "admin"
        Select Case True
            Case IsGasway
                Me.txtPassword.Text = "Gabriel_!"
            Case IsRFT
                Me.txtPassword.Text = "RftAdm!n57"
            Case IsBlueflame
                Me.txtPassword.Text = "Blu3Adm!n57"
        End Select
#End If
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

    Private Sub FRMLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub FRMLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        CloseApplication()
    End Sub

    Private Sub FRMLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                CloseApplication()
            End If
        Catch ex As Exception
            ShowMessage("Action cannot be completed : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        LogMeIn()
    End Sub

#End Region

#Region "Functions"

    Private Sub LogMeIn()
        If Me.txtUserName.Text.Trim.Length = 0 Or Me.txtPassword.Text.Trim.Length = 0 Then
            ShowMessage("Missing Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                If Not DB.User.Authenticate(Me.txtUserName.Text, Me.txtPassword.Text) Then
                    DB.User.IsUserActive(Me.txtUserName.Text, 0, True)
                    If Not String.IsNullOrEmpty(loggedInUser?.Password) Then
                        loggedInUser = Nothing
                    End If
                End If
                Me.txtPassword.Text = ""
                Me.ActiveControl = Me.txtUserName
                Me.txtUserName.Focus()

                If loggedInUser Is Nothing Then
                    ShowMessage("Invalid login details", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf loggedInUser.UpdateAtLogon Or loggedInUser.PasswordExpiryDate < Now.AddDays(-1) Then
                    Dim frm As New FRMChangePassword
                    frm.ShowDialog()
                    If frm.DialogResult = DialogResult.Yes Then
                        Unlock()
                        Login()
                    Else
                        ShowMessage("New password needed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    Unlock()
                    Login()
                End If
            Catch ex As Exception
                ShowMessage("Application cannot load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try
        End If
    End Sub

#End Region

End Class