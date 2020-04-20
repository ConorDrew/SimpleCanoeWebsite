Imports System.Data.SqlClient

Namespace Entity


    Namespace EngineerVisitQCs

        Public Class EngineerVisitQC

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

#Region "EngineerVisitQC Properties"


            Private _EngineerVisitQCID As Integer = 0
            Public ReadOnly Property EngineerVisitQCID() As Integer
                Get
                    Return _EngineerVisitQCID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitQCID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitQCID", Value)
                End Set
            End Property


            Private _EngineerVisitID As Integer = 0
            Public ReadOnly Property EngineerVisitID() As Integer
                Get
                    Return _EngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
                End Set
            End Property

            Private _FTFCode As Integer = 0
            Public ReadOnly Property FTFCode() As Integer
                Get
                    Return _FTFCode
                End Get
            End Property
            Public WriteOnly Property SetFTFCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FTFCode", Value)
                End Set
            End Property

            Private _Recall As Integer = 0
            Public ReadOnly Property Recall() As Integer
                Get
                    Return _Recall
                End Get
            End Property
            Public WriteOnly Property SetRecall() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Recall", Value)
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

            Private _JobTypeIncorrect As Integer = 0
            Public ReadOnly Property JobTypeIncorrect() As Integer
                Get
                    Return _JobTypeIncorrect
                End Get
            End Property
            Public WriteOnly Property SetJobTypeIncorrect() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobTypeIncorrect", Value)
                End Set
            End Property

            Private _CustomerDetailsIncorrect As Integer = 0
            Public ReadOnly Property CustomerDetailsIncorrect() As Integer
                Get
                    Return _CustomerDetailsIncorrect
                End Get
            End Property
            Public WriteOnly Property SetCustomerDetailsIncorrect() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerDetailsIncorrect", Value)
                End Set
            End Property

            Private _SorIncorrect As Integer = 0
            Public ReadOnly Property SorIncorrect() As Integer
                Get
                    Return _SorIncorrect
                End Get
            End Property
            Public WriteOnly Property SetSorIncorrect() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SorIncorrect", Value)
                End Set
            End Property

            Private _OrderNumberAttached As Integer = 0
            Public ReadOnly Property OrderNumberAttached() As Integer
                Get
                    Return _OrderNumberAttached
                End Get
            End Property
            Public WriteOnly Property SetOrderNumberAttached() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderNumberAttached", Value)
                End Set
            End Property

            Private _PaymentMethodDetailed As Integer = 0
            Public ReadOnly Property PaymentMethodDetailed() As Integer
                Get
                    Return _PaymentMethodDetailed
                End Get
            End Property
            Public WriteOnly Property SetPaymentMethodDetailed() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentMethodDetailed", Value)
                End Set
            End Property

            Private _LabourTimeMissing As Integer = 0
            Public ReadOnly Property LabourTimeMissing() As Integer
                Get
                    Return _LabourTimeMissing
                End Get
            End Property
            Public WriteOnly Property SetLabourTimeMissing() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LabourTimeMissing", Value)
                End Set
            End Property

            Private _LGSRMissing As Integer = 0
            Public ReadOnly Property LGSRMissing() As Integer
                Get
                    Return _LGSRMissing
                End Get
            End Property
            Public WriteOnly Property SetLGSRMissing() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LGSRMissing", Value)
                End Set
            End Property

            Private _PartsConfirmation As Integer = 0
            Public ReadOnly Property PartsConfirmation() As Integer
                Get
                    Return _PartsConfirmation
                End Get
            End Property
            Public WriteOnly Property SetPartsConfirmation() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsConfirmation", Value)
                End Set
            End Property

            Private _ApplianceRecorded As Integer = 0
            Public ReadOnly Property ApplianceRecorded() As Integer
                Get
                    Return _ApplianceRecorded
                End Get
            End Property
            Public WriteOnly Property SetApplianceRecorded() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApplianceRecorded", Value)
                End Set
            End Property

            Private _JobUploadInTimeScale As Integer = 0
            Public ReadOnly Property JobUploadInTimeScale() As Integer
                Get
                    Return _JobUploadInTimeScale
                End Get
            End Property
            Public WriteOnly Property SetJobUploadInTimeScale() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobUploadInTimeScale", Value)
                End Set
            End Property

            Private _PaymentMethodSelectionIncorrect As Integer = 0
            Public ReadOnly Property PaymentMethodSelectionIncorrect() As Integer
                Get
                    Return _PaymentMethodSelectionIncorrect
                End Get
            End Property
            Public WriteOnly Property SetPaymentMethodSelectionIncorrect() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentMethodSelectionIncorrect", Value)
                End Set
            End Property

            Private _PaymentCollection As Integer = 0
            Public ReadOnly Property PaymentCollection() As Integer
                Get
                    Return _PaymentCollection
                End Get
            End Property
            Public WriteOnly Property SetPaymentCollection() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentCollection", Value)
                End Set
            End Property

            Private _EngineerPaymentReceived As Integer = 0
            Public ReadOnly Property EngineerPaymentReceived() As Integer
                Get
                    Return _EngineerPaymentReceived
                End Get
            End Property
            Public WriteOnly Property SetEngineerPaymentReceived() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerPaymentReceived", Value)
                End Set
            End Property

            Private _CustomerSigned As Integer = 0
            Public ReadOnly Property CustomerSigned() As Integer
                Get
                    Return _CustomerSigned
                End Get
            End Property
            Public WriteOnly Property SetCustomerSigned() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerSigned", Value)
                End Set
            End Property

            Private _PoorJobNotes As String = String.Empty
            Public ReadOnly Property PoorJobNotes() As String
                Get
                    Return _PoorJobNotes
                End Get
            End Property
            Public WriteOnly Property SetPoorJobNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PoorJobNotes", Value)
                End Set
            End Property

            Private _DocumentsRecieved As Boolean = False
            Public ReadOnly Property DocumentsRecieved() As Boolean
                Get
                    Return _DocumentsRecieved
                End Get
            End Property
            Public WriteOnly Property SetDocumentsRecieved() As Boolean
                Set(ByVal Value As Boolean)
                    _DocumentsRecieved = Value
                End Set
            End Property

            Private _DateDocumentsRecieved As DateTime = Nothing
            Public Property DateDocumentsRecieved As DateTime
                Get
                    Return _DateDocumentsRecieved
                End Get
                Set(value As DateTime)
                    _DateDocumentsRecieved = value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

