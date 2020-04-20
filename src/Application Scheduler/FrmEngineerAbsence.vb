Public Class FrmEngineerAbsence : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal absenceID As Integer = 0)
        MyBase.New()

        Me.AbsenceID = absenceID

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        TheLoadedControl = New UCAbsences(Entity.Sys.Enums.UserType.Engineer, absenceID)
        Me.pnlAbsence.Controls.Add(TheLoadedControl)

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
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlAbsence As Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlAbsence = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCancel.Location = New System.Drawing.Point(12, 315)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSave.Location = New System.Drawing.Point(552, 315)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlAbsence
        '
        Me.pnlAbsence.Location = New System.Drawing.Point(0, 53)
        Me.pnlAbsence.Name = "pnlAbsence"
        Me.pnlAbsence.Size = New System.Drawing.Size(624, 249)
        Me.pnlAbsence.TabIndex = 12
        '
        'FrmEngineerAbsence
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(628, 343)
        Me.Controls.Add(Me.pnlAbsence)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEngineerAbsence"
        Me.Text = "Engineer Absence"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.pnlAbsence, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private TheLoadedControl As IUserControl

    Private _absenceID As Integer = 0

    Public Property AbsenceID() As Integer
        Get
            Return _absenceID
        End Get
        Set(value As Integer)
            _absenceID = value
        End Set
    End Property

#End Region

    Private Sub FrmEngineerAbsence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm(Me)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If TheLoadedControl.Save() Then
            Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub


End Class