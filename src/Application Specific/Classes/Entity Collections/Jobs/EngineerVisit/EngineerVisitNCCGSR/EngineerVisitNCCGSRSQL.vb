Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitNCCGSRs

        Public Class EngineerVisitNCCGSRSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerVisitNCCGSRID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitNCCGSRID", EngineerVisitNCCGSRID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Delete")
            End Sub

            Public Function [EngineerVisitNCCGSR_Get](ByVal EngineerVisitNCCGSRID As Integer) As EngineerVisitNCCGSR
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitNCCGSRID", EngineerVisitNCCGSRID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitNCCGSR As New EngineerVisitNCCGSR
                        With oEngineerVisitNCCGSR
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitNCCGSRID = dt.Rows(0).Item("EngineerVisitNCCGSRID")
                            .SetCorrectMaterialsUsedID = dt.Rows(0).Item("CorrectMaterialsUsedID")
                            .SetInstallationPipeWorkCorrectID = dt.Rows(0).Item("InstallationPipeWorkCorrectID")
                            .SetInstallationSafeToUseID = dt.Rows(0).Item("InstallationSafeToUseID")
                            .SetStrainerFittedID = dt.Rows(0).Item("StrainerFittedID")
                            .SetStrainerInspectedID = dt.Rows(0).Item("StrainerInspectedID")
                            .SetHeatingSystemTypeID = dt.Rows(0).Item("HeatingSystemTypeID")
                            .SetPartialHeatingID = dt.Rows(0).Item("PartialHeatingID")
                            .SetCylinderTypeID = dt.Rows(0).Item("CylinderTypeID")
                            .SetJacketID = dt.Rows(0).Item("JacketID")
                            .SetImmersionID = dt.Rows(0).Item("ImmersionID")
                            .SetRadiators = dt.Rows(0).Item("Radiators")
                            .SetCODetectorFittedID = dt.Rows(0).Item("CODetectorFittedID")
                            .SetApproxAgeOfBoiler = dt.Rows(0).Item("ApproxAgeOfBoiler")
                            .SetCertificateTypeID = dt.Rows(0).Item("CertificateTypeID")
                            .SetVisualInspectionSatisfactoryID = dt.Rows(0).Item("VisualInspectionSatisfactoryID")
                            .SetVisualInspectionReason = dt.Rows(0).Item("VisualInspectionReason")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetSITimerID = dt.Rows(0).Item("SITimerID")
                            .SetFillDiscID = dt.Rows(0).Item("FillDiscID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oEngineerVisitNCCGSR.Exists = True
                        Return oEngineerVisitNCCGSR
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisitNCCGSR_GetForEngineerVisit(ByVal EngineerVisitID As Integer) As EngineerVisitNCCGSR
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_GetForEngineerVisit")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitNCCGSR As New EngineerVisitNCCGSR
                        With oEngineerVisitNCCGSR
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitNCCGSRID = dt.Rows(0).Item("EngineerVisitNCCGSRID")
                            .SetCorrectMaterialsUsedID = dt.Rows(0).Item("CorrectMaterialsUsedID")
                            .SetInstallationPipeWorkCorrectID = dt.Rows(0).Item("InstallationPipeWorkCorrectID")
                            .SetInstallationSafeToUseID = dt.Rows(0).Item("InstallationSafeToUseID")
                            .SetStrainerFittedID = dt.Rows(0).Item("StrainerFittedID")
                            .SetStrainerInspectedID = dt.Rows(0).Item("StrainerInspectedID")
                            .SetHeatingSystemTypeID = dt.Rows(0).Item("HeatingSystemTypeID")
                            .SetPartialHeatingID = dt.Rows(0).Item("PartialHeatingID")
                            .SetCylinderTypeID = dt.Rows(0).Item("CylinderTypeID")
                            .SetJacketID = dt.Rows(0).Item("JacketID")
                            .SetImmersionID = dt.Rows(0).Item("ImmersionID")
                            .SetRadiators = dt.Rows(0).Item("Radiators")
                            .SetCODetectorFittedID = dt.Rows(0).Item("CODetectorFittedID")
                            .SetApproxAgeOfBoiler = dt.Rows(0).Item("ApproxAgeOfBoiler")
                            .SetCertificateTypeID = dt.Rows(0).Item("CertificateTypeID")
                            .SetVisualInspectionSatisfactoryID = dt.Rows(0).Item("VisualInspectionSatisfactoryID")
                            .SetVisualInspectionReason = dt.Rows(0).Item("VisualInspectionReason")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetSITimerID = dt.Rows(0).Item("SITimerID")
                            .SetFillDiscID = dt.Rows(0).Item("FillDiscID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oEngineerVisitNCCGSR.Exists = True
                        Return oEngineerVisitNCCGSR
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [EngineerVisitNCCGSR_Get_Friendly](ByVal engineerVisitNccGsrId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitNCCGSRID", engineerVisitNccGsrId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_Get_Friendly")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitNCCGSR.ToString
                Return New DataView(dt)
            End Function

            Public Function [EngineerVisitNCCGSR_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitNCCGSR_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitNCCGSR.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineerVisitNCCGSR As EngineerVisitNCCGSR) As EngineerVisitNCCGSR
                _database.ClearParameter()
                AddEngineerVisitNCCGSRParametersToCommand(oEngineerVisitNCCGSR)

                oEngineerVisitNCCGSR.SetEngineerVisitNCCGSRID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitNCCGSR_Insert"))
                oEngineerVisitNCCGSR.Exists = True
                Return oEngineerVisitNCCGSR
            End Function

            Public Sub [Update](ByVal oEngineerVisitNCCGSR As EngineerVisitNCCGSR)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitNCCGSRID", oEngineerVisitNCCGSR.EngineerVisitNCCGSRID, True)
                AddEngineerVisitNCCGSRParametersToCommand(oEngineerVisitNCCGSR)
                _database.ExecuteSP_NO_Return("EngineerVisitNCCGSR_Update")
            End Sub

            Private Sub AddEngineerVisitNCCGSRParametersToCommand(ByRef oEngineerVisitNCCGSR As EngineerVisitNCCGSR)
                With _database
                    .AddParameter("@CorrectMaterialsUsedID", oEngineerVisitNCCGSR.CorrectMaterialsUsedID, True)
                    .AddParameter("@InstallationPipeWorkCorrectID", oEngineerVisitNCCGSR.InstallationPipeWorkCorrectID, True)
                    .AddParameter("@InstallationSafeToUseID", oEngineerVisitNCCGSR.InstallationSafeToUseID, True)
                    .AddParameter("@StrainerFittedID", oEngineerVisitNCCGSR.StrainerFittedID, True)
                    .AddParameter("@StrainerInspectedID", oEngineerVisitNCCGSR.StrainerInspectedID, True)
                    .AddParameter("@HeatingSystemTypeID", oEngineerVisitNCCGSR.HeatingSystemTypeID, True)
                    .AddParameter("@PartialHeatingID", oEngineerVisitNCCGSR.PartialHeatingID, True)
                    .AddParameter("@CylinderTypeID", oEngineerVisitNCCGSR.CylinderTypeID, True)
                    .AddParameter("@JacketID", oEngineerVisitNCCGSR.JacketID, True)
                    .AddParameter("@ImmersionID", oEngineerVisitNCCGSR.ImmersionID, True)
                    .AddParameter("@Radiators", oEngineerVisitNCCGSR.Radiators, True)
                    .AddParameter("@CODetectorFittedID", oEngineerVisitNCCGSR.CODetectorFittedID, True)
                    .AddParameter("@ApproxAgeOfBoiler", oEngineerVisitNCCGSR.ApproxAgeOfBoiler, True)
                    .AddParameter("@CertificateTypeID", oEngineerVisitNCCGSR.CertificateTypeID, True)
                    .AddParameter("@VisualInspectionSatisfactoryID", oEngineerVisitNCCGSR.VisualInspectionSatisfactoryID, True)
                    .AddParameter("@VisualInspectionReason", oEngineerVisitNCCGSR.VisualInspectionReason, True)
                    .AddParameter("@EngineerVisitID", oEngineerVisitNCCGSR.EngineerVisitID, True)
                    .AddParameter("@FillDiscID", oEngineerVisitNCCGSR.FillDiscID, True)
                    .AddParameter("@SITimerID", oEngineerVisitNCCGSR.SITimerID, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace