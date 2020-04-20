Public Class FRMJobLocks : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpLocks As System.Windows.Forms.GroupBox

    Friend WithEvents dgLocks As System.Windows.Forms.DataGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUnlock As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpLocks = New System.Windows.Forms.GroupBox
        Me.dgLocks = New System.Windows.Forms.DataGrid
        Me.btnUnlock = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpLocks.SuspendLayout()
        CType(Me.dgLocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpLocks
        '
        Me.grpLocks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLocks.Controls.Add(Me.dgLocks)
        Me.grpLocks.Location = New System.Drawing.Point(8, 40)
        Me.grpLocks.Name = "grpLocks"
        Me.grpLocks.Size = New System.Drawing.Size(769, 405)
        Me.grpLocks.TabIndex = 1
        Me.grpLocks.TabStop = False
        Me.grpLocks.Text = "Highlight job to release and click 'Unlock'"
        '
        'dgLocks
        '
        Me.dgLocks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLocks.DataMember = ""
        Me.dgLocks.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLocks.Location = New System.Drawing.Point(8, 20)
        Me.dgLocks.Name = "dgLocks"
        Me.dgLocks.Size = New System.Drawing.Size(753, 377)
        Me.dgLocks.TabIndex = 1
        '
        'btnUnlock
        '
        Me.btnUnlock.AccessibleDescription = "Save item"
        Me.btnUnlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnlock.UseVisualStyleBackColor = True
        Me.btnUnlock.ImageIndex = 1
        Me.btnUnlock.Location = New System.Drawing.Point(721, 451)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(56, 23)
        Me.btnUnlock.TabIndex = 2
        Me.btnUnlock.Text = "Unlock"
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Save item"
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.ImageIndex = 1
        Me.btnClose.Location = New System.Drawing.Point(8, 451)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'FRMJobLocks
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(785, 486)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpLocks)
        Me.Controls.Add(Me.btnUnlock)
        Me.MinimumSize = New System.Drawing.Size(793, 520)
        Me.Name = "FRMJobLocks"
        Me.Text = "Job Locks"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnUnlock, 0)
        Me.Controls.SetChildIndex(Me.grpLocks, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.grpLocks.ResumeLayout(False)
        CType(Me.dgLocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupDataGrid()
        Locks = DB.JobLock.GetAll
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

    Private _Locks As DataView

    Private Property Locks() As DataView
        Get
            Return _Locks
        End Get
        Set(ByVal value As DataView)
            _Locks = value
            _Locks.AllowNew = False
            _Locks.AllowEdit = False
            _Locks.AllowDelete = False
            _Locks.Table.TableName = Entity.Sys.Enums.TableNames.tblJobLock.ToString
            Me.dgLocks.DataSource = Locks
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgLocks.CurrentRowIndex = -1 Then
                Return Locks(Me.dgLocks.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgLocks)
        Dim tbStyle As DataGridTableStyle = Me.dgLocks.TableStyles(0)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 150
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim FullName As New DataGridLabelColumn
        FullName.Format = ""
        FullName.FormatInfo = Nothing
        FullName.HeaderText = "Locked By"
        FullName.MappingName = "FullName"
        FullName.ReadOnly = True
        FullName.Width = 150
        FullName.NullText = ""
        tbStyle.GridColumnStyles.Add(FullName)

        Dim DateLock As New DataGridLabelColumn
        DateLock.Format = "dddd dd MMMM yyyy"
        DateLock.FormatInfo = Nothing
        DateLock.HeaderText = "Locked On"
        DateLock.MappingName = "DateLock"
        DateLock.ReadOnly = True
        DateLock.Width = 250
        DateLock.NullText = ""
        tbStyle.GridColumnStyles.Add(DateLock)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJobLock.ToString
        Me.dgLocks.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobLocks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select job to unlock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If loggedInUser.HasAccessToModule() = True Then
            If ShowMessage("Are you sure you wish to unlock this job? The next user to access this record, will relock it.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Try
                Cursor.Current = Cursors.WaitCursor

                DB.JobLock.Delete(SelectedDataRow("JobLockID"))

                Locks = DB.JobLock.GetAll
            Catch ex As Exception
                ShowMessage("Error unlocking job : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End If
    End Sub

#End Region

End Class