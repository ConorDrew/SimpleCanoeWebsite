Imports System.Data.SqlClient

Namespace Entity

    Namespace UserLevels

        Public Class UserLevel

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

#Region "UserLevel Properties"

            Private _UserLevelID As Integer = 0

            Public ReadOnly Property UserLevelID() As Integer
                Get
                    Return _UserLevelID
                End Get
            End Property

            Public WriteOnly Property SetUserLevelID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserLevelID", Value)
                End Set
            End Property

            Private _LevelID As Integer = 0

            Public ReadOnly Property LevelID() As Integer
                Get
                    Return _LevelID
                End Get
            End Property

            Public WriteOnly Property SetLevelID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LevelID", Value)
                End Set
            End Property

            Private _UserID As Integer = 0

            Public ReadOnly Property UserID() As Integer
                Get
                    Return _UserID
                End Get
            End Property

            Public WriteOnly Property SetUserID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserID", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace