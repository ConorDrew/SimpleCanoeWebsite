Public Class ValidatorMessages

#Region "Properties"

    Private _criticalMessages As ArrayList
    Public ReadOnly Property CriticalMessages() As ArrayList
        Get
            Return _criticalMessages
        End Get
    End Property

    Private _warningMessages As ArrayList
    Public ReadOnly Property WarningMessages() As ArrayList
        Get
            Return _warningMessages
        End Get
    End Property

#End Region

#Region "Functions"

    Public Sub New()
        _criticalMessages = New ArrayList
        _warningMessages = New ArrayList
    End Sub

#End Region

End Class
