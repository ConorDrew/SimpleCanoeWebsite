Public Class FRMStandardSentences : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents gpbStandardSentences As System.Windows.Forms.GroupBox
    Friend WithEvents gpbEditAdd As System.Windows.Forms.GroupBox
    Friend WithEvents dgStandardSentences As System.Windows.Forms.DataGrid
    Friend WithEvents txtSentence As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbStandardSentences = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.dgStandardSentences = New System.Windows.Forms.DataGrid
        Me.gpbEditAdd = New System.Windows.Forms.GroupBox
        Me.txtSentence = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpbStandardSentences.SuspendLayout()
        CType(Me.dgStandardSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbEditAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbStandardSentences
        '
        Me.gpbStandardSentences.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpbStandardSentences.Controls.Add(Me.btnDelete)
        Me.gpbStandardSentences.Controls.Add(Me.btnAddNew)
        Me.gpbStandardSentences.Controls.Add(Me.dgStandardSentences)
        Me.gpbStandardSentences.Location = New System.Drawing.Point(8, 40)
        Me.gpbStandardSentences.Name = "gpbStandardSentences"
        Me.gpbStandardSentences.Size = New System.Drawing.Size(608, 448)
        Me.gpbStandardSentences.TabIndex = 2
        Me.gpbStandardSentences.TabStop = False
        Me.gpbStandardSentences.Text = "Standard Sentences"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(520, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Visible = False
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(8, 16)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add New"
        '
        'dgStandardSentences
        '
        Me.dgStandardSentences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStandardSentences.DataMember = ""
        Me.dgStandardSentences.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStandardSentences.Location = New System.Drawing.Point(8, 42)
        Me.dgStandardSentences.Name = "dgStandardSentences"
        Me.dgStandardSentences.Size = New System.Drawing.Size(592, 398)
        Me.dgStandardSentences.TabIndex = 0
        '
        'gpbEditAdd
        '
        Me.gpbEditAdd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbEditAdd.Controls.Add(Me.txtSentence)
        Me.gpbEditAdd.Controls.Add(Me.Label1)
        Me.gpbEditAdd.Controls.Add(Me.btnSave)
        Me.gpbEditAdd.Location = New System.Drawing.Point(624, 40)
        Me.gpbEditAdd.Name = "gpbEditAdd"
        Me.gpbEditAdd.Size = New System.Drawing.Size(224, 448)
        Me.gpbEditAdd.TabIndex = 3
        Me.gpbEditAdd.TabStop = False
        Me.gpbEditAdd.Text = "Add/Edit"
        '
        'txtSentence
        '
        Me.txtSentence.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSentence.Location = New System.Drawing.Point(8, 42)
        Me.txtSentence.Multiline = True
        Me.txtSentence.Name = "txtSentence"
        Me.txtSentence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSentence.Size = New System.Drawing.Size(208, 256)
        Me.txtSentence.TabIndex = 0
        Me.txtSentence.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sentence"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(136, 306)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'FRMStandardSentences
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(856, 494)
        Me.Controls.Add(Me.gpbEditAdd)
        Me.Controls.Add(Me.gpbStandardSentences)
        Me.Name = "FRMStandardSentences"
        Me.Text = "Standard Sentences"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.gpbStandardSentences, 0)
        Me.Controls.SetChildIndex(Me.gpbEditAdd, 0)
        Me.gpbStandardSentences.ResumeLayout(False)
        CType(Me.dgStandardSentences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbEditAdd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupManagerDataGrid()
        PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
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

    Private _pageState As Entity.Sys.Enums.FormState
    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

    Private _dvStandardSentences As DataView
    Private Property DvStandardSentences() As DataView
        Get
            Return _dvStandardSentences
        End Get
        Set(ByVal value As DataView)
            _dvStandardSentences = value
            _dvStandardSentences.AllowNew = False
            _dvStandardSentences.AllowEdit = False
            _dvStandardSentences.AllowDelete = False
            _dvStandardSentences.Table.TableName = Entity.Sys.Enums.TableNames.tblStandardSentences.ToString
            Me.dgStandardSentences.DataSource = DvStandardSentences
        End Set
    End Property

    Private ReadOnly Property SelectedStandardSentencesDataRow() As DataRow
        Get
            If Not Me.dgStandardSentences.CurrentRowIndex = -1 Then
                Return DvStandardSentences(Me.dgStandardSentences.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "Setup"

    Private Sub SetupManagerDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgStandardSentences)
        Dim tbStyle As DataGridTableStyle = Me.dgStandardSentences.TableStyles(0)

        Dim Sentence As New DataGridLabelColumn
        Sentence.Format = ""
        Sentence.FormatInfo = Nothing
        Sentence.HeaderText = "Sentence"
        Sentence.MappingName = "Sentence"
        Sentence.ReadOnly = True
        Sentence.Width = 550
        Sentence.NullText = ""
        tbStyle.GridColumnStyles.Add(Sentence)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblStandardSentences.ToString
        Me.dgStandardSentences.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.gpbEditAdd)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.gpbEditAdd.Enabled = False
                Me.btnAddNew.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.gpbEditAdd.Enabled = True
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = True
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.gpbEditAdd.Enabled = True
                Me.btnSave.Enabled = True
                Me.btnDelete.Enabled = True
        End Select
        PageState = state
    End Sub
#End Region

#Region "Events"

    Private Sub FRMPartCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgStandardSentences_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStandardSentences.Click
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If Not SelectedStandardSentencesDataRow Is Nothing Then
                Me.txtSentence.Text = Entity.Sys.Helper.MakeStringValid(SelectedStandardSentencesDataRow("Sentence"))
            Else
                SetUpPageState(Entity.Sys.Enums.FormState.Insert)
            End If
        Catch ex As Exception
            ShowMessage("Item data cannot load : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        SetUpPageState(Entity.Sys.Enums.FormState.Insert)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub
#End Region

#Region "Functions"

    Private Sub PopulateDatagrid(ByVal state As Entity.Sys.Enums.FormState)
        DvStandardSentences = DB.StandardSentence.GetAll()
        SetUpPageState(state)
    End Sub

    Private Sub Save()
        Dim oStandardSentence As New Entity.StandardSentences.StandardSentence
        oStandardSentence.IgnoreExceptionsOnSetMethods = True
        oStandardSentence.SetSentence = Me.txtSentence.Text.Trim

        Dim validator As New Entity.StandardSentences.StandardSentenceValidator

        Try
            validator.Validate(oStandardSentence)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.StandardSentence.Insert(oStandardSentence)
                Case Entity.Sys.Enums.FormState.Update
                    oStandardSentence.SetSentenceID = SelectedStandardSentencesDataRow.Item("SentenceID")
                    DB.StandardSentence.Update(oStandardSentence)
            End Select

            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        Catch ex As ValidationException
            ShowMessage(validator.CriticalMessagesString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete()
        Try
            If Not SelectedStandardSentencesDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to delete """ & SelectedStandardSentencesDataRow("Sentence") & """?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    DB.StandardSentence.Delete(SelectedStandardSentencesDataRow("SentenceID"))
                    PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
                End If
            Else
                ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error deleting : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class
