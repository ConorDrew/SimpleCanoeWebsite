Namespace Entity

Namespace Subcontractors

Public Class SubcontractorValidator
    'make sure that contact object is valid
    Inherits BaseValidator

            Public Sub Validate(ByVal oSubcontractor As Subcontractor)

                'make sure that contact object is valid
                If oSubcontractor.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oSubcontractor.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oSubcontractor.Engineer.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oSubcontractor.Engineer.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oSubcontractor.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Subcontractor Name Missing")
                Else
                    If DB.Engineer.Check_Unique_Name(oSubcontractor.Name.Trim, oSubcontractor.Engineer.EngineerID) = False Then
                        Me.AddCriticalMessage("This Subcontractor Name already exists as an engineer")
                    End If
                End If
                If oSubcontractor.Address1.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Subcontractor Address 1 Missing")
                End If
                If oSubcontractor.Postcode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Subcontractor Postcode Missing")
                End If
                If oSubcontractor.TelephoneNum.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Subcontractor Telephone Missing")
                End If

                If oSubcontractor.Engineer.RegionID = 0 Then
                    Me.AddCriticalMessage("Region Missing")
                End If
                If DB.Engineer.Check_Unique_PDAID(oSubcontractor.Engineer.PDAID, oSubcontractor.EngineerID) = False Then
                    Me.AddCriticalMessage("PDA ID already exists")
                End If
                If Not CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearStart) Then
                    AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'")
                End If

                If Not CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearEnd) Then
                    AddCriticalMessage("'End Period' for holiday entitlement must be in the format of 'dd/mm'")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

            ' This function checks if a string is in a particular format 'dd/mm'.
            ' Note: If the string has a length equal to zero then the string is considered 
            ' valid.
            Private Function CheckShortDateIsValid(ByVal strDate As String) As Boolean

                If strDate.Length = 0 Then
                    Return True
                End If

                strDate = strDate.Trim()
                Dim valid As Boolean = True

                If strDate.Length <> 5 Then
                    valid = False
                Else
                    Dim strChars() As Char = strDate.ToCharArray()
                    If Not IsNumeric(strChars(0)) Then
                        valid = False
                    End If
                    If Not IsNumeric(strChars(1)) Then
                        valid = False
                    End If
                    If strChars(2) <> "/" Then
                        valid = False
                    End If
                    If Not IsNumeric(strChars(3)) Then
                        valid = False
                    End If
                    If Not IsNumeric(strChars(4)) Then
                        valid = False
                    End If
                End If
                Return valid
            End Function

End Class

End Namespace

End Namespace
