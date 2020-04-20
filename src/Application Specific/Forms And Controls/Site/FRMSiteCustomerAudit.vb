Public Class FRMSiteCustomerAudit: Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgAuditTrail As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgAuditTrail = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgAuditTrail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgAuditTrail)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 336)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgAuditTrail
        '
        Me.dgAuditTrail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAuditTrail.DataMember = ""
        Me.dgAuditTrail.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAuditTrail.Location = New System.Drawing.Point(10, 19)
        Me.dgAuditTrail.Name = "dgAuditTrail"
        Me.dgAuditTrail.Size = New System.Drawing.Size(458, 309)
        Me.dgAuditTrail.TabIndex = 0
        '
        'FRMSiteCustomerAudit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(496, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMSiteCustomerAudit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Site Customer Audit"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgAuditTrail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        AuditTrail = DB.SiteCustomerAudit.SiteCustomerAudit_GetAll(ID)
        LoadForm(sender, e, Me)
        SetupAuditDataGrid()
        
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

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
        End Set
    End Property

    Private _AuditTrail As DataView
    Private Property AuditTrail() As DataView
        Get
            Return _AuditTrail
        End Get
        Set(ByVal Value As DataView)
            _AuditTrail = Value
            _AuditTrail.AllowDelete = False
            _AuditTrail.AllowEdit = False
            _AuditTrail.AllowNew = False
            _AuditTrail.Table.TableName = "Audit"
            dgAuditTrail.DataSource = AuditTrail
        End Set
    End Property
#End Region

#Region "Setup"

    Public Sub SetupAuditDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgAuditTrail)
        Dim tStyle As DataGridTableStyle = Me.dgAuditTrail.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim PreviousCustomer As New DataGridLabelColumn
        PreviousCustomer.Format = ""
        PreviousCustomer.FormatInfo = Nothing
        PreviousCustomer.HeaderText = "Previous Customer"
        PreviousCustomer.MappingName = "Name"
        PreviousCustomer.ReadOnly = True
        PreviousCustomer.Width = 250
        PreviousCustomer.NullText = ""
        tStyle.GridColumnStyles.Add(PreviousCustomer)

        Dim DateChanged As New DataGridLabelColumn
        DateChanged.Format = "dd/MM/yyyy HH:mm:ss"
        DateChanged.FormatInfo = Nothing
        DateChanged.HeaderText = "Date Changed"
        DateChanged.MappingName = "DateChanged"
        DateChanged.ReadOnly = True
        DateChanged.Width = 110
        DateChanged.NullText = ""
        tStyle.GridColumnStyles.Add(DateChanged)

        Dim userFullName As New DataGridLabelColumn
        userFullName.Format = ""
        userFullName.FormatInfo = Nothing
        userFullName.HeaderText = "User"
        userFullName.MappingName = "UserFullName"
        userFullName.ReadOnly = True
        userFullName.Width = 250
        userFullName.NullText = ""
        tStyle.GridColumnStyles.Add(userFullName)

        tStyle.ReadOnly = True
        tStyle.MappingName = "Audit"
        Me.dgAuditTrail.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMSiteCustomerAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

#End Region

End Class
