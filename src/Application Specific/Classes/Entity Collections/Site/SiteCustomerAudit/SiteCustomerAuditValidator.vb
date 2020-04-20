Namespace Entity

Namespace SiteCustomerAudits

Public Class SiteCustomerAuditValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oSiteCustomerAudit As SiteCustomerAudit)

        'make sure that contact object is valid
        If oSiteCustomerAudit.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oSiteCustomerAudit.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If

        
	
        If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
            Throw New ValidationException(Me)
        End If

    End Sub

End Class

End Namespace

End Namespace
