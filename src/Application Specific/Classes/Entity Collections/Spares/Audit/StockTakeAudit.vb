
Namespace Entity
    Public Class StockTakeAudit
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
#Region "StockTake Audit Properties"
        Private _stockTakeAuditID As Integer = 0
        Public ReadOnly Property StockTakeAuditID() As Integer
            Get
                Return _stockTakeAuditID
            End Get
        End Property
        Public WriteOnly Property SetStockTakeAuditID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_stockTakeAuditID", Value)
            End Set
        End Property

        Private _partID As Integer = 0
        Public ReadOnly Property PartID() As Integer
            Get
                Return _partID
            End Get
        End Property
        Public WriteOnly Property SetPartID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_partID", Value)
            End Set
        End Property

        Private _originalAmount As Integer = 0
        Public ReadOnly Property OriginalAmount() As Integer
            Get
                Return _originalAmount
            End Get
        End Property
        Public WriteOnly Property SetOriginalAmount() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_originalAmount", Value)
            End Set
        End Property

        Private _newAmount As Integer = 0
        Public ReadOnly Property NewAmount() As Integer
            Get
                Return _newAmount
            End Get
        End Property
        Public WriteOnly Property SetNewAmount() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_newAmount", Value)
            End Set
        End Property

        Private _reasonChangeID As Integer = 0
        Public ReadOnly Property ReasonChange() As Integer
            Get
                Return _reasonChangeID
            End Get
        End Property
        Public WriteOnly Property SetReasonChange() As Integer
            Set(ByVal Value As Integer)
                _dataTypeValidator.SetValue(Me, "_reasonChangeID", Value)
            End Set
        End Property

        Private _locationID As Integer = 0
        Public ReadOnly Property LocationID() As Integer
            Get
                Return _locationID
            End Get
        End Property
        Public WriteOnly Property SetLocationID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_locationID", Value)
            End Set
        End Property

        Private _userID As Integer = 0
        Public ReadOnly Property UserID() As Integer
            Get
                Return _userID
            End Get
        End Property
        Public WriteOnly Property SetUserID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_userID", Value)
            End Set
        End Property

#End Region
    End Class
End Namespace


