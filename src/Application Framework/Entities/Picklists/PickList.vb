Namespace Entity

    Namespace PickLists

        Public Class PickList

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

#Region "PickList Properties"

            Private _ManagerID As Integer = 0
            Public ReadOnly Property ManagerID() As Integer
                Get
                    Return _ManagerID
                End Get
            End Property
            Public WriteOnly Property SetManagerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ManagerID", Value)
                End Set
            End Property

            Private _EnumTypeID As Integer = 0
            Public ReadOnly Property EnumTypeID() As Integer
                Get
                    Return _EnumTypeID
                End Get
            End Property
            Public WriteOnly Property SetEnumTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EnumTypeID", Value)
                End Set
            End Property

            Private _Name As String = String.Empty
            Public ReadOnly Property Name() As String
                Get
                    Return _Name
                End Get
            End Property
            Public WriteOnly Property SetName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Name", Value)
                End Set
            End Property

            Private _Description As String = String.Empty
            Public ReadOnly Property Description() As String
                Get
                    Return _Description
                End Get
            End Property
            Public WriteOnly Property SetDescription() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Description", Value)
                End Set
            End Property

            Private _PercentageRate As Double = 0.0
            Public ReadOnly Property PercentageRate() As Double
                Get
                    Return _PercentageRate
                End Get
            End Property
            Public WriteOnly Property SetPercentageRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PercentageRate", Value)
                End Set
            End Property

            Private _Mandatory As Boolean = False
            Public ReadOnly Property Mandatory() As Boolean
                Get
                    Return _Mandatory
                End Get
            End Property
            Public WriteOnly Property SetMandatory() As Boolean
                Set(ByVal Value As Boolean)
                    _Mandatory = Value
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace