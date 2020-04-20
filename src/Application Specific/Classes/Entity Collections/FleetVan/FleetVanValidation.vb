Namespace Entity

    Namespace FleetVans

        Public Class FleetVanValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVan As FleetVan)

                'make sure that contact object is valid
                If oFleetVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oFleetVan.VanTypeID = 0 Then
                    Me.AddCriticalMessage("Van type missing")
                End If
                If oFleetVan.Registration.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Registration missing")
                End If
                If oFleetVan.Mileage = 0 Then
                    Me.AddCriticalMessage("Current mileage missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetVanTypeValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVanType As FleetVanType)

                'make sure that contact object is valid
                If oFleetVanType.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVanType.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If


                If oFleetVanType.Make.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Make Missing")
                End If
                If oFleetVanType.Model.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Model Missing")
                End If
                If oFleetVanType.MileageServiceInterval < 0 Then
                    Me.AddCriticalMessage("The mileage service intervals cannot be less than 0")
                End If
                If oFleetVanType.DateServiceInterval < 0 Then
                    Me.AddCriticalMessage("The date service intervals cannot be less than 0")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetVanEngineerValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVan As FleetVanEngineer)

                'make sure that contact object is valid
                If oFleetVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oFleetVan.VanID = 0 Then
                    Me.AddCriticalMessage("Van type missing")
                End If
                If oFleetVan.StartDate = Nothing Then
                    Me.AddCriticalMessage("Start date missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetVanMaintenanceValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVan As FleetVanMaintenance)

                'make sure that contact object is valid
                If oFleetVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                With oFleetVan
                    If .LastServiceMileage = 0 Then
                        Me.AddCriticalMessage("Van last service mileage missing")
                    End If
                    If .MOTExpiry < Date.Now Then
                        Me.AddCriticalMessage("MOT has expired")
                    End If
                    If .RoadTaxExpiry < Date.Now Then
                        Me.AddCriticalMessage("Road tax has expired")
                    End If
                    If .Breakdown.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Please add breakdown company")
                    End If
                End With

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetVanFaultValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVan As FleetVanFault)

                'make sure that contact object is valid
                If oFleetVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                With oFleetVan
                    If .FaultTypeID = 0 Then
                        Me.AddCriticalMessage("Fault type missing")
                    End If
                    If .Notes.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Notes are missing")
                    End If
                End With

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetVanContractValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetVan As FleetVanContract)

                'make sure that contact object is valid
                If oFleetVan.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetVan.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                With oFleetVan
                    If .VanID = 0 Then
                        Me.AddCriticalMessage("Van missing")
                    End If
                    If .Lessor.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Lessor missing")
                    End If
                    If .ProcurementMethod = 0 Then
                        Me.AddCriticalMessage("Procurement method missing")
                    End If
                End With

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

        Public Class FleetEquipmentValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oFleetEquipment As FleetEquipment)

                'make sure that contact object is valid
                If oFleetEquipment.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oFleetEquipment.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                With oFleetEquipment
                    If .Name.Trim.Length = 0 Then
                        Me.AddCriticalMessage("Name missing")
                    End If
                    If .Cost = 0 Then
                        Me.AddCriticalMessage("Cost missing")
                    End If
                End With

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class
    End Namespace

End Namespace
