Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorSolar
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVisitAssetWorkSheet As EngineerVisitAssetWorkSheet, ByVal ApplianceTested As String)

                'make sure that contact object is valid
                If oEngineerVisitAssetWorkSheet.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVisitAssetWorkSheet.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If


                If ApplianceTested <> "No" Then

                    If oEngineerVisitAssetWorkSheet.AssetID = Nothing Then
                        Me.AddCriticalMessage("Appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.LandlordsApplianceID = Nothing Then
                        Me.AddCriticalMessage("Landlords appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceTestedID = Nothing Then
                        Me.AddCriticalMessage("Appliance Tested Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                        Me.AddCriticalMessage("Leaks/Presure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                        Me.AddCriticalMessage("Operation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Safety devices Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Stability Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Ventilation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = Nothing Then
                        Me.AddCriticalMessage("Safety device operation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SweepOutcomeID = Nothing Then
                        Me.AddCriticalMessage("Sweep outcome Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.OverallID = Nothing Then
                        Me.AddCriticalMessage("Overall condition Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.DischargeID = Nothing Then
                        Me.AddCriticalMessage("Discharge Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = Nothing Then
                        Me.AddCriticalMessage("Appliance service Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceSafeID = Nothing Then
                        Me.AddCriticalMessage("Appliance safety Missing")
                    End If

                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
