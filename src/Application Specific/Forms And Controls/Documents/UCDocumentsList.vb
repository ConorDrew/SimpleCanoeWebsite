Public Class UCDocumentsList : Inherits FSM.UCBase

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal EntityToLinkToIn As Entity.Sys.Enums.TableNames, ByVal IDToLinkToIn As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        EntityToLinkTo = EntityToLinkToIn
        IDToLinkTo = IDToLinkToIn
        Me.Dock = DockStyle.Fill
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
    Friend WithEvents grpDocuments As System.Windows.Forms.GroupBox
    Friend WithEvents dgDocuments As System.Windows.Forms.DataGrid
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDocuments = New System.Windows.Forms.GroupBox
        Me.dgDocuments = New System.Windows.Forms.DataGrid
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.grpDocuments.SuspendLayout()
        CType(Me.dgDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDocuments
        '
        Me.grpDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDocuments.Controls.Add(Me.dgDocuments)

        Me.grpDocuments.Location = New System.Drawing.Point(8, 8)
        Me.grpDocuments.Name = "grpDocuments"
        Me.grpDocuments.Size = New System.Drawing.Size(488, 512)
        Me.grpDocuments.TabIndex = 0
        Me.grpDocuments.TabStop = False
        Me.grpDocuments.Text = "Double Click To View / Edit"
        '
        'dgDocuments
        '
        Me.dgDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDocuments.DataMember = ""
        Me.dgDocuments.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDocuments.Location = New System.Drawing.Point(8, 26)
        Me.dgDocuments.Name = "dgDocuments"
        Me.dgDocuments.Size = New System.Drawing.Size(472, 478)
        Me.dgDocuments.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = ""
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(440, 528)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(56, 25)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = ""
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(8, 528)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 25)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'UCDocumentsList
        '
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpDocuments)
        Me.Name = "UCDocumentsList"
        Me.Size = New System.Drawing.Size(504, 560)
        Me.grpDocuments.ResumeLayout(False)
        CType(Me.dgDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _EntityToLinkTo As Entity.Sys.Enums.TableNames
    Public Property EntityToLinkTo() As Entity.Sys.Enums.TableNames
        Get
            Return _EntityToLinkTo
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _EntityToLinkTo = Value
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0
    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value

            If IDToLinkTo = 0 Then
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
            Else
                If EntityToLinkTo = Entity.Sys.Enums.TableNames.tblCustomer Then
                    'So we can see site documents as well at customer level
                    Documents = DB.Documents.Documents_GetAll_For_Customer_ID(EntityToLinkTo, IDToLinkTo)
                ElseIf EntityToLinkTo = Entity.Sys.Enums.TableNames.tblSite Then
                    Documents = DB.Documents.Documents_GetAll_For_Site_ID(EntityToLinkTo, IDToLinkTo)
                Else
                    Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
                End If

                Me.btnAdd.Enabled = True
                Me.btnDelete.Enabled = True
            End If
        End Set
    End Property

    Private _dvDocuments As DataView
    Public Property Documents() As DataView
        Get
            Return _dvDocuments
        End Get
        Set(ByVal value As DataView)
            _dvDocuments = value
            _dvDocuments.Table.TableName = Entity.Sys.Enums.TableNames.TBLDocuments.ToString
            _dvDocuments.AllowNew = False
            _dvDocuments.AllowEdit = False
            _dvDocuments.AllowDelete = False
            Me.dgDocuments.DataSource = Documents
        End Set
    End Property

    Private ReadOnly Property SelectedDocumentDataRow() As DataRow
        Get
            If Not Me.dgDocuments.CurrentRowIndex = -1 Then
                Return Documents(Me.dgDocuments.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "SetUp"

    Private Sub SetupDocumentsDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgDocuments.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Reference"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 200
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim LastUpdated As New DataGridLabelColumn
        LastUpdated.Format = "dddd dd MMMM yyyy HH:mm:ss"
        LastUpdated.FormatInfo = Nothing
        LastUpdated.HeaderText = "Last Updated"
        LastUpdated.MappingName = "LastUpdatedOn"
        LastUpdated.ReadOnly = True
        LastUpdated.Width = 200
        LastUpdated.NullText = ""
        tStyle.GridColumnStyles.Add(LastUpdated)

        Dim LastUpdatedBy As New DataGridLabelColumn
        LastUpdatedBy.Format = ""
        LastUpdatedBy.FormatInfo = Nothing
        LastUpdatedBy.HeaderText = "Last Updated By"
        LastUpdatedBy.MappingName = "LastUpdatedByUserName"
        LastUpdatedBy.ReadOnly = True
        LastUpdatedBy.Width = 200
        LastUpdatedBy.NullText = ""
        tStyle.GridColumnStyles.Add(LastUpdatedBy)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.TBLDocuments.ToString
        Me.dgDocuments.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCDocumentsList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBaseControl(Me)
        SetupDocumentsDataGrid()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ShowForm(GetType(FRMDocuments), True, New Object() {EntityToLinkTo, Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), 0, Me})
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedDocumentDataRow Is Nothing Then
            ShowMessage("Please select a document to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.Documents.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")))
        ' Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
        'JUST REFERESH THROUGH THE PROPERTY
        IDToLinkTo = IDToLinkTo

    End Sub

    Private Sub dgDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocuments.DoubleClick
        If SelectedDocumentDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMDocuments), True, New Object() {CType(SelectedDocumentDataRow.Item("TableEnumID"), Entity.Sys.Enums.TableNames), Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")), Me})
    End Sub

#End Region

#Region "Functions"
    Public Sub Populate()
        If EntityToLinkTo = Entity.Sys.Enums.TableNames.tblCustomer Then
            'So we can see site documents as well at customer level
            Documents = DB.Documents.Documents_GetAll_For_Customer_ID(EntityToLinkTo, IDToLinkTo)
        ElseIf EntityToLinkTo = Entity.Sys.Enums.TableNames.tblSite Then
            Documents = DB.Documents.Documents_GetAll_For_Site_ID(EntityToLinkTo, IDToLinkTo)
        Else
            Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
        End If
    End Sub
#End Region

End Class
