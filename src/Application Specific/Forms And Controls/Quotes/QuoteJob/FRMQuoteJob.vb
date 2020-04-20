Public Class FRMQuoteJob : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        TheLoadedControl = New UCQuoteJob
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

    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnViewJob As System.Windows.Forms.Button
    Friend WithEvents btnViewSite As System.Windows.Forms.Button
    Friend WithEvents btnConvert As Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnViewJob = New System.Windows.Forms.Button()
        Me.btnViewSite = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Location = New System.Drawing.Point(0, 32)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1184, 708)
        Me.pnlMain.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 747)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(72, 747)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'btnViewJob
        '
        Me.btnViewJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewJob.Location = New System.Drawing.Point(808, 747)
        Me.btnViewJob.Name = "btnViewJob"
        Me.btnViewJob.Size = New System.Drawing.Size(88, 24)
        Me.btnViewJob.TabIndex = 5
        Me.btnViewJob.Text = "View Job"
        Me.btnViewJob.Visible = False
        '
        'btnViewSite
        '
        Me.btnViewSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewSite.Location = New System.Drawing.Point(134, 747)
        Me.btnViewSite.Name = "btnViewSite"
        Me.btnViewSite.Size = New System.Drawing.Size(100, 24)
        Me.btnViewSite.TabIndex = 7
        Me.btnViewSite.Text = "View Property"
        '
        'btnConvert
        '
        Me.btnConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConvert.Location = New System.Drawing.Point(1022, 747)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(92, 23)
        Me.btnConvert.TabIndex = 8
        Me.btnConvert.Text = "Convert"
        '
        'FRMQuoteJob
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1184, 781)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnViewSite)
        Me.Controls.Add(Me.btnViewJob)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1200, 820)
        Me.Name = "FRMQuoteJob"
        Me.Text = "Quote Job : ID {0}"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnViewJob, 0)
        Me.Controls.SetChildIndex(Me.btnViewSite, 0)
        Me.Controls.SetChildIndex(Me.btnConvert, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        AddHandler CType(LoadedControl, UCQuoteJob).RefreshButton, AddressOf ShowButton

        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))

        Dim convertedJobNumber As String = DB.Job.Job_Get_For_Quote_ID(ID)?.JobNumber

        CType(LoadedControl, UCQuoteJob).CurrentQuoteJob = DB.QuoteJob.Get(ID)
        CType(LoadedControl, UCQuoteJob).CurrentSite = DB.Sites.Get(Entity.Sys.Helper.MakeIntegerValid(GetParameter(1)))
        CType(LoadedControl, UCQuoteJob).LoadDepartment()
        LoadForm(sender, e, Me)

        CType(LoadedControl, UCQuoteJob).SetupPartsAndProductsDataGrid()
        CType(LoadedControl, UCQuoteJob).SetupScheduleOfRatesDataGrid()
        ShowButton()

        If Not String.IsNullOrWhiteSpace(convertedJobNumber) Then
            Me.btnConvert.Text = convertedJobNumber
            Me.btnConvert.Enabled = False
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
                Me.Text = "Quote Job : Adding New..."
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Quote Job : ID " & ID
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

    Private _Job As Entity.Jobs.Job

    Private Property Job() As Entity.Jobs.Job
        Get
            Return _Job
        End Get
        Set(ByVal Value As Entity.Jobs.Job)
            _Job = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMQuoteJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCQuoteJob).CurrentQuoteJob = DB.QuoteJob.Get(ID)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnViewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewJob.Click
        Select Case CType(btnViewJob.Tag, Entity.Sys.Enums.QuoteContractStatus)
            Case Entity.Sys.Enums.QuoteContractStatus.Accepted
                ShowForm(GetType(FRMLogCallout), True, New Object() {Job.JobID, Job.PropertyID, Me})
            Case Entity.Sys.Enums.QuoteContractStatus.Rejected
                ShowForm(GetType(FRMQuoteRejection), True, New Object() {TheLoadedControl, CType(TheLoadedControl, UCQuoteJob).CurrentQuoteJob.ReasonForReject, CType(TheLoadedControl, UCQuoteJob).CurrentQuoteJob.ReasonForRejectID})
            Case Entity.Sys.Enums.QuoteContractStatus.Generated

        End Select
    End Sub

    Private Sub btnViewSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSite.Click
        ' ShowForm(GetType(FRMSite), True, New Object() {Job.PropertyID, Me})
        ShowForm(GetType(FRMSite), True, New Object() {CType(LoadedControl, UCQuoteJob).CurrentSite.SiteID, Me})
    End Sub

    Private Sub ShowButton()
        Select Case CType(CType(TheLoadedControl, UCQuoteJob).CurrentQuoteJob.StatusEnumID, Entity.Sys.Enums.QuoteContractStatus)
            Case Entity.Sys.Enums.QuoteContractStatus.Accepted
                Job = DB.Job.Job_Get_For_Quote_ID(ID)
                btnViewJob.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Accepted)
                btnViewJob.Text = "View Job"
                btnViewJob.Visible = Not Job Is Nothing

            Case Entity.Sys.Enums.QuoteContractStatus.Rejected
                btnViewJob.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Rejected)
                btnViewJob.Text = "View Reason"
                btnViewJob.Visible = True

            Case Entity.Sys.Enums.QuoteContractStatus.Generated
                btnViewJob.Visible = False
                btnViewJob.Tag = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated)
        End Select

    End Sub

    Private Sub FRMQuoteJob_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        CloseTheForm()
    End Sub

#End Region

#Region "Functions"

    Private Sub CloseTheForm()
        If CType(TheLoadedControl, UCQuoteJob).QuoteNumberUsed = False Then
            DB.QuoteJob.DeleteReservedQuoteNumber(CType(TheLoadedControl, UCQuoteJob).QuoteNumber.JobNumber)
        End If
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Me.btnConvert.Enabled = False
        Dim jobNumber As String = CType(TheLoadedControl, UCQuoteJob).QuoteJob_Create_InstallJob()
        Me.btnConvert.Text = If(jobNumber.Length > 0, jobNumber, Me.btnConvert.Text)
        Me.btnConvert.Enabled = Not jobNumber.Length > 0
    End Sub

#End Region

End Class