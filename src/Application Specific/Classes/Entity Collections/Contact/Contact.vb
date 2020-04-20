Imports System.Data.SqlClient

Namespace Entity

    Namespace Contacts

        Public Class Contact

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

#Region "Contact Properties"

            Private _ContactID As Integer = 0

            Public ReadOnly Property ContactID() As Integer
                Get
                    Return _ContactID
                End Get
            End Property

            Public WriteOnly Property SetContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContactID", Value)
                End Set
            End Property

            Private _Salutation As String = String.Empty

            Public ReadOnly Property Salutation() As String
                Get
                    Return _Salutation
                End Get
            End Property

            Public WriteOnly Property SetSalutation() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Salutation", Value)
                End Set
            End Property

            Private _FirstName As String = String.Empty

            Public ReadOnly Property FirstName() As String
                Get
                    Return _FirstName
                End Get
            End Property

            Public WriteOnly Property SetFirstName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FirstName", Value)
                End Set
            End Property

            Private _Surname As String = String.Empty

            Public ReadOnly Property Surname() As String
                Get
                    Return _Surname
                End Get
            End Property

            Public WriteOnly Property SetSurname() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Surname", Value)
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

            Private _MobileNo As String = String.Empty

            Public ReadOnly Property MobileNo() As String
                Get
                    Return _MobileNo
                End Get
            End Property

            Public WriteOnly Property SetMobileNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MobileNo", Value)
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

            Private _PropertyID As Integer = 0

            Public ReadOnly Property PropertyID() As Integer
                Get
                    Return _PropertyID
                End Get
            End Property

            Public WriteOnly Property SetPropertyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyID", Value)
                End Set
            End Property

            Private _LinkID As Integer = 0

            Public ReadOnly Property LinkID() As Integer
                Get
                    Return _LinkID
                End Get
            End Property

            Public WriteOnly Property SetLinkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LinkID", Value)
                End Set
            End Property

            Private _LinkRef As Integer = 0

            Public ReadOnly Property LinkRef() As Integer
                Get
                    Return _LinkRef
                End Get
            End Property

            Public WriteOnly Property SetLinkRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LinkRef", Value)
                End Set
            End Property

            Private _NoMarketing As Boolean = False

            Public ReadOnly Property NoMarketing() As Boolean
                Get
                    Return _NoMarketing
                End Get
            End Property

            Public WriteOnly Property SetNoMarketing() As Boolean
                Set(ByVal Value As Boolean)
                    _NoMarketing = Value
                End Set
            End Property

            Private _PortalUserName As String = String.Empty

            Public ReadOnly Property PortalUserName() As String
                Get
                    Return _PortalUserName
                End Get
            End Property

            Public WriteOnly Property SetPortalUserName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PortalUserName", Value)
                End Set
            End Property

            Private _PortalPassword As String = String.Empty

            Public ReadOnly Property PortalPassword() As String
                Get
                    Return _PortalPassword
                End Get
            End Property

            Public WriteOnly Property SetPortalPassword() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PortalPassword", Value)
                End Set
            End Property

            Private _PortalGSRPrint As Boolean = False

            Public ReadOnly Property PortalGSRPrint() As Boolean
                Get
                    Return _PortalGSRPrint
                End Get
            End Property

            Public WriteOnly Property SetPortalGSRPrint() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PortalGSRPrint", Value)
                End Set
            End Property

            Private _EID As Integer = 0

            Public ReadOnly Property EID() As Integer
                Get
                    Return _EID
                End Get
            End Property

            Public WriteOnly Property SetEID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EID", Value)
                End Set
            End Property

            Private _onContract As Boolean = False

            Public ReadOnly Property OnContract() As Boolean
                Get
                    Return _onContract
                End Get
            End Property

            Public WriteOnly Property SetOnContract() As Boolean
                Set(ByVal Value As Boolean)
                    _onContract = Value
                End Set
            End Property

            Private _pointOfContact As Boolean = False

            Public ReadOnly Property PointOfContact() As Boolean
                Get
                    Return _pointOfContact
                End Get
            End Property

            Public WriteOnly Property SetPointOfContact() As Boolean
                Set(value As Boolean)
                    _pointOfContact = value
                End Set
            End Property

            Private _relationshipID As Integer

            Public ReadOnly Property RelationshipID() As Integer
                Get
                    Return _relationshipID
                End Get
            End Property

            Public WriteOnly Property SetRelationshipID() As Integer
                Set(value As Integer)
                    _relationshipID = value
                End Set
            End Property

            Private _relationship As String

            Public ReadOnly Property Relationship() As Integer
                Get
                    Return _relationship
                End Get
            End Property

            Public WriteOnly Property SetRelationship() As Integer
                Set(value As Integer)
                    _relationship = value
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

#End Region

        End Class

    End Namespace

End Namespace