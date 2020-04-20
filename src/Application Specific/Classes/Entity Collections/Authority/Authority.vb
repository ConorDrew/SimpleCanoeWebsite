Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Entity

    Namespace Authority

        Public Class Authority

            Private _dataTypeValidator As DataTypeValidator
            Public Sub New()
                _dataTypeValidator = New DataTypeValidator
            End Sub

#Region "Class Properties"

            Public Property IgnoreExceptionsOnSetMethods() As Boolean
                Get
                    Return Me._dataTypeValidator.IgnoreExceptionsOnSetMethods
                End Get
                Set(ByVal Value As Boolean)
                    Me._dataTypeValidator.IgnoreExceptionsOnSetMethods = Value
                End Set
            End Property

            Public ReadOnly Property Errors() As Hashtable
                Get
                    Return _dataTypeValidator.Errors
                End Get
            End Property

            Public ReadOnly Property DTValIdator() As DataTypeValidator
                Get
                    Return _dataTypeValidator
                End Get
            End Property

            Private _exists As Boolean = False
            Public Property Exists() As Boolean
                Get
                    Return _exists
                End Get
                Set(ByVal Value As Boolean)
                    _exists = Value
                End Set
            End Property

            Private _deleted As Boolean = False
            Public ReadOnly Property Deleted() As Boolean
                Get
                    Return _deleted
                End Get
            End Property
            Public WriteOnly Property SetDeleted() As Boolean
                Set(ByVal Value As Boolean)
                    _deleted = Value
                End Set
            End Property

#End Region

#Region "Property Properties"

            Private _authorityId As Integer = 0
            Public ReadOnly Property AuthorityId() As Integer
                Get
                    Return _authorityId
                End Get
            End Property
            Public WriteOnly Property SetAuthorityId() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_authorityId", Value)
                End Set
            End Property

            Private _notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_notes", Value)
                End Set
            End Property

            Private _dateAdded As DateTime = Nothing
            Public Property DateAdded() As DateTime
                Get
                    Return _dateAdded
                End Get
                Set(ByVal Value As DateTime)
                    _dateAdded = Value
                End Set
            End Property

            Private _addedById As Integer = 0
            Public ReadOnly Property AddedById() As Integer
                Get
                    Return _addedById
                End Get
            End Property
            Public WriteOnly Property SetAddedById() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_addedById", Value)
                End Set
            End Property

            Private _lastChanged As DateTime = Nothing
            Public Property LastChanged() As DateTime
                Get
                    Return _lastChanged
                End Get
                Set(ByVal Value As DateTime)
                    _lastChanged = Value
                End Set
            End Property

            Private _lastChangedById As Integer = 0
            Public ReadOnly Property LastChangedById() As Integer
                Get
                    Return _lastChangedById
                End Get
            End Property
            Public WriteOnly Property SetLastChangedById() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_lastChangedById", Value)
                End Set
            End Property

            Public Function GetChanges(ByVal oldAuthority As Authority) As String
                Dim changes As String = String.Empty
                Try
                    Dim oType As Type = oldAuthority.GetType()

                    For Each oProperty As PropertyInfo In oType.GetProperties()
                        Dim oOldValue As Object = oProperty.GetValue(oldAuthority)
                        Dim oNewValue As Object = oProperty.GetValue(Me)
                        If Not Object.Equals(oOldValue, oNewValue) Then
                            Dim sOldValue As String = If(oOldValue Is Nothing, "null", oOldValue.ToString())
                            Dim sNewValue As String = If(oNewValue Is Nothing, "null", oNewValue.ToString())
                            changes += "Property " & oProperty.Name & " was: " & sOldValue & "; is: " & sNewValue
                        End If
                    Next
                Catch ex As Exception
                    changes += ex.Message
                End Try

                Return changes
            End Function

#End Region

        End Class

    End Namespace

End Namespace

