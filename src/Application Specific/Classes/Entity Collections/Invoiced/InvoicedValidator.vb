Namespace Entity

    Namespace Invoiceds

        Public Class InvoicedValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oInvoiced As Invoiced)

                'make sure that contact object is valid
                If oInvoiced.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oInvoiced.Errors
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
