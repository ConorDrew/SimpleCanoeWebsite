Namespace Entity

    Namespace Appointments

        Public Class Appointment

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

#Region "Appointment Properties"

            Private _AppointmentID As Integer = 0
            Public ReadOnly Property AppointmentID() As Integer
                Get
                    Return _AppointmentID
                End Get
            End Property
            Public WriteOnly Property SetAppointmentID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AppointmentID", Value)
                End Set
            End Property

            Private _Name As String
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

            Private _StartTime As TimeSpan
            Public ReadOnly Property StartTime() As TimeSpan
                Get
                    Return _StartTime
                End Get
            End Property
            Public WriteOnly Property SetStartTime() As Object
                Set(ByVal Value As Object)
                    _StartTime = Value
                End Set
            End Property

            Private _EndTime As TimeSpan
            Public ReadOnly Property EndTime() As TimeSpan
                Get
                    Return _EndTime
                End Get
            End Property
            Public WriteOnly Property SetEndTime() As Object
                Set(ByVal Value As Object)
                    _EndTime = Value
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace