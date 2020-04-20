Namespace Entity

    Namespace Sites

        Public Class SiteValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oSite As Site)

                'make sure that contact object is valid
                If oSite.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oSite.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oSite.CustomerID = 0 Then
                    Me.AddCriticalMessage("Customer Missing")
                End If
                If oSite.RegionID = 0 Then
                    Me.AddCriticalMessage("Region Missing")
                End If
                If oSite.Address1.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Address1 Missing")
                End If
                If oSite.Postcode.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Postcode Missing")
                Else
                    If oSite.Postcode.Split("-").Length = 1 Then
                        Me.AddCriticalMessage("Postcode Format should have a dash in (xx-xxx or xxx-xxx or xxxx-xxx)")
                    Else
                        If oSite.Postcode.Split("-")(0).Trim.Length = 1 Or oSite.Postcode.Split("-")(0).Trim.Length >= 5 Then
                            Me.AddCriticalMessage("Postcode Format should have 2 - 4 characters before dash (xx-xxx or xxx-xxx or xxxx-xxx)")
                        End If
                        If oSite.Postcode.Split("-")(1).Trim.Length <> 3 Then
                            Me.AddCriticalMessage("Postcode Format should have 3 characters after dash (xx-xxx or xxx-xxx or xxxx-xxx)")
                        End If
                    End If
                End If

                Select Case True
                    Case IsGasway
                        If oSite.SiteID = 0 And oSite.SourceOfCustomerID = 0 Then
                            Me.AddCriticalMessage("Source Of Customer Missing")
                        End If

                        If oSite.SiteID = 0 And oSite.ReasonForContactID = 0 Then
                            Me.AddCriticalMessage("Reason For Contact Missing")
                        End If
                End Select

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace