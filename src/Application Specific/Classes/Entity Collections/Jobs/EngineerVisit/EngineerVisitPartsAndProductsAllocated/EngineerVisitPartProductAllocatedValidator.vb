Namespace Entity

    Namespace EngineerVisitPartProductAllocateds

        Public Class EngineerVisitPartProductAllocatedValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVisitPartAllocated As EngineerVisitPartProductAllocated)

                'make sure that contact object is valid
                If oEngineerVisitPartAllocated.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVisitPartAllocated.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oEngineerVisitPartAllocated.Type.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Item Type Missing")
                End If
                If oEngineerVisitPartAllocated.PartProductID = 0 Then
                    Me.AddCriticalMessage("Item Missing")
                End If
                If Not oEngineerVisitPartAllocated.Quantity > 0 Then
                    Me.AddCriticalMessage("Quantity Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
