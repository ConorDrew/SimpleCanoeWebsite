Public MustInherit Class ScheduleTest

    Public Class TestResult
        Private _pass As Boolean
        Private _cancelSchedule As Boolean
        Private _passwordPrompt As Boolean
        Private _failMessage As String
        Private _failMessages As New ArrayList

        Public Sub New()
            _pass = True
            _failMessage = failMessage
            _cancelSchedule = False
            _passwordPrompt = False
        End Sub

        Public Sub New(ByVal failMessage As String, Optional cancelSchedule As Boolean = False, Optional passwordPrompt As Boolean = False)
            _pass = False
            _failMessage = failMessage
            _cancelSchedule = cancelSchedule
            _passwordPrompt = passwordPrompt
        End Sub

        Public Sub New(ByVal failMessages As ArrayList, Optional cancelSchedule As Boolean = False, Optional passwordPrompt As Boolean = False)
            _pass = False
            _failMessages = failMessages
            _cancelSchedule = cancelSchedule
            _passwordPrompt = passwordPrompt
        End Sub

        Public ReadOnly Property pass() As Boolean
            Get
                Return _pass
            End Get
        End Property

        Public ReadOnly Property failMessage() As String
            Get
                Return _failMessage
            End Get
        End Property

        Public ReadOnly Property failMessages() As ArrayList
            Get
                Return _failMessages
            End Get
        End Property

        Public ReadOnly Property CancelSchedule() As Boolean
            Get
                Return _cancelSchedule
            End Get
        End Property

        Public ReadOnly Property PasswordPrompt() As Boolean
            Get
                Return _passwordPrompt
            End Get
        End Property

    End Class

    Protected MustOverride ReadOnly Property TestName() As String

    Public MustOverride Function Test(ByVal testRow As DataRow, ByVal engineerID As Integer, ByVal day As DateTime) As TestResult

End Class