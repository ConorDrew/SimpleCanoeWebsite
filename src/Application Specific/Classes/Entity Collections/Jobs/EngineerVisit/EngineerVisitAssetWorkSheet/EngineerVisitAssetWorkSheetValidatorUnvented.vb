Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorUnvented
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
                    Me.AddCriticalMessage("Appliance Safe Missing")
                End If

                If oEngineerVisitAssetWorkSheet.LandlordsApplianceID = Nothing Then
                    Me.AddCriticalMessage("Water pressure Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                    Me.AddCriticalMessage("Cylinder integrity Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                    Me.AddCriticalMessage("Pre-Charge pressure Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Filter/Strainer check  Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Sacrificial anode check Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Expansion Gap check  Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = Nothing Then
                    Me.AddCriticalMessage("Tundish check Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SweepOutcomeID = Nothing Then
                    Me.AddCriticalMessage("Connection check Missing")
                End If

                If oEngineerVisitAssetWorkSheet.OverallID = Nothing Then
                    Me.AddCriticalMessage("Discharge pipe checks Missing")
                End If

                If oEngineerVisitAssetWorkSheet.DischargeID = Nothing Then
                    Me.AddCriticalMessage("temp/ pressure relief value Missing")
                End If

                If oEngineerVisitAssetWorkSheet.TankID = Nothing Then
                    Me.AddCriticalMessage("expansion value check Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = Nothing Then
                    Me.AddCriticalMessage("water pressure / flow rates check  Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceSafeID = Nothing Then
                    Me.AddCriticalMessage("Service record  Missing")
                End If


                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
