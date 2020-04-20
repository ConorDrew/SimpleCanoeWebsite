Public Class UCJobCostings : Inherits FSM.UCBase

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal IDToLinkToIn As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'UCJobCostings
        '
        Me.Name = "UCJobCostings"
        Me.Size = New System.Drawing.Size(504, 560)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

   


    Private _JI As Entity.JobInstalls.JobInstall
    Private Property JI() As Entity.JobInstalls.JobInstall
        Get
            Return _JI
        End Get
        Set(ByVal value As Entity.JobInstalls.JobInstall)
            _JI = value
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
           
            Else
            

            End If
        End Set
    End Property

    Private _dvDocuments As DataView
    'Public Property Documents() As DataView
    '    Get
    '        Return _dvDocuments
    '    End Get
    '    Set(ByVal value As DataView)
    '        _dvDocuments = value
    '        _dvDocuments.Table.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
    '        _dvDocuments.AllowNew = False
    '        _dvDocuments.AllowEdit = False
    '        _dvDocuments.AllowDelete = False
    '        Me.dgDocuments.DataSource = Documents
    '    End Set
    'End Property

    'Private ReadOnly Property SelectedDocumentDataRow() As DataRow
    '    Get
    '        If Not Me.dgDocuments.CurrentRowIndex = -1 Then
    '            Return Documents(Me.dgDocuments.CurrentRowIndex).Row
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

#End Region

#Region "SetUp"

    Private Sub SetupDocumentsDataGrid()



    End Sub


 


    


#End Region

#Region "Events"

    Private Sub UCJobCost_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBaseControl(Me)
        ' UCLogCallout.OnCostings = Me
       
     
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' ShowForm(GetType(FRMDocuments), True, New Object() {EntityToLinkTo, Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), 0, Me})
    End Sub

    'Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If SelectedDocumentDataRow Is Nothing Then
    '        ShowMessage("Please select a document to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If

    '    If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '        Exit Sub
    '    End If

    '    DB.Documents.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")))
    '    ' Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
    '    'JUST REFERESH THROUGH THE PROPERTY
    '    IDToLinkTo = IDToLinkTo

    'End Sub

    'Private Sub dgDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If SelectedDocumentDataRow Is Nothing Then
    '        Exit Sub
    '    End If

    '    ShowForm(GetType(FRMDocuments), True, New Object() {CType(SelectedDocumentDataRow.Item("TableEnumID"), Entity.Sys.Enums.TableNames), Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow.Item("DocumentID")), Me})
    'End Sub

#End Region

#Region "Functions"
    Public Sub Populate()



    End Sub
#End Region

End Class
