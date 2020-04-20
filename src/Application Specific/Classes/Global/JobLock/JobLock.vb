Namespace Entity

    Namespace JobLock

        Public Class JobLock

#Region "JobLock Properties"

            Private _jobLockID As Integer = 0
            Public Property JobLockID() As Integer
                Get
                    Return _jobLockID
                End Get
                Set(ByVal Value As Integer)
                    _jobLockID = Value
                End Set
            End Property

            Private _jobID As Integer = 0
            Public Property JobID() As Integer
                Get
                    Return _jobID
                End Get
                Set(ByVal Value As Integer)
                    _jobID = Value
                End Set
            End Property

            Private _userID As Integer = 0
            Public Property UserID() As Integer
                Get
                    Return _userID
                End Get
                Set(ByVal Value As Integer)
                    _userID = Value
                End Set
            End Property

            Private _dateLock As DateTime = Nothing
            Public Property DateLock() As DateTime
                Get
                    Return _dateLock
                End Get
                Set(ByVal Value As DateTime)
                    _dateLock = Value
                End Set
            End Property

            Private _nameOfUserWhoLocked As String = ""
            Public Property NameOfUserWhoLocked() As String
                Get
                    Return _nameOfUserWhoLocked
                End Get
                Set(ByVal Value As String)
                    _nameOfUserWhoLocked = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace
