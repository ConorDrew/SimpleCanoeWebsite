Namespace Entity.Customers

    Public Class CustomerServiceProcess

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

#Region "Customer Properties"

        Private _CustomerServiceProcessID As Integer = 0

        Public ReadOnly Property CustomerServiceProcessID() As Integer
            Get
                Return _CustomerServiceProcessID
            End Get
        End Property

        Public WriteOnly Property SetCustomerServiceProcessID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_CustomerServiceProcessID", Value)
            End Set
        End Property

        Private _CustomerID As Integer = 0

        Public ReadOnly Property CustomerID() As Integer
            Get
                Return _CustomerID
            End Get
        End Property

        Public WriteOnly Property SetCustomerID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_CustomerID", Value)
            End Set
        End Property

        Private _Letter1 As Integer = 0

        Public ReadOnly Property Letter1() As Integer
            Get
                Return _Letter1
            End Get
        End Property

        Public WriteOnly Property SetLetter1() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Letter1", Value)
            End Set
        End Property

        Private _Letter2 As Integer = 0

        Public ReadOnly Property Letter2() As Integer
            Get
                Return _Letter2
            End Get
        End Property

        Public WriteOnly Property SetLetter2() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Letter2", Value)
            End Set
        End Property

        Private _Letter3 As Integer = 0

        Public ReadOnly Property Letter3() As Integer
            Get
                Return _Letter3
            End Get
        End Property

        Public WriteOnly Property SetLetter3() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Letter3", Value)
            End Set
        End Property

        Private _Appointment1 As Integer = 0

        Public ReadOnly Property Appointment1() As Integer
            Get
                Return _Appointment1
            End Get
        End Property

        Public WriteOnly Property SetAppointment1() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Appointment1", Value)
            End Set
        End Property

        Private _Appointment2 As Integer = 0

        Public ReadOnly Property Appointment2() As Integer
            Get
                Return _Appointment2
            End Get
        End Property

        Public WriteOnly Property SetAppointment2() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Appointment2", Value)
            End Set
        End Property

        Private _Appointment3 As Integer = 0

        Public ReadOnly Property Appointment3() As Integer
            Get
                Return _Appointment3
            End Get
        End Property

        Public WriteOnly Property SetAppointment3() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Appointment3", Value)
            End Set
        End Property

        Private _DateAdded As DateTime = Nothing

        Public Property DateAdded() As DateTime
            Get
                Return _DateAdded
            End Get
            Set(ByVal Value As DateTime)
                _DateAdded = Value
            End Set
        End Property

        Private _AddedBy As Integer = 0

        Public ReadOnly Property AddedBy() As Integer
            Get
                Return _AddedBy
            End Get
        End Property

        Public WriteOnly Property SetAddedBy() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_AddedBy", Value)
            End Set
        End Property

        Private _template1 As Byte()

        Public Property Template1() As Byte()
            Get
                Return _template1
            End Get
            Set(ByVal value As Byte())
                _template1 = value
            End Set
        End Property

        Private _template2 As Byte()

        Public Property Template2() As Byte()
            Get
                Return _template2
            End Get
            Set(ByVal value As Byte())
                _template2 = value
            End Set
        End Property

        Private _template3 As Byte()

        Public Property Template3() As Byte()
            Get
                Return _template3
            End Get
            Set(ByVal value As Byte())
                _template3 = value
            End Set
        End Property

        Private _patchCheckTemplate As Byte()

        Public Property PatchCheckTemplate() As Byte()
            Get
                Return _patchCheckTemplate
            End Get
            Set(ByVal value As Byte())
                _patchCheckTemplate = value
            End Set
        End Property

#End Region

    End Class

End Namespace