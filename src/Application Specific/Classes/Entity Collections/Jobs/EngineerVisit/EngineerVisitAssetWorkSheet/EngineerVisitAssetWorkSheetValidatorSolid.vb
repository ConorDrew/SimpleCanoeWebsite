Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorSolid
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oEngineerVisitAssetWorkSheet As EngineerVisitAssetWorkSheet)

                'make sure that contact object is valid
                If oEngineerVisitAssetWorkSheet.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oEngineerVisitAssetWorkSheet.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oEngineerVisitAssetWorkSheet.AssetID = Nothing Then
                    Me.AddCriticalMessage("Appliance Missing")
                End If

                If oEngineerVisitAssetWorkSheet.LandlordsApplianceID = Nothing Then
                    Me.AddCriticalMessage("Termination Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceTestedID = Nothing Then
                    Me.AddCriticalMessage("Visual Condition Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                    Me.AddCriticalMessage("Chimney Structure Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Chimney Swept Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Hearth Size Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                    Me.AddCriticalMessage("Fire guard Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Flue clear Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = Nothing Then
                    Me.AddCriticalMessage("Swept brush Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ColdWaterTemp = Nothing Then
                    Me.AddCriticalMessage("Compustion air Missing")
                End If

                If oEngineerVisitAssetWorkSheet.DHWTemp = Nothing Then
                    Me.AddCriticalMessage("Flue performance Missing")
                End If

                If oEngineerVisitAssetWorkSheet.InletWorkingPressure = Nothing Then
                    Me.AddCriticalMessage("Safety device Missing")
                End If

                If oEngineerVisitAssetWorkSheet.MinBurnerPressure = Nothing Then
                    Me.AddCriticalMessage("Appliance serviced Missing")
                End If

                If oEngineerVisitAssetWorkSheet.Nozzle = Nothing Then
                    Me.AddCriticalMessage("Immersion heater Missing")
                End If

                If oEngineerVisitAssetWorkSheet.CO2 = Nothing Then
                    Me.AddCriticalMessage("Tennant knowlege Missing")
                End If

                If oEngineerVisitAssetWorkSheet.CO2CORatio = Nothing Then
                    Me.AddCriticalMessage("Operating instructions Missing")
                End If

                If oEngineerVisitAssetWorkSheet.BMake = Nothing Then
                    Me.AddCriticalMessage("Type of cylinder Missing")
                End If

                If oEngineerVisitAssetWorkSheet.BModel = Nothing Then
                    Me.AddCriticalMessage("Ventilation type Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = Nothing Then
                    Me.AddCriticalMessage("Extractor fans Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceSafeID = Nothing Then
                    Me.AddCriticalMessage("Appliance safe Missing")
                End If

                If oEngineerVisitAssetWorkSheet.DischargeID = Nothing Then
                    Me.AddCriticalMessage("Smoke draw test Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SweepOutcomeID = Nothing Then
                    Me.AddCriticalMessage("Smoke pressure test Missing")
                End If

                If oEngineerVisitAssetWorkSheet.OverallID = Nothing Then
                    Me.AddCriticalMessage("Ventilation air provision Missing")
                End If

                If oEngineerVisitAssetWorkSheet.TankID = Nothing Then
                    Me.AddCriticalMessage("Approved fuel Missing")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
