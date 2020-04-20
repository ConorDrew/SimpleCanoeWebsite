Namespace Entity

Namespace SiteOrders

Public Class SiteOrderValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oSiteOrder As SiteOrder)

        'make sure that contact object is valid
        If oSiteOrder.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oSiteOrder.Errors
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
