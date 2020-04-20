Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractManager


        Public Class ContractManagerSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"
            Public Function Contracts_GetAll(ByVal datefrom As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractType1Enum", CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1), True)
                _database.AddParameter("@ContractType2Enum", CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_2), True)
                _database.AddParameter("@ContractType3Enum", CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_3), True)
                _database.AddParameter("@UploadStatusEnum", CInt(Entity.Sys.Enums.VisitStatus.Uploaded), True)
                _database.AddParameter("@DateFrom", datefrom, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contracts_GetAll_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Sub ContractRenewalsInsert(ByVal oldContractID As Integer, ByVal newContractID As Integer, ByVal ContractTypeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@oldContractID", oldContractID, True)
                _database.AddParameter("@newContractID", newContractID, True)
                _database.AddParameter("@ContractTypeID", ContractTypeID, True)
                DB.ExecuteSP_NO_Return("ContractRenewalsInsert")
            End Sub

            Public Function ContractRenewals_GetNewID_ByOldID(ByVal oldContractID As Integer, ByVal ContractTypeID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@oldContractID", oldContractID, True)
                _database.AddParameter("@ContractTypeID", ContractTypeID, True)
                Return Entity.Sys.Helper.MakeIntegerValid(DB.ExecuteSP_OBJECT("ContractRenewals_GetNewID_ByOldID"))
            End Function

            Public Function ContractRenewal_AlternativeSitesJobOfWorks(ByVal ContractID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractRenewal_AlternativeSitesJobOfWorks")
                dt.TableName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                Return New DataView(dt)
            End Function


            Public Function Contracts_GetAddresses(ByVal ContractIDs As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractIDs", ContractIDs, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contracts_GetAddresses")
                dt.TableName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                Return New DataView(dt)
            End Function

#End Region
        End Class
    End Namespace
End Namespace