Public Class FRMPostcodeManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents btnSave As System.Windows.Forms.Button

    Friend WithEvents grpEngineers As System.Windows.Forms.GroupBox
    Friend WithEvents dgEngineers As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineers = New System.Windows.Forms.GroupBox
        Me.dgEngineers = New System.Windows.Forms.DataGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.grpEngineers.SuspendLayout()
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpEngineers
        '
        Me.grpEngineers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineers.Controls.Add(Me.dgEngineers)
        Me.grpEngineers.Location = New System.Drawing.Point(8, 40)
        Me.grpEngineers.Name = "grpEngineers"
        Me.grpEngineers.Size = New System.Drawing.Size(344, 408)
        Me.grpEngineers.TabIndex = 1
        Me.grpEngineers.TabStop = False
        Me.grpEngineers.Text = "Tick those engineers associated to this new postcode"
        '
        'dgEngineers
        '
        Me.dgEngineers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEngineers.DataMember = ""
        Me.dgEngineers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineers.Location = New System.Drawing.Point(8, 25)
        Me.dgEngineers.Name = "dgEngineers"
        Me.dgEngineers.Size = New System.Drawing.Size(328, 375)
        Me.dgEngineers.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 456)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'FRMPostcodeManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(360, 486)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpEngineers)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(368, 520)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(368, 520)
        Me.Name = "FRMPostcodeManager"
        Me.Text = "Postcode Manager"
        Me.Controls.SetChildIndex(Me.grpEngineers, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.grpEngineers.ResumeLayout(False)
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupEngineersDataGrid()

        PostcodeID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
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

    Private _PostcodeID As Integer = 0

    Public Property PostcodeID() As Integer
        Get
            Return _PostcodeID
        End Get
        Set(ByVal Value As Integer)
            _PostcodeID = Value

            Engineers = DB.Engineer.Engineer_GetAll()
        End Set
    End Property

    Private _dvEngineers As DataView

    Private Property Engineers() As DataView
        Get
            Return _dvEngineers
        End Get
        Set(ByVal value As DataView)
            _dvEngineers = value
            _dvEngineers.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
            _dvEngineers.AllowNew = False
            _dvEngineers.AllowEdit = False
            _dvEngineers.AllowDelete = False
            Me.dgEngineers.DataSource = Engineers
        End Set
    End Property

    Private ReadOnly Property SelectedEngineerDataRow() As DataRow
        Get
            If Not Me.dgEngineers.CurrentRowIndex = -1 Then
                Return Engineers(Me.dgEngineers.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMPostcodeManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgEngineers_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgEngineers.Click, dgEngineers.DoubleClick
        Try
            If SelectedEngineerDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgEngineers(Me.dgEngineers.CurrentRowIndex, 0))
            Me.dgEngineers(Me.dgEngineers.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

#End Region

#Region "Functions"

    Private Sub SetupEngineersDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgEngineers.TableStyles(0)

        Me.dgEngineers.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = False
        Tick.Width = 25
        Tick.AllowNull = False
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineer.ToString

        Me.dgEngineers.TableStyles.Add(tStyle)
    End Sub

    Private Sub Save()
        Try
            Cursor.Current = Cursors.WaitCursor

            For Each row As DataRow In Engineers.Table.Rows
                If row.Item("Tick") Then
                    DB.EngineerPostalRegion.Insert(row.Item("EngineerID"), PostcodeID)
                End If
            Next

            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        Catch ex As Exception
            ShowMessage("Error saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

End Class