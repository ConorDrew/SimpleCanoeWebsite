Public Class FRMJobWizard : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCJobWizard
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
    Friend WithEvents btnClose As System.Windows.Forms.Button

    Friend WithEvents btnPrivateNotes As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSaveProg As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnPrivateNotes = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSaveProg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(12, 724)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 25)
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
        Me.pnlMain.Size = New System.Drawing.Size(926, 685)
        Me.pnlMain.TabIndex = 1
        '
        'btnPrivateNotes
        '
        Me.btnPrivateNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrivateNotes.Location = New System.Drawing.Point(380, 724)
        Me.btnPrivateNotes.Name = "btnPrivateNotes"
        Me.btnPrivateNotes.Size = New System.Drawing.Size(123, 25)
        Me.btnPrivateNotes.TabIndex = 4
        Me.btnPrivateNotes.Text = "Private Notes"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(709, 724)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(87, 25)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Restart"
        '
        'btnSaveProg
        '
        Me.btnSaveProg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveProg.Location = New System.Drawing.Point(802, 724)
        Me.btnSaveProg.Name = "btnSaveProg"
        Me.btnSaveProg.Size = New System.Drawing.Size(122, 25)
        Me.btnSaveProg.TabIndex = 6
        Me.btnSaveProg.Text = "Save Progress"
        Me.btnSaveProg.Visible = False
        '
        'FRMJobWizard
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(934, 761)
        Me.Controls.Add(Me.btnSaveProg)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnPrivateNotes)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(950, 733)
        Me.Name = "FRMJobWizard"
        Me.Text = "Job Wizard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnPrivateNotes, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.btnSaveProg, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCJobWizard).DGVSites.AutoGenerateColumns = False
        CType(LoadedControl, UCJobWizard).SetupSiteDataGridView()
        CType(LoadedControl, UCJobWizard).SetupAppsDG()
        CType(LoadedControl, UCJobWizard).SetupSOR()
        CType(LoadedControl, UCJobWizard).SetupDGSymptoms()
        CType(LoadedControl, UCJobWizard).SetupDGAdditional()
        CType(LoadedControl, UCJobWizard).SetupExisitingJobs()

        LoadForm(sender, e, Me)

        Try
            CType(LoadedControl, UCJobWizard).FromForm = GetParameter(1)
        Catch ex As Exception
            'DO NOTHING
        End Try
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
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Dim oCust As New Entity.Customers.Customer
                oCust = DB.Customer.Customer_Get_ForSiteID(ID)
                Me.Text = "Property : ID " & ID & " for Customer: " & oCust.Name & ", Acc: " & oCust.AccountNumber
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

    Private Sub FRMSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoadedControl.Save() Then
            ' CType(LoadedControl, UCJobWizard).CurrentSite = DB.Sites.Get(ID)
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

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnPrivateNotes.Click
        CType(LoadedControl, UCJobWizard).Notes()
    End Sub

    Private Sub btnReset_Click_1(sender As Object, e As EventArgs) Handles btnReset.Click
        CType(LoadedControl, UCJobWizard).Reset()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSaveProg.Click
        CType(LoadedControl, UCJobWizard).SaveProgress()
    End Sub

End Class