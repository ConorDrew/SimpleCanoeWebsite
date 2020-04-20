Namespace Entity

    Namespace EngineerVisitOrders

        Public Class EngineerVisitOrderValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVistOrder As EngineerVisitOrder)

                'make sure that contact object is valid
                If oEngineerVistOrder.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVistOrder.Errors
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
