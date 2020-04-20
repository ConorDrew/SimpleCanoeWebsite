Public Class ErrorMsg
    Public Const ERROR_MSG_CAPTION As String = "Error"

    Public Shared Function InputExceedsMaxCharsAllowed(ByVal fieldName As String, ByVal maxChars As Int16) As String
        Return String.Format("*{0} exceeds maximum length of {1} characters.", fieldName, maxChars)
    End Function

    Public Shared Function Message(ByVal _message As String) As String
        Return String.Format("*{0}.", _message)
    End Function

    Public Shared Function AddSeperator() As String
        Return "****************************************************"
    End Function

    Public Shared Function FieldRequired(ByVal fieldName As String) As String
        Return String.Format("*{0} is required.", fieldName)
    End Function

    Public Shared Function NotNumeric(ByVal fieldName As String) As String
        Return String.Format("*{0} is required to be numeric.", fieldName)
    End Function

    Public Shared Function InvalidFormat(ByVal fieldName As String, ByVal requiredformat As String) As String
        Return String.Format("*{0} must be in the following format: {1}", fieldName, requiredformat)
    End Function

    Public Shared Function LoginIncorrect() As String
        Return String.Format("*User Details are incorrect.")
    End Function

    Public Shared Function AlreadyExists(ByVal fieldName As String) As String
        Return String.Format("*{0} already exists.", fieldName)
    End Function

    Public Shared Function ErrorOccured(ByVal msg As String) As String
        Return String.Format("The system encountered an error, please contact support informing them of the following error: " + vbCrLf + "{0}", msg)
    End Function

    Public Shared Function FieldMinimumLengthNotAchieved(ByVal fieldName As String, ByVal minimumLength As Integer) As String
        If (minimumLength > 1) Then
            Return String.Format("*{0} must be at least {1} characters in length.", fieldName, minimumLength)
        Else
            Return String.Format("*{0} must be at least {1} characters in length.", fieldName, minimumLength)
        End If
    End Function

    Public Shared Function FieldNotWithinRange(ByVal fieldName As String, ByVal value1 As String, ByVal value2 As String) As String
        Return String.Format("*{0} must be between {1} and {2}", fieldName, value1, value2)
    End Function


    Public Shared Function FieldsDoNotMatch(ByVal fieldName1 As String, ByVal fieldname2 As String) As String
        Return String.Format("*{0} does not match {1}", fieldName1, fieldname2)
    End Function

    Public Shared Function NegativeNumber(ByVal fieldName1 As String) As String
        Return String.Format("*{0} cannot be a negative number.", fieldName1)
    End Function

End Class