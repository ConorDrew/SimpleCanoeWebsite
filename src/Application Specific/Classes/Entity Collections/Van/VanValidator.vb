Namespace Entity

Namespace Vans

Public Class VanValidator
    'make sure that contact object is valid
    Inherits BaseValidator

    Public Sub Validate(ByVal oVan As Van)

        'make sure that contact object is valid
        If oVan.Errors.Count > 0 Then
            Dim de As DictionaryEntry
            For Each de In oVan.Errors
                Me.AddCriticalMessage(CStr(de.Value))
            Next
        End If


                If oVan.Registration.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Profile Name Missing")
                Else
                    If oVan.Registration.Contains("*") Then
                        Me.AddCriticalMessage("An asterix (*) cannot be placed in the profile name")
                    Else
                        If DB.Van.Check_Unique_Registration(oVan.Registration, oVan.VanID) = False Then
                            Me.AddCriticalMessage("Profile name already exists")
                        End If
                    End If
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

    End Sub

End Class

End Namespace

End Namespace
