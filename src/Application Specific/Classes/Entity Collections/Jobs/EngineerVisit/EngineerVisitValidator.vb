Namespace Entity

    Namespace EngineerVisits

        Public Class EngineerVisitValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVisit As EngineerVisit, ByVal CustomerID As Integer)

                'make sure that contact object is valid
                If oEngineerVisit.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVisit.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                Select Case oEngineerVisit.OutcomeEnumID
                    Case CInt(Entity.Sys.Enums.EngineerVisitOutcomes.NOT_SET)
                        Me.AddCriticalMessage("Outcome Missing")
                    Case CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Complete)
                        'OK
                    Case Else
                        If oEngineerVisit.OutcomeDetails.Trim.Length = 0 Then
                            Me.AddCriticalMessage("Outcome Details Missing")
                        End If
                End Select

                'If oEngineerVisit.VisitLocked And oEngineerVisit.CostsTo = String.Empty Then
                '    Me.AddCriticalMessage("Costs To Details Missing")
                'End If
                'If oEngineerVisit.CustomerName.Trim.Length = 0 Then
                '    Me.AddCriticalMessage("Customer Name Missing")
                'End If

                'If CustomerID = Entity.Sys.Enums.Customer.NCC Then
                '    If oEngineerVisit.PropertyRented = 0 Then
                '        Me.AddCriticalMessage("Property Rented Missing")
                '    End If

                '    If oEngineerVisit.GasInstallationTightnessTestID = 0 Then
                '        Me.AddCriticalMessage("Gas Installation Tightness Test Missing")
                '    End If

                '    If oEngineerVisit.EmergencyControlAccessibleID = 0 Then
                '        Me.AddCriticalMessage("Emergency Control Accessible Missing")
                '    End If

                '    If oEngineerVisit.BondingID = 0 Then
                '        Me.AddCriticalMessage("Bonding Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.CorrectMaterialsUsedID = 0 Then
                '        Me.AddCriticalMessage("Correct Materials Used Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.InstallationPipeWorkCorrectID = 0 Then
                '        Me.AddCriticalMessage("Installation Pipe Work Correct Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.InstallationSafeToUseID = 0 Then
                '        Me.AddCriticalMessage("Installation Safe To Use Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.StrainerFittedID = 0 Then
                '        Me.AddCriticalMessage("Strainer Fitted Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.StrainerInspectedID = 0 Then
                '        Me.AddCriticalMessage("Strainer Inspected Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.HeatingSystemTypeID = 0 Then
                '        Me.AddCriticalMessage("Heating System Type Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.CylinderTypeID = 0 Then
                '        Me.AddCriticalMessage("Cylinder Type Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.JacketID = 0 Then
                '        Me.AddCriticalMessage("Jacket Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.ImmersionID = 0 Then
                '        Me.AddCriticalMessage("Immersion Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.CODetectorFittedID = 0 Then
                '        Me.AddCriticalMessage("CO Detector Fitted Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.CertificateTypeID = 0 Then
                '        Me.AddCriticalMessage("Certificate Type Missing")
                '    End If

                '    If oEngineerVisit.EngineerVisitNCCGSR.VisualInspectionSatisfactoryID = 0 Then
                '        Me.AddCriticalMessage("Visual Inspection Satisfactory Missing")
                '    End If

                'End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
