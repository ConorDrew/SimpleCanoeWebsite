Namespace Entity

    Namespace ContractOption3s

        Public Class ContractOption3Validator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContractOption3 As ContractOption3)

                'make sure that contact object is valid
                If oContractOption3.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContractOption3.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContractOption3.ContractReference.Trim.Length = 0 Then
                    AddCriticalMessage("* Contract Referenece is required")

                Else
                    'DEAL WITH FORMATTING
                    Dim fmtStr As String = "* Contract Reference must be of the format :" & _
                                                     vbCrLf & _
                                                     " ALPHA/NUMERIC " & vbCrLf & _
                                                     " NUMERIC/ALPHA " & vbCrLf & _
                                                     " ALPHA/NUMERIC/ALPHA " & vbCrLf & _
                                                     " or a standard alphanumeric with no /( forward slash)"

                    If Left(oContractOption3.ContractReference, 1) = "/" Or _
                                    Right(oContractOption3.ContractReference, 1) = "/" Then
                        AddCriticalMessage(fmtStr)
                    Else
                        Dim spArr As Array
                        spArr = oContractOption3.ContractReference.Split("/")

                        If spArr.Length = 1 Then
                            'do nothing
                        ElseIf spArr.Length = 2 Then
                            'MUST BE NUMBER / CHAR 
                            If IsNumeric(spArr(0)) Then
                                If IsNumeric(spArr(1)) Then
                                    AddCriticalMessage(fmtStr)
                                End If
                            Else
                                'OR 
                                'MUST BE CHAR / NUMBER
                                If Not IsNumeric(spArr(1)) Then
                                    AddCriticalMessage(fmtStr)
                                End If
                            End If
                        ElseIf spArr.Length = 3 Then
                            'MUST BE CHAR / NUMBER /CHAR
                            If Not IsNumeric(spArr(0)) Then
                                If IsNumeric(spArr(1)) Then
                                    If IsNumeric(spArr(2)) Then
                                        AddCriticalMessage(fmtStr)
                                    End If
                                Else
                                    AddCriticalMessage(fmtStr)
                                End If
                            Else
                                AddCriticalMessage(fmtStr)
                            End If
                        Else
                            'T0O MANY SPLITS
                            AddCriticalMessage(fmtStr)
                        End If

                        'IS REF UNIQUE?
                        If oContractOption3.ContractID = 0 Then
                            If Not (DB.ContractOption3.ContractReference_CheckUnique(oContractOption3.ContractReference, oContractOption3.CustomerID)) Then
                                AddCriticalMessage("* Contract Reference must be unqiue")
                            End If
                        End If

                    End If
                End If


                If InStr(oContractOption3.ContractReference, "-") > 0 Then
                    AddCriticalMessage("* Contract Referenece cannot contain '-'.")
                End If
                If oContractOption3.ContractStatusID = 0 Then
                    AddCriticalMessage("* Contract Status is required")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
