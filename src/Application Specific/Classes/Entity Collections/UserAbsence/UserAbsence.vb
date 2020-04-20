
Imports System.Data.SqlClient


Namespace Entity.UserAbsence
    Public Class UserAbsence

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

#Region "UserAbsence Properties"

        Private _UserAbsenceID As Integer = 0
        Public ReadOnly Property UserAbsenceID() As Integer
            Get
                Return _UserAbsenceID
            End Get
        End Property
        Public WriteOnly Property SetUserAbsenceID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_UserAbsenceID", Value)
            End Set
        End Property

        Private _UserID As String = String.Empty
        Public ReadOnly Property UserID() As String
            Get
                Return _UserID
            End Get
        End Property
        Public WriteOnly Property SetUserID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_UserID", Value)
            End Set
        End Property

        Private _AbsenceTypeID As Integer = 0
        Public ReadOnly Property AbsenceTypeID() As Integer
            Get
                Return _AbsenceTypeID
            End Get
        End Property
        Public WriteOnly Property SetAbsenceTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_AbsenceTypeID", Value)
            End Set
        End Property

        Private _DateFrom As Date = Nothing
        Public Property DateFrom() As Date
            Get
                Return _DateFrom
            End Get
            Set(ByVal Value As Date)
                _DateFrom = Value
            End Set
        End Property

        Private _DateTo As Date = Nothing
        Public Property DateTo() As Date
            Get
                Return _DateTo
            End Get
            Set(ByVal Value As Date)
                _DateTo = Value
            End Set
        End Property


        Private _MorningSlots As Integer = 0
        Public ReadOnly Property MorningSlots() As Integer
            Get
                Return _MorningSlots
            End Get
        End Property
        Public WriteOnly Property SetMorningSlots() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_MorningSlots", Value)
            End Set
        End Property


        Private _AfternoonSlots As Integer = 0
        Public ReadOnly Property AfternoonSlots() As Integer
            Get
                Return _AfternoonSlots
            End Get
        End Property
        Public WriteOnly Property SetAfternoonSlots() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_AfternoonSlots", Value)
            End Set
        End Property


        Private _Comments As String = String.Empty
        Public ReadOnly Property Comments() As String
            Get
                Return _Comments
            End Get
        End Property
        Public WriteOnly Property SetComments() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Comments", Value)
            End Set
        End Property




#End Region

    End Class

End Namespace