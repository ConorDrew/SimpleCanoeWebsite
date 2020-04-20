Namespace Entity.Skills
    Public Class Skill
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

#End Region
    End Class

    Public Class SkillType
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

#Region "Skill Type Properties"
        Private _skillTypeId As Integer = 0
        Public ReadOnly Property SkillTypeID() As Integer
            Get
                Return _skillTypeId
            End Get
        End Property
        Public WriteOnly Property SetSkillTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_skillTypeId", Value)
            End Set
        End Property

        Private _name As String = String.Empty
        Public ReadOnly Property Name() As String
            Get
                Return _name
            End Get
        End Property
        Public WriteOnly Property SetName() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_name", Value)
            End Set
        End Property
#End Region
    End Class
End Namespace
