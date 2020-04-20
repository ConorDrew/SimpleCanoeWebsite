Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSiteJobOfWorks

        Public Class ContractAlternativeSiteJobOfWork

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

#Region "ContractAlternativeSiteJobOfWork Properties"


            Private _ContractSiteJobOfWorkID As Integer = 0
            Public ReadOnly Property ContractSiteJobOfWorkID() As Integer
                Get
                    Return _ContractSiteJobOfWorkID
                End Get
            End Property
            Public WriteOnly Property SetContractSiteJobOfWorkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSiteJobOfWorkID", Value)
                End Set
            End Property


            Private _ContractSiteID As Integer = 0
            Public ReadOnly Property ContractSiteID() As Integer
                Get
                    Return _ContractSiteID
                End Get
            End Property
            Public WriteOnly Property SetContractSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSiteID", Value)
                End Set
            End Property


            Private _FirstVisitDate As DateTime = Nothing
            Public Property FirstVisitDate() As DateTime
                Get
                    Return _FirstVisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _FirstVisitDate = Value
                End Set
            End Property

            Private _PricePerVisit As Double = 0.0
            Public ReadOnly Property PricePerVisit() As Double
                Get
                    Return _PricePerVisit
                End Get
            End Property
            Public WriteOnly Property SetPricePerVisit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PricePerVisit", Value)
                End Set
            End Property

            Private _AverageMileage As Double = 0.0
            Public ReadOnly Property AverageMileage() As Double
                Get
                    Return _AverageMileage
                End Get
            End Property
            Public WriteOnly Property SetAverageMileage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AverageMileage", Value)
                End Set
            End Property


            Private _PricePerMile As Double = 0.0
            Public ReadOnly Property PricePerMile() As Double
                Get
                    Return _PricePerMile
                End Get
            End Property
            Public WriteOnly Property SetPricePerMile() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PricePerMile", Value)
                End Set
            End Property


            Private _IncludeMileagePrice As Boolean = False
            Public ReadOnly Property IncludeMileagePrice() As Boolean
                Get
                    Return _IncludeMileagePrice
                End Get
            End Property
            Public WriteOnly Property SetIncludeMileagePrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_IncludeMileagePrice", Value)
                End Set
            End Property


            Private _IncludeRates As Boolean = False
            Public ReadOnly Property IncludeRates() As Boolean
                Get
                    Return _IncludeRates
                End Get
            End Property
            Public WriteOnly Property SetIncludeRates() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_IncludeRates", Value)
                End Set
            End Property


            Private _TotalSitePrice As Double = 0
            Public ReadOnly Property TotalSitePrice() As Double
                Get
                    Return _TotalSitePrice
                End Get
            End Property
            Public WriteOnly Property SetTotalSitePrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TotalSitePrice", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

