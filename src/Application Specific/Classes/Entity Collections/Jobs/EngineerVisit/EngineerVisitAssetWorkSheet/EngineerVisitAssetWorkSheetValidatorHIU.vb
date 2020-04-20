Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorHIU
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
                    Me.AddCriticalMessage("Landlord Appliance Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                    Me.AddCriticalMessage("Check for leaks Missing")
                End If

                If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                    Me.AddCriticalMessage("Port valves Missing")
                End If

                If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Strainers Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("Pumps Missing")
                End If

                If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                    Me.AddCriticalMessage("System operation Missing")
                End If

                If oEngineerVisitAssetWorkSheet.Nozzle = Nothing Then
                    Me.AddCriticalMessage("Recorded results Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID = Nothing Then
                    Me.AddCriticalMessage("Appliance service Missing")
                End If

                If oEngineerVisitAssetWorkSheet.ApplianceSafeID = Nothing Then
                    Me.AddCriticalMessage("Appliance safety Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
