Imports System.Data.SqlClient

Namespace Entity

    Namespace Subcontractors

        Public Class Subcontractor

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

#Region "Subcontractor Properties"

            Private _SubcontractorID As Integer = 0

            Public ReadOnly Property SubcontractorID() As Integer
                Get
                    Return _SubcontractorID
                End Get
            End Property

            Public WriteOnly Property SetSubcontractorID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubcontractorID", Value)
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
                    Engineer = DB.Engineer.Engineer_Get(EngineerID)
                End Set
            End Property

            Private _LinkToSupplierID As Integer = 0

            Public ReadOnly Property LinkToSupplierID() As Integer
                Get
                    Return _LinkToSupplierID
                End Get
            End Property

            Public WriteOnly Property SetLinkToSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LinkToSupplierID", Value)
                End Set
            End Property

            Private _taxRate As Integer = 0

            Public ReadOnly Property TaxRate() As Integer
                Get
                    Return _taxRate
                End Get
            End Property

            Public WriteOnly Property SetTaxRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_taxRate", Value)
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

#End Region

#Region "Additional Properties"

            Private _Engineer As Engineers.Engineer = Nothing

            Public Property Engineer() As Engineers.Engineer
                Get
                    Return _Engineer
                End Get
                Set(ByVal Value As Engineers.Engineer)
                    _Engineer = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace