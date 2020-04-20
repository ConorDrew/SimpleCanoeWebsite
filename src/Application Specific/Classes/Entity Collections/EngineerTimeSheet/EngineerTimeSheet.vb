Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerTimeSheets

        Public Class EngineerTimeSheet

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

#Region "EngineerTimeSheet Properties"

            Private _EngineerTimeSheetID As Integer = 0

            Public ReadOnly Property EngineerTimeSheetID() As Integer
                Get
                    Return _EngineerTimeSheetID
                End Get
            End Property

            Public WriteOnly Property SetEngineerTimeSheetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerTimeSheetID", Value)
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

            Private _AppointmentTime As String = String.Empty

            Public ReadOnly Property AppointmentTime() As String
                Get
                    Return _AppointmentTime
                End Get
            End Property

            Public WriteOnly Property SetAppointmentTime() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AppointmentTime", Value)
                End Set
            End Property

            Private _TimeSheetType As String = String.Empty

            Public ReadOnly Property TimeSheetType() As String
                Get
                    Return _TimeSheetType
                End Get
            End Property

            Public WriteOnly Property SetTimeSheetType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TimeSheetType", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace