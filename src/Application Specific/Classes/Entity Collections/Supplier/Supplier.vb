Imports System.Data.SqlClient

Namespace Entity

    Namespace Suppliers

        Public Class Supplier

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

            Private _SecondaryPrice As Boolean
            Public Property SecondaryPrice As Boolean
                Get
                    Return _SecondaryPrice
                End Get
                Set(value As Boolean)
                    _SecondaryPrice = value
                End Set
            End Property






#End Region

#Region "Supplier Properties"


            Private _SupplierID As Integer = 0
            Public ReadOnly Property SupplierID() As Integer
                Get
                    Return _SupplierID
                End Get
            End Property
            Public WriteOnly Property SetSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SupplierID", Value)
                End Set
            End Property

            Private _AccountNumber As String = String.Empty
            Public ReadOnly Property AccountNumber() As String
                Get
                    Return _AccountNumber
                End Get
            End Property
            Public WriteOnly Property SetAccountNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AccountNumber", Value)
                End Set
            End Property

            Private _secondAccountNumber As String = String.Empty
            Public ReadOnly Property SecondAccountNumber() As String
                Get
                    Return _secondAccountNumber
                End Get
            End Property
            Public WriteOnly Property SetSecondAccountNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_secondAccountNumber", Value)
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


            Private _Address1 As String = String.Empty
            Public ReadOnly Property Address1() As String
                Get
                    Return _Address1
                End Get
            End Property
            Public WriteOnly Property SetAddress1() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address1", Value)
                End Set
            End Property


            Private _Address2 As String = String.Empty
            Public ReadOnly Property Address2() As String
                Get
                    Return _Address2
                End Get
            End Property
            Public WriteOnly Property SetAddress2() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address2", Value)
                End Set
            End Property


            Private _Address3 As String = String.Empty
            Public ReadOnly Property Address3() As String
                Get
                    Return _Address3
                End Get
            End Property
            Public WriteOnly Property SetAddress3() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address3", Value)
                End Set
            End Property


            Private _Address4 As String = String.Empty
            Public ReadOnly Property Address4() As String
                Get
                    Return _Address4
                End Get
            End Property
            Public WriteOnly Property SetAddress4() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address4", Value)
                End Set
            End Property


            Private _Address5 As String = String.Empty
            Public ReadOnly Property Address5() As String
                Get
                    Return _Address5
                End Get
            End Property
            Public WriteOnly Property SetAddress5() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address5", Value)
                End Set
            End Property


            Private _Postcode As String = String.Empty
            Public ReadOnly Property Postcode() As String
                Get
                    Return _Postcode
                End Get
            End Property
            Public WriteOnly Property SetPostcode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Postcode", Value)
                End Set
            End Property


            Private _TelephoneNum As String = String.Empty
            Public ReadOnly Property TelephoneNum() As String
                Get
                    Return _TelephoneNum
                End Get
            End Property
            Public WriteOnly Property SetTelephoneNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TelephoneNum", Value)
                End Set
            End Property


            Private _FaxNum As String = String.Empty
            Public ReadOnly Property FaxNum() As String
                Get
                    Return _FaxNum
                End Get
            End Property
            Public WriteOnly Property SetFaxNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FaxNum", Value)
                End Set
            End Property


            Private _EmailAddress As String = String.Empty
            Public ReadOnly Property EmailAddress() As String
                Get
                    Return _EmailAddress
                End Get
            End Property
            Public WriteOnly Property SetEmailAddress() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmailAddress", Value)
                End Set
            End Property


            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property


            Private _FilePath As String = String.Empty
            Public ReadOnly Property FilePath() As String
                Get
                    Return _FilePath
                End Get
            End Property
            Public WriteOnly Property SetFilePath() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FilePath", Value)
                End Set
            End Property


            Private _GaswayAccount As String = String.Empty
            Public ReadOnly Property GaswayAccount() As String
                Get
                    Return _GaswayAccount
                End Get
            End Property
            Public WriteOnly Property SetGaswayAccount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GaswayAccount", Value)
                End Set
            End Property

            Private _MasterSupplierID As Integer = 0
            Public ReadOnly Property MasterSupplierID() As String
                Get
                    Return _MasterSupplierID
                End Get
            End Property
            Public WriteOnly Property SetMasterSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MasterSupplierID", Value)
                End Set
            End Property

            Private _ReleaseToTablets As Boolean = False
            Public ReadOnly Property ReleaseToTablets() As String
                Get
                    Return _ReleaseToTablets
                End Get
            End Property
            Public WriteOnly Property SetReleaseToTablets() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReleaseToTablets", Value)
                End Set
            End Property

            Private _SubContractor As Boolean = False
            Public ReadOnly Property SubContractor() As Boolean
                Get
                    Return _SubContractor
                End Get
            End Property
            Public WriteOnly Property SetSubContractor() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubContractor", Value)
                End Set
            End Property

            Private _DefaultNominal As String = String.Empty
            Public ReadOnly Property DefaultNominal() As String
                Get
                    Return _DefaultNominal
                End Get
            End Property
            Public WriteOnly Property SetDefaultNominal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DefaultNominal", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

