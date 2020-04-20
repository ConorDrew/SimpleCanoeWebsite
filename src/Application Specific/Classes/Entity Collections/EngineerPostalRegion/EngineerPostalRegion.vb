Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerPostalRegions

        Public Class EngineerPostalRegion

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

#Region "EngineerPostalRegion Properties"


            Private _EngineerPostalRegionID As Integer = 0
            Public ReadOnly Property EngineerPostalRegionID() As Integer
                Get
                    Return _EngineerPostalRegionID
                End Get
            End Property
            Public WriteOnly Property SetEngineerPostalRegionID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerPostalRegionID", Value)
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

            Private _PostalRegionID As Integer = 0
            Public ReadOnly Property PostalRegionID() As Integer
                Get
                    Return _PostalRegionID
                End Get
            End Property
            Public WriteOnly Property SetPostalRegionID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PostalRegionID", Value)
                End Set
            End Property






#End Region

        End Class

    End Namespace

End Namespace

