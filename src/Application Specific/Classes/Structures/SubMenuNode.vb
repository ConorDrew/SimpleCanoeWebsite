Public Class SubMenuNode : Inherits LinkLabel

#Region "Constructors"

    Public Sub New(ByVal nameIn As String)
        LevelNumber = 1
        MyName = nameIn
    End Sub

    Public Sub New(ByVal nameIn As String, ByVal LevelNumberIn As Integer)
        LevelNumber = LevelNumberIn
        MyName = nameIn
    End Sub

    Public Sub New(ByVal nameIn As String, ByVal tableToSearchIn As Entity.Sys.Enums.TableNames)
        LevelNumber = 1
        MyName = nameIn
        TableToSearch = tableToSearchIn
    End Sub

    Public Sub New(ByVal nameIn As String, ByVal tableToSearchIn As Entity.Sys.Enums.TableNames, ByVal LevelNumberIn As Integer)
        LevelNumber = LevelNumberIn
        MyName = nameIn
        TableToSearch = tableToSearchIn
    End Sub

    Public Sub New(ByVal nameIn As String, ByVal formToOpenIn As String)
        LevelNumber = 1
        MyName = nameIn
        FormToOpen = formToOpenIn
    End Sub

    Public Sub New(ByVal nameIn As String, ByVal formToOpenIn As String, ByVal LevelNumberIn As Integer)
        LevelNumber = LevelNumberIn
        MyName = nameIn
        FormToOpen = formToOpenIn
    End Sub

#End Region

#Region "Properties"

    Private _LevelNumber As Integer = 1
    Public Property LevelNumber() As Integer
        Get
            Return _LevelNumber
        End Get
        Set(ByVal Value As Integer)
            _LevelNumber = Value
        End Set
    End Property

    Private _MyName As String = ""
    Public Property MyName() As String
        Get
            Return _MyName
        End Get
        Set(ByVal Value As String)
            _MyName = Value
            Me.Text = MyName

            If LevelNumber = 1 Then
                Me.Location = New Point(5, MainForm.MenuBar.pnlSubMenu.Controls.Count * 20)
                Me.Size = New Size(152, 15)
            Else
                Me.Location = New Point(10 * LevelNumber, MainForm.MenuBar.pnlSubMenu.Controls.Count * 20)
                Me.Size = New Size(152 - (10 * LevelNumber), 15)
            End If

            Me.LinkColor = Color.FromArgb(0, 52, 102)
            Me.ActiveLinkColor = Color.FromArgb(0, 52, 102)
            Me.DisabledLinkColor = Color.FromArgb(0, 52, 102)
            Me.VisitedLinkColor = Color.FromArgb(0, 52, 102)

            AddHandler Me.Click, AddressOf ButtonClicked
        End Set
    End Property

    Private _ChildNodes As Array = Nothing
    Public Property ChildNodes() As Array
        Get
            Return _ChildNodes
        End Get
        Set(ByVal Value As Array)
            _ChildNodes = Value

            For Each childNode As SubMenuNode In ChildNodes
                MainForm.MenuBar.pnlSubMenu.Controls.Add(childNode)
            Next
        End Set
    End Property

    Private _FormToOpen As String = "UsePanels"
    Public Property FormToOpen() As String
        Get
            Return _FormToOpen
        End Get
        Set(ByVal Value As String)
            _FormToOpen = Value
        End Set
    End Property

    Private _TableToSearch As Entity.Sys.Enums.TableNames = Entity.Sys.Enums.TableNames.NO_TABLE
    Public Property TableToSearch() As Entity.Sys.Enums.TableNames
        Get
            Return _TableToSearch
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _TableToSearch = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Private Sub ButtonClicked(ByVal sender As Object, ByVal e As EventArgs)
        Navigation.Sub_Menu(Me)
    End Sub

#End Region

End Class
