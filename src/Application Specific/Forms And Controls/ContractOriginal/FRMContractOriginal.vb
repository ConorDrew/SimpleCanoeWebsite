Public Class FRMContractOriginal : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCContractOriginal
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
    Friend WithEvents btnPrint As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlMain = New System.Windows.Forms.Panel
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
        Me.pnlMain.Size = New System.Drawing.Size(784, 616)
        Me.pnlMain.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(728, 656)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(56, 25)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        '
        'FRMContractOriginal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(792, 694)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 728)
        Me.Name = "FRMContractOriginal"
        Me.Text = "Contract : ID {0}"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe

        LoadForm(sender, e, Me)
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(GetParameter(1))
        Dim readyToBeInvoiceID As Integer = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))

        CType(LoadedControl, UCContractOriginal).SetupSitesDataGrid()
        CType(LoadedControl, UCContractOriginal).SetupInvoiceAddressDataGrid()
        CType(LoadedControl, UCContractOriginal).CurrentContract = DB.ContractOriginal.Get(ID)
        CType(LoadedControl, UCContractOriginal).IDToLinkTo = IDToLinkTo
        CType(LoadedControl, UCContractOriginal).InvoiceToBeRaised = DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(readyToBeInvoiceID)

        If IDToLinkTo = Entity.Sys.Enums.Customer.Domestic Then
            Try
                If ID > 0 Then
                    Dim dr As DataRow() = CType(LoadedControl, UCContractOriginal).Sites.Table.Select("tick=1")

                    CType(LoadedControl, UCContractOriginal).SiteID = Entity.Sys.Helper.MakeIntegerValid(dr(0).Item("SiteID"))
                Else
                    CType(LoadedControl, UCContractOriginal).SiteID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))
                End If
            Catch ex As Exception
                ShowForm(GetType(FRMQuoteJobSelectASite), True, New Object() {IDToLinkTo, Me})
            End Try

        End If
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

                Me.btnPrint.Visible = False
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Contract : ID " & ID

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

#End Region

#Region "Events"

    Private Sub FRMContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCContractOriginal).CurrentContract = DB.ContractOriginal.Get(ID)
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If CType(LoadedControl, UCContractOriginal).NumberUsed = False And Not CType(LoadedControl, UCContractOriginal).Number Is Nothing Then
            DB.Job.DeleteReservedOrderNumber(CType(LoadedControl, UCContractOriginal).Number.JobNumber, CType(LoadedControl, UCContractOriginal).Number.Prefix)
        End If
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim dtContracts As DataTable = DB.ContractOriginal.ProcessContract(ID)
        If dtContracts Is Nothing Then Exit Sub
        Dim details As New ArrayList() From {dtContracts}
        Dim oPrint As New Entity.Sys.Printing(details, CType(LoadedControl, UCContractOriginal).CurrentContract.ContractReference.Trim & " ", Entity.Sys.Enums.SystemDocumentType.ContractOption1)
    End Sub

    Private Sub FRMContractOriginal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            CType(GetParameter(2), FRMContractManager).PopulateDatagrid()
        Catch ex As Exception
            'EMPTY TRY - ALP
        End Try
    End Sub

#End Region

End Class