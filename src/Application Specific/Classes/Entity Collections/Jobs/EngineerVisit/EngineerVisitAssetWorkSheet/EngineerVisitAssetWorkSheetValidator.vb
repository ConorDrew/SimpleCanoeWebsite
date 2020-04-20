Namespace Entity

Namespace EngineerVisitAssetWorkSheets

Public Class EngineerVisitAssetWorkSheetValidator
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


                If ApplianceTested = "Yes" Then

                    If oEngineerVisitAssetWorkSheet.ApplianceSafeID = 0 Then
                        Me.AddCriticalMessage("Appliance Safe Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = 0 Then
                        Me.AddCriticalMessage("Appliance Serviced Or Inspected Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SpillageTestID = 0 Then
                        Me.AddCriticalMessage("Flue Spilage Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.AssetID = 0 Then
                        Me.AddCriticalMessage("Appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = 0 Then
                        Me.AddCriticalMessage("Flue Flow Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.CO2 = 0 Then
                        Me.AddCriticalMessage("CO2 % Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.CO2CORatio = 0 Then
                        Me.AddCriticalMessage("CO2/CO Ratio Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ColdWaterTemp = 0 Then
                        Me.AddCriticalMessage("Cold Water Temp Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.DHWFlowRate = 0 Then
                        Me.AddCriticalMessage("DHW Flow Rate Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.DHWTemp = 0 Then
                        Me.AddCriticalMessage("DHW Temp Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = 0 Then
                        Me.AddCriticalMessage("Flue Flow Test Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = 0 Then
                        Me.AddCriticalMessage("Flue Termination Satisfactory Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.InletStaticPressure = 0 Then
                        Me.AddCriticalMessage("Inlet Static Pressure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.InletWorkingPressure = 0 Then
                        Me.AddCriticalMessage("Inlet Working Pressure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.LandlordsApplianceID = 0 Then
                        Me.AddCriticalMessage("Landlords Appliance Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.MaxBurnerPressure = 0 Then
                        Me.AddCriticalMessage("Max Burner Pressure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.MinBurnerPressure = 0 Then
                        Me.AddCriticalMessage("Min Burner Pressure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.MinBurnerPressure = 0 Then
                        Me.AddCriticalMessage("Min Burner Pressure Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = 0 Then
                        Me.AddCriticalMessage("Safety Device Operation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = 0 Then
                        Me.AddCriticalMessage("Ventilation Provision Satisfactory Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = 0 Then
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
