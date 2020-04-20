Imports System.Data.SqlClient

Namespace Entity

Namespace ContractOriginalSiteRatess

Public Class ContractOriginalSiteRatesSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal ContractOriginalSiteRateID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@ContractOriginalSiteRateID", ContractOriginalSiteRateID, True)
            _database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Delete")
    End Sub

    Public Function [ContractOriginalSiteRates_Get](ByVal ContractOriginalSiteRateID As Integer) As ContractOriginalSiteRates
        _database.ClearParameter()
        _database.AddParameter("@ContractOriginalSiteRateID", ContractOriginalSiteRateID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oContractOriginalSiteRates As New ContractOriginalSiteRates
				With oContractOriginalSiteRates
				    .IgnoreExceptionsOnSetMethods = True
						.SetContractOriginalSiteRateID= dt.Rows(0).Item("ContractOriginalSiteRateID")
				.SetContractSiteID= dt.Rows(0).Item("ContractSiteID")
				.SetRateID= dt.Rows(0).Item("RateID")
				.SetQty= dt.Rows(0).Item("Qty")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oContractOriginalSiteRates.Exists = true				
			Return oContractOriginalSiteRates
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
            End Function

            Public Function ContractOriginalSiteRates_GetForContractSite(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_GetForContractSite")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString
                Return New DataView(dt)

            End Function

    Public Function [ContractOriginalSiteRates_GetAll]() As DataView
       _database.ClearParameter()
        Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteRates_GetAll")
        dt.TableName = Entity.Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString
        Return New DataView(dt)
    End Function
   
    Public Function [Insert](ByVal oContractOriginalSiteRates As ContractOriginalSiteRates) As ContractOriginalSiteRates
		 _database.ClearParameter()			
	     AddContractOriginalSiteRatesParametersToCommand(oContractOriginalSiteRates)	
						
		oContractOriginalSiteRates.SetContractOriginalSiteRateID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSiteRates_Insert"))				
        oContractOriginalSiteRates.Exists = True
        Return oContractOriginalSiteRates
    End Function   
    

    Public Sub [Update](ByVal oContractOriginalSiteRates As ContractOriginalSiteRates)
		_database.ClearParameter()
		_database.AddParameter("@ContractOriginalSiteRateID", oContractOriginalSiteRates.ContractOriginalSiteRateID, True)  
		AddContractOriginalSiteRatesParametersToCommand(oContractOriginalSiteRates)
		_database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Update")
    End Sub



    Private Sub AddContractOriginalSiteRatesParametersToCommand(ByRef oContractOriginalSiteRates As ContractOriginalSiteRates)    
        With _database
			.AddParameter("@ContractSiteID", oContractOriginalSiteRates.ContractSiteID, True)
			.AddParameter("@RateID", oContractOriginalSiteRates.RateID, True)
			.AddParameter("@Qty", oContractOriginalSiteRates.Qty, True)

		
            
        End With        
    End Sub      
    

#End Region

End Class

End Namespace

End Namespace


