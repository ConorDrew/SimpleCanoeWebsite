Public Class JobNumber


    Private _jobNumber As Integer = 0
    Private _prefix As String = 0
    Private _OrderNumber As String = ""

    Public Property JobNumber() As Integer
        Get
            Return _jobNumber
        End Get
        Set(ByVal Value As Integer)
            _jobNumber = Value
        End Set
    End Property

    Public Property Prefix() As String
        Get
            Return _prefix
        End Get
        Set(ByVal Value As String)
            _prefix = Value
        End Set
    End Property

    Public Property OrderNumber() As String
        Get
            Return _OrderNumber
        End Get
        Set(ByVal Value As String)
            _OrderNumber = Value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal jobNumberIn As Integer, ByVal PrefixIn As String)
        JobNumber = jobNumberIn
        Prefix = PrefixIn
    End Sub

End Class
