Public Class FullyQualifiedFileName

#Region " member data "

    ' This provides the fully qualified name of the file for persisting operations.
    Public Text As String = String.Empty

#End Region

#Region " private static methods "

    Private Shared Function extractExtension(ByVal text As String) As String
        Dim folder As String
        Dim name As String
        Dim ext As String
        splitText(text, folder, name, ext)
        Return ext
    End Function

    Private Shared Function extractFolder(ByVal text As String) As String
        Dim folder As String
        Dim name As String
        Dim ext As String
        splitText(text, folder, name, ext)
        If folder = "\" Then folder = XmlPersister.DefaultFolder
        Return folder
    End Function

    Private Shared Function extractFolderAndName(ByVal text As String) As String
        Dim folder As String
        Dim name As String
        Dim ext As String
        splitText(text, folder, name, ext)
        If folder.Length = 0 Then folder = XmlPersister.DefaultFolder
        Return folder + name
    End Function

    Private Shared Function extractName(ByVal text As String) As String
        Dim folder As String
        Dim name As String
        Dim ext As String
        splitText(text, folder, name, ext)
        Return name
    End Function

    Private Shared Function extractNameWithExt(ByVal text As String) As String
        Dim folder As String
        Dim name As String
        Dim ext As String
        splitText(text, folder, name, ext)
        If ext.Length > 0 Then
            Return name + "." + ext
        Else
            Return name
        End If
    End Function

    Private Shared Sub splitText(ByVal toSplit As String, _
                                 ByRef folder As String, _
                                 ByRef name As String, _
                                 ByRef ext As String)
        folder = String.Empty
        name = String.Empty
        ext = String.Empty
        If toSplit.Length > 0 Then
            Dim pos As Integer = toSplit.LastIndexOf("\")
            If pos > 0 Then
                folder = toSplit.Substring(0, pos)
                name = toSplit.Substring(pos + 1)
            Else
                ' there is no "\" in the file, so there is no folder
                name = toSplit
            End If
            toSplit = name
            If toSplit.Length > 0 Then
                pos = toSplit.LastIndexOf(".")
                If pos > 0 Then
                    name = toSplit.Substring(0, pos)
                    ext = toSplit.Substring(pos + 1)
                End If
            End If
        End If
        If Not folder.EndsWith("\") Then
            folder += "\"
        End If
    End Sub

#End Region

#Region " accessors "

    ' Provides a unique name of the object to the user with extension appended
    Public ReadOnly Property Extension() As String
        Get
            Return extractExtension(Text)
        End Get
    End Property

    ' Provides initial directory during open operations from a document
    ' that HAS been saved (IsNew is False).  Also provides initial
    ' directory when saving documents with a new name (Save As...)
    Public Property Folder() As String
        Get
            Return extractFolder(Me.Text)
        End Get
        Set(ByVal Value As String)
            If Not Value.EndsWith("\") Then Value += "\"
            Me.Text = Value + NameAndExt
        End Set
    End Property

    Public ReadOnly Property FolderAndName() As String
        Get
            Return extractFolderAndName(Me.Text)
        End Get
    End Property

    ' Provides a unique name of the object to the user with extension appended
    Public ReadOnly Property Name() As String
        Get
            Return extractName(Text)
        End Get
    End Property

    ' Provides a unique name of the object to the user with extension appended
    Public ReadOnly Property NameAndExt() As String
        Get
            Return extractNameWithExt(Text)
        End Get
    End Property

#End Region

End Class
