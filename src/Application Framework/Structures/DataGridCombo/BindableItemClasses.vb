Imports System.ComponentModel
Imports System.Reflection
'Imports SolutionsNET.Persistence

Public MustInherit Class BindableItem
    Implements IEditableObject
    Implements IDataErrorInfo

#Region " declarations "

    ' these hold and handle contained properties
    Protected ReadOnly PersistedProperties As New PersistedProperties(Me)
    Protected ReadOnly CalculatedProperties As New CalculatedProperties(Me)

    ' events
    Friend Event internalPropertyChanged As PropertyChangedEventHandler
    Protected Friend Event propertyChanged As PropertyChangedEventHandler

    ' for IEditableObject members
    Private _editing As Boolean = False
    Protected _isNew As Boolean = True

    'Public MustOverride ReadOnly Property IsRootObject()

#End Region

#Region " accessors "

    Public ReadOnly Property PropertyValue(ByVal name As String) As Object
        Get
            If PersistedProperties.Exists(name) Then
                Return PersistedProperties(name).Value
            ElseIf CalculatedProperties.Exists(name) Then
                'Return CalculatedProperties(name).value
                Return Nothing
            End If

        End Get
    End Property

#End Region

#Region " event calls "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        CalculatedProperties.onChildPropertyChanged(sender, e)
    End Sub

    Friend Sub onInternalPropertyChanged(ByVal name As String)
        RaiseEvent internalPropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Friend Sub onPropertyChanged(ByVal name As String)
        RaiseEvent propertyChanged(Me, New PropertyChangedEventArgs(name))

        Dim myType As System.Type = Me.GetType()
        For Each thisEvent As EventInfo In myType.GetEvents()
            If thisEvent.Name.StartsWith(name) Then
                Dim myMethodName As String = String.Format("On{0}Changed", name)
                Dim thisRaiseMethod As MethodInfo = myType.GetMethod(myMethodName)
                If Not thisRaiseMethod Is Nothing Then
                    Dim myArguments() As Object = {New PropertyChangedEventArgs(name)}
                    thisRaiseMethod.Invoke(Me, myArguments)
                Else
                    Dim newMethod As MethodInfo

                End If
            End If
        Next

    End Sub

#End Region

#Region " IEditableObject members "

    Private Sub BeginEdit() Implements System.ComponentModel.IEditableObject.BeginEdit
        If Not _editing Then
            _editing = True
            PersistedProperties.BeginEdit()
        End If
    End Sub

    Protected Overridable Sub CancelEdit() Implements System.ComponentModel.IEditableObject.CancelEdit

        If _editing Then
            _editing = False
        End If

        PersistedProperties.CancelEdit()

    End Sub

    Private Sub EndEdit() Implements System.ComponentModel.IEditableObject.EndEdit

        _editing = False
        _isNew = False

    End Sub

#End Region

#Region " IDataErrorInfo members "

    Private ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get
            Return PersistedProperties.Error
        End Get
    End Property

    Private ReadOnly Property ErrorInfoItem(ByVal columnName As String) As String _
                                                Implements System.ComponentModel.IDataErrorInfo.Item
        Get
            Return String.Empty
        End Get
    End Property

#End Region

End Class

Public MustInherit Class BindableChildItem
    Inherits BindableItem

#Region " declarations "

    Public Event RemoveMe(ByVal item As BindableChildItem)

#End Region

#Region " event calls "

    Private Sub onRemoveMe()
        RaiseEvent RemoveMe(Me)
    End Sub

#End Region

#Region " overrides "

    Protected Overrides Sub CancelEdit()

        MyBase.CancelEdit()

        If _isNew Then
            onRemoveMe()
        End If

    End Sub

#End Region

End Class

Public MustInherit Class BindableRootItem
    Inherits BindableItem
    Implements IPersistable

#Region " declarations "

    ' native member declarations
    Private myRoot As New RootObject

    ' must overrides
    Public MustOverride ReadOnly Property DefaultFileNameAndExt() As String Implements IPersistable.DefaultName

#End Region

#Region " accessors "

    <System.Xml.Serialization.XmlIgnore()> _
    Public Property CurrentLocation() As String Implements IPersistable.CurrentLocation
        Get
            Return myRoot.CurrentLocation
        End Get
        Set(ByVal Value As String)
            myRoot.CurrentLocation = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnore()> _
    Public Property HasBeenPersisted() As Boolean Implements IPersistable.HasBeenPersisted
        Get
            Return myRoot.HasBeenPersisted
        End Get
        Set(ByVal Value As Boolean)
            myRoot.HasBeenPersisted = Value
        End Set
    End Property

    <System.Xml.Serialization.XmlIgnore()> _
    Public Property PersistName() As String Implements IPersistable.PersistName
        Get
            Return myRoot.PersistName
        End Get
        Set(ByVal Value As String)
            myRoot.PersistName = Value
        End Set
    End Property

#End Region

#Region " shared persistence methods and properties "

    Public Shared Function CreateDefaultList(ByVal item As Object) As Object

        Return RootObject.CreateDefaultList(item)

    End Function

    Public Shared Function DefaultListExits(ByVal objectType As Type) As Boolean
        Return RootObject.DefaultListExits(objectType)
    End Function

    Public Shared Property defaultPersistFolder() As String
        Get
            Return RootObject.DefaultPersistFolder
        End Get
        Set(ByVal Value As String)
            RootObject.DefaultPersistFolder = Value
        End Set
    End Property

    Public Shared Function GetDefaultList(ByVal itemType As Type) As Object

        Return RootObject.GetDefaultList(itemType)

    End Function

    Public Shared Function Read(ByVal fileName As String, ByVal itemType As Type) As Object

        Return RootObject.Read(fileName, itemType)

    End Function

    Public Shared Sub Write(ByVal item As Object)

        RootObject.Write(item)

    End Sub

#End Region

End Class