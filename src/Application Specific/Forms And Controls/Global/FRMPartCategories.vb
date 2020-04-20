Public Class FRMPartCategories : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboCategory, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents dgManager As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgManager = New System.Windows.Forms.DataGrid()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAddNew)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.dgManager)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 344)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Part Categories Mapping"
        '
        'btnAddNew
        '
        Me.btnAddNew.AccessibleDescription = "Add new item"
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.UseVisualStyleBackColor = True
        Me.btnAddNew.Location = New System.Drawing.Point(8, 16)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(48, 24)
        Me.btnAddNew.TabIndex = 5
        Me.btnAddNew.Text = "New"
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Delete item"
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Location = New System.Drawing.Point(724, 18)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 24)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        '
        'dgManager
        '
        Me.dgManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgManager.DataMember = ""
        Me.dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgManager.Location = New System.Drawing.Point(8, 49)
        Me.dgManager.Name = "dgManager"
        Me.dgManager.Size = New System.Drawing.Size(764, 287)
        Me.dgManager.TabIndex = 0
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.cboCategory)
        Me.grpDetails.Controls.Add(Me.Label1)
        Me.grpDetails.Controls.Add(Me.txtName)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.Controls.Add(Me.btnSave)

        Me.grpDetails.Location = New System.Drawing.Point(8, 384)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(780, 56)
        Me.grpDetails.TabIndex = 8
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'cboCategory
        '
        Me.cboCategory.Location = New System.Drawing.Point(409, 21)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(306, 21)
        Me.cboCategory.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(357, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Map To"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(79, 21)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(265, 21)
        Me.txtName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Map From"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save item"
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.ImageIndex = 1
        Me.btnSave.Location = New System.Drawing.Point(721, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        '
        'FRMPartCategories
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(796, 454)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpDetails)
        Me.MinimumSize = New System.Drawing.Size(496, 488)
        Me.Name = "FRMPartCategories"
        Me.Text = "Part Categories"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpDetails, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
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

    Private _dvManager As DataView
    Private Property ManagerDataview() As DataView
        Get
            Return _dvManager
        End Get
        Set(ByVal value As DataView)
            _dvManager = value
            _dvManager.AllowNew = False
            _dvManager.AllowEdit = False
            _dvManager.AllowDelete = False
            _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPartCategoryMapping.ToString
            Me.dgManager.DataSource = ManagerDataview
        End Set
    End Property

    Private ReadOnly Property SelectedManagerDataRow() As DataRow
        Get
            If Not Me.dgManager.CurrentRowIndex = -1 Then
                Return ManagerDataview(Me.dgManager.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "Setup"
    Private Sub SetupManagerDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgManager)
        Dim tbStyle As DataGridTableStyle = Me.dgManager.TableStyles(0)

        Dim PartMapID As New DataGridLabelColumn
        PartMapID.HeaderText = "ID"
        PartMapID.MappingName = "PartMapID"
        PartMapID.ReadOnly = True
        tbStyle.GridColumnStyles.Add(PartMapID)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Map To"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 177
        name.NullText = ""
        tbStyle.GridColumnStyles.Add(name)

        Dim mapping As New DataGridLabelColumn
        mapping.Format = ""
        mapping.FormatInfo = Nothing
        mapping.HeaderText = "Map From"
        mapping.MappingName = "PartMapMatch"
        mapping.ReadOnly = True
        mapping.Width = 177
        mapping.NullText = ""
        tbStyle.GridColumnStyles.Add(mapping)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartCategoryMapping.ToString
        Me.dgManager.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.grpDetails)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.grpDetails.Enabled = False
                Me.btnAddNew.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.grpDetails.Enabled = True
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = True
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.grpDetails.Enabled = True
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

    Private Sub dgManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgManager.Click
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If Not SelectedManagerDataRow Is Nothing Then
                Me.txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("PartMapMatch"))
                Combo.SetSelectedComboItem_By_Value(cboCategory, SelectedManagerDataRow("ManagerID"))
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
        ManagerDataview = DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories)
        SetUpPageState(state)
    End Sub

    Private Sub Save()
        Try

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.Picklists.InsertPartCategory(Combo.GetSelectedItemValue(Me.cboCategory), txtName.Text)
                Case Entity.Sys.Enums.FormState.Update
                    DB.Picklists.UpdatePartMapping(SelectedManagerDataRow.Item("PartMapID"), Combo.GetSelectedItemValue(Me.cboCategory), txtName.Text)
            End Select

            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete()
        Try
            If Not SelectedManagerDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to delete """ & SelectedManagerDataRow("Name") & """ from " & " Part Categories " & "?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    DB.Picklists.DeletePartMapping(SelectedManagerDataRow("PartMapID"))
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
