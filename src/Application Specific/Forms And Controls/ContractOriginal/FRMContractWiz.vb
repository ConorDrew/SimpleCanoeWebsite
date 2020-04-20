Public Class FRMContractWiz : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCContractWiz
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
    Public WithEvents btnSave As System.Windows.Forms.Button

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents btnReprintExpiry As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnReprintExpiry = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(905, 734)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(171, 25)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Create Contract"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(12, 734)
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
        Me.pnlMain.Size = New System.Drawing.Size(1076, 693)
        Me.pnlMain.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(714, 734)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 25)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Print Documentation"
        '
        'btnReprintExpiry
        '
        Me.btnReprintExpiry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReprintExpiry.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintExpiry.Location = New System.Drawing.Point(522, 731)
        Me.btnReprintExpiry.Name = "btnReprintExpiry"
        Me.btnReprintExpiry.Size = New System.Drawing.Size(171, 25)
        Me.btnReprintExpiry.TabIndex = 5
        Me.btnReprintExpiry.Text = "Print Expiry"
        '
        'FRMContractWiz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1084, 771)
        Me.Controls.Add(Me.btnReprintExpiry)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1100, 810)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1100, 810)
        Me.Name = "FRMContractWiz"
        Me.Text = "Contract : ID {0}"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.btnReprintExpiry, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe

        LoadForm(sender, e, Me)
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(GetParameter(1))

        'CType(LoadedControl, UCContractWiz).SetupMainDataGrid()
        'CType(LoadedControl, UCContractWiz).SetupInvoiceAddressDataGrid()
        CType(LoadedControl, UCContractWiz).CurrentContract = DB.ContractOriginal.Get(ID)
        CType(LoadedControl, UCContractWiz).IDToLinkTo = IDToLinkTo
        CType(LoadedControl, UCContractWiz).SiteID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))

        'If IDToLinkTo = Entity.Sys.Enums.Customer.Domestic Then
        '    Try
        '        If ID > 0 Then
        '            Dim dr As DataRow() = CType(LoadedControl, UCContractWiz).Sites.Table.Select("tick=1")

        '            CType(LoadedControl, UCContractWiz).SiteID = Entity.Sys.Helper.MakeIntegerValid(dr(0).Item("SiteID"))
        '        Else
        '            CType(LoadedControl, UCContractWiz).SiteID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))
        '        End If
        '    Catch ex As Exception
        '        ShowForm(GetType(FRMQuoteJobSelectASite), True, New Object() {IDToLinkTo, Me})
        '    End Try

        'End If
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
                Me.Text = "Contract : Adding New..."
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Contract : ID " & ID
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

#End Region

#Region "Events"

    Private Sub FRMContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCContractWiz).CurrentContract = DB.ContractOriginal.Get(ID)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CType(LoadedControl, UCContractWiz).ProcessContracts()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If CType(LoadedControl, UCContractWiz).NumberUsed = False And Not CType(LoadedControl, UCContractWiz).Number Is Nothing Then
            DB.Job.DeleteReservedOrderNumber(CType(LoadedControl, UCContractWiz).Number.JobNumber, CType(LoadedControl, UCContractWiz).Number.Prefix)
        End If
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub FRMContractOriginal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            CType(GetParameter(2), FRMContractManager).PopulateDatagrid()
        Catch ex As Exception
            'EMPTY TRY - ALP
        End Try
    End Sub

#End Region

    Private Sub btnReprintExpiry_Click(sender As Object, e As EventArgs) Handles btnReprintExpiry.Click
        CType(LoadedControl, UCContractWiz).ProcessExpiry()
    End Sub

End Class