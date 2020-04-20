Public Class SimpleBooleanArray

    Friend array() As Boolean

    Public Overridable Sub AddNew(ByVal item As Boolean)

        Dim redimNumber As Integer

        If IsNothing(array) Then
            redimNumber = 0
        Else
            redimNumber = array.GetUpperBound(0) + 1
        End If

        ReDim Preserve array(redimNumber)
        array(redimNumber) = item

    End Sub

    Public ReadOnly Property Exists(ByVal item As Boolean) As Boolean
        Get
            If Not array Is Nothing Then
                If array.IndexOf(array, item) > -1 Then
                    Return True
                Else
                    Return False
                End If
            Else : Return False
            End If
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            If IsNothing(array) Then
                Return 0
            Else
                Return UpperBound + 1
            End If
        End Get
    End Property

    Default Public Overridable ReadOnly Property Item(ByVal index As Boolean) As String
        Get
            If index < 0 Or index > UpperBound Then
                Throw New IndexOutOfRangeException
            Else
                Return array(index)
            End If
        End Get
    End Property

    Private ReadOnly Property UpperBound() As Integer
        Get
            If Not array Is Nothing Then
                Return array.GetUpperBound(0)
            Else
                Return 0
            End If
        End Get
    End Property

End Class

Public Class SimpleObjectArrayByKey
    ' An array of objects.  You can retrieve an item by either index or key
    ' It also automatically expands as you add items.
    Inherits SimpleObjectArray

    Private myKeys As New SimpleStringArray

    Public Overridable Shadows Sub AddNew(ByVal Key As String, ByVal item As Object)

        myKeys.AddNew(Key)
        MyBase.AddNew(item)

    End Sub

    Public Overridable Shadows ReadOnly Property Exists(ByVal key As String) As Boolean
        Get
            Return myKeys.Exists(key)
        End Get
    End Property

    Default Public Overloads ReadOnly Property Item(ByVal key As String) As Object
        Get
            Return MyBase.Item(array.IndexOf(myKeys.array, key))
        End Get
    End Property

End Class

Public Class SimpleObjectArray

    Friend array() As Object

    Public Overridable Sub AddNew(ByVal item As Object)

        Dim redimNumber As Integer

        If IsNothing(array) Then
            redimNumber = 0
        Else
            redimNumber = array.GetUpperBound(0) + 1
        End If

        ReDim Preserve array(redimNumber)
        array(redimNumber) = item

    End Sub

    Public ReadOnly Property Exists(ByVal item As Object) As Boolean
        Get
            If Not array Is Nothing Then
                For x As Integer = 0 To array.Length - 1 Step 1
                    Debug.WriteLine(array(x).ToString)
                Next
                If array.IndexOf(array, item) > -1 Then
                    Return True
                Else
                    Return False
                End If
            Else : Return False
            End If
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            If IsNothing(array) Then
                Return 0
            Else
                Return UpperBound + 1
            End If
        End Get
    End Property

    Default Public Overridable ReadOnly Property Item(ByVal index As Integer) As [Object]
        Get
            If index < 0 Or index > UpperBound Then
                Throw New IndexOutOfRangeException
            Else
                Return array(index)
            End If
        End Get
    End Property

    Private ReadOnly Property UpperBound() As Integer
        Get

            If Not array Is Nothing Then
                Return array.GetUpperBound(0)
            Else
                Return 0
            End If
        End Get
    End Property

End Class

Public Class SimpleStringArray

    Friend array() As String

    Public Overridable Sub AddNew(ByVal item As String)

        Dim redimNumber As Integer

        If IsNothing(array) Then
            redimNumber = 0
        Else
            redimNumber = array.GetUpperBound(0) + 1
        End If

        ReDim Preserve array(redimNumber)
        array(redimNumber) = item

    End Sub

    Public ReadOnly Property Exists(ByVal item As String) As Boolean
        Get
            If Not array Is Nothing Then
                If array.IndexOf(array, item) > -1 Then
                    Return True
                Else
                    Return False
                End If
            Else : Return False
            End If
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            If IsNothing(array) Then
                Return 0
            Else
                Return UpperBound + 1
            End If
        End Get
    End Property

    Default Public Overridable ReadOnly Property Item(ByVal index As Integer) As String
        Get
            If index < 0 Or index > UpperBound Then
                Throw New IndexOutOfRangeException
            Else
                Return array(index)
            End If
        End Get
    End Property

    Private ReadOnly Property UpperBound() As Integer
        Get
            If Not array Is Nothing Then
                Return array.GetUpperBound(0)
            Else
                Return 0
            End If
        End Get
    End Property

End Class

Public Class SimpleStringArrayOld
    Inherits SimpleObjectArray

    Public Overridable Shadows Sub AddNew(ByVal [string] As String)

        MyBase.AddNew([string])

    End Sub

    Default Public Overridable Shadows ReadOnly Property Item(ByVal index As Integer) As String
        Get
            Return MyBase.Item(index)
        End Get
    End Property

End Class