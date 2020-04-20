GO
/****** Object:  StoredProcedure [dbo].[EngineerVisits_Manager_Search_Paged_Inc_Priority]    Script Date: 12/08/2014 11:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER  PROCEDURE [dbo].[EngineerVisits_Manager_Search_Paged_Inc_Priority]

(
				@lastRow bigint,
				@pageSize bigint,
				@totalRowCount bigint output,
				@sortBy nvarchar(255),
				@sortDirection int,
						
				@InvoiceTypeIDEnum int,
				@InvoicedIDEnum int,
				@ReadyToBeInvoicedIDEnum int,
				@NoNeedForInvoiceIDEnum int,
				
				@customerID int,
				@SiteID int,
				@EngineerID int,
				@JobDefinitionEnumID int,
				@JobTypeID int,				
				@VisitEnumID int,
				@OutcomeEnumID int,
				@JobNumber nvarchar(255),
				@PONumber nvarchar(255),
				@DateFrom datetime,
				@DateTo datetime,
				@postcode nvarchar(255),
				@RegionID int,
				@ContractTypeID int,
				@LetterType nvarchar(50),
				@DueDateFrom datetime,
				@DueDateTo datetime,
				@ChargeInProgress int,
				@CostsTo nvarchar(250),
				@Priority nvarchar(250)
			)
AS

BEGIN

	WITH ResultsCTE AS (

	SELECT 
      tblEngineerVisit.EngineerVisitID,
	  tblEngineerVisit.StartDateTime,
      tblEngineerVisit.EndDateTime, 
      (cast(DATEPART (dd, tblEngineerVisit.StartDateTime) as nvarchar(12))
			+ '/' + DATENAME  (mm, tblEngineerVisit.StartDateTime)
			+ '/' + DATENAME  (yyyy, tblEngineerVisit.StartDateTime)
			+ char(13) + char(10)
			+ convert(nvarchar(5), tblEngineerVisit.StartDateTime, 108)
			+ ' to ' + convert(nvarchar(5), tblEngineerVisit.EndDateTime, 108)
      )as VisitDate,
      CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)
      WHEN 0 THEN tblEngineerVisit.StatusEnumID
      WHEN 1 THEN tblEngineerVisit.StatusEnumID
      WHEN 2 THEN
		CASE WHEN tblEngineerVisit.VisitLocked = 1 then
            CASE WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN @InvoicedIDEnum  
				 ELSE @ReadyToBeInvoicedIDEnum 
            END
        ELSE
            tblEngineerVisit.StatusEnumID
        END
      WHEN 3 THEN 
      CASE 
            WHEN tblEngineerVisit.VisitLocked = 1 then
      @NoNeedForInvoiceIDEnum 
      ELSE
            tblEngineerVisit.StatusEnumID
            END
      END AS StatusEnumID,
      CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)
      WHEN 0 THEN tblVisitStatuses.VisitStatus
      WHEN 1 THEN tblVisitStatuses.VisitStatus
      WHEN 2 THEN 
		CASE WHEN tblEngineerVisit.VisitLocked = 1 then
            CASE WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 'Invoiced'
				 ELSE 'Ready To Be Invoiced'
            END
        ELSE
            tblVisitStatuses.VisitStatus
        END
      WHEN 3 THEN 
            CASE WHEN tblEngineerVisit.VisitLocked = 1 then
				'Non Chargable'
            ELSE
				tblVisitStatuses.VisitStatus
            END
      END AS VisitStatus,
      tblEngineerVisit.OutcomeEnumID,
      tblEngineerVisit.OutcomeDetails,
      tblVisitOutcomes.VisitOutcome,
      tblEngineerVisit.CustomerName,
      tblEngineerVisit.Deleted,
      tblSite.SiteID,
      tblCustomer.CustomerID,
      tblCustomer.Name + ' (' + tblCustomer.AccountNumber + ')' AS Customer,
      REPLACE (REPLACE (REPLACE (tblSite.Address1 + ', ' +
                              tblSite.Address2  + ', ' +
                              tblSite.Address3  + ', ' +
                              tblSite.Address4 + ', ' +
                              tblSite.Address5  + ', ' +
                              tblsite.Postcode, ', ,', ','), ', ,', ','), ', ,', ',') as Site,
      tblSite.Postcode,
      tblJob.JobID,
      tblJob.JobNumber,
      tblJobOfWork.PONumber,
      tblJob.JobDefinitionEnumID,
      tblJobDefinitions.JobDefinition,
      tblJob.JobTypeID,
      tblPicklists.Name AS Type,
      tblEngineerVisit.ManualEntryByUserID,
      tblEngineerVisit.ManualEntryOn,
      tblEngineerVisit.PaymentMethodID,
      tblEngineerVisit.AmountCollected,
      tblEngineerVisit.VisitLocked,
      tblEngineer.[Name] AS Engineer,
      tblEngineerVisitCharge.JobValue AS VisitValue,
      CASE isnull (tblEngineerVisitCharge.ChargeTypeID, 0)
      WHEN 0 THEN ''
      ELSE
            CASE tblEngineerVisitCharge.ChargeTypeID
            WHEN 1 THEN
                  '£' + convert(nvarchar(255),cast (tblEngineerVisitCharge.JobValue  AS money))
            WHEN 6 THEN
                  '£' +CONVERT (nvarchar(255),cast ((tblQuoteJob.GrandTotal/100)* tblEngineerVisitCharge.Charge AS money))
            ELSE
                  CASE tblJob.JobDefinitionEnumID
                  WHEN 1 THEN
                        '£' + CONVERT (nvarchar(255), cast(tblQuoteJob.GrandTotal AS money))
                  WHEN 2 THEN
                        'Charged at Contract Level'
                  WHEN 3 THEN
                        'No Charge Applied'
                  WHEN 4 THEN
                        'No Charge Applied'
                  END
            END
      END AS VisitCharge,
      PartsToFit,
      EmailReceipt,
      tblContractOriginal.ContractTypeID,
      EXPECTEDENGINEER.Name AS ExpectedEngineer,
      tblContractType.Name AS ContractType, 
      tblSite.RegionID,
      tblEngineerVisit.Recharge,
      REPLACE(tblLettersGenerated.LetterType, 'Letter ','') as LetterType,
      tblEngineerVisit.DueDate,
      tblEngineerVisit.AMPM,  
      tblEngineerVisitCharge.EngineerVisitChargeID,
      CASE isnull (tblEngineerVisitCharge.ChargeTypeID, 0)
      WHEN 0 THEN 0
      ELSE
            CASE tblEngineerVisitCharge.ChargeTypeID
			  WHEN 1 THEN  1
              WHEN 6 THEN  1
			  ELSE
                  CASE tblJob.JobDefinitionEnumID
				    WHEN 1 THEN 1
					WHEN 2 THEN 0
					WHEN 3 THEN 0
					WHEN 4 THEN 0
                  END
			END
      END Charged,
      tblInvoiceToBeRaised.InvoiceToBeRaisedID,
      tblEngineerVisit.CostsTo, 
      tblJobOfWork.Priority,
      Priorities.Name as PriorityName,
	  ROW_NUMBER() OVER(ORDER BY CASE WHEN @SortDirection = 1 THEN
      
                              CASE WHEN @sortBy = 'Customer'		   THEN     tblCustomer.Name + ' (' + tblCustomer.AccountNumber + ')'   
								   WHEN @sortBy = 'Site'               THEN 
   																				REPLACE (REPLACE (REPLACE (tblSite.Address1 + ', ' +
																				tblSite.Address2  + ', ' +
																				tblSite.Address3  + ', ' +
																				tblSite.Address4 + ', ' +
																				tblSite.Address5  + ', ' +
																				tblsite.Postcode, ', ,', ','), ', ,', ','), ', ,', ',')
                                         
                                   WHEN @sortBy = 'JobNumber'          THEN     tblJob.JobNumber
                                   WHEN @sortBy = 'JobDefinition'      THEN     tblJobDefinitions.JobDefinition     
                                   WHEN @sortBy = 'Type'               THEN     tblPicklists.Name
                                   WHEN @sortBy = 'PartsToFit'		   THEN     CAST(tblEngineerVisit.PartsToFit as nvarchar(1))
                                   WHEN @sortBy = 'VisitStatus'		   THEN  
																				CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)
																					 WHEN 0 THEN tblVisitStatuses.VisitStatus
																					 WHEN 1 THEN tblVisitStatuses.VisitStatus
																					 WHEN 2 THEN
																						CASE 
																							WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 'Invoiced'
																							ELSE 'Ready To Be Invoiced'
																						END
																					 WHEN 3 THEN 'Non Chargable'
																				END
                                    WHEN @sortBy = 'VisitOutcome'      THEN     tblEngineerVisit.OutcomeDetails 
                                    WHEN @sortBy = 'VisitDate'         THEN     CAST(tblEngineerVisit.StartDateTime AS nvarchar(max))
                                    WHEN @sortBy = 'Engineer'          THEN     tblEngineer.[Name]
                                    WHEN @sortBy = 'EmailReceipt'      THEN     CAST(tblEngineerVisit.EmailReceipt as nvarchar(1))
                                    WHEN @sortBy = 'PONumber'          THEN     tblJobOfWork.PONumber
                                    WHEN @sortBy = 'ContractType'      THEN     CAST(tblContractOriginal.ContractTypeID as nvarchar(255))
                              END
						END ASC,
						CASE WHEN @sortDirection = 2 THEN
							  CASE WHEN @sortBy = 'Customer'		   THEN     tblCustomer.Name + ' (' + tblCustomer.AccountNumber + ')'   
								   WHEN @sortBy = 'Site'               THEN 
   																				REPLACE (REPLACE (REPLACE (tblSite.Address1 + ', ' +
																				tblSite.Address2  + ', ' +
																				tblSite.Address3  + ', ' +
																				tblSite.Address4 + ', ' +
																				tblSite.Address5  + ', ' +
																				tblsite.Postcode, ', ,', ','), ', ,', ','), ', ,', ',')
                                         
                                   WHEN @sortBy = 'JobNumber'          THEN     tblJob.JobNumber
                                   WHEN @sortBy = 'JobDefinition'      THEN     tblJobDefinitions.JobDefinition     
                                   WHEN @sortBy = 'Type'               THEN     tblPicklists.Name
                                   WHEN @sortBy = 'PartsToFit'		   THEN     CAST(tblEngineerVisit.PartsToFit as nvarchar(1))
                                   WHEN @sortBy = 'VisitStatus'		   THEN  
																				CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)
																					 WHEN 0 THEN tblVisitStatuses.VisitStatus
																					 WHEN 1 THEN tblVisitStatuses.VisitStatus
																					 WHEN 2 THEN
																						CASE 
																							WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 'Invoiced'
																							ELSE 'Ready To Be Invoiced'
																						END
																					 WHEN 3 THEN 'Non Chargable'
																				END
                                    WHEN @sortBy = 'VisitOutcome'      THEN     tblEngineerVisit.OutcomeDetails 
                                    WHEN @sortBy = 'VisitDate'         THEN     CAST(tblEngineerVisit.StartDateTime AS nvarchar(max))
                                    WHEN @sortBy = 'Engineer'          THEN     tblEngineer.[Name]
                                    WHEN @sortBy = 'EmailReceipt'      THEN     CAST(tblEngineerVisit.EmailReceipt as nvarchar(1))
                                    WHEN @sortBy = 'PONumber'          THEN     tblJobOfWork.PONumber
                                    WHEN @sortBy = 'ContractType'      THEN     CAST(tblContractOriginal.ContractTypeID as nvarchar(255))
                              END
						END DESC) AS RowNumber

      FROM tblEngineerVisit
      INNER JOIN tblVisitStatuses ON tblEngineerVisit.StatusEnumID = tblVisitStatuses.VisitStatusID
      INNER JOIN tblVisitOutcomes ON tblEngineerVisit.OutcomeEnumID = tblVisitOutcomes.VisitOutcomeID
      INNER JOIN tblJobOfWork ON tblEngineerVisit.JobOfWorkID = tblJobOfWork.JobOfWorkID
      INNER JOIN tblJob ON tblJobOfWork.JobID = tblJob.JobID
      INNER JOIN tblSite ON tblJob.SiteID = tblSite.SiteID
      INNER JOIN tblCustomer ON tblSite.CustomerID = tblCustomer.CustomerID
      INNER JOIN tblJobDefinitions ON tblJob.JobDefinitionEnumID = tblJobDefinitions.JobDefinitionID
      LEFT JOIN tblPicklists ON tblJob.JobTypeID = tblPicklists.ManagerID
      LEFT JOIN tblEngineer ON tblEngineerVisit.EngineerID = tblEngineer.EngineerID
      LEFT JOIN tblEngineerVisitCharge ON tblEngineerVisitCharge.EngineerVisitID = tblEngineerVisit.EngineerVisitID
      LEFT JOIN tblQuoteJob ON tblJob.QuoteID = tblQuoteJob.QuoteJobID
      LEFT JOIN tblInvoiceToBeRaised ON tblInvoiceToBeRaised.LinkID = tblEngineerVisitCharge.EngineerVisitChargeID
      LEFT JOIN tblInvoicedLines ON tblInvoicedLines.InvoiceToBeRaisedID = tblInvoiceToBeRaised.InvoiceToBeRaisedID
      LEFT JOIN tblContractOriginalPPMVisit ON tblJob.JobID = tblContractOriginalPPMVisit.JobID
      LEFT JOIN tblContractOriginalSite ON tblContractOriginalSite.ContractSiteID = tblContractOriginalPPMVisit.ContractSiteID
      LEFT JOIN tblContractOriginal ON tblContractOriginalSite.ContractID = tblContractOriginal.ContractID
	  LEFT JOIN tblPicklists tblContractType ON tblContractOriginal.ContractTypeID = tblContractType.ManagerID     
	  LEFT JOIN tblEngineer EXPECTEDENGINEER ON tblEngineerVisit.ExpectedEngineerID = EXPECTEDENGINEER.EngineerID
      LEFT JOIN tblLettersGenerated ON tblLettersGenerated.JobID = tblJob.JobID
      LEFT JOIN tblPicklists as Priorities ON tblJobOfWork.Priority = Priorities.ManagerID
	
      WHERE tblSite.Deleted = 0 AND
            tblEngineerVisit.Deleted = 0 AND
            tblJobOfWork.Deleted = 0 AND
            tblJob.Deleted = 0 AND
            (tblInvoiceToBeRaised.InvoiceTypeID = @InvoiceTypeIDEnum  OR tblInvoiceToBeRaised.InvoiceTypeID is null) AND
            (@customerID						= 0 OR tblCustomer.customerID = @customerID)						 AND
            (@siteID							= 0 OR tblSite.siteID = @siteID)								     AND
            (@ContractTypeID					= 0 OR tblContractOriginal.ContractTypeID = @ContractTypeID)         AND
            (@JobDefinitionEnumID				= 0 OR tblJob.JobDefinitionEnumID = @JobDefinitionEnumID)			 AND
            (@JobTypeID							= 0 OR tblJob.JobTypeID = @JobTypeID)								 AND
            (@EngineerID						= 0 OR tblEngineer.EngineerID = @EngineerID)						 AND
            (@VisitEnumID						= 0 OR CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0)
															WHEN 0 THEN tblEngineerVisit.StatusEnumID
															WHEN 1 THEN tblEngineerVisit.StatusEnumID
															WHEN 2 THEN
																CASE 
																	WHEN tblEngineerVisit.VisitLocked = 1 then
																		CASE
																			  WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 
																			  THEN @InvoicedIDEnum  
																			  ELSE @ReadyToBeInvoicedIDEnum 
																		END
																	ELSE
																		tblEngineerVisit.StatusEnumID
																END
															WHEN 3 THEN 
																CASE WHEN tblEngineerVisit.VisitLocked = 1 then
																	@NoNeedForInvoiceIDEnum 
																ELSE
																	tblEngineerVisit.StatusEnumID
																END 
														END = @VisitEnumID)											  AND
                    (@OutcomeEnumID			   = 0 OR tblEngineerVisit.OutcomeEnumID = @OutcomeEnumID)				  AND
                                            
                    (@DateFrom                  IS Null OR tblEngineerVisit.StartDateTime >= @DateFrom)				  AND
                    (@DateTo                    IS Null OR tblEngineerVisit.StartDateTime <= @DateTo)				  AND
                    (tblJobOfWork.PONumber      LIKE  '%' + @PONumber + '%')										  AND
                    (tblJob.JobNumber                 LIKE  '%' + @JobNumber + '%')									  AND
                    (tblSite.Postcode                 LIKE  '%' + @postcode + '%')									  AND
                    (@LetterType                      = '0' OR tblLettersGenerated.LetterType = @LetterType)		  AND
                    (@DueDateFrom               IS Null OR tblEngineerVisit.DueDate >=@DueDateFrom)					  AND
                    (@DueDateTo                       IS Null OR tblEngineerVisit.DueDate <=@DueDateTo)				  AND
                    (@RegionID				   = 0 OR tblSite.RegionID = @RegionID)									  AND
                    (CASE WHEN @ChargeInProgress = 0 THEN 0
                          WHEN EngineerVisitChargeID is not null AND tblInvoiceToBeRaised.InvoiceToBeRaisedID is null AND
                                                (CASE isnull (tblEngineerVisitCharge.ChargeTypeID, 0)
                                                     WHEN 0 THEN 0
                                                     ELSE
                                                         CASE tblEngineerVisitCharge.ChargeTypeID 
															WHEN 1 THEN 1
                                                            WHEN 6 THEN 1
                                                            ELSE
                                                                CASE tblJob.JobDefinitionEnumID   
																	WHEN 1 THEN 1
                                                                    ELSE 0 
                                                                END
                                                            END
                                                END) = 1 THEN 2 
                          ELSE 1 
                     END = @ChargeInProgress)																         AND
                     (COALESCE(tblEngineerVisit.CostsTo,'0') LIKE @CostsTo)											 AND 
                     (tblJobOfWork.Priority like @Priority)
	) 
	
	SELECT *, 
	JobItems = LEFT(JobSummarys.list, LEN(JobSummarys.list)-1),
	(SELECT MAX(RowNumber) FROM ResultsCTE) AS TotalRowCount
	FROM ResultsCTE
	  CROSS APPLY ( 
			SELECT CAST(Summary AS nvarchar(max)) + ', '
			FROM  tblJobOfWork JobOfWork 
			INNER JOIN tblJobItem ON tblJobItem.JobOfWorkID = JobOfWork.JobOfWorkID 
			WHERE JobOfWork.JobID = ResultsCTE.JobID
			FOR XML PATH('') 
		) JobSummarys (list) 
	WHERE RowNumber between ( @lastRow + 1 ) and ( @lastRow + @pageSize ) 

END
                   