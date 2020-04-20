Public Class BaseValidator

#Region "Properties"

    Protected _validatorMessages As ValidatorMessages

    Public Property ValidatorMessages() As ValidatorMessages
        Get
            Return Me._validatorMessages
        End Get
        Set(ByVal value As ValidatorMessages)
            Me._validatorMessages = value
        End Set
    End Property

    Public Function CriticalMessagesString() As String
        Dim msgString As String = ""
        For Each s As String In _validatorMessages.CriticalMessages
            msgString += s & vbCrLf
        Next
        Return msgString
    End Function

    Public Function WarningMessageString() As String
        Dim msgString As String = ""
        For Each s As String In _validatorMessages.WarningMessages
            msgString += s & vbCrLf
        Next
        Return msgString
    End Function

#End Region

#Region "Functions"

    Public Sub New()
        _validatorMessages = New ValidatorMessages
    End Sub

    Public Sub AddCriticalMessage(ByVal message As String)
        _validatorMessages.CriticalMessages.Add(message)
    End Sub

    Public Sub AddWarningMessage(ByVal message As String)
        _validatorMessages.WarningMessages.Add(message)
    End Sub

#End Region

End Class

Public Class ValidationException : Inherits Exception

#Region "Properties"

    Private m_valid As New BaseValidator
    Public Property Validator() As BaseValidator
        Get
            Return m_valid
        End Get
        Set(ByVal Value As BaseValidator)
            m_valid = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Public Sub New(ByVal inValidator As BaseValidator)
        m_valid = inValidator
    End Sub

#End Region

End Class