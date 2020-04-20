Imports System.ComponentModel
'Imports SolutionsNET.Persistence

Public MustInherit Class BindableCollection
    Inherits CollectionBase
    Implements IBindingList

#Region " declarations "

    ' primitives for IBindingList
    Private _allowEdit As Boolean = True
    Private _allowNew As Boolean = True
    Private _allowRemove As Boolean = True
    Private _isSorted As Boolean = False
    Private _sortDirection As ListSortDirection
    Private _supportsChangeNotification As Boolean = True
    Private _supportsSearching As Boolean = False
    Private _supportsSorting As Boolean = False

    ' for calculated events
    Protected Friend Event propertyChanged As PropertyChangedEventHandler

    ' these hold contained properties
    Protected ReadOnly Properties As New CollectionProperties(Me)

#End Region

#Region " collection methods "

    Public Sub Add(ByVal item As BindableChildItem)
        MyBase.List.Add(item)
    End Sub

    Friend Function IndexOf(ByVal item As BindableChildItem) As Integer
        Return list.IndexOf(item)
    End Function

    Public Sub Remove(ByVal item As BindableChildItem)
        MyBase.List.Remove(item)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As BindableChildItem
        Get
            Return MyBase.List.Item(index)
        End Get
    End Property

#End Region

#Region " property events "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Properties.onChildPropertyChanged(sender, e)
    End Sub

    Friend Sub onPropertyChanged(ByVal name As String)
        RaiseEvent propertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

#End Region

#Region " IBindingList properties "

    Public ReadOnly Property AllowEdit() As Boolean Implements System.ComponentModel.IBindingList.AllowEdit
        Get
            Return _allowEdit
        End Get
    End Property

    Public ReadOnly Property AllowNew() As Boolean Implements System.ComponentModel.IBindingList.AllowNew
        Get
            Return _allowNew
        End Get
    End Property

    Public ReadOnly Property AllowRemove() As Boolean Implements System.ComponentModel.IBindingList.AllowRemove
        Get
            Return _allowRemove
        End Get
    End Property

    Public ReadOnly Property IsSorted() As Boolean Implements System.ComponentModel.IBindingList.IsSorted
        Get
            Return _isSorted
        End Get
    End Property

    Public ReadOnly Property SortDirection() As System.ComponentModel.ListSortDirection Implements System.ComponentModel.IBindingList.SortDirection
        Get
            Return _sortDirection
        End Get
    End Property

    Public ReadOnly Property SortProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.IBindingList.SortProperty
        Get
            Throw New NotSupportedException
        End Get
    End Property

    Public ReadOnly Property SupportsChangeNotification() As Boolean Implements System.ComponentModel.IBindingList.SupportsChangeNotification
        Get
            Return _supportsChangeNotification
        End Get
    End Property

    Public ReadOnly Property SupportsSearching() As Boolean Implements System.ComponentModel.IBindingList.SupportsSearching
        Get
            Return _supportsSearching
        End Get
    End Property

    Public ReadOnly Property SupportsSorting() As Boolean Implements System.ComponentModel.IBindingList.SupportsSorting
        Get
            Return _supportsSorting
        End Get
    End Property

#End Region

#Region " IBindingList methods "

    Public MustOverride Function AddNew() As Object Implements System.ComponentModel.IBindingList.AddNew

    Public Sub AddIndex(ByVal [property] As System.ComponentModel.PropertyDescriptor) Implements System.ComponentModel.IBindingList.AddIndex
        Throw New NotSupportedException
    End Sub

    Public Sub ApplySort(ByVal [property] As System.ComponentModel.PropertyDescriptor, ByVal direction As System.ComponentModel.ListSortDirection) Implements System.ComponentModel.IBindingList.ApplySort
        Throw New NotSupportedException
    End Sub

    Public Function Find(ByVal [property] As System.ComponentModel.PropertyDescriptor, ByVal key As Object) As Integer Implements System.ComponentModel.IBindingList.Find
        Throw New NotSupportedException
    End Function

    Public Sub RemoveIndex(ByVal [property] As System.ComponentModel.PropertyDescriptor) Implements System.ComponentModel.IBindingList.RemoveIndex
        Throw New NotSupportedException
    End Sub

    Public Sub RemoveSort() Implements System.ComponentModel.IBindingList.RemoveSort
        Throw New NotSupportedException
    End Sub

#End Region

#Region " events and their calls "

    Public Event ListChanged(ByVal sender As Object, _
                             ByVal e As System.ComponentModel.ListChangedEventArgs) _
                             Implements System.ComponentModel.IBindingList.ListChanged

    Friend Sub onInternalListChanged(ByVal type As ListChangedType, ByVal index As Integer)
        RaiseEvent ListChanged(Me, New ListChangedEventArgs(type, index))
    End Sub

    Protected Friend Overridable Sub onListChanged(ByVal type As ListChangedType, ByVal index As Integer)
        onInternalListChanged(type, index)
        Properties.onListChanged()
    End Sub

#End Region

#Region " base overrides "

    Protected Overrides Sub OnClearComplete()
        onListChanged(ListChangedType.Reset, 0)
    End Sub

    Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As Object)
        Dim item As BindableChildItem = CType(value, BindableChildItem)
        AddHandler item.RemoveMe, AddressOf Remove
        AddHandler item.propertyChanged, AddressOf Me.onChildPropertyChanged
    End Sub

    Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
        onListChanged(ListChangedType.ItemAdded, index)
    End Sub

    Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
        onListChanged(ListChangedType.ItemDeleted, index)
    End Sub

    Protected Overrides Sub OnSetComplete(ByVal index As Integer, _
                                          ByVal oldValue As Object, _
                                          ByVal newValue As Object)
        onListChanged(ListChangedType.ItemChanged, index)
    End Sub

#End Region

End Class

Public MustInherit Class BindableRootCollection
    Inherits BindableCollection
    Implements IPersistable

#Region " declarations "

    ' native member declarations
    Private myRoot As New RootObject

    ' must overrides
    <System.Xml.Serialization.XmlIgnore()> _
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

    Protected Shared Property defaultPersistFolder() As String
        Get
            Return RootObject.defaultPersistFolder
        End Get
        Set(ByVal Value As String)
            RootObject.defaultPersistFolder = Value
        End Set
    End Property

    Protected Shared Function Read(ByVal fileName As String, ByVal itemType As Type) As Object

        Return RootObject.Read(fileName, itemType)

    End Function

    Protected Shared Sub Write(ByVal item As Object)

        RootObject.Write(item)

    End Sub

#End Region


End Class