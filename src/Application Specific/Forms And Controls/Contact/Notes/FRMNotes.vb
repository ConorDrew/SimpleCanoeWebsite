Public Class FRMNotes : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCNotes
        Me.pnlMain.Controls.Add(TheLoadedControl)
        AddHandler LoadedControl.StateChanged, AddressOf ResetMe
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
    Friend WithEvents btnSave As System.Windows.Forms.Button

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 328)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 25)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(72, 328)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 25)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Location = New System.Drawing.Point(0, 32)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(803, 288)
        Me.pnlMain.TabIndex = 1
        '
        'FRMNotes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(811, 366)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(819, 400)
        Me.Name = "FRMNotes"
        Me.Text = "Note : ID {0}"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCNotes).CurrentNote = DB.Notes.Notes_Get(ID)
        CType(LoadedControl, UCNotes).CurrentNote.SetContactID = GetParameter(1)
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Me.pnlMain.Controls(0)
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
        If GetParameter(2).Name = "UCContact" Then
            CType(GetParameter(2), UCContact).NotesDataView = DB.Notes.NotesForContact(GetParameter(1))
        End If
    End Sub

#End Region

#Region "Properties"

    Private TheLoadedControl As IUserControl

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
            If ID = 0 Then
                PageState = Entity.Sys.Enums.FormState.Insert
                Me.Text = "Note : Adding New..."
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Note : ID " & ID
            End If
        End Set
    End Property

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMNotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCNotes).CurrentNote = DB.Notes.Notes_Get(ID)
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

End Class