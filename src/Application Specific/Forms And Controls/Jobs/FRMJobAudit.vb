Public Class FRMJobAudit : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpJobAudit As System.Windows.Forms.GroupBox

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgJobAudits As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobAudit = New System.Windows.Forms.GroupBox
        Me.dgJobAudits = New System.Windows.Forms.DataGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpJobAudit.SuspendLayout()
        CType(Me.dgJobAudits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJobAudit
        '
        Me.grpJobAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobAudit.Controls.Add(Me.dgJobAudits)

        Me.grpJobAudit.Location = New System.Drawing.Point(10, 40)
        Me.grpJobAudit.Name = "grpJobAudit"
        Me.grpJobAudit.Size = New System.Drawing.Size(837, 400)
        Me.grpJobAudit.TabIndex = 3
        Me.grpJobAudit.TabStop = False
        Me.grpJobAudit.Text = "Job Audit Trail"
        '
        'dgJobAudits
        '
        Me.dgJobAudits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobAudits.DataMember = ""
        Me.dgJobAudits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobAudits.Location = New System.Drawing.Point(10, 18)
        Me.dgJobAudits.Name = "dgJobAudits"
        Me.dgJobAudits.Size = New System.Drawing.Size(817, 374)
        Me.dgJobAudits.TabIndex = 14
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Export Job List To Excel"
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Location = New System.Drawing.Point(10, 454)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(67, 25)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        '
        'FRMJobAudit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(856, 486)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpJobAudit)
        Me.MaximumSize = New System.Drawing.Size(864, 520)
        Me.MinimumSize = New System.Drawing.Size(864, 520)
        Me.Name = "FRMJobAudit"
        Me.Text = "Job Audit"
        Me.Controls.SetChildIndex(Me.grpJobAudit, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.grpJobAudit.ResumeLayout(False)
        CType(Me.dgJobAudits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupJobAuditDataGrid()
        PopulateDatagrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _dvJobAudits As DataView

    Private Property JobAuditsDataview() As DataView
        Get
            Return _dvJobAudits
        End Get
        Set(ByVal value As DataView)
            _dvJobAudits = value
            _dvJobAudits.AllowNew = False
            _dvJobAudits.AllowEdit = False
            _dvJobAudits.AllowDelete = False
            _dvJobAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString
            Me.dgJobAudits.DataSource = JobAuditsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedJobAuditDataRow() As DataRow
        Get
            If Not Me.dgJobAudits.CurrentRowIndex = -1 Then
                Return JobAuditsDataview(Me.dgJobAudits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupJobAuditDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgJobAudits.TableStyles(0)

        Dim ActionDateTime As New DataGridLabelColumn
        ActionDateTime.Format = "dddd dd MMMM yyyy HH:mm:ss"
        ActionDateTime.FormatInfo = Nothing
        ActionDateTime.HeaderText = "Action Date Time"
        ActionDateTime.MappingName = "ActionDateTime"
        ActionDateTime.ReadOnly = True
        ActionDateTime.Width = 250
        ActionDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(ActionDateTime)

        Dim Fullname As New DataGridLabelColumn
        Fullname.Format = ""
        Fullname.FormatInfo = Nothing
        Fullname.HeaderText = "User"
        Fullname.MappingName = "Fullname"
        Fullname.ReadOnly = True
        Fullname.Width = 175
        Fullname.NullText = ""
        tbStyle.GridColumnStyles.Add(Fullname)

        Dim ActionChange As New DataGridLabelColumn
        ActionChange.Format = ""
        ActionChange.FormatInfo = Nothing
        ActionChange.HeaderText = "Action"
        ActionChange.MappingName = "ActionChange"
        ActionChange.ReadOnly = True
        ActionChange.Width = 1000
        ActionChange.NullText = ""
        tbStyle.GridColumnStyles.Add(ActionChange)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString

        Me.dgJobAudits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMJobAudit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try

            JobAuditsDataview = DB.JobAudit.Get_For_Job(GetParameter(0))
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class