Namespace Entity

    Namespace Engineers

        Public Class EngineerValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineer As Engineer)

                'make sure that contact object is valid
                If oEngineer.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineer.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oEngineer.EngineerGroupID <= 0 Then
                    Me.AddCriticalMessage("Engineer Group")
                End If

                If oEngineer.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Name Missing")
                Else
                    If DB.Engineer.Check_Unique_Name(oEngineer.Name, oEngineer.EngineerID) = False Then
                        Me.AddCriticalMessage("Engineer name already exists")
                    End If
                End If
                If oEngineer.RegionID = 0 Then
                    Me.AddCriticalMessage("Region Missing")
                End If
                'If oEngineer.PDAID = 0 Then
                '    Me.AddCriticalMessage("PDA ID Missing")
                'Else
                'If DB.Engineer.Check_Unique_PDAID(oEngineer.PDAID, oEngineer.EngineerID) = False Then
                '    Me.AddCriticalMessage("PDA ID already exists")
                'End If
                'End If
                'If oEngineer.WebAppPassword.Trim.Length = 0 Then
                    'Me.AddCriticalMessage("WebApp Password Missing")
                'End If

                If Not CheckShortDateIsValid(oEngineer.HolidayYearStart) Then
                    AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'")
                End If

                If Not CheckShortDateIsValid(oEngineer.HolidayYearEnd) Then
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
