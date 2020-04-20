Namespace Entity

    Namespace FleetVans

        Public Class FleetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

            Public Function FleetJobType_GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetJobType_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetJobType.ToString
                Return New DataView(dt)
            End Function
        End Class

        Public Class FleetVanSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVan As FleetVan)
                With _database
                    .AddParameter("@Registration", oFleetVan.Registration, True)
                    .AddParameter("@VanTypeID", oFleetVan.VanTypeID, True)
                    .AddParameter("@Mileage", oFleetVan.Mileage, True)
                    .AddParameter("@AverageMileage", oFleetVan.AverageMileage, True)
                    .AddParameter("@Department", oFleetVan.Department, True)
                    .AddParameter("@Notes", oFleetVan.Notes, True)
                    .AddParameter("@TyreSize", oFleetVan.TyreSize, True)
                End With
            End Sub

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVan_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanType.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Returned() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVan_GetAll_Returned")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanType.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal vanId As Integer) As FleetVan
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVan_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVan
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetRegistration = dt.Rows(0).Item("Registration")
                            .SetVanTypeID = dt.Rows(0).Item("VanTypeID")
                            .SetMileage = dt.Rows(0).Item("Mileage")
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetDepartment = dt.Rows(0).Item("Department")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetReturned = Entity.Sys.Helper.MakeBooleanValid(
                                dt.Rows(0).Item("Returned"))
                            If dt.Columns.Contains("TyreSize") Then .SetTyreSize = dt.Rows(0).Item("TyreSize")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByRegistration](ByVal registration As String) As FleetVan
                _database.ClearParameter()
                _database.AddParameter("@Registration", registration)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVan_Get_ByRegistrationTrim")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVan
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetRegistration = dt.Rows(0).Item("Registration")
                            .SetVanTypeID = dt.Rows(0).Item("VanTypeID")
                            .SetMileage = dt.Rows(0).Item("Mileage")
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetDepartment = dt.Rows(0).Item("Department")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetReturned = Entity.Sys.Helper.MakeBooleanValid(
                                dt.Rows(0).Item("Returned"))
                            If dt.Columns.Contains("TyreSize") Then .SetTyreSize = dt.Rows(0).Item("TyreSize")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_NextVanID]() As Integer
                _database.ClearParameter()
                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVan_Get_NextVan"))
            End Function

            Public Function [Update](ByVal oVan As FleetVan) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanID", oVan.VanID, True)
                AddParametersToCommand(oVan)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVan_Update") = 1)
            End Function

            Public Function [Insert](ByVal van As FleetVan) As FleetVan
                _database.ClearParameter()
                AddParametersToCommand(van)

                van.SetVanID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVan_Insert"))
                van.Exists = True
                Return van
            End Function

            Public Function [Search](ByVal Criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", Criteria, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVan_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVan.ToString
                Return New DataView(dt)
            End Function

            Public Function [ReturnVan](ByVal vanID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID, True)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVan_ReturnVan") = 1)
            End Function

            Public Function [VanAudit_Get](ByVal vanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@FleetVanID", vanID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanAudit_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString
                Return New DataView(dt)
            End Function

            Public Sub [VanAudit_Insert](ByVal vanID As Integer, ByVal actionChange As String)
                _database.ClearParameter()

                _database.AddParameter("@FleetVanID", vanID, True)
                _database.AddParameter("@ActionChange", actionChange, True)
                _database.AddParameter("@ActionDateTime", DateTime.Now, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("FleetVanAudit_Insert")
            End Sub
#End Region

        End Class

        Public Class FleetVanTypeSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVanType As FleetVanType)
                With _database
                    .AddParameter("@Make", oFleetVanType.Make, True)
                    .AddParameter("@Model", oFleetVanType.Model, True)
                    .AddParameter("@MileageServiceInterval", oFleetVanType.MileageServiceInterval, True)
                    .AddParameter("@DateServiceInterval", oFleetVanType.DateServiceInterval, True)
                    .AddParameter("@GrossVehicleWeight", oFleetVanType.GrossVehicleWeight, True)
                    .AddParameter("@Payload", oFleetVanType.Payload, True)
                End With
            End Sub

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanType_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanType.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal vanTypeId As Integer) As FleetVanType
                _database.ClearParameter()
                _database.AddParameter("@VanTypeID", vanTypeId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanType_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVanType As New FleetVanType
                        With oVanType
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanTypeID = dt.Rows(0).Item("VanTypeID")
                            .SetMake = dt.Rows(0).Item("Make")
                            .SetModel = dt.Rows(0).Item("Model")
                            .SetMileageServiceInterval = dt.Rows(0).Item("MileageServiceInterval")
                            .SetDateServiceInterval = dt.Rows(0).Item("DateServiceInterval")
                            If dt.Columns.Contains("GrossVehicleWeight") Then .SetGrossVehicleWeight = dt.Rows(0).Item("GrossVehicleWeight")
                            If dt.Columns.Contains("Payload") Then .SetPayload = dt.Rows(0).Item("Payload")
                        End With
                        oVanType.Exists = True
                        Return oVanType
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Insert](ByVal vanType As FleetVanType) As FleetVanType
                _database.ClearParameter()
                AddParametersToCommand(vanType)

                vanType.SetVanTypeID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanType_Insert"))
                vanType.Exists = True
                Return vanType
            End Function

            Public Function [Update](ByVal vanType As FleetVanType) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanTypeID", vanType.VanTypeID, True)
                AddParametersToCommand(vanType)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanType_Update") = 1)
            End Function

            Public Function [Delete](ByVal vanTypeID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanTypeID", vanTypeID, True)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanType_Delete") = 1)
            End Function

            Public Function [Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanType_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanType.ToString
                Return New DataView(dt)
            End Function

#End Region
        End Class

        Public Class FleetVanEngineerSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVan As FleetVanEngineer)
                With _database
                    .AddParameter("@VanID", oFleetVan.VanID, True)
                    .AddParameter("@EngineerID", oFleetVan.EngineerID, True)
                    .AddParameter("@StartDateTime", oFleetVan.StartDate, True)
                    .AddParameter("@EndDateTime", IIf(oFleetVan.EndDate <> Nothing, oFleetVan.EndDate, DBNull.Value),
                                  True)
                End With
            End Sub

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanType.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ByVanID(ByVal vanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_ForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ByEngineerID(ByVal engineerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_Get_EngineerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Trans(ByVal where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Where", where, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_Trans")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal vanEngineerID As Integer) As FleetVanEngineer
                _database.ClearParameter()
                _database.AddParameter("@VanEngineerID", vanEngineerID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVanEngineer As New FleetVanEngineer
                        With oVanEngineer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanEngineerID = dt.Rows(0).Item("VanEngineerID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .StartDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("StartDateTime"))
                            .EndDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("EndDateTime"))
                        End With
                        oVanEngineer.Exists = True
                        Return oVanEngineer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByVanID](ByVal vanID As Integer) As FleetVanEngineer
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEngineer_Get_VanID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVanEngineer As New FleetVanEngineer
                        With oVanEngineer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanEngineerID = dt.Rows(0).Item("VanEngineerID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .StartDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("StartDateTime"))
                            .EndDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("EndDateTime"))
                        End With
                        oVanEngineer.Exists = True
                        Return oVanEngineer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Update](ByVal oVan As FleetVanEngineer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanEngineerID", oVan.VanEngineerID, True)
                AddParametersToCommand(oVan)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanEngineer_Update") = 1)
            End Function

            Public Function [Insert](ByVal van As FleetVanEngineer) As FleetVanEngineer
                _database.ClearParameter()
                AddParametersToCommand(van)

                van.SetVanEngineerID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanEngineer_Insert"))
                van.Exists = True
                Return van
            End Function

            Public Function [Delete](ByVal oVanEngineerID As Integer, Optional ByVal endDate As DateTime = Nothing) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanEngineerID", oVanEngineerID, True)
                If endDate <> Nothing Then
                    _database.AddParameter("@EndDate", endDate, True)
                End If
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanEngineer_Delete") = 1)
            End Function
#End Region

        End Class

        Public Class FleetVanMaintenanceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVan As FleetVanMaintenance)
                With _database
                    .AddParameter("@VanID", oFleetVan.VanID, True)
                    .AddParameter("@LastService", oFleetVan.LastService, True)
                    .AddParameter("@NextService", oFleetVan.NextService, True)
                    .AddParameter("@LastServiceMileage", oFleetVan.LastServiceMileage, True)
                    .AddParameter("@MOTExpiry", oFleetVan.MOTExpiry, True)
                    .AddParameter("@RoadTaxExpiry", oFleetVan.RoadTaxExpiry, True)
                    .AddParameter("@Breakdown", oFleetVan.Breakdown, True)
                    .AddParameter("@BreakdownExpiry", oFleetVan.BreakdownExpiry, True)
                    .AddParameter("@WarrantyExpiry", oFleetVan.WarrantyExpiry, True)
                End With
            End Sub

            Public Function [Get](ByVal vanMaintenanceID As Integer) As FleetVanMaintenance
                _database.ClearParameter()
                _database.AddParameter("@VanMaintenanceID", vanMaintenanceID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanMaintenance_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanMaintenance
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanMaintenanceID = dt.Rows(0).Item("VanMaintenanceID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .LastService = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("LastService"))
                            .NextService = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("NextService"))
                            .SetLastServiceMileage = dt.Rows(0).Item("LastServiceMileage")
                            .MOTExpiry = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("MOTExpiry"))
                            .RoadTaxExpiry = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("RoadTaxExpiry"))
                            .SetBreakdown = dt.Rows(0).Item("Breakdown")
                            If dt.Columns.Contains("WarrantyExpiry") Then .WarrantyExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("WarrantyExpiry"))
                            If dt.Columns.Contains("BreakdownExpiry") Then .BreakdownExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("BreakdownExpiry"))
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByVanID](ByVal vanID As Integer) As FleetVanMaintenance
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanMaintenance_Get_ForVan")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanMaintenance
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanMaintenanceID = dt.Rows(0).Item("VanMaintenanceID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .LastService = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("LastService"))
                            .NextService = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("NextService"))
                            .SetLastServiceMileage = dt.Rows(0).Item("LastServiceMileage")
                            .MOTExpiry = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("MOTExpiry"))
                            .RoadTaxExpiry = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("RoadTaxExpiry"))
                            .SetBreakdown = dt.Rows(0).Item("Breakdown")
                            If dt.Columns.Contains("WarrantyExpiry") Then .WarrantyExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("WarrantyExpiry"))
                            If dt.Columns.Contains("BreakdownExpiry") Then .BreakdownExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("BreakdownExpiry"))
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Update](ByVal oVan As FleetVanMaintenance) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanMaintenanceID", oVan.VanMaintenanceID, True)
                AddParametersToCommand(oVan)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanMaintenance_Update") = 1)
            End Function

            Public Function [Insert](ByVal van As FleetVanMaintenance) As FleetVanMaintenance
                _database.ClearParameter()
                AddParametersToCommand(van)

                van.SetVanMaintenanceID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanMaintenance_Insert"))
                van.Exists = True
                Return van
            End Function
#End Region

        End Class

        Public Class FleetVanFaultSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVan As FleetVanFault)
                With _database
                    .AddParameter("@VanID", oFleetVan.VanID, True)
                    .AddParameter("@FaultTypeID", oFleetVan.FaultTypeID, True)
                    .AddParameter("@FaultDate", oFleetVan.FaultDate, True)
                    If oFleetVan.ResolvedDate <> Nothing Then
                        .AddParameter("@ResolvedDate", oFleetVan.ResolvedDate, True)
                    End If
                    .AddParameter("@EngineerNotes", oFleetVan.EngineerNotes, True)
                    .AddParameter("@Notes", oFleetVan.Notes, True)
                    .AddParameter("@JobID", oFleetVan.JobID, True)
                    .AddParameter("@UserID", loggedInUser.UserID, True)
                    .AddParameter("@Archive", oFleetVan.Archive, True)
                End With
            End Sub

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Trans(ByVal where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Where", where, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_Trans")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Unresolved() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_Unresolved")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Unresolved_WithNoJob() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_Unresolved_WithNoJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ByVanID(ByVal vanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_ForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal vanFaultID As Integer) As FleetVanFault
                _database.ClearParameter()
                _database.AddParameter("@VanFaultID", vanFaultID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanFault
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanFaultID = dt.Rows(0).Item("VanFaultID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetFaultTypeID = dt.Rows(0).Item("FaultType")
                            .FaultDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("FaultDate"))
                            If dt.Rows(0).Item("ResolvedDate") IsNot DBNull.Value Then
                                .ResolvedDate = Entity.Sys.Helper.MakeDateTimeValid(
                                    dt.Rows(0).Item("ResolvedDate"))
                            End If
                            .SetEngineerNotes = dt.Rows(0).Item("EngineerNotes")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetJobID = dt.Rows(0).Item("JobID")
                            .SetArchive = dt.Rows(0).Item("Archive")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByVanID](ByVal vanID As Integer) As FleetVanFault
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_Get_ForVan")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanFault
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanFaultID = dt.Rows(0).Item("VanFaultID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetFaultTypeID = dt.Rows(0).Item("FaultType")
                            .FaultDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("FaultDate"))
                            If dt.Rows(0).Item("ResolvedDate") IsNot DBNull.Value Then
                                .ResolvedDate = Entity.Sys.Helper.MakeDateTimeValid(
                                    dt.Rows(0).Item("ResolvedDate"))
                            End If
                            .SetEngineerNotes = dt.Rows(0).Item("EngineerNotes")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetJobID = dt.Rows(0).Item("JobID")
                            .SetArchive = dt.Rows(0).Item("Archive")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByJobID](ByVal jobID As Integer) As FleetVanFault
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFault_Get_ForJob")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanFault
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanFaultID = dt.Rows(0).Item("VanFaultID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetFaultTypeID = dt.Rows(0).Item("FaultType")
                            .FaultDate = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("FaultDate"))
                            If dt.Rows(0).Item("ResolvedDate") IsNot DBNull.Value Then
                                .ResolvedDate = Entity.Sys.Helper.MakeDateTimeValid(
                                    dt.Rows(0).Item("ResolvedDate"))
                            End If
                            .SetEngineerNotes = dt.Rows(0).Item("EngineerNotes")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetJobID = dt.Rows(0).Item("JobID")
                            .SetArchive = dt.Rows(0).Item("Archive")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Update](ByVal oVan As FleetVanFault) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanFaultID", oVan.VanFaultID, True)
                AddParametersToCommand(oVan)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanFault_Update") = 1)
            End Function

            Public Function [Insert](ByVal van As FleetVanFault) As FleetVanFault
                _database.ClearParameter()
                AddParametersToCommand(van)

                van.SetFaultTypeID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanFault_Insert"))
                van.Exists = True
                Return van
            End Function

            Public Function FaultTypes_GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanFaultType_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                Return New DataView(dt)
            End Function
#End Region

        End Class

        Public Class FleetVanContractSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Private Sub AddParametersToCommand(ByRef oFleetVan As FleetVanContract)
                With _database
                    .AddParameter("@VanID", oFleetVan.VanID, True)
                    .AddParameter("@Lessor", oFleetVan.Lessor, True)
                    .AddParameter("@ProcurementMethod", oFleetVan.ProcurementMethod, True)
                    .AddParameter("@ContractLength", oFleetVan.ContractLength, True)
                    .AddParameter("@StartDateTime", oFleetVan.ContractStart, True)
                    If oFleetVan.ContractEnd <> Nothing Then
                        .AddParameter("@EndDateTime", oFleetVan.ContractEnd, True)
                    End If
                    .AddParameter("@ContractMileage", oFleetVan.ContractMileage, True)
                    .AddParameter("@StartingMileage", oFleetVan.StartingMileage, True)
                    .AddParameter("@ExcessMileageRate", oFleetVan.ExcessMileageRate, True)
                    .AddParameter("@WeeklyRental", oFleetVan.WeeklyRental, True)
                    .AddParameter("@MonthlyRental", oFleetVan.MonthlyRental, True)
                    .AddParameter("@AnnualRental", oFleetVan.AnnualRental, True)
                    .AddParameter("@ExcessMileageCost", oFleetVan.ExcessMileageCost, True)
                    .AddParameter("@ForecastExcessMileageCost", oFleetVan.ForecastExcessMileageCost, True)
                    .AddParameter("@AgreementRef", oFleetVan.AgreementRef, True)
                    .AddParameter("@Notes", oFleetVan.Notes, True)
                End With
            End Sub

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanContract_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanContract.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_Active() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanContract_GetAll_Active")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal vanContractID As Integer) As FleetVanContract
                _database.ClearParameter()
                _database.AddParameter("@VanContractID", vanContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanContract_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanContract
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanContractID = dt.Rows(0).Item("VanContractID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetLessor = dt.Rows(0).Item("Lessor")
                            .SetProcurementMethod = dt.Rows(0).Item("ProcurementMethod")
                            .SetContractLength = dt.Rows(0).Item("ContractLength")
                            .ContractStart = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("StartDateTime"))
                            .ContractEnd = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("EndDateTime"))
                            .SetContractMileage = dt.Rows(0).Item("ContractMileage")
                            .SetStartingMileage = dt.Rows(0).Item("StartingMileage")
                            .SetExcessMileageRate = dt.Rows(0).Item("ExcessMileageRate")
                            .SetWeeklyRental = dt.Rows(0).Item("WeeklyRental")
                            .SetMonthlyRental = dt.Rows(0).Item("MonthlyRental")
                            .SetAnnualRental = dt.Rows(0).Item("AnnualRental")
                            .SetAgreementRef = dt.Rows(0).Item("AgreementRef")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetExcessMileageCost = dt.Rows(0).Item("ExcessMileageCost")
                            .SetForecastExcessMileageCost = dt.Rows(0).Item("ForecastExcessMileageCost")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Get_ByVanID](ByVal vanID As Integer) As FleetVanContract
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanContract_Get_ForVan")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New FleetVanContract
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanContractID = dt.Rows(0).Item("VanContractID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetLessor = dt.Rows(0).Item("Lessor")
                            .SetProcurementMethod = dt.Rows(0).Item("ProcurementMethod")
                            .SetContractLength = dt.Rows(0).Item("ContractLength")
                            .ContractStart = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("StartDateTime"))
                            .ContractEnd = Entity.Sys.Helper.MakeDateTimeValid(
                                dt.Rows(0).Item("EndDateTime"))
                            .SetContractMileage = dt.Rows(0).Item("ContractMileage")
                            .SetStartingMileage = dt.Rows(0).Item("StartingMileage")
                            .SetExcessMileageRate = dt.Rows(0).Item("ExcessMileageRate")
                            .SetWeeklyRental = dt.Rows(0).Item("WeeklyRental")
                            .SetMonthlyRental = dt.Rows(0).Item("MonthlyRental")
                            .SetAnnualRental = dt.Rows(0).Item("AnnualRental")
                            .SetAgreementRef = dt.Rows(0).Item("AgreementRef")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetExcessMileageCost = dt.Rows(0).Item("ExcessMileageCost")
                            .SetForecastExcessMileageCost = dt.Rows(0).Item("ForecastExcessMileageCost")
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Update](ByVal oVan As FleetVanContract) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@VanContractID", oVan.VanContractID, True)
                AddParametersToCommand(oVan)
                Return CBool(_database.ExecuteSP_OBJECT("FleetVanContract_Update") = 1)
            End Function

            Public Function [Insert](ByVal van As FleetVanContract) As FleetVanContract
                _database.ClearParameter()
                AddParametersToCommand(van)

                van.SetVanContractID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanContract_Insert"))
                van.Exists = True
                Return van
            End Function
#End Region


        End Class

        Public Class FleetVanServiceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [GetServices_ByVanId](ByVal vanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanService_GetJobs_ForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetVanId_ByJobId](ByVal jobID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobID)

                'Get the datatable from the database store in dt
                Return _database.ExecuteSP_OBJECT("FleetVanService_GetVan_ForJob")
            End Function

            Public Function [Update](ByVal jobID As Integer, ByVal vanID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                _database.AddParameter("@JobID", jobID)

                Return _database.ExecuteSP_OBJECT("FleetVanService_Update")
            End Function

            Public Function [Insert](ByVal jobID As Integer, ByVal vanID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                _database.AddParameter("@JobID", jobID)

                Return _database.ExecuteSP_OBJECT("FleetVanService_Insert")
            End Function

            Public Sub [Delete](ByVal jobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobID)

                _database.ExecuteSP_NO_Return("FleetVanService_Delete")
            End Sub
#End Region


        End Class

        Public Class FleetEquipmentSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetEquipment_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetEquipment.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal equipmentId As Integer) As FleetEquipment
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", equipmentId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetEquipment_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVanType As New FleetEquipment
                        With oVanType
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEquipmentID = dt.Rows(0).Item("EquipmentID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetDescription = dt.Rows(0).Item("Description")
                            .SetCost = dt.Rows(0).Item("Cost")
                        End With
                        oVanType.Exists = True
                        Return oVanType
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [GetActiveCount](ByVal equipmentId As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", equipmentId, True)
                Dim siteCount As Integer = _database.SP_ExecuteScalar("FleetEquipment_Get_ActiveCount")
                Return siteCount
            End Function

            Public Function [Insert](ByVal oEquipment As FleetEquipment) As FleetEquipment
                _database.ClearParameter()
                _database.AddParameter("@Name", oEquipment.Name, True)
                _database.AddParameter("@Description", oEquipment.Description, True)
                _database.AddParameter("@Cost", oEquipment.Cost, True)

                oEquipment.SetEquipmentID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetEquipment_Insert"))
                oEquipment.Exists = True
                Return oEquipment
            End Function

            Public Function [Update](ByVal oEquipment As FleetEquipment) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", oEquipment.EquipmentID, True)
                _database.AddParameter("@Name", oEquipment.Name, True)
                _database.AddParameter("@Description", oEquipment.Description, True)
                _database.AddParameter("@Cost", oEquipment.Cost, True)
                Return CBool(_database.ExecuteSP_OBJECT("FleetEquipment_Update") = 1)
            End Function

            Public Function [Delete](ByVal equipmentId As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", equipmentId, True)
                Return CBool(_database.ExecuteSP_OBJECT("FleetEquipment_Delete") = 1)
            End Function

            Public Function [Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetEquipment_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetEquipment.ToString
                Return New DataView(dt)
            End Function
#End Region
        End Class

        Public Class FleetVanEquipmentSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal vanEquipmentID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanEquipmentID", vanEquipmentID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEquipment_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get_ByVanID](ByVal vanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("FleetVanEquipment_Get_ForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal vanID As Integer, ByVal equipmentID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                _database.AddParameter("@EquipmentID", equipmentID)

                Return _database.ExecuteSP_OBJECT("FleetVanEquipment_Insert")
            End Function

            Public Function [Check](ByVal vanID As Integer, ByVal equipmentID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@VanID", vanID)
                _database.AddParameter("@EquipmentID", equipmentID)

                Return _database.ExecuteSP_OBJECT("FleetVanEquipment_Check")
            End Function

            Public Sub [Update](ByVal vanEquipmentID As Integer, ByVal vanID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@VanEquipmentID", vanEquipmentID)
                _database.AddParameter("@VanID", vanID)

                _database.ExecuteSP_NO_Return("FleetVanEquipment_Update")
            End Sub

            Public Sub [Delete](ByVal vanEquipmentID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@VanEquipmentID", vanEquipmentID)

                _database.ExecuteSP_NO_Return("FleetVanEquipment_Delete")
            End Sub
#End Region
        End Class

    End Namespace

End Namespace