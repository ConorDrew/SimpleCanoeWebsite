Public Class FRMAnswers : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpAnswers As System.Windows.Forms.GroupBox

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgChecklist As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpAnswers = New System.Windows.Forms.GroupBox
        Me.dgChecklist = New System.Windows.Forms.DataGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpAnswers.SuspendLayout()
        CType(Me.dgChecklist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpAnswers
        '
        Me.grpAnswers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAnswers.Controls.Add(Me.dgChecklist)
        Me.grpAnswers.Location = New System.Drawing.Point(8, 40)
        Me.grpAnswers.Name = "grpAnswers"
        Me.grpAnswers.Size = New System.Drawing.Size(856, 480)
        Me.grpAnswers.TabIndex = 1
        Me.grpAnswers.TabStop = False
        Me.grpAnswers.Text = "Answers relate to the closest question (All preceeding information are headings)"
        '
        'dgChecklist
        '
        Me.dgChecklist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgChecklist.DataMember = ""
        Me.dgChecklist.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgChecklist.Location = New System.Drawing.Point(8, 25)
        Me.dgChecklist.Name = "dgChecklist"
        Me.dgChecklist.Size = New System.Drawing.Size(840, 447)
        Me.dgChecklist.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(8, 528)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(48, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(816, 528)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(208, 528)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pick a result and enter any comments for each question and then click save"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRMAnswers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(872, 558)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpAnswers)
        Me.MinimumSize = New System.Drawing.Size(880, 592)
        Me.Name = "FRMAnswers"
        Me.Text = "Checklist Questions & Answers"
        Me.Controls.SetChildIndex(Me.grpAnswers, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.grpAnswers.ResumeLayout(False)
        CType(Me.dgChecklist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupDataGrid()

        EngineerVisitID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        SectionID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(1))
        Checklist = DB.Checklists.Get(Entity.Sys.Helper.MakeIntegerValid(GetParameter(2)))
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

    Private _EngineerVisitID As Integer = 0

    Public Property EngineerVisitID() As Integer
        Get
            Return _EngineerVisitID
        End Get
        Set(ByVal Value As Integer)
            _EngineerVisitID = Value
        End Set
    End Property

    Private _SectionID As Integer = 0

    Public Property SectionID() As Integer
        Get
            Return _SectionID
        End Get
        Set(ByVal Value As Integer)
            _SectionID = Value
        End Set
    End Property

    Private _Checklist As Entity.CheckLists.CheckList = Nothing

    Public Property Checklist() As Entity.CheckLists.CheckList
        Get
            Return _Checklist
        End Get
        Set(ByVal Value As Entity.CheckLists.CheckList)
            _Checklist = Value

            If _Checklist Is Nothing Then
                _Checklist = New Entity.CheckLists.CheckList
                _Checklist.Exists = False
            End If

            Populate()
        End Set
    End Property

    Private _ChecklistDataview As DataView

    Public Property ChecklistDataview() As DataView
        Get
            Return _ChecklistDataview
        End Get
        Set(ByVal value As DataView)
            _ChecklistDataview = value
            _ChecklistDataview.AllowNew = False
            _ChecklistDataview.AllowEdit = True
            _ChecklistDataview.AllowDelete = False
            _ChecklistDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString
            Me.dgChecklist.DataSource = ChecklistDataview
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgChecklist.TableStyles(0)

        Me.dgChecklist.ReadOnly = False
        tbStyle.AllowSorting = False
        tbStyle.ReadOnly = False

        Dim Section As New DataGridLabelColumn
        Section.Format = ""
        Section.FormatInfo = Nothing
        Section.HeaderText = "Section"
        Section.MappingName = "Section"
        Section.ReadOnly = True
        Section.Width = 150
        Section.NullText = ""
        tbStyle.GridColumnStyles.Add(Section)

        Dim Area As New DataGridLabelColumn
        Area.Format = ""
        Area.FormatInfo = Nothing
        Area.HeaderText = "Area"
        Area.MappingName = "Area"
        Area.ReadOnly = True
        Area.Width = 150
        Area.NullText = ""
        tbStyle.GridColumnStyles.Add(Area)

        Dim Task As New DataGridLabelColumn
        Task.Format = ""
        Task.FormatInfo = Nothing
        Task.HeaderText = "Task"
        Task.MappingName = "Task"
        Task.ReadOnly = True
        Task.Width = 150
        Task.NullText = ""
        tbStyle.GridColumnStyles.Add(Task)

        Dim SubTask As New DataGridLabelColumn
        SubTask.Format = ""
        SubTask.FormatInfo = Nothing
        SubTask.HeaderText = "Sub Task"
        SubTask.MappingName = "SubTask"
        SubTask.ReadOnly = True
        SubTask.Width = 150
        SubTask.NullText = ""
        tbStyle.GridColumnStyles.Add(SubTask)

        Dim Result As New DataGridComboBoxColumn
        Result.HeaderText = "Result (Select)"
        Result.MappingName = "Result"
        Result.ReadOnly = False
        Result.Width = 75
        Result.NullText = ""
        Result.ComboBox.DataSource = DynamicDataTables.ChecklistResults
        Result.ComboBox.DisplayMember = "DisplayMember"
        Result.ComboBox.ValueMember = "ValueMember"
        tbStyle.GridColumnStyles.Add(Result)

        Dim Comments As New DataGridEditableTextBoxColumn
        Comments.Format = ""
        Comments.FormatInfo = Nothing
        Comments.HeaderText = "Comments"
        Comments.MappingName = "Comments"
        Comments.ReadOnly = False
        Comments.Width = 500
        Comments.NullText = ""
        tbStyle.GridColumnStyles.Add(Comments)

        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString
        Me.dgChecklist.TableStyles.Add(tbStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMAnswers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        ChecklistDataview = DB.Checklists.Get_Questions_And_Answers_For_Section(SectionID, Checklist.CheckListID)
    End Sub

    Private Sub Save()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim tempChecklistID As Integer
            If Checklist.Exists = True Then
                tempChecklistID = Checklist.CheckListID
            Else
                Checklist.IgnoreExceptionsOnSetMethods = True
                Checklist.SetEngineerVisitID = EngineerVisitID
                Checklist.SetSectionID = SectionID
                tempChecklistID = DB.Checklists.Insert(Checklist).CheckListID
            End If

            Dim oCheckListAnswer As New Entity.CheckLists.CheckListAnswer
            oCheckListAnswer.SetCheckListID = tempChecklistID

            DB.Checklists.DeleteAnswers(tempChecklistID)

            For Each row As DataRow In ChecklistDataview.Table.Rows
                If Not Entity.Sys.Helper.MakeIntegerValid(row.Item("SubTaskID")) = 0 Then
                    oCheckListAnswer.SetEnumTableID = CInt(Entity.Sys.Enums.TableNames.tblSubTask)
                    oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row.Item("SubTaskID"))
                Else
                    If Not Entity.Sys.Helper.MakeIntegerValid(row.Item("TaskID")) = 0 Then
                        oCheckListAnswer.SetEnumTableID = CInt(Entity.Sys.Enums.TableNames.tblTask)
                        oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row.Item("TaskID"))
                    Else
                        If Not Entity.Sys.Helper.MakeIntegerValid(row.Item("AreaID")) = 0 Then
                            oCheckListAnswer.SetEnumTableID = CInt(Entity.Sys.Enums.TableNames.tblArea)
                            oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row.Item("AreaID"))
                        Else
                            oCheckListAnswer.SetEnumTableID = CInt(Entity.Sys.Enums.TableNames.tblSection)
                            oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row.Item("SectionID"))
                        End If
                    End If
                End If

                oCheckListAnswer.SetResultID = Entity.Sys.Helper.MakeIntegerValid(row.Item("Result"))
                oCheckListAnswer.SetComments = Entity.Sys.Helper.MakeStringValid(row.Item("Comments"))
                DB.Checklists.InsertAnswer(oCheckListAnswer)
            Next

            Checklist = DB.Checklists.Get(tempChecklistID)
        Catch ex As Exception
            ShowMessage("Error saving answers : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

End Class