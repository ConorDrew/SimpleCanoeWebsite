Namespace Entity

    Namespace Documentss

        Public Class DocumentsValidator
            'make sure that contact object is valid
            Inherits BaseValidator

            Public Sub Validate(ByVal oDocuments As Documents)

                'make sure that contact object is valid
                If oDocuments.Errors.Count > 0 Then
                    Dim de As DictionaryEntry
                    For Each de In oDocuments.Errors
                        Me.AddCriticalMessage(CStr(de.Value))
                    Next
                End If

                If oDocuments.TableEnumID = CInt(Entity.Sys.Enums.TableNames.NO_TABLE) Then
                    Me.AddCriticalMessage("Document Entity Missing")
                End If
                If oDocuments.RecordID = 0 Then
                    Me.AddCriticalMessage("Document Record ID Missing")
                End If
                If oDocuments.DocumentTypeID = 0 Then
                    Me.AddCriticalMessage("Document Type Missing")
                End If
                If oDocuments.Name.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Document Reference Missing")
                End If
                If oDocuments.Location.Trim.Length = 0 Then
                    Me.AddCriticalMessage("Document Missing")
                End If

                If Me.ValidatorMessages.CriticalMessages.Count > 0 Then
                    Throw New ValidationException(Me)
                End If

            End Sub

        End Class

    End Namespace

End Namespace
