Public Class FRMQuoteContractAlternativeConvert : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        TheLoadedControl = New UCQuoteContractAlternativeConvert
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
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Location = New System.Drawing.Point(0, 32)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(982, 616)
        Me.pnlMain.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(8, 664)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 25)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(136, 664)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(488, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Convert Quote to Contract"
        '
        'FRMQuoteContractAlternativeConvert
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(982, 702)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MinimumSize = New System.Drawing.Size(990, 736)
        Me.Name = "FRMQuoteContractAlternativeConvert"
        Me.Text = "FRMQuoteContractConvert"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCQuoteContractAlternativeConvert).CurrentQuoteContract = DB.QuoteContractAlternative.Get(ID)

        CType(LoadedControl, UCQuoteContractAlternativeConvert).SetupSitesDataGrid()
        CType(LoadedControl, UCQuoteContractAlternativeConvert).SetupInvoiceAddressDataGrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Me.pnlMain.Controls(0)
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
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

            Me.Text = "Convert Quote to Contract "

        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
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