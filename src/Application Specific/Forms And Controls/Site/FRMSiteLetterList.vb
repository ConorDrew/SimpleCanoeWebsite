Imports System.IO

Public Class FRMSiteLetterList : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        SetupTemplateDataGrid()
        Dim dt As New DataTable
        dt.Columns.Add("Template")

        Dim r As DataRow
        Dim files() As String = System.IO.Directory.GetFiles(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SiteLetters\")
        For Each f As String In files
            If f.Replace(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SiteLetters\", "") <> "vssver.scc" Then
                r = dt.NewRow
                r("Template") = Path.GetFileName(f)
                dt.Rows.Add(r)
            End If
        Next

        dvLetters = New DataView(dt)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _dvLetters As DataView = Nothing

    Public Property dvLetters() As DataView
        Get
            Return _dvLetters
        End Get
        Set(ByVal Value As DataView)
            _dvLetters = Value
            _dvLetters.Table.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            _dvLetters.AllowNew = False
            _dvLetters.AllowEdit = False
            _dvLetters.AllowDelete = False
            Me.dgLetters.DataSource = dvLetters
        End Set
    End Property

    Private ReadOnly Property SelectedLetterDatarow() As DataRow
        Get
            If Not Me.dgLetters.CurrentRowIndex = -1 Then
                Return dvLetters(Me.dgLetters.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _selectedTemplate As String = ""

    Public Property SelectedTemplate() As String
        Get
            Return _selectedTemplate
        End Get
        Set(ByVal value As String)
            _selectedTemplate = value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupTemplateDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgLetters)
        Dim tStyle As DataGridTableStyle = Me.dgLetters.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Template As New DataGridLabelColumn
        Template.Format = ""
        Template.FormatInfo = Nothing
        Template.HeaderText = "Template"
        Template.MappingName = "Template"
        Template.ReadOnly = True
        Template.Width = 300
        Template.NullText = ""
        tStyle.GridColumnStyles.Add(Template)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSite.ToString
        Me.dgLetters.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If SelectedLetterDatarow Is Nothing Then
            Exit Sub
        End If

        SelectedTemplate = SelectedLetterDatarow("Template")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMSiteLetterList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
    End Sub

#End Region

End Class