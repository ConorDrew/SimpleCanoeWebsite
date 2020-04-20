Namespace Entity

    Namespace ContractsAlternative

        Public Class ContractAlternativeValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oContract As ContractAlternative)

                'make sure that contact object is valid
                If oContract.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oContract.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oContract.ContractReference.Trim.Length = 0 Then
                    AddCriticalMessage("* Contract Referenece is required")

                Else
                    'DEAL WITH FORMATTING
                    Dim fmtStr As String = "* Contract Reference must be of the format :" & _
                                                     vbCrLf & _
                                                     " ALPHA/NUMERIC " & vbCrLf & _
                                                     " NUMERIC/ALPHA " & vbCrLf & _
                                                     " ALPHA/NUMERIC/ALPHA " & vbCrLf & _
                                                     " or a standard alphanumeric with no /( forward slash)"

                    If Left(oContract.ContractReference, 1) = "/" Or _
                                    Right(oContract.ContractReference, 1) = "/" Then
                        AddCriticalMessage(fmtStr)
                    Else
                        Dim spArr As Array
                        spArr = oContract.ContractReference.Split("/")

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
                        If oContract.ContractID = 0 Then
                            If Not (DB.ContractOption3.ContractReference_CheckUnique(oContract.ContractReference, oContract.CustomerID)) Then
                                AddCriticalMessage("* Contract Reference must be unqiue")
                            End If
                        End If

                    End If
                End If


                If oContract.ContractStatusID = 0 Then
                    AddCriticalMessage("Contract Status Missing")
                End If

                If oContract.ContractEndDate <= oContract.ContractStartDate Then
                    AddCriticalMessage("Contract End Date must be greater than Contract Start Date")
                End If

                If oContract.InvoiceFrequencyID = 0 Then
                    AddCriticalMessage("Invoice Frequency Missing")
                End If
            
                If oContract.InvoiceAddressID = 0 Then
                    AddCriticalMessage("Invoice Address Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
