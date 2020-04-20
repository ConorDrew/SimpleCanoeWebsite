Namespace Entity

Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetValidatorComCat
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
                        Me.AddCriticalMessage("Landlords Appliance  Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.ApplianceTestedID = Nothing Then
                        Me.AddCriticalMessage("Appliance tested Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueFlowTestID = Nothing Then
                        Me.AddCriticalMessage("Gas hose field Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SpillageTestID = Nothing Then
                        Me.AddCriticalMessage("Electrical isolator field Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Manufactures info field Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("Gas isolation Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID = Nothing Then
                        Me.AddCriticalMessage("FSP fitted Missing")
                    End If

                    If oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID = Nothing Then
                        Me.AddCriticalMessage("pipework gastight Missing")
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
