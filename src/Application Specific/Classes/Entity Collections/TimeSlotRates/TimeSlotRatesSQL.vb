Imports System.Data.SqlClient

Namespace Entity

    Namespace TimeSlotRates

        Public Class TimeSlotRatesSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("TimeSlotRates_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString
                Return New DataView(dt)
            End Function

            Public Sub Update(ByVal UniqueID As Integer, ByVal Monday As Integer, ByVal Tuesday As Integer,
                            ByVal Wednesday As Integer, ByVal Thursday As Integer, ByVal Friday As Integer,
                            ByVal Saturday As Integer, ByVal Sunday As Integer)

                _database.ClearParameter()

                _database.AddParameter("@UniqueID", UniqueID)
                _database.AddParameter("@Monday", Monday)
                _database.AddParameter("@Tuesday", Tuesday)
                _database.AddParameter("@Wednesday", Wednesday)
                _database.AddParameter("@Thursday", Thursday)
                _database.AddParameter("@Friday", Friday)
                _database.AddParameter("@Saturday", Saturday)
                _database.AddParameter("@Sunday", Sunday)

                DB.ExecuteSP_NO_Return("TimeSlotRates_Update")
            End Sub

            Public Function BankHolidays_GetAllAsync() As DataView
                Dim dt As New DataTable
                Dim command As New SqlCommand("BankHolidays_GetAll", New SqlConnection(_database.ServerConnectionString))
                Try
                    command.CommandType = CommandType.StoredProcedure

                    dt = _database.ExecuteCommand_DataTable(command)
                    dt.TableName = Sys.Enums.TableNames.tblBankHolidays.ToString

                    Return New DataView(dt)
                Catch ex As Exception
                    Return New DataView(dt)
                Finally
                    command.Connection.Close()
                End Try
            End Function

            Public Function BankHolidays_GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("BankHolidays_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblBankHolidays.ToString
                Return New DataView(dt)
            End Function

            Public Function BankHolidays_Insert(ByVal BankHolidayDate As DateTime,
                                                    ByVal LabourRateID As Integer)

                _database.ClearParameter()

                _database.AddParameter("@BankHolidayDate", BankHolidayDate, True)
                _database.AddParameter("@LabourRateID", LabourRateID, True)

                DB.ExecuteSP_NO_Return("BankHolidays_Insert")
            End Function

            Public Function BankHolidays_Update(ByVal BankHolidayDate As DateTime,
                                                   ByVal LabourRateID As Integer,
                                                    ByVal BankHolidayID As Integer)

                _database.ClearParameter()

                _database.AddParameter("@BankHolidayDate", BankHolidayDate, True)
                _database.AddParameter("@LabourRateID", LabourRateID, True)
                _database.AddParameter("@BankHolidayID", BankHolidayID, True)

                DB.ExecuteSP_NO_Return("BankHolidays_Update")
            End Function

            Public Function LabourTypes_Get() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("LabourTypes_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace