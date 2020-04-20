Namespace Entity

    Namespace Jobs

        Public Class JobValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oJob As Job)

                'make sure that contact object is valid
                If oJob.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oJob.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oJob.PropertyID = 0 Then
                    Me.AddCriticalMessage("Property not set")
                End If
                If oJob.JobNumber.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Job Number not set")
                End If
                If oJob.JobTypeID = 0 Then
                    Me.AddCriticalMessage("Job Type not selected")
                End If
                If oJob.FOC = 0 And oJob.OTI = 0 And oJob.POC = 0 Then
                    Me.AddCriticalMessage("Payment Method not selected")
                End If

                Dim jobOfWorkIndex As Integer = 1
                For Each jobOfWork As Entity.JobOfWorks.JobOfWork In oJob.JobOfWorks
                    If jobOfWork.Priority = 0 And DB.Job.JobOfWork_Required_Priority(oJob.PropertyID) = True Then
                        Me.AddCriticalMessage("Job Of Work #" & jobOfWorkIndex & " Priority Missing")
                    End If
                    Dim jobOfItemIndex As Integer = 1
                    For Each jobItem As Entity.JobItems.JobItem In jobOfWork.JobItems
                        If jobItem.Summary.Trim.Length = 0 Then
                            Me.AddCriticalMessage("Job Of Work #" & jobOfWorkIndex & " Job Item #" & jobOfItemIndex & " Summary Missing")
                        End If
                        jobOfItemIndex += 1
                    Next

                    Dim engineerVisitIndex As Integer = 1
                    For Each engineerVisit As Entity.EngineerVisits.EngineerVisit In jobOfWork.EngineerVisits
                        If engineerVisit.StatusEnumID = 0 Then
                            Me.AddCriticalMessage("Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Status Not Selected")
                        End If
                        If engineerVisit.NotesToEngineer.Trim.Length = 0 Then
                            Me.AddCriticalMessage("Job Of Work #" & jobOfWorkIndex & " Visit #" & engineerVisitIndex & " Notes To Engineer Missing")
                        End If
                        engineerVisitIndex += 1
                    Next

                    jobOfWorkIndex += 1
                Next

                'If oJob.Assets.Count = 0 Then
                '    If ShowMessage("You have not selected any appliances - would you like to continue anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                '        Me.AddCriticalMessage("No appliances selected")
                '    End If
                'End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If
            End Sub

        End Class

    End Namespace

End Namespace
