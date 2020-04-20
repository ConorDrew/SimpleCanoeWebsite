Public Class Properties
    Inherits SimpleObjectArrayByKey

#Region " declarations "

    ' native member declarations
    Friend Parent As Object

#End Region

#Region " constructors "

    Friend Sub New(ByVal parent As Object)

        Me.Parent = parent

    End Sub

#End Region

#Region " collection members "

    Public Shadows Function AddNew(ByVal name As String) As [Property]

        Dim newItem As New [Property](Me, name)
        Me.AddNew(newItem)
        Return newItem

    End Function

    Public Shadows Function AddNew(ByVal item As [Property])

        MyBase.AddNew(item.name, item)

    End Function

    Default Public Shadows ReadOnly Property Item(ByVal Index As Integer) As [Property]
        Get
            Return MyBase.Item(Index)
        End Get
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal name As String) As [Property]
        Get
            Return MyBase.Item(name)
        End Get
    End Property

#End Region

End Class

Public Class [Property]

#Region " declarations "

    ' native member declarations
    Protected Friend name As String
    Private _container As Properties

#End Region

#Region " accessors "

    Friend Property Container() As Properties
        Get
            Return _container
        End Get
        Set(ByVal Value As Properties)
            _container = Value
        End Set
    End Property

#End Region

#Region " constructors "

    Friend Sub New(ByVal container As Properties, ByVal name As String)
        ' This keeps us from raising property changed events during
        ' construction of the object
        Me.Container = container
        Me.name = name
    End Sub

#End Region

End Class

Public Class PersistedProperties
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

    Public Shadows Function AddNew(ByVal name As String, ByVal value As Object) As PersistedProperty

        Dim newItem As New PersistedProperty(Me, name, value)
        MyBase.AddNew(newItem)
        Return newItem

    End Function

    Public Shadows Function AddNew(ByVal name As String, ByVal value As Object, ByVal required As Boolean)

        AddNew(name, value)
        Me(name).Required = required

    End Function

    Default Public Shadows ReadOnly Property Item(ByVal Index As Integer) As PersistedProperty
        Get
            Return MyBase.Item(Index)
        End Get
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal name As String) As PersistedProperty
        Get
            Return MyBase.Item(name)
        End Get
    End Property

#End Region

#Region " work methods "

    Friend Sub BeginEdit()

        For x As Integer = 0 To (Count - 1)
            Item(x).BeginEdit()
        Next

    End Sub

    Friend Sub CancelEdit()

        For x As Integer = 0 To (Count - 1)
            Item(x).CancelEdit()
        Next

    End Sub

    Friend ReadOnly Property [Error]() As String
        Get
            Dim s As String
            For x As Integer = 0 To (Count - 1)
                s = Item(x).Error
                If s.Length > 0 Then
                    Exit For
                End If
            Next
            Return s
        End Get
    End Property

#End Region

End Class

Public Class PersistedProperty
    Inherits [Property]

#Region " declarations "

    ' native member declarations
    Private _beingConstructed As Boolean
    Private _oldValue As Object
    Private _value As Object
    Friend Required As Boolean = True

#End Region

#Region " constructors "

    Friend Sub New(ByVal container As PersistedProperties, ByVal name As String, ByVal value As Object)
        MyBase.New(container, name)
        _beingConstructed = True
        Me.Value = value
        _beingConstructed = False
    End Sub

#End Region

#Region " accessors "

    Friend Shadows Property Container() As PersistedProperties
        Get
            Return MyBase.Container
        End Get
        Set(ByVal Value As PersistedProperties)
            MyBase.Container = Value
        End Set
    End Property

#End Region

#Region " properties "

    Friend ReadOnly Property [Error]() As String
        Get
            If Not Required Then Return String.Empty
            If isString Then If CType(Value, String).Length = 0 Then Return name + " required"
            If isNumeric Then If Value = 0 Then Return name + " required"
            If isDate Then If DateTime.Equals(CType(Value, DateTime), DateTime.MinValue) Then Return name + " required"
            If isTimeSpan Then If TimeSpan.Equals(Value, System.TimeSpan.Zero) Then Return name + " required"
            Return String.Empty
        End Get
    End Property

    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal newValue As Object)

            Dim _setValue As Boolean = True
            Dim _isBusinessClass As Boolean = False

            ' Assume the value will change and then
            ' find all those instances when it should NOT be
            ' changed.
            If newValue Is Nothing Then
                ' if the newValue is nothing then of course
                ' leave it alone.  IE, by default values are
                ' non-nullable.
                _setValue = False
            Else
                If isElemental(newValue) Then
                    If isElemental(_value) Then
                        ' classic case of elemental value being changed
                        If _value = newValue Then
                            _setValue = False
                        End If
                    End If
                ElseIf isTimeSpan(newValue) Then
                    If isTimeSpan(_value) Then
                        ' again class case but just must do compare differently with
                        ' this object type.
                        If CType(_value, TimeSpan).CompareTo(newValue) = 0 Then
                            _setValue = False
                        End If
                    End If
                ElseIf isBusinessClass(newValue) Then
                    _isBusinessClass = True
                End If
            End If

            If _setValue Then
                _value = newValue
                ' For child objects, there is no need to raise any
                ' events that may be called in onValueChange()
                If _isBusinessClass Then
                    Dim myChild As BindableCollection
                    Dim myParent As BindableItem
                    myChild = newValue
                    myParent = Container.Parent
                    AddHandler myChild.propertyChanged, AddressOf myParent.onChildPropertyChanged
                Else
                    If Not _beingConstructed Then
                        Container.Parent.onPropertyChanged(name)
                        Container.Parent.onInternalPropertyChanged(name)
                    End If

                End If

            End If

        End Set
    End Property

#End Region

#Region " shared boolean type properties "

    Private Shared ReadOnly Property isBoolean(ByVal myValue As Object) As Boolean
        Get
            If Not isPrimitive(myValue) Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "boolean"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property isBusinessClass(ByVal myValue As Object) As Boolean
        Get
            If myValue Is Nothing Then Return False
            If isElemental(myValue) Then Return False
            If isTimeSpan(myValue) Then Return False
            Return True
        End Get
    End Property

    Private Shared ReadOnly Property isDate(ByVal myValue As Object) As Boolean
        Get
            If myValue Is Nothing Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "datetime"
                    Return True
                Case "date"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property isElemental(ByVal myValue As Object) As Boolean
        Get
            ' Elementals are all primitive, string and date types
            If isPrimitive(myValue) Then Return True
            If isString(myValue) Then Return True
            If isDate(myValue) Then Return True
            Return False
        End Get
    End Property

    Private Shared ReadOnly Property isIntegral(ByVal myValue As Object) As Boolean
        Get
            If Not isPrimitive(myValue) Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "byte", "sbyte", "int16", "uint16", "int32", "uint32", "int64", "uint64"
                    Return True
                Case "byte", "integer", "short", "long"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property isNonIntegral(ByVal myValue As Object) As Boolean
        Get
            If Not isPrimitive(myValue) Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "decimal", "single", "double"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property isNumeric(ByVal myValue As Object) As Boolean
        Get
            If Not isPrimitive(myValue) Then Return False
            If isIntegral(myValue) Then Return True
            If isNonIntegral(myValue) Then Return True
            Return False
        End Get
    End Property

    Private Shared ReadOnly Property isPrimitive(ByVal myValue As Object) As Boolean
        Get
            If myValue Is Nothing Then Return False
            If myValue.GetType.IsPrimitive Then Return True
            Return False
        End Get
    End Property

    Private Shared ReadOnly Property isString(ByVal myValue As Object) As Boolean
        Get
            If myValue Is Nothing Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "string", "char"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

    Private Shared ReadOnly Property isTimeSpan(ByVal myValue As Object) As Boolean
        Get
            If myValue Is Nothing Then Return False
            Select Case myValue.GetType.Name.ToLower
                Case "timespan"
                    Return True
                Case Else
                    Return False
            End Select
        End Get
    End Property

#End Region

#Region " boolean type properties "

    Private ReadOnly Property isBoolean() As Boolean
        Get
            Return isBoolean(Value)
        End Get
    End Property

    Private ReadOnly Property isBusinessClass() As Boolean
        Get
            Return isBusinessClass(Value)
        End Get
    End Property

    Private ReadOnly Property isDate() As Boolean
        Get
            Return isDate(Value)
        End Get
    End Property

    Private ReadOnly Property isElemental() As Boolean
        Get
            Return isElemental(Value)
        End Get
    End Property

    Private ReadOnly Property isIntegral() As Boolean
        Get
            Return isIntegral(Value)
        End Get
    End Property

    Private ReadOnly Property isNonIntegral() As Boolean
        Get
            Return isNonIntegral(Value)
        End Get
    End Property

    Private ReadOnly Property isNumeric() As Boolean
        Get
            Return isNumeric(Value)
        End Get
    End Property

    Private ReadOnly Property isPrimitive() As Boolean
        Get
            Return isPrimitive(Value)
        End Get
    End Property

    Private ReadOnly Property isString() As Boolean
        Get
            Return isString(Value)
        End Get
    End Property

    Private ReadOnly Property isTimeSpan() As Boolean
        Get
            Return isTimeSpan(Value)
        End Get
    End Property

#End Region

#Region " work methods "

    Friend Sub BeginEdit()
        _oldValue = _value
    End Sub

    Friend Sub CancelEdit()
        ' by using the accessor, then other pertinant events will be called
        Value = _oldValue
    End Sub

#End Region

End Class