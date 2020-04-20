Public Class FRMQuoteContractOption3 : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCQuoteContractOption3
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
    Friend WithEvents btnViewContract As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.btnViewContract = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 656)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 25)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(72, 656)
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
        Me.pnlMain.Size = New System.Drawing.Size(640, 616)
        Me.pnlMain.TabIndex = 1
        '
        'btnViewContract
        '
        Me.btnViewContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewContract.Location = New System.Drawing.Point(472, 656)
        Me.btnViewContract.Name = "btnViewContract"
        Me.btnViewContract.Size = New System.Drawing.Size(104, 25)
        Me.btnViewContract.TabIndex = 5
        Me.btnViewContract.Text = "View Contract"
        Me.btnViewContract.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(584, 656)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(55, 25)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.Visible = False
        '
        'FRMQuoteContractOption3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(648, 694)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnViewContract)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(656, 728)
        Me.Name = "FRMQuoteContractOption3"
        Me.Text = "Quote Contract Option3 : ID {0}"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnViewContract, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3 = DB.QuoteContractOption3.QuoteContractOption3_Get(ID)
        LoadForm(sender, e, Me)

        AddHandler CType(LoadedControl, UCQuoteContractOption3).RefreshButton, AddressOf ShowButton
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(GetParameter(1))
        CType(LoadedControl, UCQuoteContractOption3).IDToLinkTo = IDToLinkTo
        CType(LoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3 = DB.QuoteContractOption3.QuoteContractOption3_Get(ID)

        CType(LoadedControl, UCQuoteContractOption3).SetupSitesDataGrid()
        ShowButton()
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
            If ID = 0 Then
                PageState = Entity.Sys.Enums.FormState.Insert
                Me.Text = "Quote Contract : Adding New..."

                Me.btnPrint.Visible = False
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Quote Contract: ID " & ID

                Me.btnPrint.Visible = True
            End If
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
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

    Private _Contract As Entity.ContractOption3s.ContractOption3

    Private Property Contract() As Entity.ContractOption3s.ContractOption3
        Get
            Return _Contract
        End Get
        Set(ByVal Value As Entity.ContractOption3s.ContractOption3)
            _Contract = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMQuoteContractOption3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3 = DB.QuoteContractOption3.QuoteContractOption3_Get(ID)
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnViewContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewContract.Click
        Select Case CType(btnViewContract.Tag, Entity.Sys.Enums.QuoteContractStatus)
            Case Entity.Sys.Enums.QuoteContractStatus.Rejected
                ShowForm(GetType(FRMQuoteRejection), True, New Object() {TheLoadedControl, CType(TheLoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3.ReasonForReject()})
            Case Entity.Sys.Enums.QuoteContractStatus.Generated

        End Select

    End Sub

    Private Sub ShowButton()
        Select Case CType(CType(TheLoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus)
            Case Entity.Sys.Enums.QuoteContractStatus.Accepted
                Contract = DB.ContractOption3.ContractOption3_Get_For_Quote_ID(ID)
                btnViewContract.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Accepted)
                btnViewContract.Text = "View Contract"
                btnViewContract.Visible = Not Contract Is Nothing

            Case Entity.Sys.Enums.QuoteContractStatus.Rejected
                btnViewContract.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Rejected)
                btnViewContract.Text = "View Reason"
                btnViewContract.Visible = True

            Case Entity.Sys.Enums.QuoteContractStatus.Generated
                btnViewContract.Visible = False
                btnViewContract.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated)
        End Select

    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim details As New ArrayList
        details.Add(ID)
        Dim oPrint As New Entity.Sys.Printing(details, CType(LoadedControl, UCQuoteContractOption3).CurrentQuoteContractOption3.QuoteContractReference.Trim & " ", Entity.Sys.Enums.SystemDocumentType.QuoteContractOption3)
    End Sub

#End Region

End Class