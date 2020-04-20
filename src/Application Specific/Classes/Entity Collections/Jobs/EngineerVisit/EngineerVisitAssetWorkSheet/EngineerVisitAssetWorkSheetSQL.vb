Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerVisitAssetWorkSheetID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", EngineerVisitAssetWorkSheetID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Delete")
            End Sub

            Public Function [EngineerVisitAssetWorkSheet_Get](ByVal EngineerVisitAssetWorkSheetID As Integer) As EngineerVisitAssetWorkSheet
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", EngineerVisitAssetWorkSheetID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitAssetWorkSheet As New EngineerVisitAssetWorkSheet
                        With oEngineerVisitAssetWorkSheet
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitAssetWorkSheetID = dt.Rows(0).Item("EngineerVisitAssetWorkSheetID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetAssetID = dt.Rows(0).Item("AssetID")
                            .SetFlueTerminationSatisfactoryID = dt.Rows(0).Item("FlueTerminationSatisfactoryID")
                            .SetFlueFlowTestID = dt.Rows(0).Item("FlueFlowTestID")
                            .SetSpillageTestID = dt.Rows(0).Item("SpillageTestID")
                            .SetVentilationProvisionSatisfactoryID = dt.Rows(0).Item("VentilationProvisionSatisfactoryID")
                            .SetSafetyDeviceOperationID = dt.Rows(0).Item("SafetyDeviceOperationID")
                            .SetDHWFlowRate = dt.Rows(0).Item("DHWFlowRate")
                            .SetColdWaterTemp = dt.Rows(0).Item("ColdWaterTemp")
                            .SetDHWTemp = dt.Rows(0).Item("DHWTemp")
                            .SetInletStaticPressure = dt.Rows(0).Item("InletStaticPressure")
                            .SetInletWorkingPressure = dt.Rows(0).Item("InletWorkingPressure")
                            .SetMinBurnerPressure = dt.Rows(0).Item("MinBurnerPressure")
                            .SetMaxBurnerPressure = dt.Rows(0).Item("MaxBurnerPressure")
                            .SetCO2 = dt.Rows(0).Item("CO2")
                            .SetCO2CORatio = dt.Rows(0).Item("CO2CORatio")
                            .SetLandlordsApplianceID = dt.Rows(0).Item("LandlordsApplianceID")
                            .SetApplianceServiceOrInspectedID = dt.Rows(0).Item("ApplianceServiceOrInspectedID")
                            .SetApplianceTestedID = dt.Rows(0).Item("ApplianceTestedID")
                            .SetApplianceSafeID = dt.Rows(0).Item("ApplianceSafeID")
                            .SetVisualConditionOfFlueSatisfactoryID = dt.Rows(0).Item("VisualConditionOfFlueSatisfactoryID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetNozzle = dt.Rows(0).Item("Nozzle")
                            .SetReading = dt.Rows(0).Item("ReadingType")
                            .SetTankID = dt.Rows(0).Item("TankID")
                            .SetBMake = dt.Rows(0).Item("BurMake")
                            .SetBModel = dt.Rows(0).Item("BurModel")
                            .SetSweepOutcomeID = dt.Rows(0).Item("SweepOutcomeID")
                            .SetOverallID = dt.Rows(0).Item("OverallID")
                            .SetDischargeID = dt.Rows(0).Item("DischargeID")
                        End With
                        oEngineerVisitAssetWorkSheet.Exists = True
                        Return oEngineerVisitAssetWorkSheet
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [EngineerVisitAssetWorkSheet_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitAssetWorkSheet_GetForVisit(ByVal EngineerVisitID As Integer, Optional ByVal Oil As Integer = -1) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@Fuel", Oil, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_GetForVisit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_Friendly(ByVal engineerVisitAssetWorkSheetId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", engineerVisitAssetWorkSheetId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Get_Friendly")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineerVisitAssetWorkSheet As EngineerVisitAssetWorkSheet) As EngineerVisitAssetWorkSheet
                _database.ClearParameter()
                AddEngineerVisitAssetWorkSheetParametersToCommand(oEngineerVisitAssetWorkSheet)

                oEngineerVisitAssetWorkSheet.SetEngineerVisitAssetWorkSheetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitAssetWorkSheet_Insert"))
                oEngineerVisitAssetWorkSheet.Exists = True
                Return oEngineerVisitAssetWorkSheet
            End Function

            Public Function [EngineerVisitAssetWorkSheet_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oEngineerVisitAssetWorkSheet As EngineerVisitAssetWorkSheet)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", oEngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheetID, True)
                AddEngineerVisitAssetWorkSheetParametersToCommand(oEngineerVisitAssetWorkSheet)
                _database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Update")
            End Sub

            Private Sub AddEngineerVisitAssetWorkSheetParametersToCommand(ByRef oEngineerVisitAssetWorkSheet As EngineerVisitAssetWorkSheet)
                With _database
                    .AddParameter("@EngineerVisitID", oEngineerVisitAssetWorkSheet.EngineerVisitID, True)
                    .AddParameter("@AssetID", oEngineerVisitAssetWorkSheet.AssetID, True)
                    .AddParameter("@FlueTerminationSatisfactoryID", oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID, True)
                    .AddParameter("@FlueFlowTestID", oEngineerVisitAssetWorkSheet.FlueFlowTestID, True)
                    .AddParameter("@SpillageTestID", oEngineerVisitAssetWorkSheet.SpillageTestID, True)
                    .AddParameter("@VentilationProvisionSatisfactoryID", oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID, True)
                    .AddParameter("@SafetyDeviceOperationID", oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID, True)
                    .AddParameter("@DHWFlowRate", oEngineerVisitAssetWorkSheet.DHWFlowRate, True)
                    .AddParameter("@ColdWaterTemp", oEngineerVisitAssetWorkSheet.ColdWaterTemp, True)
                    .AddParameter("@DHWTemp", oEngineerVisitAssetWorkSheet.DHWTemp, True)
                    .AddParameter("@InletStaticPressure", oEngineerVisitAssetWorkSheet.InletStaticPressure, True)
                    .AddParameter("@InletWorkingPressure", oEngineerVisitAssetWorkSheet.InletWorkingPressure, True)
                    .AddParameter("@MinBurnerPressure", oEngineerVisitAssetWorkSheet.MinBurnerPressure, True)
                    .AddParameter("@MaxBurnerPressure", oEngineerVisitAssetWorkSheet.MaxBurnerPressure, True)
                    .AddParameter("@CO2", oEngineerVisitAssetWorkSheet.CO2, True)
                    .AddParameter("@CO2CORatio", oEngineerVisitAssetWorkSheet.CO2CORatio, True)
                    .AddParameter("@LandlordsApplianceID", oEngineerVisitAssetWorkSheet.LandlordsApplianceID, True)
                    .AddParameter("@ApplianceServiceOrInspectedID", oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID, True)
                    .AddParameter("@ApplianceSafeID", oEngineerVisitAssetWorkSheet.ApplianceSafeID, True)
                    .AddParameter("@VisualConditionOfFlueSatisfactoryID", oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID, True)
                    .AddParameter("@ApplianceTestedID", oEngineerVisitAssetWorkSheet.ApplianceTestedID, True)
                    .AddParameter("@TankID", oEngineerVisitAssetWorkSheet.TankID, True)
                    .AddParameter("@ReadingType", oEngineerVisitAssetWorkSheet.Reading, True)
                    .AddParameter("@Nozzle", oEngineerVisitAssetWorkSheet.Nozzle, True)
                    .AddParameter("@BurMake", oEngineerVisitAssetWorkSheet.BMake, True)
                    .AddParameter("@BurModel", oEngineerVisitAssetWorkSheet.BModel, True)
                    .AddParameter("@Sweep", oEngineerVisitAssetWorkSheet.SweepOutcomeID, True)
                    .AddParameter("@Overall", oEngineerVisitAssetWorkSheet.OverallID, True)
                    .AddParameter("@Discharge", oEngineerVisitAssetWorkSheet.DischargeID, True)
                End With
            End Sub

            Public Function Products_LastGSRDone(ByVal dateFrom As DateTime, ByVal dateTo As DateTime,
                                                 ByVal regionId As Integer,
                                                 Optional ByVal customerId As Integer = 0,
                                                 Optional ByVal onContract As Integer = 0,
                                                 Optional ByVal tenantsAppliance As Boolean = False,
                                                 Optional ByVal printed As Boolean = False) As DataView
                _database.ClearParameter()
                _database.AddParameter("@DateFrom", dateFrom, True)
                _database.AddParameter("@DateTo", dateTo, True)
                _database.AddParameter("@CustomerID", customerId, True)
                If regionId > 0 Then _database.AddParameter("@RegionID", regionId, True)
                If onContract > 0 Then
                    If onContract = 1 Then
                        _database.AddParameter("@OnContract", True, True)
                    End If
                    If onContract = 2 Then
                        _database.AddParameter("@OnContract", False, True)
                    End If
                End If
                _database.AddParameter("@TenantsAppliance", tenantsAppliance, True)
                _database.AddParameter("@Printed", printed, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Products_LastGSRDone_New")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
                Return New DataView(dt)
            End Function

            Public Sub PrintedGSRLettersInsert(ByVal AssetID As Integer, ByVal DateDue As DateTime, Optional ByVal otherContact As Boolean = False)
                _database.ClearParameter()
                _database.AddParameter("@AssetID", AssetID, True)
                _database.AddParameter("@DateDue", DateDue, True)
                _database.AddParameter("PrintedDate", Now, True)
                If otherContact Then
                    _database.AddParameter("OtherContact", True, True)
                End If

                _database.ExecuteSP_NO_Return("PrintedGSRLettersInsert")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace