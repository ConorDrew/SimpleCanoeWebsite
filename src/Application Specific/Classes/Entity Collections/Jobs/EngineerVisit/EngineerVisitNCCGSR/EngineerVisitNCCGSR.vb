Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerVisitNCCGSRs

Public Class EngineerVisitNCCGSR

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

#Region "EngineerVisitNCCGSR Properties"


            Private _EngineerVisitNCCGSRID As Integer = 0
            Public ReadOnly Property EngineerVisitNCCGSRID() As Integer
                Get
                    Return _EngineerVisitNCCGSRID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitNCCGSRID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitNCCGSRID", Value)
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


            Private _CorrectMaterialsUsedID As Integer = 0
            Public ReadOnly Property CorrectMaterialsUsedID() As Integer
                Get
                    Return _CorrectMaterialsUsedID
                End Get
            End Property
            Public WriteOnly Property SetCorrectMaterialsUsedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CorrectMaterialsUsedID", Value)
                End Set
            End Property


            Private _InstallationPipeWorkCorrectID As Integer = 0
            Public ReadOnly Property InstallationPipeWorkCorrectID() As Integer
                Get
                    Return _InstallationPipeWorkCorrectID
                End Get
            End Property
            Public WriteOnly Property SetInstallationPipeWorkCorrectID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InstallationPipeWorkCorrectID", Value)
                End Set
            End Property


            Private _InstallationSafeToUseID As Integer = 0
            Public ReadOnly Property InstallationSafeToUseID() As Integer
                Get
                    Return _InstallationSafeToUseID
                End Get
            End Property
            Public WriteOnly Property SetInstallationSafeToUseID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InstallationSafeToUseID", Value)
                End Set
            End Property


            Private _StrainerFittedID As Integer = 0
            Public ReadOnly Property StrainerFittedID() As Integer
                Get
                    Return _StrainerFittedID
                End Get
            End Property
            Public WriteOnly Property SetStrainerFittedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_StrainerFittedID", Value)
                End Set
            End Property


            Private _StrainerInspectedID As Integer = 0
            Public ReadOnly Property StrainerInspectedID() As Integer
                Get
                    Return _StrainerInspectedID
                End Get
            End Property
            Public WriteOnly Property SetStrainerInspectedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_StrainerInspectedID", Value)
                End Set
            End Property


            Private _HeatingSystemTypeID As Integer = 0
            Public ReadOnly Property HeatingSystemTypeID() As Integer
                Get
                    Return _HeatingSystemTypeID
                End Get
            End Property
            Public WriteOnly Property SetHeatingSystemTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HeatingSystemTypeID", Value)
                End Set
            End Property


            Private _PartialHeatingID As Integer = 0
            Public ReadOnly Property PartialHeatingID() As Integer
                Get
                    Return _PartialHeatingID
                End Get
            End Property
            Public WriteOnly Property SetPartialHeatingID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartialHeatingID", Value)
                End Set
            End Property


            Private _CylinderTypeID As Integer = 0
            Public ReadOnly Property CylinderTypeID() As Integer
                Get
                    Return _CylinderTypeID
                End Get
            End Property
            Public WriteOnly Property SetCylinderTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CylinderTypeID", Value)
                End Set
            End Property


            Private _JacketID As Integer = 0
            Public ReadOnly Property JacketID() As Integer
                Get
                    Return _JacketID
                End Get
            End Property
            Public WriteOnly Property SetJacketID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JacketID", Value)
                End Set
            End Property


            Private _ImmersionID As Integer = 0
            Public ReadOnly Property ImmersionID() As Integer
                Get
                    Return _ImmersionID
                End Get
            End Property
            Public WriteOnly Property SetImmersionID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ImmersionID", Value)
                End Set
            End Property


            Private _Radiators As Integer = 0
            Public ReadOnly Property Radiators() As Integer
                Get
                    Return _Radiators
                End Get
            End Property
            Public WriteOnly Property SetRadiators() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Radiators", Value)
                End Set
            End Property


            Private _CODetectorFittedID As Integer = 0
            Public ReadOnly Property CODetectorFittedID() As Integer
                Get
                    Return _CODetectorFittedID
                End Get
            End Property
            Public WriteOnly Property SetCODetectorFittedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CODetectorFittedID", Value)
                End Set
            End Property


            Private _ApproxAgeOfBoiler As Integer = 0
            Public ReadOnly Property ApproxAgeOfBoiler() As Integer
                Get
                    Return _ApproxAgeOfBoiler
                End Get
            End Property
            Public WriteOnly Property SetApproxAgeOfBoiler() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApproxAgeOfBoiler", Value)
                End Set
            End Property


            Private _CertificateTypeID As Integer = 0
            Public ReadOnly Property CertificateTypeID() As Integer
                Get
                    Return _CertificateTypeID
                End Get
            End Property
            Public WriteOnly Property SetCertificateTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CertificateTypeID", Value)
                End Set
            End Property


            Private _VisualInspectionSatisfactoryID As Integer = 0
            Public ReadOnly Property VisualInspectionSatisfactoryID() As Integer
                Get
                    Return _VisualInspectionSatisfactoryID
                End Get
            End Property
            Public WriteOnly Property SetVisualInspectionSatisfactoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisualInspectionSatisfactoryID", Value)
                End Set
            End Property



            Private _SITimerID As Integer = 0
            Public ReadOnly Property SITimerID() As Integer
                Get
                    Return _SITimerID
                End Get
            End Property
            Public WriteOnly Property SetSITimerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SITimerID", Value)
                End Set
            End Property

            Private _FillDiscID As Integer = 0
            Public ReadOnly Property FillDiscID() As Integer
                Get
                    Return _FillDiscID
                End Get
            End Property
            Public WriteOnly Property SetFillDiscID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FillDiscID", Value)
                End Set
            End Property













            Private _VisualInspectionReason As String = String.Empty
            Public ReadOnly Property VisualInspectionReason() As String
                Get
                    Return _VisualInspectionReason
                End Get
            End Property
            Public WriteOnly Property SetVisualInspectionReason() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisualInspectionReason", Value)
                End Set
            End Property



#End Region

End Class

End Namespace

End Namespace

