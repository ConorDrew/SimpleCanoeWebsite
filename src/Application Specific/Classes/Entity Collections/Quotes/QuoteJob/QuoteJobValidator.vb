Namespace Entity

    Namespace QuoteJobs

        Public Class QuoteJobValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal qJob As QuoteJob, ByVal JobItems As DataView)

                'make sure that contact object is valid
                If qJob.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In qJob.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If qJob.SiteID = 0 Then
                    Me.AddCriticalMessage("* Property not set")
                End If
                If qJob.Reference.Trim.Length = 0 Then
                    Me.AddCriticalMessage("*Reference Missing")
                End If

                If Not qJob.Exists Then
                    qJob.SetStatusEnumID = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated)
                Else
                    If qJob.StatusEnumID = 0 Then
                        Me.AddCriticalMessage("*Status Missing")
                    End If
                End If

                'If Not IsNumeric(qJob.MileageRate) Then
                '    Me.AddCriticalMessage("*Mileage Rate must be Numeric")
                'End If

                'If Not IsNumeric(qJob.EstimatedMileage) Then
                '    Me.AddCriticalMessage("*Estimated Mileage must be Numeric")
                'End If

                If Not IsNumeric(qJob.PartsAndProductsMarkup) Then
                    Me.AddCriticalMessage("*Parts And Products Markup must be Numeric")
                End If

                If Not IsNumeric(qJob.ScheduleOfRatesMarkup) Then
                    Me.AddCriticalMessage("*Schedule Of Rates Markup must be Numeric")
                End If

                'Dim jobOfWorkIndex As Integer = 1
                'For Each jobOfWork As Entity.QuoteJobOfWorks.QuoteJobOfWork In qJob.QuoteJobOfWorks
                '    Dim jobOfItemIndex As Integer = 1
                '    For Each jobItem As Entity.QuoteJobItems.QuoteJobItem In jobOfWork.QuoteJobItems
                '        If jobItem.Summary.Trim.Length = 0 Then
                '            Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Job Item #" & jobOfItemIndex & " Summary Missing")
                '        End If
                '        jobOfItemIndex += 1
                '    Next

                '    Dim engineerVisitIndex As Integer = 1
                '    For Each engineerVisit As Entity.QuoteEngineerVisits.QuoteEngineerVisit In jobOfWork.QuoteEngineerVisits
                '        If engineerVisit.StatusEnumID = 0 Then
                '            Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Status Not Selected")
                '        End If
                '        If engineerVisit.NotesToEngineer.Trim.Length = 0 Then
                '            Me.AddCriticalMessage("*Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Notes To Engineer Missing")
                '        End If
                '        engineerVisitIndex += 1
                '    Next

                '    jobOfWorkIndex += 1
                'Next

                'If JobItems.Table.Rows.Count = 0 Then
                '    Me.AddCriticalMessage("*Quote Items Missing")
                'End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

        End Class

    End Namespace

End Namespace
