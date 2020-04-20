Imports System.Collections.Generic
Public Class FRMHistory : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents dgHistory As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgHistory = New System.Windows.Forms.DataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFilter = New System.Windows.Forms.ComboBox
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgHistory
        '
        Me.dgHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistory.DataMember = ""
        Me.dgHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgHistory.Location = New System.Drawing.Point(8, 40)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.Size = New System.Drawing.Size(752, 432)
        Me.dgHistory.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Location = New System.Drawing.Point(8, 488)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 16)
        Me.Panel1.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(32, 488)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Out of hours login recorded."
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "Clear system interaction history"
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Location = New System.Drawing.Point(712, 480)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(48, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(216, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Show last "
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(360, 488)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Records"
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.Location = New System.Drawing.Point(280, 484)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(80, 21)
        Me.cboFilter.TabIndex = 2
        Me.cboFilter.Text = "ComboBox1"
        '
        'FRMHistory
        '
        Me.AcceptButton = Me.btnClear
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(768, 510)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgHistory)
        Me.MinimumSize = New System.Drawing.Size(776, 544)
        Me.Name = "FRMHistory"
        Me.Text = "System History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.dgHistory, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnClear, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboFilter, 0)
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupHistoryDataGrid()

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("ValueMember"))
        Dim newRow As DataRow

        For i As Integer = 100 To 10000 Step +100
            newRow = dt.NewRow
            newRow("ValueMember") = i
            dt.Rows.Add(newRow)
        Next

        Combo.SetUpCombo(Me.cboFilter, dt, "ValueMember", "ValueMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetSelectedComboItem_By_Value(Me.cboFilter, 100)

        PopulatePage()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Variables / Properties"

    Private _dvHistory As DataView
    Private Property HistoryDataview() As DataView
        Get
            Return _dvHistory
        End Get
        Set(ByVal value As DataView)
            _dvHistory = value
            _dvHistory.AllowNew = False
            _dvHistory.AllowEdit = False
            _dvHistory.AllowDelete = False
            _dvHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblHistory.ToString
            Me.dgHistory.DataSource = HistoryDataview
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupHistoryDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgHistory.TableStyles(0)


        Dim OutOfHours As New OutOfHoursColourColumn
        OutOfHours.Format = ""
        OutOfHours.FormatInfo = Nothing
        OutOfHours.HeaderText = ""
        OutOfHours.MappingName = "OutOfHours"
        OutOfHours.ReadOnly = True
        OutOfHours.Width = 25
        OutOfHours.NullText = ""
        tStyle.GridColumnStyles.Add(OutOfHours)


        Dim AccessDate As New DataGridLabelColumn
        AccessDate.Format = "dd/MM/yyyy HH:mm"
        AccessDate.FormatInfo = Nothing
        AccessDate.HeaderText = "Date"
        AccessDate.MappingName = "AccessDate"
        AccessDate.ReadOnly = True
        AccessDate.Width = 125
        AccessDate.NullText = ""
        tStyle.GridColumnStyles.Add(AccessDate)


        Dim User As New DataGridLabelColumn
        User.Format = ""
        User.FormatInfo = Nothing
        User.HeaderText = "User"
        User.MappingName = "Fullname"
        User.ReadOnly = True
        User.Width = 85
        User.NullText = ""
        tStyle.GridColumnStyles.Add(User)


        Dim FormTitle As New DataGridLabelColumn
        FormTitle.Format = ""
        FormTitle.FormatInfo = Nothing
        FormTitle.HeaderText = "Page ; Action"
        FormTitle.MappingName = "FormTitle"
        FormTitle.ReadOnly = True
        FormTitle.Width = 185
        FormTitle.NullText = ""
        tStyle.GridColumnStyles.Add(FormTitle)


        Dim AccessType As New DataGridLabelColumn
        AccessType.Format = ""
        AccessType.FormatInfo = Nothing
        AccessType.HeaderText = "Type"
        AccessType.MappingName = "AccessType"
        AccessType.ReadOnly = True
        AccessType.Width = 65
        AccessType.NullText = ""
        tStyle.GridColumnStyles.Add(AccessType)


        Dim Statement As New DataGridLabelColumn
        Statement.Format = ""
        Statement.FormatInfo = Nothing
        Statement.HeaderText = "Statement"
        Statement.MappingName = "Statement"
        Statement.ReadOnly = True
        Statement.Width = 800
        Statement.NullText = ""
        tStyle.GridColumnStyles.Add(Statement)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblHistory.ToString
        Me.dgHistory.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        PopulatePage()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.FSMAdmin) Then
            If ShowMessage("Are you sure you want to delete all records?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                DB.Manager.DeleteHistory()
                PopulatePage()
            End If
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulatePage()
        Try
            HistoryDataview = DB.Manager.GetHistory(Combo.GetSelectedItemValue(Me.cboFilter))
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

End Class
