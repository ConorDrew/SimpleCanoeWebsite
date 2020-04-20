Imports System.ComponentModel

Public Class CalculatedProperties
    Inherits Properties

#Region " constructors "

    Friend Sub New(ByVal parent As BindableItem)

        MyBase.New(parent)

    End Sub

#End Region

#Region " accessors "

    Friend Shadows Property Parent() As BindableItem
        Get
            Return MyBase.Parent
        End Get
        Set(ByVal Value As BindableItem)
            MyBase.Parent = Value
        End Set
    End Property

#End Region

#Region " collection members "

    Public Shadows Function AddNew(ByVal name As String) As CalculatedProperty

        Dim newItem As New CalculatedProperty(Me, name)
        MyBase.AddNew(newItem)
        Return newItem

    End Function

    Public Shadows Function AddNew(ByVal name As String, ByVal triggers As String) As CalculatedProperty
        ' triggers is a comma delimited string of property names that when
        ' have a change, trigger a change to this calculated value as well.
        Dim pos As Integer
        Dim propName As String
        Dim newStr As String = triggers

        With AddNew(name)

            Do

                pos = newStr.IndexOf(",")

                If pos > 0 Then
                    propName = newStr.Substring(0, pos)
                    newStr = newStr.Substring(pos + 1)
                Else
                    propName = newStr
                End If

                .triggers.AddNew(propName)

            Loop Until pos = -1

        End With

    End Function

    Default Public Shadows ReadOnly Property Item(ByVal Index As Integer) As CalculatedProperty
        Get
            Return MyBase.Item(Index)
        End Get
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal name As String) As CalculatedProperty
        Get
            Return MyBase.Item(name)
        End Get
    End Property

#End Region

#Region " work methods "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

        For x As Integer = 0 To (Count - 1)
            Item(x).onChildPropertyChanged(sender, e)
        Next

    End Sub

#End Region

End Class

Public Class CalculatedProperty
    Inherits [Property]

#Region " declarations "

    Private WithEvents Parent As BindableItem
    Friend triggers As New SimpleStringArray

    Private _value As Object

#End Region

#Region " constructors "

    Friend Sub New(ByVal container As CalculatedProperties, ByVal name As String)
        MyBase.New(container, name)
        Parent = container.Parent
    End Sub

#End Region

#Region " accessors "

    Friend Shadows Property Container() As CalculatedProperties
        Get
            Return MyBase.Container
        End Get
        Set(ByVal Value As CalculatedProperties)
            MyBase.Container = Value
        End Set
    End Property

#End Region

#Region " properties "

    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal newValue As Object)
            _value = newValue
        End Set
    End Property

#End Region

#Region " work methods "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

        ' Whenever a child property is changed, we hear it here.  If its a trigger for an
        ' property of the collection, thne raise the property changed event.  Happens to be the
        ' exact code as 'triggerChangedHandler' method, so call it.
        triggerChangedHandler(sender, e)

    End Sub

    Friend Sub triggerChangedHandler(ByVal sender As Object, _
                                      ByVal e As PropertyChangedEventArgs) _
                                      Handles Parent.internalPropertyChanged
        ' Listen to all persisted property changed events.

        ' if the property just changed is a trigger then raise this
        ' property change event.
        If triggers.Exists(e.PropertyName) Then
            Parent.onPropertyChanged(Me.name)
        End If

    End Sub

#End Region

End Class

Public Class CollectionProperties
    Inherits Properties

#Region " constructors "

    Friend Sub New(ByVal parent As BindableCollection)

        MyBase.New(parent)

    End Sub

#End Region

#Region " accessors "

    Friend Shadows Property Parent() As BindableCollection
        Get
            Return MyBase.Parent
        End Get
        Set(ByVal Value As BindableCollection)
            MyBase.Parent = Value
        End Set
    End Property

#End Region

#Region " collection members "

    Public Shadows Function AddNew(ByVal name As String) As CollectionProperty

        Dim newItem As New CollectionProperty(Me, name)
        MyBase.AddNew(newItem)
        Return newItem

    End Function

    Public Shadows Function AddNew(ByVal name As String, ByVal childTriggers As String) As CollectionProperty
        ' triggers is a comma delimited string of child property names that when
        ' have a change, trigger a change to this value as well.
        Dim pos As Integer
        Dim propName As String
        Dim newStr As String = childTriggers

        With AddNew(name)

            Do

                pos = newStr.IndexOf(",")

                If pos > 0 Then
                    propName = newStr.Substring(0, pos)
                    newStr = newStr.Substring(pos + 1)
                Else
                    propName = newStr
                End If

                .childTriggers.AddNew(propName)

            Loop Until pos = -1

        End With

    End Function

    Default Public Shadows ReadOnly Property Item(ByVal Index As Integer) As CollectionProperty
        Get
            Return MyBase.Item(Index)
        End Get
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal name As String) As CollectionProperty
        Get
            Return MyBase.Item(name)
        End Get
    End Property

#End Region

#Region " work methods "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

        For x As Integer = 0 To (Count - 1)
            Item(x).onChildPropertyChanged(sender, e)
        Next

    End Sub

    Friend Sub onListChanged()

        For x As Integer = 0 To (Count - 1)
            Item(x).onListChanged()
        Next

    End Sub

#End Region

End Class

Public Class CollectionProperty
    Inherits [Property]

#Region " declarations "

    ' Indicates to raise the ListChanged event after the PropertyChanged event
    Public DoListChangedOnPropertyChange As Boolean = True
    ' Indicates to raise the PropertyChanged event after the ListChanged event
    Public DoPropertyChangeOnListChanged As Boolean = True

    ' Contains the list of child property changed names that trigger a change
    ' in this calculated collection property.
    Friend childTriggers As New SimpleStringArray

#End Region

#Region " constructors "

    Friend Sub New(ByVal container As CollectionProperties, ByVal name As String)
        MyBase.New(container, name)
    End Sub

#End Region

#Region " accessors "

    Friend Shadows Property Container() As CollectionProperties
        Get
            Return MyBase.Container
        End Get
        Set(ByVal Value As CollectionProperties)
            MyBase.Container = Value
        End Set
    End Property

#End Region

#Region " work methods "

    Friend Sub onChildPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

        Dim myParent As BindableCollection = Container.Parent

        If childTriggers.Exists(e.PropertyName) Then
            ' this property is triggered by this child property change.  IOW, we have a change in
            ' this property, so call the event.
            myParent.onPropertyChanged(e.PropertyName)

            If Me.DoListChangedOnPropertyChange Then
                ' And since we need to also raise a listChanged event when this property changes...
                myParent.onInternalListChanged(ListChangedType.ItemChanged, myParent.IndexOf(sender))
            End If

        End If

    End Sub

    Friend Sub onListChanged()

        Dim myParent As BindableCollection = Container.Parent

        If Me.DoPropertyChangeOnListChanged Then

            myParent.onPropertyChanged(Me.name)

        End If

    End Sub

#End Region

End Class