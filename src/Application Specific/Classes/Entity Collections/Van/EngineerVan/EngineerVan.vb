Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVans

        Public Class EngineerVan

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

#Region "EngineerVan Properties"


            Private _EngineerVanID As Integer = 0
            Public ReadOnly Property EngineerVanID() As Integer
                Get
                    Return _EngineerVanID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVanID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVanID", Value)
                End Set
            End Property


            Private _EngineerID As Integer = 0
            Public ReadOnly Property EngineerID() As Integer
                Get
                    Return _EngineerID
                End Get
            End Property
            Public WriteOnly Property SetEngineerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerID", Value)
                End Set
            End Property


            Private _VanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _VanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VanID", Value)
                End Set
            End Property


            Private _StartDateTime As DateTime = Nothing
            Public Property StartDateTime() As DateTime
                Get
                    Return _StartDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _StartDateTime = Value
                End Set
            End Property


            Private _EndDateTime As DateTime = Nothing
            Public Property EndDateTime() As DateTime
                Get
                    Return _EndDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _EndDateTime = Value
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

