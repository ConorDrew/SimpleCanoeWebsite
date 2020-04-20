Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorGas
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

                    If oEngineerVisitAssetWorkSheet.ApplianceSafeID = Nothing Then
                        Me.AddCriticalMessage("Appliance Safe Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = Nothing Then
                        Me.AddCriticalMessage("Appliance Serviced Or Inspected Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                        Me.AddCriticalMessage("Flue Spilage Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.AssetID = Nothing Then
                        Me.AddCriticalMessage("Appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                        Me.AddCriticalMessage("Flue Flow Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                        Me.AddCriticalMessage("Flue Flow Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Flue Termination Satisfactory Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.LandlordsApplianceID = Nothing Then
                        Me.AddCriticalMessage("Landlords Appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = Nothing Then
                        Me.AddCriticalMessage("Safety Device Operation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Ventilation Provision Satisfactory Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Visual Condition of Flue Satisfactory Missing")
                    End If

                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
