Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitTimeSheets

        Public Class EngineerVisitTimeSheet

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

#Region "EngineerVisitTimeSheet Properties"


            Private _EngineerVisitTimeSheetID As Integer = 0
            Public ReadOnly Property EngineerVisitTimeSheetID() As Integer
                Get
                    Return _EngineerVisitTimeSheetID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitTimeSheetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitTimeSheetID", Value)
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


            Private _StartDateTime As DateTime = Nothing
            Public Property StartDateTime() As DateTime
                Get
                    Return _StartDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _StartDateTime = Value
                End Set
            End Property


            Private _EndDateTime As DateTime = Nothing
            Public Property EndDateTime() As DateTime
                Get
                    Return _EndDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _EndDateTime = Value
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

            Private _TimeSheetTypeID As Integer = 0
            Public ReadOnly Property TimeSheetTypeID() As Integer
                Get
                    Return _TimeSheetTypeID
                End Get
            End Property
            Public WriteOnly Property SetTimeSheetTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TimeSheetTypeID", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

