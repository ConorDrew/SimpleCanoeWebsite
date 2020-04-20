Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitQCs

        Public Class EngineerVisitQCSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"
            Public Function [EngineerVisitQC_Get_EngineerVisitID](ByVal EngineerVisitID As Integer) As EngineerVisitQC
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitQC_Get_EngineerVisitID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitQC As New EngineerVisitQC
                        With oEngineerVisitQC
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitQCID = dt.Rows(0).Item("EngineerVisitQCID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetFTFCode = dt.Rows(0).Item("FTFCode")
                            .SetRecall = dt.Rows(0).Item("Recall")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetJobTypeIncorrect = dt.Rows(0).Item("JobTypeIncorrect")
                            .SetCustomerDetailsIncorrect = dt.Rows(0).Item("CustomerDetailsIncorrect")
                            .SetSorIncorrect = dt.Rows(0).Item("SorIncorrect")
                            .SetOrderNumberAttached = dt.Rows(0).Item("OrderNumberAttached")
                            .SetPaymentMethodDetailed = dt.Rows(0).Item("PaymentMethodDetailed")
                            .SetLabourTimeMissing = dt.Rows(0).Item("LabourTimeMissing")
                            .SetLGSRMissing = dt.Rows(0).Item("LGSRMissing")
                            .SetPartsConfirmation = dt.Rows(0).Item("PartsConfirmation")
                            .SetApplianceRecorded = dt.Rows(0).Item("ApplianceRecorded")
                            .SetJobUploadInTimeScale = dt.Rows(0).Item("JobUploadInTimeScale")
                            .SetPaymentMethodSelectionIncorrect = dt.Rows(0).Item("PaymentMethodSelectionIncorrect")
                            .SetPaymentCollection = dt.Rows(0).Item("PaymentCollection")
                            .SetEngineerPaymentReceived = dt.Rows(0).Item("EngineerPaymentReceived")
                            .SetPoorJobNotes = dt.Rows(0).Item("PoorJobNotes")
                            .SetDocumentsRecieved = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("DocumentsRecieved"))
                            .DateDocumentsRecieved = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("DateDocumentsRecieved"))
                            If dt.Columns.Contains("CustomerSigned") Then .SetCustomerSigned = dt.Rows(0).Item("CustomerSigned")
                        End With
                        oEngineerVisitQC.Exists = True
                        Return oEngineerVisitQC
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Insert](ByVal oEngineerVisitQC As EngineerVisitQC) As EngineerVisitQC
                _database.ClearParameter()
                AddParametersToCommand(oEngineerVisitQC)

                oEngineerVisitQC.SetEngineerVisitQCID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitQC_Insert"))
                oEngineerVisitQC.Exists = True
                Return oEngineerVisitQC
            End Function

            Public Sub [Update](ByVal oEngineerVisitQC As EngineerVisitQC)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitQCID", oEngineerVisitQC.EngineerVisitQCID, True)
                AddParametersToCommand(oEngineerVisitQC)
                _database.ExecuteSP_NO_Return("EngineerVisitQC_Update")
            End Sub

            Private Sub AddParametersToCommand(ByRef oEngineerVisitQC As EngineerVisitQC)
                With _database
                    .AddParameter("@EngineerVisitID", oEngineerVisitQC.EngineerVisitID, True)
                    .AddParameter("@FTFCode", oEngineerVisitQC.FTFCode, True)
                    .AddParameter("@Recall", oEngineerVisitQC.Recall, True)
                    .AddParameter("@EngineerID", oEngineerVisitQC.EngineerID, True)
                    .AddParameter("@JobTypeIncorrect", oEngineerVisitQC.JobTypeIncorrect, True)
                    .AddParameter("@CustomerDetailsIncorrect", oEngineerVisitQC.CustomerDetailsIncorrect, True)
                    .AddParameter("@SorIncorrect", oEngineerVisitQC.SorIncorrect, True)
                    .AddParameter("@OrderNumberAttached", oEngineerVisitQC.OrderNumberAttached, True)
                    .AddParameter("@PaymentMethodDetailed", oEngineerVisitQC.PaymentMethodDetailed, True)
                    .AddParameter("@LabourTimeMissing", oEngineerVisitQC.LabourTimeMissing, True)
                    .AddParameter("@LGSRMissing", oEngineerVisitQC.LGSRMissing, True)
                    .AddParameter("@PartsConfirmation", oEngineerVisitQC.PartsConfirmation, True)
                    .AddParameter("@ApplianceRecorded", oEngineerVisitQC.ApplianceRecorded, True)
                    .AddParameter("@JobUploadInTimeScale", oEngineerVisitQC.JobUploadInTimeScale, True)
                    .AddParameter("@PaymentMethodSelectionIncorrect", oEngineerVisitQC.PaymentMethodSelectionIncorrect, True)
                    .AddParameter("@PaymentCollection", oEngineerVisitQC.PaymentCollection, True)
                    .AddParameter("@EngineerPaymentReceived", oEngineerVisitQC.EngineerPaymentReceived, True)
                    .AddParameter("@PoorJobNotes", oEngineerVisitQC.PoorJobNotes, True)
                    .AddParameter("@DocumentsRecieved", oEngineerVisitQC.DocumentsRecieved, True)
                    If oEngineerVisitQC.DateDocumentsRecieved <> Nothing Then
                        .AddParameter("@DateDocumentsRecieved", oEngineerVisitQC.DateDocumentsRecieved, True)
                    End If
                    .AddParameter("@CustomerSigned", oEngineerVisitQC.CustomerSigned, True)
                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


