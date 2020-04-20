Imports System.IO

Public Class FRMReleaseNotes : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents rtbReleaseNotes As RichTextBox


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rtbReleaseNotes = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtbReleaseNotes
        '
        Me.rtbReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbReleaseNotes.Location = New System.Drawing.Point(0, 32)
        Me.rtbReleaseNotes.Name = "rtbReleaseNotes"
        Me.rtbReleaseNotes.Size = New System.Drawing.Size(478, 300)
        Me.rtbReleaseNotes.TabIndex = 2
        Me.rtbReleaseNotes.Text = ""
        '
        'FRMReleaseNotes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(478, 332)
        Me.Controls.Add(Me.rtbReleaseNotes)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(416, 208)
        Me.Name = "FRMReleaseNotes"
        Me.Controls.SetChildIndex(Me.rtbReleaseNotes, 0)
        Me.ResumeLayout(False)

    End Sub
    Public process As System.Diagnostics.Process = New System.Diagnostics.Process()
#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        FillReleaseNotes()
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

    Private Sub FRMReleaseNotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub
#End Region

#Region "Functions"
    Private Sub FillReleaseNotes()
        Dim releaseNote As String = Entity.Sys.Helper.GetTextResource(ReleaseNoteTextFile)
        rtbReleaseNotes.Text = releaseNote
    End Sub

    Private Sub rtbReleaseNotes_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles rtbReleaseNotes.LinkClicked
        process = System.Diagnostics.Process.Start(e.LinkText)
    End Sub
#End Region

End Class
