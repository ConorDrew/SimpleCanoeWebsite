Namespace Entity

    Namespace Management

        Public Class ManagerSQL

            Private _database As Sys.Database

            Public Sub New(ByVal databaseIn As Sys.Database)
                _database = databaseIn
            End Sub

#Region "Settings"

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim sql As String = Entity.Sys.Helper.GetTextResource("Settings_Get.sql")

                Dim dt As DataTable = _database.ExecuteWithReturn(sql, False)
                dt.TableName = Sys.Enums.TableNames.tblSettings.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get]() As Settings
                Dim settings As New Settings
                Dim settingsList As DataView = GetAll()

                If (settingsList.Table.Rows.Count > 0) Then
                    With settingsList.Table.Rows(0)
                        settings.SetWorkingHoursStart = Entity.Sys.Helper.MakeStringValid(.Item("WorkingHoursStart"))
                        settings.SetWorkingHoursEnd = Entity.Sys.Helper.MakeStringValid(.Item("WorkingHoursEnd"))
                        settings.SetOverridePassword = Entity.Sys.Helper.MakeStringValid(.Item("OverridePassword"))
                        settings.SetOverridePassword_Service = Entity.Sys.Helper.MakeStringValid(.Item("OverridePassword_Service"))
                        settings.SetMileageRate = Entity.Sys.Helper.MakeDoubleValid(.Item("MileageRate"))
                        settings.SetPartsMarkup = Entity.Sys.Helper.MakeDoubleValid(.Item("PartsMarkup"))
                        settings.SetRatesMarkup = Entity.Sys.Helper.MakeDoubleValid(.Item("RatesMarkup"))
                        settings.SetCalloutPrefix = Entity.Sys.Helper.MakeStringValid(.Item("CalloutPrefix"))
                        settings.SetMiscPrefix = Entity.Sys.Helper.MakeStringValid(.Item("MiscPrefix"))
                        settings.SetPPMPrefix = Entity.Sys.Helper.MakeStringValid(.Item("PPMPrefix"))
                        settings.SetQuotePrefix = Entity.Sys.Helper.MakeStringValid(.Item("QuotePrefix"))
                        settings.SetTimeSlot = Entity.Sys.Helper.MakeIntegerValid(.Item("TimeSlot"))
                        settings.SetInvoicePrefix = Entity.Sys.Helper.MakeStringValid(.Item("InvoicePrefix"))
                        settings.SetRecallVariable = Entity.Sys.Helper.MakeIntegerValid(.Item("RecallVariable"))
                        settings.SetPartsImportMarkup = Entity.Sys.Helper.MakeDoubleValid(.Item("PartsImportMarkup"))
                        settings.SetServiceFromLetterPrefix = Entity.Sys.Helper.MakeStringValid(.Item("ServiceFromLetterPrefix"))
                        settings.Exists = True
                    End With
                End If

                Return settings
            End Function

            Public Sub UpdateSettings(ByVal settings As Entity.Management.Settings)
                _database.ClearParameter()
                _database.AddParameter("?WorkingHoursStart", settings.WorkingHoursStart)
                _database.AddParameter("?WorkingHoursEnd", settings.WorkingHoursEnd)
                _database.AddParameter("?MileageRate", CDbl(settings.MileageRate))
                _database.AddParameter("?PartsMarkup", CDbl(settings.PartsMarkup))
                _database.AddParameter("?RatesMarkup", CDbl(settings.RatesMarkup))
                _database.AddParameter("?CalloutPrefix", settings.CalloutPrefix)
                _database.AddParameter("?MiscPrefix", settings.MiscPrefix)
                _database.AddParameter("?PPMPrefix", settings.PPMPrefix)
                _database.AddParameter("?QuotePrefix", settings.QuotePrefix)
                _database.AddParameter("?TimeSlot", settings.TimeSlot)
                _database.AddParameter("?InvoicePrefix", settings.InvoicePrefix)
                _database.AddParameter("?RecallVariable", settings.RecallVariable)
                _database.AddParameter("?PartsImportMarkup", settings.PartsImportMarkup)
                _database.AddParameter("?ServiceFromLetterPrefix", settings.ServiceFromLetterPrefix)
                _database.ExecuteCommand_NO_Return("Settings_Update.sql")
            End Sub

            Public Sub UpdateOverridePassword(ByVal Password As String)
                _database.ClearParameter()
                _database.AddParameter("?Password", Entity.Sys.Helper.HashPassword(Password))
                _database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword.sql")
            End Sub

            Public Sub UpdateOverridePassword_Service(ByVal Password As String)
                _database.ClearParameter()
                _database.AddParameter("?Password", Entity.Sys.Helper.HashPassword(Password))
                _database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword_Service.sql")
            End Sub

#End Region

#Region "History"

            Public Function GetHistory(ByVal LimitNumber As Integer) As DataView
                Dim sql As String = Entity.Sys.Helper.GetTextResource("History_Get.sql")
                If Not LimitNumber = 0 Then
                    sql = String.Format(sql, " TOP " & LimitNumber)
                Else
                    sql = String.Format(sql, "")
                End If

                Dim dt As DataTable = _database.ExecuteWithReturn(sql)
                dt.TableName = Sys.Enums.TableNames.tblHistory.ToString

                Return New DataView(dt)
            End Function

            Public Sub DeleteHistory()
                _database.ExecuteWithOutReturn(Entity.Sys.Helper.GetTextResource("History_Delete.sql"))
            End Sub

#End Region

#Region "Data Downloader"

            Public Function Get_Tables() As DataView
                Dim dt As New DataTable
                dt.Columns.Add(New DataColumn("TableEnumID"))
                dt.Columns.Add(New DataColumn("TableName"))
                dt.Columns.Add(New DataColumn("Deleted", System.Type.GetType("System.Boolean")))

                Dim newRow As DataRow

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblCustomer)
                newRow("TableName") = "Customers"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblSite)
                newRow("TableName") = "Sites"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblSupplier)
                newRow("TableName") = "Suppliers"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblPart)
                newRow("TableName") = "Parts"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblProduct)
                newRow("TableName") = "Products"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblAsset)
                newRow("TableName") = "Assets"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblType)
                newRow("TableName") = "Types"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblMake)
                newRow("TableName") = "Makes"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblModel)
                newRow("TableName") = "Models"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblLocations)
                newRow("TableName") = "Locations"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblEngineer)
                newRow("TableName") = "Engineers"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow
                newRow("TableEnumID") = CInt(Entity.Sys.Enums.TableNames.tblHistory)
                newRow("TableName") = "System History"
                newRow("Deleted") = False
                dt.Rows.Add(newRow)

                Return New DataView(dt)
            End Function

#End Region

#Region "Reports"

            Public Function Record_Summary(ByVal fromDate As DateTime, ByVal toDate As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@FromDate", Format(fromDate, "dd-MMMM-yyyy 00:00:00"), True)
                _database.AddParameter("@ToDate", Format(toDate, "dd-MMMM-yyyy 23:59:59"), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Report_Record_Summary")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace