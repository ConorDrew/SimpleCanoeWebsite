Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalVisits

        Public Class ContractOriginalVisit

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

#End Region

#Region "ContractVisit Properties"


            Private _ContractVisitID As Integer = 0
            Public ReadOnly Property ContractVisitID() As Integer
                Get
                    Return _ContractVisitID
                End Get
            End Property
            Public WriteOnly Property SetContractVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractVisitID", Value)
                End Set
            End Property


            Private _SubContractor As String = 0
            Public ReadOnly Property SubContractor() As String
                Get
                    Return _SubContractor
                End Get
            End Property
            Public WriteOnly Property SetSubContractor() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubContractor", Value)
                End Set
            End Property

            Private _PreferredEngineer As String = ""
            Public ReadOnly Property PreferredEngineer() As String
                Get
                    Return _PreferredEngineer
                End Get
            End Property
            Public WriteOnly Property SetPreferredEngineer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PreferredEngineer", Value)
                End Set
            End Property

            Private _VisitType As String = ""
            Public ReadOnly Property VisitType() As String
                Get
                    Return _VisitType
                End Get
            End Property
            Public WriteOnly Property SetVisitType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitType", Value)
                End Set
            End Property

            Private _Frequency As String = ""
            Public ReadOnly Property Frequency() As String
                Get
                    Return _Frequency
                End Get
            End Property
            Public WriteOnly Property SetFrequency() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Frequency", Value)
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


            Private _EstimatedVisitDate As DateTime = Nothing
            Public Property EstimatedVisitDate() As DateTime
                Get
                    Return _EstimatedVisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _EstimatedVisitDate = Value
                End Set
            End Property


            Private _JobID As Integer = 0
            Public ReadOnly Property JobID() As Integer
                Get
                    Return _JobID
                End Get
            End Property
            Public WriteOnly Property SetJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobID", Value)
                End Set
            End Property

            Private _SubContractorID As Integer = 0
            Public ReadOnly Property SubContractorID() As Integer
                Get
                    Return _SubContractorID
                End Get
            End Property
            Public WriteOnly Property SetSubContractorID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubContractorID", Value)
                End Set
            End Property

            Private _PreferredEngineerID As Integer = 0
            Public ReadOnly Property PreferredEngineerID() As Integer
                Get
                    Return _PreferredEngineerID
                End Get
            End Property
            Public WriteOnly Property SetPreferredEngineerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PreferredEngineerID", Value)
                End Set
            End Property

            Private _Cost As Double = 0
            Public ReadOnly Property Cost() As Double
                Get
                    Return _Cost
                End Get
            End Property
            Public WriteOnly Property SetCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Cost", Value)
                End Set
            End Property

            Private _FrequencyID As Integer = 0
            Public ReadOnly Property FrequencyID() As Integer
                Get
                    Return _FrequencyID
                End Get
            End Property
            Public WriteOnly Property SetFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FrequencyID", Value)
                End Set
            End Property

            Private _VisitTypeID As Integer = 0
            Public ReadOnly Property VisitTypeID() As Integer
                Get
                    Return _VisitTypeID
                End Get
            End Property
            Public WriteOnly Property SetVisitTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitType", Value)
                End Set
            End Property

            Private _HoursReq As Integer = 0
            Public ReadOnly Property HoursReq() As Integer
                Get
                    Return _HoursReq
                End Get
            End Property
            Public WriteOnly Property SetHoursReq() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HoursReq", Value)
                End Set
            End Property

            Private _AdditionalNotes As String = ""
            Public ReadOnly Property AdditionalNotes() As String
                Get
                    Return _AdditionalNotes
                End Get
            End Property
            Public WriteOnly Property SetAdditionalNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AdditionalNotes", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

