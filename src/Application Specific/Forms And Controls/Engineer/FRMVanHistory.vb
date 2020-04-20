Public Class FRMVanHistory : Inherits FSM.FRMBaseForm : Implements IForm

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grpHistory As System.Windows.Forms.GroupBox
    Friend WithEvents dgHistory As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpHistory = New System.Windows.Forms.GroupBox
        Me.dgHistory = New System.Windows.Forms.DataGrid
        Me.grpHistory.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpHistory
        '
        Me.grpHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHistory.Controls.Add(Me.dgHistory)
        Me.grpHistory.Location = New System.Drawing.Point(8, 40)
        Me.grpHistory.Name = "grpHistory"
        Me.grpHistory.Size = New System.Drawing.Size(856, 440)
        Me.grpHistory.TabIndex = 1
        Me.grpHistory.TabStop = False
        Me.grpHistory.Text = "History"
        '
        'dgHistory
        '
        Me.dgHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistory.DataMember = ""
        Me.dgHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgHistory.Location = New System.Drawing.Point(8, 24)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.Size = New System.Drawing.Size(840, 405)
        Me.dgHistory.TabIndex = 1
        '
        'FRMVanHistory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(872, 486)
        Me.Controls.Add(Me.grpHistory)
        Me.MinimumSize = New System.Drawing.Size(880, 520)
        Me.Name = "FRMVanHistory"
        Me.Text = "Stock Profile History For Engineer : {0}"
        Me.Controls.SetChildIndex(Me.grpHistory, 0)
        Me.grpHistory.ResumeLayout(False)
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        LoadForm(sender, e, Me)
        SetupDataGrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _ID As Integer = 0
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
            Engineer = DB.Engineer.Engineer_Get(ID)
        End Set
    End Property

    Private _Engineer As Entity.Engineers.Engineer = Nothing
    Public Property Engineer() As Entity.Engineers.Engineer
        Get
            Return _Engineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _Engineer = Value

            Me.Text = "Stock Profile History For Engineer : " & Engineer.Name

            VanHistory = DB.EngineerVan.EngineerVan_GetAll_For_Engineer(Engineer.EngineerID, True)
        End Set
    End Property

    Private _VanHistory As DataView
    Public Property VanHistory() As DataView
        Get
            Return _VanHistory
        End Get
        Set(ByVal value As DataView)
            _VanHistory = value
            _VanHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString
            _VanHistory.AllowNew = False
            _VanHistory.AllowEdit = False
            _VanHistory.AllowDelete = False
            Me.dgHistory.DataSource = VanHistory
        End Set
    End Property

    Private ReadOnly Property SelectedHistoryDataRow() As DataRow
        Get
            If Not Me.dgHistory.CurrentRowIndex = -1 Then
                Return VanHistory(Me.dgHistory.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgHistory)
        Dim tStyle As DataGridTableStyle = Me.dgHistory.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Van As New DataGridLabelColumn
        Van.Format = ""
        Van.FormatInfo = Nothing
        Van.HeaderText = "Stock Profile Name"
        Van.MappingName = "Van"
        Van.ReadOnly = True
        Van.Width = 330
        Van.NullText = ""
        tStyle.GridColumnStyles.Add(Van)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dddd dd MMMM yyyy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "From"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 250
        StartDateTime.NullText = ""
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim EndDateTime As New DataGridLabelColumn
        EndDateTime.Format = "dddd dd MMMM yyyy HH:mm"
        EndDateTime.FormatInfo = Nothing
        EndDateTime.HeaderText = "To"
        EndDateTime.MappingName = "EndDateTime"
        EndDateTime.ReadOnly = True
        EndDateTime.Width = 250
        EndDateTime.NullText = "Until Further Notice"
        tStyle.GridColumnStyles.Add(EndDateTime)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString
        Me.dgHistory.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMVanHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

#End Region

End Class
