Public Class FrmOverride
    Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub New(ByVal fails As ArrayList, ByVal engineerVisitIDIn As Integer, ByVal isCopyIn As Boolean,
                   ByVal _cancelScheduled As Boolean, ByVal _passwordPrompt As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        ReasonsForFailure = fails
        CancelSchedule = _cancelScheduled
        PasswordPrompt = _passwordPrompt
        'Add any initialization after the InitializeComponent() call
        EngineerVisitID = engineerVisitIDIn
        isCopy = isCopyIn
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
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.TreeView1.ImageIndex = -1
        Me.TreeView1.Location = New System.Drawing.Point(8, 56)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = -1
        Me.TreeView1.Size = New System.Drawing.Size(518, 392)
        Me.TreeView1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The test you are trying to assign does not satisfy all the conditions of the engi" &
        "neer scheduler due to the reasons below."
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TreeView1)

        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(538, 456)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Result"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.UseVisualStyleBackColor = True
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnOk.Location = New System.Drawing.Point(472, 504)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Continue"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCancel.Location = New System.Drawing.Point(8, 502)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'FrmOverride
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 534)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(560, 568)
        Me.Name = "FrmOverride"
        Me.Text = "Are you sure you want to schedule this work here?"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private isCopy As Boolean = False

    Private _engineerVisitID As Integer

    Private Property EngineerVisitID() As Integer
        Get
            Return _engineerVisitID
        End Get
        Set(ByVal value As Integer)
            _engineerVisitID = value
        End Set
    End Property

    Private _fails As ArrayList

    Public Property ReasonsForFailure() As ArrayList
        Get
            Return _fails
        End Get
        Set(ByVal Value As ArrayList)
            _fails = Value
        End Set
    End Property

    Private _cancelSchedule As Boolean

    Private Property CancelSchedule() As Boolean
        Get
            Return _cancelSchedule
        End Get
        Set(ByVal Value As Boolean)
            _cancelSchedule = Value
        End Set
    End Property

    Private _passwordPrompt As Boolean

    Private Property PasswordPrompt() As Boolean
        Get
            Return _passwordPrompt
        End Get
        Set(ByVal Value As Boolean)
            _passwordPrompt = Value
        End Set
    End Property

    Private Sub FrmOverride_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)
        LoadReasons()
    End Sub

    Private Sub LoadReasons()
        For x As Integer = 0 To ReasonsForFailure.Count - 1
            TreeView1.Nodes.Add(CStr(ReasonsForFailure.Item(x)))
        Next
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.No
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        For x As Integer = 0 To ReasonsForFailure.Count - 1

            If PasswordPrompt Then
                Dim dialogue As DLGPasswordOverride
                dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
                If dialogue Is Nothing Then
                    dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
                End If
                dialogue.ShowInTaskbar = False
                dialogue.ShowDialog()

                If dialogue.DialogResult = DialogResult.OK Then
                    DialogResult = DialogResult.OK
                    Exit For
                Else
                    Me.DialogResult = DialogResult.No
                    ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                End If
            ElseIf CancelSchedule Then
                Me.DialogResult = DialogResult.No
                ShowMessage("Visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit For
            End If
            DialogResult = DialogResult.OK
        Next
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class