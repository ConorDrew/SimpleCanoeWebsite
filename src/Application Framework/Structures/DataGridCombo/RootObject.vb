Imports System.ComponentModel
'Imports SolutionsNET.Persistence

Friend Class RootObject

#Region " declarations "

    ' native member declarations
    <System.Xml.Serialization.XmlIgnore()> _
    Friend Filename As New FullyQualifiedFileName

    <System.Xml.Serialization.XmlIgnore()> _
    Friend HasBeenPersisted As Boolean = False

#End Region

#Region " constructor "

    Public Sub New()

        Me.CurrentLocation = RootObject.defaultPersistFolder

    End Sub

#End Region

#Region " accessors "

    <System.Xml.Serialization.XmlIgnore()> _
    Friend Property CurrentLocation() As String
        Get
            Return Filename.Folder
        End Get
        Set(ByVal Value As String)
            Filename.Folder = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnore()> _
    Friend Property PersistName() As String
        Get
            Return Filename.Text
        End Get
        Set(ByVal Value As String)
            Filename.Text = Value
        End Set
    End Property

#End Region

#Region " shared persistence methods and properties "

    Friend Shared Function CreateDefaultList(ByVal item As IPersistable) As IPersistable

        XmlPersister.Write(item)
        Return item

    End Function

    Friend Shared Function DefaultListExits(ByVal objectType As Type) As Boolean
        Return XmlPersister.DefaultListExits(objectType)
    End Function

    Friend Shared Property DefaultPersistFolder() As String
        Get
            Return XmlPersister.DefaultFolder
        End Get
        Set(ByVal Value As String)
            XmlPersister.DefaultFolder = Value
        End Set
    End Property

    Friend Shared Function GetDefaultList(ByVal itemType As Type) As IPersistable

        Return XmlPersister.GetDefaultList(itemType)

    End Function

    Friend Shared Function Read(ByVal filename As String, ByVal itemType As Type) As IPersistable

        Return XmlPersister.Read(filename, itemType)

    End Function

    Friend Shared Sub Write(ByVal item As IPersistable)

        XmlPersister.Write(item)

    End Sub

#End Region

End Class