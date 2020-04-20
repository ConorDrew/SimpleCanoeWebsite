Public Class FRMCheckListManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpSections As System.Windows.Forms.GroupBox
    Friend WithEvents dgSection As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveSection As System.Windows.Forms.Button
    Friend WithEvents btnUpdateSection As System.Windows.Forms.Button
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
    Friend WithEvents grpAreas As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdateArea As System.Windows.Forms.Button
    Friend WithEvents btnRemoveArea As System.Windows.Forms.Button
    Friend WithEvents dgArea As System.Windows.Forms.DataGrid
    Friend WithEvents dgTask As System.Windows.Forms.DataGrid
    Friend WithEvents dgSubTask As System.Windows.Forms.DataGrid
    Friend WithEvents grpTasks As System.Windows.Forms.GroupBox
    Friend WithEvents grpSubTask As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveTask As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSubTask As System.Windows.Forms.Button
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtTasks As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTasks As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdateTask As System.Windows.Forms.Button
    Friend WithEvents btnUpdateSubTask As System.Windows.Forms.Button
    Friend WithEvents btnMoveDownArea As System.Windows.Forms.Button
    Friend WithEvents btnMoveUpArea As System.Windows.Forms.Button
    Friend WithEvents btnMoveDownTask As System.Windows.Forms.Button
    Friend WithEvents btnMoveUpTask As System.Windows.Forms.Button
    Friend WithEvents btnMoveDownSubTask As System.Windows.Forms.Button
    Friend WithEvents btnMoveUpSubTask As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSections = New System.Windows.Forms.GroupBox
        Me.txtSection = New System.Windows.Forms.TextBox
        Me.btnUpdateSection = New System.Windows.Forms.Button
        Me.btnRemoveSection = New System.Windows.Forms.Button
        Me.dgSection = New System.Windows.Forms.DataGrid
        Me.grpAreas = New System.Windows.Forms.GroupBox
        Me.btnMoveDownArea = New System.Windows.Forms.Button
        Me.btnMoveUpArea = New System.Windows.Forms.Button
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.btnUpdateArea = New System.Windows.Forms.Button
        Me.btnRemoveArea = New System.Windows.Forms.Button
        Me.dgArea = New System.Windows.Forms.DataGrid
        Me.grpTasks = New System.Windows.Forms.GroupBox
        Me.btnMoveDownTask = New System.Windows.Forms.Button
        Me.btnMoveUpTask = New System.Windows.Forms.Button
        Me.txtTasks = New System.Windows.Forms.TextBox
        Me.btnUpdateTask = New System.Windows.Forms.Button
        Me.btnRemoveTask = New System.Windows.Forms.Button
        Me.dgTask = New System.Windows.Forms.DataGrid
        Me.grpSubTask = New System.Windows.Forms.GroupBox
        Me.btnMoveDownSubTask = New System.Windows.Forms.Button
        Me.btnMoveUpSubTask = New System.Windows.Forms.Button
        Me.txtSubTasks = New System.Windows.Forms.TextBox
        Me.btnUpdateSubTask = New System.Windows.Forms.Button
        Me.btnRemoveSubTask = New System.Windows.Forms.Button
        Me.dgSubTask = New System.Windows.Forms.DataGrid
        Me.grpSections.SuspendLayout()
        CType(Me.dgSection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAreas.SuspendLayout()
        CType(Me.dgArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTasks.SuspendLayout()
        CType(Me.dgTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSubTask.SuspendLayout()
        CType(Me.dgSubTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSections
        '
        Me.grpSections.Controls.Add(Me.txtSection)
        Me.grpSections.Controls.Add(Me.btnUpdateSection)
        Me.grpSections.Controls.Add(Me.btnRemoveSection)
        Me.grpSections.Controls.Add(Me.dgSection)

        Me.grpSections.Location = New System.Drawing.Point(16, 40)
        Me.grpSections.Name = "grpSections"
        Me.grpSections.Size = New System.Drawing.Size(400, 272)
        Me.grpSections.TabIndex = 2
        Me.grpSections.TabStop = False
        Me.grpSections.Text = "Sections"
        '
        'txtSection
        '
        Me.txtSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSection.Location = New System.Drawing.Point(8, 240)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(240, 21)
        Me.txtSection.TabIndex = 2
        Me.txtSection.Text = ""
        '
        'btnUpdateSection
        '
        Me.btnUpdateSection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateSection.Location = New System.Drawing.Point(256, 240)
        Me.btnUpdateSection.Name = "btnUpdateSection"
        Me.btnUpdateSection.Size = New System.Drawing.Size(64, 24)
        Me.btnUpdateSection.TabIndex = 3
        Me.btnUpdateSection.Text = "Add"
        '
        'btnRemoveSection
        '
        Me.btnRemoveSection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveSection.Location = New System.Drawing.Point(328, 240)
        Me.btnRemoveSection.Name = "btnRemoveSection"
        Me.btnRemoveSection.Size = New System.Drawing.Size(64, 24)
        Me.btnRemoveSection.TabIndex = 4
        Me.btnRemoveSection.Text = "Remove"
        '
        'dgSection
        '
        Me.dgSection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSection.DataMember = ""
        Me.dgSection.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSection.Location = New System.Drawing.Point(8, 20)
        Me.dgSection.Name = "dgSection"
        Me.dgSection.Size = New System.Drawing.Size(384, 212)
        Me.dgSection.TabIndex = 1
        '
        'grpAreas
        '
        Me.grpAreas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpAreas.Controls.Add(Me.btnMoveDownArea)
        Me.grpAreas.Controls.Add(Me.btnMoveUpArea)
        Me.grpAreas.Controls.Add(Me.txtArea)
        Me.grpAreas.Controls.Add(Me.btnUpdateArea)
        Me.grpAreas.Controls.Add(Me.btnRemoveArea)
        Me.grpAreas.Controls.Add(Me.dgArea)

        Me.grpAreas.Location = New System.Drawing.Point(16, 320)
        Me.grpAreas.Name = "grpAreas"
        Me.grpAreas.Size = New System.Drawing.Size(400, 224)
        Me.grpAreas.TabIndex = 3
        Me.grpAreas.TabStop = False
        Me.grpAreas.Text = "Areas For Section "
        '
        'btnMoveDownArea
        '
        Me.btnMoveDownArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDownArea.Location = New System.Drawing.Point(368, 128)
        Me.btnMoveDownArea.Name = "btnMoveDownArea"
        Me.btnMoveDownArea.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveDownArea.TabIndex = 9
        Me.btnMoveDownArea.Text = "/\"
        '
        'btnMoveUpArea
        '
        Me.btnMoveUpArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUpArea.Location = New System.Drawing.Point(368, 160)
        Me.btnMoveUpArea.Name = "btnMoveUpArea"
        Me.btnMoveUpArea.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveUpArea.TabIndex = 10
        Me.btnMoveUpArea.Text = "\/"
        '
        'txtArea
        '
        Me.txtArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArea.Location = New System.Drawing.Point(8, 192)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(240, 21)
        Me.txtArea.TabIndex = 6
        Me.txtArea.Text = ""
        '
        'btnUpdateArea
        '
        Me.btnUpdateArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateArea.Location = New System.Drawing.Point(256, 192)
        Me.btnUpdateArea.Name = "btnUpdateArea"
        Me.btnUpdateArea.Size = New System.Drawing.Size(64, 24)
        Me.btnUpdateArea.TabIndex = 7
        Me.btnUpdateArea.Text = "Add"
        '
        'btnRemoveArea
        '
        Me.btnRemoveArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveArea.Location = New System.Drawing.Point(328, 193)
        Me.btnRemoveArea.Name = "btnRemoveArea"
        Me.btnRemoveArea.Size = New System.Drawing.Size(64, 24)
        Me.btnRemoveArea.TabIndex = 8
        Me.btnRemoveArea.Text = "Remove"
        '
        'dgArea
        '
        Me.dgArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgArea.DataMember = ""
        Me.dgArea.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgArea.Location = New System.Drawing.Point(8, 26)
        Me.dgArea.Name = "dgArea"
        Me.dgArea.Size = New System.Drawing.Size(352, 158)
        Me.dgArea.TabIndex = 5
        '
        'grpTasks
        '
        Me.grpTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTasks.Controls.Add(Me.btnMoveDownTask)
        Me.grpTasks.Controls.Add(Me.btnMoveUpTask)
        Me.grpTasks.Controls.Add(Me.txtTasks)
        Me.grpTasks.Controls.Add(Me.btnUpdateTask)
        Me.grpTasks.Controls.Add(Me.btnRemoveTask)
        Me.grpTasks.Controls.Add(Me.dgTask)

        Me.grpTasks.Location = New System.Drawing.Point(424, 40)
        Me.grpTasks.Name = "grpTasks"
        Me.grpTasks.Size = New System.Drawing.Size(368, 272)
        Me.grpTasks.TabIndex = 4
        Me.grpTasks.TabStop = False
        Me.grpTasks.Text = "Tasks For Area"
        '
        'btnMoveDownTask
        '
        Me.btnMoveDownTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDownTask.Location = New System.Drawing.Point(336, 176)
        Me.btnMoveDownTask.Name = "btnMoveDownTask"
        Me.btnMoveDownTask.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveDownTask.TabIndex = 15
        Me.btnMoveDownTask.Text = "/\"
        '
        'btnMoveUpTask
        '
        Me.btnMoveUpTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUpTask.Location = New System.Drawing.Point(336, 208)
        Me.btnMoveUpTask.Name = "btnMoveUpTask"
        Me.btnMoveUpTask.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveUpTask.TabIndex = 16
        Me.btnMoveUpTask.Text = "\/"
        '
        'txtTasks
        '
        Me.txtTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTasks.Location = New System.Drawing.Point(8, 240)
        Me.txtTasks.Name = "txtTasks"
        Me.txtTasks.Size = New System.Drawing.Size(208, 21)
        Me.txtTasks.TabIndex = 12
        Me.txtTasks.Text = ""
        '
        'btnUpdateTask
        '
        Me.btnUpdateTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateTask.Location = New System.Drawing.Point(224, 240)
        Me.btnUpdateTask.Name = "btnUpdateTask"
        Me.btnUpdateTask.Size = New System.Drawing.Size(64, 24)
        Me.btnUpdateTask.TabIndex = 13
        Me.btnUpdateTask.Text = "Add"
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTask.Location = New System.Drawing.Point(296, 241)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(64, 24)
        Me.btnRemoveTask.TabIndex = 14
        Me.btnRemoveTask.Text = "Remove"
        '
        'dgTask
        '
        Me.dgTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTask.DataMember = ""
        Me.dgTask.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTask.Location = New System.Drawing.Point(8, 20)
        Me.dgTask.Name = "dgTask"
        Me.dgTask.Size = New System.Drawing.Size(320, 212)
        Me.dgTask.TabIndex = 11
        '
        'grpSubTask
        '
        Me.grpSubTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSubTask.Controls.Add(Me.btnMoveDownSubTask)
        Me.grpSubTask.Controls.Add(Me.btnMoveUpSubTask)
        Me.grpSubTask.Controls.Add(Me.txtSubTasks)
        Me.grpSubTask.Controls.Add(Me.btnUpdateSubTask)
        Me.grpSubTask.Controls.Add(Me.btnRemoveSubTask)
        Me.grpSubTask.Controls.Add(Me.dgSubTask)

        Me.grpSubTask.Location = New System.Drawing.Point(424, 320)
        Me.grpSubTask.Name = "grpSubTask"
        Me.grpSubTask.Size = New System.Drawing.Size(368, 224)
        Me.grpSubTask.TabIndex = 5
        Me.grpSubTask.TabStop = False
        Me.grpSubTask.Text = "Sub Tasks For Task"
        '
        'btnMoveDownSubTask
        '
        Me.btnMoveDownSubTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDownSubTask.Location = New System.Drawing.Point(336, 128)
        Me.btnMoveDownSubTask.Name = "btnMoveDownSubTask"
        Me.btnMoveDownSubTask.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveDownSubTask.TabIndex = 21
        Me.btnMoveDownSubTask.Text = "/\"
        '
        'btnMoveUpSubTask
        '
        Me.btnMoveUpSubTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUpSubTask.Location = New System.Drawing.Point(336, 160)
        Me.btnMoveUpSubTask.Name = "btnMoveUpSubTask"
        Me.btnMoveUpSubTask.Size = New System.Drawing.Size(24, 23)
        Me.btnMoveUpSubTask.TabIndex = 22
        Me.btnMoveUpSubTask.Text = "\/"
        '
        'txtSubTasks
        '
        Me.txtSubTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTasks.Location = New System.Drawing.Point(8, 192)
        Me.txtSubTasks.Name = "txtSubTasks"
        Me.txtSubTasks.Size = New System.Drawing.Size(208, 21)
        Me.txtSubTasks.TabIndex = 18
        Me.txtSubTasks.Text = ""
        '
        'btnUpdateSubTask
        '
        Me.btnUpdateSubTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateSubTask.Location = New System.Drawing.Point(224, 192)
        Me.btnUpdateSubTask.Name = "btnUpdateSubTask"
        Me.btnUpdateSubTask.Size = New System.Drawing.Size(64, 24)
        Me.btnUpdateSubTask.TabIndex = 19
        Me.btnUpdateSubTask.Text = "Add"
        '
        'btnRemoveSubTask
        '
        Me.btnRemoveSubTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveSubTask.Location = New System.Drawing.Point(296, 192)
        Me.btnRemoveSubTask.Name = "btnRemoveSubTask"
        Me.btnRemoveSubTask.Size = New System.Drawing.Size(64, 24)
        Me.btnRemoveSubTask.TabIndex = 20
        Me.btnRemoveSubTask.Text = "Remove"
        '
        'dgSubTask
        '
        Me.dgSubTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSubTask.DataMember = ""
        Me.dgSubTask.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSubTask.Location = New System.Drawing.Point(8, 26)
        Me.dgSubTask.Name = "dgSubTask"
        Me.dgSubTask.Size = New System.Drawing.Size(320, 158)
        Me.dgSubTask.TabIndex = 17
        '
        'FRMCheckListManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 558)
        Me.Controls.Add(Me.grpSubTask)
        Me.Controls.Add(Me.grpTasks)
        Me.Controls.Add(Me.grpAreas)
        Me.Controls.Add(Me.grpSections)
        Me.MinimumSize = New System.Drawing.Size(808, 592)
        Me.Name = "FRMCheckListManager"
        Me.Text = "CheckList Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpSections, 0)
        Me.Controls.SetChildIndex(Me.grpAreas, 0)
        Me.Controls.SetChildIndex(Me.grpTasks, 0)
        Me.Controls.SetChildIndex(Me.grpSubTask, 0)
        Me.grpSections.ResumeLayout(False)
        CType(Me.dgSection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAreas.ResumeLayout(False)
        CType(Me.dgArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTasks.ResumeLayout(False)
        CType(Me.dgTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSubTask.ResumeLayout(False)
        CType(Me.dgSubTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupSectionsDataGrid()
        SetupAreasDataGrid()
        SetupTasksDataGrid()
        SetupSubTaskDataGrid()
        SectionDataView = DB.Section.Section_GetAll()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Properties"

    Private SectionSelected As Boolean = False
    Private AreaSelected As Boolean = False
    Private TaskSelected As Boolean = False
    Private SubTaskSelected As Boolean = False

    Private _SectionDataView As DataView = Nothing
    Public Property SectionDataView() As DataView
        Get
            Return _SectionDataView
        End Get
        Set(ByVal Value As DataView)
            _SectionDataView = Value
            _SectionDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblSection.ToString
            _SectionDataView.AllowNew = False
            _SectionDataView.AllowEdit = False
            _SectionDataView.AllowDelete = False
            Me.dgSection.DataSource = SectionDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSectionDataRow() As DataRow
        Get
            If Not Me.dgSection.CurrentRowIndex = -1 Then
                Return SectionDataView(Me.dgSection.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _AreaDataView As DataView = Nothing
    Public Property AreaDataView() As DataView
        Get
            Return _AreaDataView
        End Get
        Set(ByVal Value As DataView)
            _AreaDataView = Value
            _AreaDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblArea.ToString
            _AreaDataView.AllowNew = False
            _AreaDataView.AllowEdit = False
            _AreaDataView.AllowDelete = False
            Me.dgArea.DataSource = AreaDataView
        End Set
    End Property

    Private ReadOnly Property SelectedAreaDataRow() As DataRow
        Get
            If Not Me.dgArea.CurrentRowIndex = -1 Then
                Return AreaDataView(Me.dgArea.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _TaskDataView As DataView = Nothing
    Public Property TaskDataView() As DataView
        Get
            Return _TaskDataView
        End Get
        Set(ByVal Value As DataView)
            _TaskDataView = Value
            _TaskDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblTask.ToString
            _TaskDataView.AllowNew = False
            _TaskDataView.AllowEdit = False
            _TaskDataView.AllowDelete = False
            Me.dgTask.DataSource = TaskDataView
        End Set
    End Property

    Private ReadOnly Property SelectedTaskDataRow() As DataRow
        Get
            If Not Me.dgTask.CurrentRowIndex = -1 Then
                Return TaskDataView(Me.dgTask.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _SubTaskDataView As DataView = Nothing
    Public Property SubTaskDataView() As DataView
        Get
            Return _SubTaskDataView
        End Get
        Set(ByVal Value As DataView)
            _SubTaskDataView = Value
            _SubTaskDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblSubTask.ToString
            _SubTaskDataView.AllowNew = False
            _SubTaskDataView.AllowEdit = False
            _SubTaskDataView.AllowDelete = False
            Me.dgSubTask.DataSource = SubTaskDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSubTaskDataRow() As DataRow
        Get
            If Not Me.dgSubTask.CurrentRowIndex = -1 Then
                Return SubTaskDataView(Me.dgSubTask.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupSectionsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgSection)
        Dim tStyle As DataGridTableStyle = Me.dgSection.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Desc As New DataGridLabelColumn
        Desc.Format = ""
        Desc.FormatInfo = Nothing
        Desc.HeaderText = "Description"
        Desc.MappingName = "Description"
        Desc.ReadOnly = True
        Desc.Width = 300
        Desc.NullText = ""
        tStyle.GridColumnStyles.Add(Desc)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSection.ToString
        Me.dgSection.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupAreasDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgArea)
        Dim tStyle As DataGridTableStyle = Me.dgArea.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Desc As New DataGridLabelColumn
        Desc.Format = ""
        Desc.FormatInfo = Nothing
        Desc.HeaderText = "Description"
        Desc.MappingName = "Description"
        Desc.ReadOnly = True
        Desc.Width = 300
        Desc.NullText = ""
        tStyle.GridColumnStyles.Add(Desc)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblArea.ToString
        Me.dgArea.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupTasksDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgTask)
        Dim tStyle As DataGridTableStyle = Me.dgTask.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Desc As New DataGridLabelColumn
        Desc.Format = ""
        Desc.FormatInfo = Nothing
        Desc.HeaderText = "Description"
        Desc.MappingName = "Description"
        Desc.ReadOnly = True
        Desc.Width = 300
        Desc.NullText = ""
        tStyle.GridColumnStyles.Add(Desc)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblTask.ToString
        Me.dgTask.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupSubTaskDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgSubTask)
        Dim tStyle As DataGridTableStyle = Me.dgSubTask.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Desc As New DataGridLabelColumn
        Desc.Format = ""
        Desc.FormatInfo = Nothing
        Desc.HeaderText = "Description"
        Desc.MappingName = "Description"
        Desc.ReadOnly = True
        Desc.Width = 300
        Desc.NullText = ""
        tStyle.GridColumnStyles.Add(Desc)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSubTask.ToString
        Me.dgSubTask.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMCheckListManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgSection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSection.Click
        If SelectedSectionDataRow Is Nothing Then
            Me.btnUpdateSection.Text = "Add"
            Exit Sub
        End If

        SectionSelected = True

        Me.txtSection.Text = SelectedSectionDataRow.Item("Description")
        Me.btnUpdateSection.Text = "Update"

        AreaDataView = DB.Area.Area_Get_For_Section(SelectedSectionDataRow.Item("SectionID"))

        Me.grpAreas.Text = "Areas For Section: " & SelectedSectionDataRow.Item("Description")

        If Not TaskDataView Is Nothing Then
            TaskDataView.Table.Rows.Clear()
            Me.grpTasks.Text = "Tasks"
        End If
        If Not SubTaskDataView Is Nothing Then
            SubTaskDataView.Table.Rows.Clear()
            Me.grpSubTask.Text = "Sub-Tasks"
        End If

        Me.txtArea.Text = ""
        Me.btnUpdateArea.Text = "Add"
        Me.txtTasks.Text = ""
        Me.btnUpdateTask.Text = "Add"
        Me.txtSubTasks.Text = ""
        Me.btnUpdateSubTask.Text = "Add"
    End Sub

    Private Sub dgArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgArea.Click
        If SelectedAreaDataRow Is Nothing Then
            Me.btnUpdateArea.Text = "Add"
            Exit Sub
        End If

        AreaSelected = True

        Me.txtArea.Text = SelectedAreaDataRow.Item("Description")
        Me.btnUpdateArea.Text = "Update"

        TaskDataView = DB.Task.Task_Get_For_Area(SelectedAreaDataRow.Item("AreaID"))

        Me.grpTasks.Text = "Tasks For Area: " & SelectedAreaDataRow.Item("Description")

        If Not SubTaskDataView Is Nothing Then
            SubTaskDataView.Table.Rows.Clear()
            Me.grpSubTask.Text = "Sub-Tasks"
        End If

        Me.txtTasks.Text = ""
        Me.btnUpdateTask.Text = "Add"
        Me.txtSubTasks.Text = ""
        Me.btnUpdateSubTask.Text = "Add"
    End Sub

    Private Sub dgTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTask.Click
        If SelectedTaskDataRow Is Nothing Then
            Me.btnUpdateTask.Text = "Add"
            Exit Sub
        End If

        TaskSelected = True

        Me.txtTasks.Text = SelectedTaskDataRow.Item("Description")
        Me.btnUpdateTask.Text = "Update"

        Me.grpSubTask.Text = "Sub-Tasks For Task: " & SelectedTaskDataRow.Item("Description")

        SubTaskDataView = DB.SubTask.SubTask_Get_For_Task(SelectedTaskDataRow.Item("TaskID"))

        Me.txtSubTasks.Text = ""
        Me.btnUpdateSubTask.Text = "Add"
    End Sub

    Private Sub dgSubTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSubTask.Click
        If SelectedSubTaskDataRow Is Nothing Then
            Me.btnUpdateSubTask.Text = "Add"
            Exit Sub
        End If

        SubTaskSelected = True

        Me.txtSubTasks.Text = SelectedSubTaskDataRow.Item("Description")
        Me.btnUpdateSubTask.Text = "Update"
    End Sub

    Private Sub btnUpdateSection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSection.Click
        Dim ok As Boolean = True

        If Me.btnUpdateSection.Text = "Add" Then
            ok = AddSection()
        Else
            If SelectedSectionDataRow Is Nothing Then
                ShowMessage("Please select a section to update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            ok = UpdateSection()
        End If

        If ok Then
            Me.btnUpdateSection.Text = "Add"
            Me.btnUpdateArea.Text = "Add"
            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtSection.Text = ""
            Me.txtArea.Text = ""
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            SectionDataView = DB.Section.Section_GetAll
            If Not AreaDataView Is Nothing Then
                AreaDataView.Table.Rows.Clear()
                Me.grpAreas.Text = "Areas"
            End If
            If Not TaskDataView Is Nothing Then
                TaskDataView.Table.Rows.Clear()
                Me.grpTasks.Text = "Tasks"
            End If
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        End If
    End Sub

    Private Sub btnUpdateArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateArea.Click
        Dim ok As Boolean = True

        If Me.btnUpdateArea.Text = "Add" Then
            If SelectedSectionDataRow Is Nothing Or SectionSelected = False Then
                ShowMessage("Please select a section to link this area to", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ok = AddArea()
        Else
            If SelectedAreaDataRow Is Nothing Then
                ShowMessage("Please select an area to update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            ok = UpdateArea()
        End If

        If ok Then
            Me.btnUpdateArea.Text = "Add"
            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtArea.Text = ""
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            AreaDataView = DB.Area.Area_Get_For_Section(SelectedSectionDataRow.Item("SectionID"))
            If Not TaskDataView Is Nothing Then
                TaskDataView.Table.Rows.Clear()
                Me.grpTasks.Text = "Tasks"
            End If
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        End If
    End Sub

    Private Sub btnUpdateTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTask.Click
        Dim ok As Boolean = True

        If Me.btnUpdateTask.Text = "Add" Then
            If SelectedAreaDataRow Is Nothing Or AreaSelected = False Then
                ShowMessage("Please select an area to link this task to", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ok = AddTask()
        Else
            If SelectedTaskDataRow Is Nothing Then
                ShowMessage("Please select a task to update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            ok = UpdateTask()
        End If

        If ok Then
            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            TaskDataView = DB.Task.Task_Get_For_Area(SelectedAreaDataRow.Item("AreaID"))
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        End If
    End Sub

    Private Sub btnUpdateSubTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSubTask.Click
        Dim ok As Boolean = True

        If Me.btnUpdateSubTask.Text = "Add" Then
            If SelectedTaskDataRow Is Nothing Or TaskSelected = False Then
                ShowMessage("Please select a task to link this sub task to", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ok = AddSubTask()
        Else
            If SelectedSubTaskDataRow Is Nothing Then
                ShowMessage("Please select a sub task to update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            ok = UpdateSubTask()
        End If

        If ok Then
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtSubTasks.Text = ""
            SubTaskDataView = DB.SubTask.SubTask_Get_For_Task(SelectedTaskDataRow.Item("TaskID"))
        End If
    End Sub

    Private Sub btnRemoveSection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSection.Click
        If SelectedSectionDataRow Is Nothing Then
            ShowMessage("Plase select a section to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this Section? All associated Areas, Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            DB.Section.Delete(SelectedSectionDataRow.Item("SectionID"))

            Me.btnUpdateSection.Text = "Add"
            Me.btnUpdateArea.Text = "Add"
            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtSection.Text = ""
            Me.txtArea.Text = ""
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            SectionDataView = DB.Section.Section_GetAll
            If Not AreaDataView Is Nothing Then
                AreaDataView.Table.Rows.Clear()
                Me.grpAreas.Text = "Areas"
            End If
            If Not TaskDataView Is Nothing Then
                TaskDataView.Table.Rows.Clear()
                Me.grpTasks.Text = "Tasks"
            End If
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        Catch ex As Exception
            ShowMessage("Could not delete section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRemoveArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveArea.Click
        If SelectedAreaDataRow Is Nothing Or SelectedSectionDataRow Is Nothing Then
            ShowMessage("Plase select an area to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this Area? All associated Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            DB.Area.Delete(SelectedAreaDataRow.Item("AreaID"))

            Me.btnUpdateArea.Text = "Add"
            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtArea.Text = ""
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            AreaDataView = DB.Area.Area_Get_For_Section(SelectedSectionDataRow.Item("SectionID"))
            If Not TaskDataView Is Nothing Then
                TaskDataView.Table.Rows.Clear()
                Me.grpTasks.Text = "Tasks"
            End If
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        Catch ex As Exception
            ShowMessage("Could not delete area", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRemoveTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTask.Click
        If SelectedTaskDataRow Is Nothing Or SelectedAreaDataRow Is Nothing Then
            ShowMessage("Plase select a task to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this Task? All associated Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            DB.Task.Delete(SelectedTaskDataRow.Item("TaskID"))

            Me.btnUpdateTask.Text = "Add"
            Me.btnUpdateSubTask.Text = "Add"
            Me.txtTasks.Text = ""
            Me.txtSubTasks.Text = ""
            TaskDataView = DB.Task.Task_Get_For_Area(SelectedAreaDataRow.Item("AreaID"))
            If Not SubTaskDataView Is Nothing Then
                SubTaskDataView.Table.Rows.Clear()
                Me.grpSubTask.Text = "Sub-Tasks"
            End If
        Catch ex As Exception
            ShowMessage("Could not delete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRemoveSubTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSubTask.Click
        If SelectedSubTaskDataRow Is Nothing Or SelectedTaskDataRow Is Nothing Then
            ShowMessage("Plase select a sub task to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this Sub-Task?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            DB.SubTask.Delete(SelectedSubTaskDataRow.Item("SubTaskID"))

            Me.btnUpdateSubTask.Text = "Add"
            Me.txtSubTasks.Text = ""
            SubTaskDataView = DB.SubTask.SubTask_Get_For_Task(SelectedTaskDataRow.Item("TaskID"))
        Catch ex As Exception
            ShowMessage("Could not delete sub task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnMoveUpArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUpArea.Click
        If SelectedAreaDataRow Is Nothing Then
            ShowMessage("Plase select an area to move down", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.Area.Area_AdjustOrderNumber(SelectedAreaDataRow.Item("AreaID"), SelectedAreaDataRow.Item("OrderNumber"), SelectedAreaDataRow.Item("OrderNumber") + 1, SelectedAreaDataRow.Item("SectionID"))
        AreaDataView = DB.Area.Area_Get_For_Section(SelectedAreaDataRow.Item("SectionID"))
    End Sub

    Private Sub btnMoveDownArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDownArea.Click
        If SelectedAreaDataRow Is Nothing Then
            ShowMessage("Plase select an area to move up", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.Area.Area_AdjustOrderNumber(SelectedAreaDataRow.Item("AreaID"), SelectedAreaDataRow.Item("OrderNumber"), SelectedAreaDataRow.Item("OrderNumber") - 1, SelectedAreaDataRow.Item("SectionID"))
        AreaDataView = DB.Area.Area_Get_For_Section(SelectedAreaDataRow.Item("SectionID"))
    End Sub

    Private Sub btnMoveUpTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUpTask.Click
        If SelectedTaskDataRow Is Nothing Then
            ShowMessage("Plase select a task to move down", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.Task.Task_AdjustOrderNumber(SelectedTaskDataRow.Item("TaskID"), SelectedTaskDataRow.Item("OrderNumber"), SelectedTaskDataRow.Item("OrderNumber") + 1, SelectedTaskDataRow.Item("AreaID"))
        TaskDataView = DB.Task.Task_Get_For_Area(SelectedTaskDataRow.Item("AreaID"))
    End Sub

    Private Sub btnMoveDownTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDownTask.Click
        If SelectedTaskDataRow Is Nothing Then
            ShowMessage("Plase select a task to move up", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.Task.Task_AdjustOrderNumber(SelectedTaskDataRow.Item("TaskID"), SelectedTaskDataRow.Item("OrderNumber"), SelectedTaskDataRow.Item("OrderNumber") - 1, SelectedTaskDataRow.Item("AreaID"))
        TaskDataView = DB.Task.Task_Get_For_Area(SelectedTaskDataRow.Item("AreaID"))
    End Sub

    Private Sub btnMoveUpSubTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUpSubTask.Click
        If SelectedSubTaskDataRow Is Nothing Then
            ShowMessage("Plase select a sub task to move down", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.SubTask.SubTask_AdjustOrderNumber(SelectedSubTaskDataRow.Item("SubTaskID"), SelectedSubTaskDataRow.Item("OrderNumber"), SelectedSubTaskDataRow.Item("OrderNumber") + 1, SelectedSubTaskDataRow.Item("TaskID"))
        SubTaskDataView = DB.SubTask.SubTask_Get_For_Task(SelectedSubTaskDataRow.Item("TaskID"))
    End Sub

    Private Sub btnMoveDownSubTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDownSubTask.Click
        If SelectedSubTaskDataRow Is Nothing Then
            ShowMessage("Plase select a sub task to move up", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.SubTask.SubTask_AdjustOrderNumber(SelectedSubTaskDataRow.Item("SubTaskID"), SelectedSubTaskDataRow.Item("OrderNumber"), SelectedSubTaskDataRow.Item("OrderNumber") - 1, SelectedSubTaskDataRow.Item("TaskID"))
        SubTaskDataView = DB.SubTask.SubTask_Get_For_Task(SelectedSubTaskDataRow.Item("TaskID"))
    End Sub

#End Region

#Region "Functions"

    Private Function AddSection() As Boolean
        Try
            Dim oSection As New Entity.Sections.Section
            Me.Cursor = Cursors.WaitCursor
            oSection.IgnoreExceptionsOnSetMethods = True

            oSection.SetDescription = Me.txtSection.Text

            Dim sV As New Entity.Sections.SectionValidator

            sV.Validate(oSection)

            oSection = DB.Section.Insert(oSection)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateSection() As Boolean
        Try
            Dim oSection As New Entity.Sections.Section
            Me.Cursor = Cursors.WaitCursor
            oSection.IgnoreExceptionsOnSetMethods = True

            If SelectedSectionDataRow Is Nothing Then
                Exit Function
            End If

            oSection.SetDescription = Me.txtSection.Text
            oSection.SetSectionID = SelectedSectionDataRow.Item("SectionID")

            Dim sV As New Entity.Sections.SectionValidator

            sV.Validate(oSection)

            DB.Section.Update(oSection)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function AddArea() As Boolean
        Try
            Dim oArea As New Entity.Areas.Area
            Me.Cursor = Cursors.WaitCursor
            oArea.IgnoreExceptionsOnSetMethods = True
            oArea.SetDescription = Me.txtArea.Text
            oArea.SetSectionID = SelectedSectionDataRow.Item("SectionID")

            Dim aV As New Entity.Areas.AreaValidator

            aV.Validate(oArea)

            oArea = DB.Area.Insert(oArea)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateArea() As Boolean
        Try
            Dim oArea As New Entity.Areas.Area
            Me.Cursor = Cursors.WaitCursor
            oArea.IgnoreExceptionsOnSetMethods = True

            If SelectedAreaDataRow Is Nothing Or SelectedSectionDataRow Is Nothing Then
                Exit Function
            End If

            oArea.SetDescription = Me.txtArea.Text
            oArea.SetSectionID = SelectedSectionDataRow.Item("SectionID")
            oArea.SetAreaID = SelectedAreaDataRow.Item("AreaID")
            oArea.SetOrderNumber = SelectedAreaDataRow.Item("OrderNumber")

            Dim aV As New Entity.Areas.AreaValidator

            aV.Validate(oArea)

            DB.Area.Update(oArea)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function AddTask() As Boolean
        Try
            Dim oTask As New Entity.Tasks.Task
            Me.Cursor = Cursors.WaitCursor
            oTask.IgnoreExceptionsOnSetMethods = True
            oTask.SetDescription = Me.txtTasks.Text
            oTask.SetAreaID = SelectedAreaDataRow.Item("AreaID")

            Dim tV As New Entity.Tasks.TaskValidator

            tV.Validate(oTask)

            oTask = DB.Task.Insert(oTask)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateTask() As Boolean
        Try
            Dim oTask As New Entity.Tasks.Task
            Me.Cursor = Cursors.WaitCursor
            oTask.IgnoreExceptionsOnSetMethods = True

            If SelectedAreaDataRow Is Nothing Or SelectedTaskDataRow Is Nothing Then
                Exit Function
            End If

            oTask.SetDescription = Me.txtTasks.Text
            oTask.SetAreaID = SelectedAreaDataRow.Item("AreaID")
            oTask.SetOrderNumber = SelectedTaskDataRow.Item("OrderNumber")
            oTask.SetTaskID = SelectedTaskDataRow.Item("TaskID")

            Dim tV As New Entity.Tasks.TaskValidator

            tV.Validate(oTask)

            DB.Task.Update(oTask)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function AddSubTask() As Boolean
        Try
            Dim oSubTask As New Entity.SubTasks.SubTask
            Me.Cursor = Cursors.WaitCursor
            oSubTask.IgnoreExceptionsOnSetMethods = True
            oSubTask.SetDescription = Me.txtSubTasks.Text
            oSubTask.SetTaskID = SelectedTaskDataRow.Item("TaskID")

            Dim stV As New Entity.SubTasks.SubTaskValidator

            stV.Validate(oSubTask)

            oSubTask = DB.SubTask.Insert(oSubTask)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateSubTask() As Boolean
        Try
            Dim oSubTask As New Entity.SubTasks.SubTask
            Me.Cursor = Cursors.WaitCursor
            oSubTask.IgnoreExceptionsOnSetMethods = True

            If SelectedTaskDataRow Is Nothing Or SelectedSubTaskDataRow Is Nothing Then
                Exit Function
            End If

            oSubTask.SetDescription = Me.txtSubTasks.Text
            oSubTask.SetTaskID = SelectedTaskDataRow.Item("TaskID")
            oSubTask.SetSubTaskID = SelectedSubTaskDataRow.Item("SubTaskID")
            oSubTask.SetOrderNumber = SelectedSubTaskDataRow.Item("OrderNumber")
            Dim stV As New Entity.SubTasks.SubTaskValidator

            stV.Validate(oSubTask)

            DB.SubTask.Update(oSubTask)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

End Class
