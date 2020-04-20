Imports System.Data.SqlClient

Namespace Entity

    Namespace StandardSentences

        Public Class StandardSentence

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

            Public ReadOnly Property DTValidator() As DataTypeValidator
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

#Region "Standard Sentence Properties"

            Private _SentenceID As Integer = 0
            Public ReadOnly Property SentenceID() As Integer
                Get
                    Return _SentenceID
                End Get
            End Property
            Public WriteOnly Property SetSentenceID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SentenceID", Value)
                End Set
            End Property


            Private _Sentence As String = String.Empty
            Public ReadOnly Property Sentence() As String
                Get
                    Return _Sentence
                End Get
            End Property
            Public WriteOnly Property SetSentence() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Sentence", Value)
                End Set
            End Property

            Private _LastChanged As DateTime = Nothing
            Public Property LastChanged() As DateTime
                Get
                    Return _LastChanged
                End Get
                Set(ByVal Value As DateTime)
                    _LastChanged = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

