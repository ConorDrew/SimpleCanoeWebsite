Imports System.Data.SqlClient

Namespace Entity

    Namespace Vans

        Public Class Van

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

#Region "Van Properties"

            Private _VanID As Integer = 0

            Public ReadOnly Property VanID() As Integer
                Get
                    Return _VanID
                End Get
            End Property

            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VanID", Value)
                End Set
            End Property

            Private _Registration As String = String.Empty

            Public ReadOnly Property Registration() As String
                Get
                    Return _Registration
                End Get
            End Property

            Public WriteOnly Property SetRegistration() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Registration", Value)
                End Set
            End Property

            Private _Notes As String = String.Empty

            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property

            Public WriteOnly Property SetNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property

            Private _InsuranceDue As DateTime = Nothing

            Public Property InsuranceDue() As DateTime
                Get
                    Return _InsuranceDue
                End Get
                Set(ByVal Value As DateTime)
                    _InsuranceDue = Value
                End Set
            End Property

            Private _MOTDue As DateTime = Nothing

            Public Property MOTDue() As DateTime
                Get
                    Return _MOTDue
                End Get
                Set(ByVal Value As DateTime)
                    _MOTDue = Value
                End Set
            End Property

            Private _TaxDue As DateTime = Nothing

            Public Property TaxDue() As DateTime
                Get
                    Return _TaxDue
                End Get
                Set(ByVal Value As DateTime)
                    _TaxDue = Value
                End Set
            End Property

            Private _ServiceDue As DateTime = Nothing

            Public Property ServiceDue() As DateTime
                Get
                    Return _ServiceDue
                End Get
                Set(ByVal Value As DateTime)
                    _ServiceDue = Value
                End Set
            End Property

            Private _SecondaryPrice As Boolean

            Public Property SecondaryPrice As Boolean
                Get
                    Return _SecondaryPrice
                End Get
                Set(value As Boolean)
                    _SecondaryPrice = value
                End Set
            End Property

            Private _EngineerVanID As Integer

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

            Private _MileageLimit As Double = 0.0

            Public ReadOnly Property MileageLimit() As Double
                Get
                    Return _MileageLimit
                End Get
            End Property

            Public WriteOnly Property SetMileageLimit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MileageLimit", Value)
                End Set
            End Property

            Private _PeriodValue As Integer = 0

            Public ReadOnly Property PeriodValue() As Integer
                Get
                    Return _PeriodValue
                End Get
            End Property

            Public WriteOnly Property SetPeriodValue() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PeriodValue", Value)
                End Set
            End Property

            Private _PeriodType As Integer = 0

            Public ReadOnly Property PeriodType() As Integer
                Get
                    Return _PeriodType
                End Get
            End Property

            Public WriteOnly Property SetPeriodType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PeriodType", Value)
                End Set
            End Property

            Private _PreferredSupplierID As Integer = 0

            Public ReadOnly Property PreferredSupplierID() As Integer
                Get
                    Return _PreferredSupplierID
                End Get
            End Property

            Public WriteOnly Property SetPreferredSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PreferredSupplierID", Value)
                End Set
            End Property

            Private _UseContainerStock As Boolean = False

            Public ReadOnly Property UseContainerStock() As Boolean
                Get
                    Return _UseContainerStock
                End Get
            End Property

            Public WriteOnly Property SetUseContainerStock() As Boolean
                Set(ByVal Value As Boolean)
                    _UseContainerStock = Value
                End Set
            End Property

            Private _ExcludeFromAutoReplenishment As Boolean = False

            Public ReadOnly Property ExcludeFromAutoReplenishment() As Boolean
                Get
                    Return _ExcludeFromAutoReplenishment
                End Get
            End Property

            Public WriteOnly Property SetExcludeFromAutoReplenishment() As Boolean
                Set(ByVal Value As Boolean)
                    _ExcludeFromAutoReplenishment = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace