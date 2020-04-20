USE [GaswayServicesFSM_LIVE]
GO
/****** Object:  StoredProcedure [dbo].[Order_GetAll_NEW]    Script Date: 02/06/2014 15:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Order_GetAll_NEW]
	(
		@OrderInvoiceTypeID int, 
		@VisitInvoiceTypeID int,
		@SearchCriteria nvarchar(100),
		@OrderSiteID int,
		@OrderVanID int,
		@OrderWarehouseID int,
		@OrderJobID int,
		@OrderTypeID int,
		@OrderReference nvarchar(4000),
		@OrderConsolidationRef nvarchar(4000),
		@OrderStatus int,
		@PartsNotReceived bit,
		@OrderSupplierExported int,
		@OrderSupplierID int,
		@OrderDatePlacedFrom datetime = null,
		@OrderDatePlacedTo datetime = null,
		@OrderDeliveryDeadlineFrom datetime = null,
		@OrderDeliveryDeadlineTo datetime = null,
		@OrderDepartment nvarchar(50) = null
	)
AS

EXECUTE Order_Auto_Cancel

SELECT
TBL_TEMP_PartsNotReceived.OrderID,
SUM(TBL_TEMP_PartsNotReceived.PartsNotReceived) AS PartsNotReceived
INTO #PartsNotReceived
FROM 
(
	SELECT
	tblOrder.OrderID,
	CASE
		WHEN 
			SUM(CASE
				WHEN tblEngineerVisitPartAllocated.ReceivedByEngineer IS NULL THEN 1
				ELSE 0
			END) = 0 THEN 0
		ELSE 1
	END AS PartsNotReceived
	FROM tblOrder
	INNER JOIN tblEngineerVisitOrder ON tblOrder.OrderID = tblEngineerVisitOrder.OrderID 
	INNER JOIN tblEngineerVisitPartAllocated ON tblEngineerVisitOrder.EngineerVisitID = tblEngineerVisitPartAllocated.EngineerVisitID
	WHERE tblOrder.OrderTypeID = 4
	GROUP BY tblOrder.OrderID
	UNION ALL
	SELECT
	tblOrder.OrderID,
	CASE
		WHEN 
			SUM(CASE
				WHEN tblOrderPart.EngineerReceivedOn IS NULL THEN 1
				ELSE 0
			END) = 0 THEN 0
		ELSE 1
	END AS PartsNotReceived
	FROM tblOrder
	INNER JOIN tblOrderPart ON tblOrder.OrderID = tblOrderPart.OrderID 
	WHERE tblOrder.OrderTypeID = 2
	GROUP BY tblOrder.OrderID
	UNION ALL
	SELECT
	tblOrder.OrderID,
	CASE
		WHEN 
			SUM(CASE
				WHEN tblOrderLocationPart.EngineerReceivedOn IS NULL THEN 1
				ELSE 0
			END) = 0 THEN 0
		ELSE 1
	END AS PartsNotReceived
	FROM tblOrder
	INNER JOIN tblOrderLocationPart ON tblOrder.OrderID = tblOrderLocationPart.OrderID
	WHERE tblOrder.OrderTypeID = 2
	GROUP BY tblOrder.OrderID
) TBL_TEMP_PartsNotReceived
GROUP BY TBL_TEMP_PartsNotReceived.OrderID



CREATE TABLE #FILTERIDs
(
OrderID int
)

IF LEN(LTRIM(RTRIM(@SearchCriteria))) = 0 OR @SearchCriteria = '## Last Month ##'
	BEGIN
		IF @SearchCriteria = '## Last Month ##'
			BEGIN
				INSERT INTO #FILTERIDs
		SELECT DISTINCT OrderID
FROM         tblOrder
WHERE DatePlaced BETWEEN DATEADD(mm, -2, GETDATE()) AND DATEADD(dd, +1, GETDATE())
			END
		ELSE
			BEGIN
		INSERT INTO #FILTERIDs
		SELECT DISTINCT OrderID
FROM         tblOrder
		END
	END
ELSE
	BEGIN
		INSERT INTO #FILTERIDs
		SELECT DISTINCT 
		tblOrder.OrderID 
		FROM tblOrder
		LEFT JOIN tblOrderType ON tblOrder.OrderTypeID = tblOrderType.OrderTypeID
		LEFT JOIN tblSiteOrder ON tblOrder.OrderID = tblSiteOrder.OrderID
		LEFT JOIN tblSite ON tblSiteOrder.SiteID = tblSite.SiteID
		LEFT JOIN tblCustomer ON tblSite.CustomerID = tblCustomer.CustomerID
		LEFT JOIN tblEngineerVisitOrder ON tblOrder.OrderID = tblEngineerVisitOrder.OrderID
		LEFT JOIN tblEngineerVisit ON tblEngineerVisitOrder.EngineerVisitID = tblEngineerVisit.EngineerVisitID
		LEFT JOIN tblJobOfWork ON tblJobOfWork.JobOfWorkID = tblEngineerVisit.JobOfWorkID
		LEFT JOIN tblJob ON tblJob.JobID = tblJobOfWork.JobID
		LEFT JOIN tblOrderLocation ON tblOrder.OrderID = tblOrderLocation.OrderID
		LEFT JOIN tblLocations ON tblOrderLocation.LocationID = tblLocations.LocationID
		LEFT JOIN tblVan ON tblLocations.VanID = tblVan.VanID
		LEFT JOIN tblWarehouse ON tblLocations.WarehouseID = tblWarehouse.WarehouseID 
		LEFT JOIN tblOrderPart ON tblOrder.OrderID = tblOrderPart.OrderID
		LEFT JOIN tblPartSupplier ON tblPartSupplier.PartSupplierID = tblOrderPart.PartSupplierID
		LEFT JOIN tblPart ON tblPart.PartID = tblPartSupplier.PartID
		LEFT JOIN tblOrderProduct ON tblOrder.OrderID = tblOrderProduct.OrderID
		LEFT JOIN tblProductSupplier ON tblProductSupplier.ProductSupplierID = tblOrderProduct.ProductSupplierID
		LEFT JOIN tblProduct ON tblProduct.ProductID = tblProductSupplier.ProductID
		LEFT JOIN tblpicklists type ON tblProduct.TypeID = type.managerid
		LEFT JOIN tblpicklists make ON tblProduct.MakeID = make.managerid
		LEFT JOIN tblpicklists model ON tblProduct.ModelID = model.managerid
		WHERE
		(
			tblOrder.OrderReference LIKE '%' + @SearchCriteria + '%'
			OR tblCustomer.Name LIKE '%' + @SearchCriteria + '%'
			OR tblCustomer.AccountNumber LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Name LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Address1 LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Postcode LIKE '%' + @SearchCriteria + '%'
			OR tblJob.JobNumber LIKE '%' + @SearchCriteria + '%'
			OR tblVan.Registration LIKE '%' + @SearchCriteria + '%'
			OR tblWarehouse.Name LIKE '%' + @SearchCriteria + '%'
			OR tblPart.Number LIKE '%' + @SearchCriteria + '%'
			OR tblPart.Name LIKE '%' + @SearchCriteria + '%'
			OR tblProduct.Number LIKE '%' + @SearchCriteria + '%'
			OR type.Name LIKE '%' + @SearchCriteria + '%'
			OR make.Name LIKE '%' + @SearchCriteria + '%'
			OR model.Name LIKE '%' + @SearchCriteria + '%'
		)UNION
		SELECT DISTINCT 
		tblOrder.OrderID 
		FROM tblOrder
		LEFT JOIN tblOrderType ON tblOrder.OrderTypeID = tblOrderType.OrderTypeID
		LEFT JOIN tblSiteOrder ON tblOrder.OrderID = tblSiteOrder.OrderID
		LEFT JOIN tblSite ON tblSiteOrder.SiteID = tblSite.SiteID
		LEFT JOIN tblCustomer ON tblSite.CustomerID = tblCustomer.CustomerID
		LEFT JOIN tblEngineerVisitOrder ON tblOrder.OrderID = tblEngineerVisitOrder.OrderID
		LEFT JOIN tblEngineerVisit ON tblEngineerVisitOrder.EngineerVisitID = tblEngineerVisit.EngineerVisitID
		LEFT JOIN tblJobOfWork ON tblJobOfWork.JobOfWorkID = tblEngineerVisit.JobOfWorkID
		LEFT JOIN tblJob ON tblJob.JobID = tblJobOfWork.JobID
		LEFT JOIN tblOrderLocation ON tblOrder.OrderID = tblOrderLocation.OrderID
		LEFT JOIN tblLocations ON tblOrderLocation.LocationID = tblLocations.LocationID
		LEFT JOIN tblVan ON tblLocations.VanID = tblVan.VanID
		LEFT JOIN tblWarehouse ON tblLocations.WarehouseID = tblWarehouse.WarehouseID 
		LEFT JOIN tblOrderLocationPart ON tblOrder.OrderID = tblOrderLocationPart.OrderID
		LEFT JOIN tblPart ON tblPart.PartID = tblOrderLocationPart.PartID
	    LEFT JOIN tblOrderLocationProduct ON tblOrder.OrderID = tblOrderLocationProduct.OrderID
		LEFT JOIN tblProduct ON tblProduct.ProductID = tblOrderLocationProduct.ProductID
		LEFT JOIN tblpicklists type ON tblProduct.TypeID = type.managerid
		LEFT JOIN tblpicklists make ON tblProduct.MakeID = make.managerid
		LEFT JOIN tblpicklists model ON tblProduct.ModelID = model.managerid
		WHERE
		(
			tblOrder.OrderReference LIKE '%' + @SearchCriteria + '%'
			OR tblCustomer.Name LIKE '%' + @SearchCriteria + '%'
			OR tblCustomer.AccountNumber LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Name LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Address1 LIKE '%' + @SearchCriteria + '%'
			OR tblSite.Postcode LIKE '%' + @SearchCriteria + '%'
			OR tblJob.JobNumber LIKE '%' + @SearchCriteria + '%'
			OR tblVan.Registration LIKE '%' + @SearchCriteria + '%'
			OR tblWarehouse.Name LIKE '%' + @SearchCriteria + '%'
			OR tblPart.Number LIKE '%' + @SearchCriteria + '%'
			OR tblPart.Name LIKE '%' + @SearchCriteria + '%'
			OR tblProduct.Number LIKE '%' + @SearchCriteria + '%'
			OR type.Name LIKE '%' + @SearchCriteria + '%'
			OR make.Name LIKE '%' + @SearchCriteria + '%'
			OR model.Name LIKE '%' + @SearchCriteria + '%'
		)
	END

-------------------------------------------------PRICES  ------------

(SELECT OrderLocationPartID,   (ISNULL((SELECT Top 1 Price FROM tblPartSupplier WHERE tblPartSupplier.PartID = tblOrderLocationPart.PartID AND Preferred = 1), 
(SELECT MIN(Price) FROM tblPartSupplier WHERE tblPartSupplier.PartID =  tblOrderLocationPart.PartID)))   as BuyPrice
INTO #TempPartPrices
FROM tblOrderLocationPart
WHERE tblOrderLocationPart.OrderID in (SELECT OrderID FROM #FILTERIDs)
GROUP BY OrderLocationPartID, tblOrderLocationPart.PartID
)
(
SELECT OrderLocationProductID,   (SELECT MIN(Price) FROM tblProductSupplier WHERE tblProductSupplier.ProductID =  tblOrderLocationProduct.ProductID)   as BuyPrice
INTO #TempProductPrices
FROM tblOrderLocationProduct
WHERE tblOrderLocationProduct.OrderID in (SELECT OrderID FROM #FILTERIDs)
GROUP BY OrderLocationProductID, tblOrderLocationProduct.ProductID
)

(
SELECT OrderID, SUM(#TempPartPrices.BuyPrice * tblOrderLocationPart.Quantity)  as BuyPrice,  SUM(SellPrice * tblOrderLocationPart.Quantity) as SellPrice
INTO #temp1
FROM tblOrderLocationPart
INNER JOIN #TempPartPrices ON tblOrderLocationPart.OrderLocationPartID = #TempPartPrices.OrderLocationPartID
GROUP BY OrderID
)UNION(
SELECT OrderID, SUM(#TempProductPrices.BuyPrice * tblOrderLocationProduct.Quantity) as BuyPrice,  SUM(SellPrice * tblOrderLocationProduct.Quantity) as SellPrice
FROM tblOrderLocationProduct
INNER JOIN #TempProductPrices ON tblOrderLocationProduct.OrderLocationProductID = #TempProductPrices.OrderLocationProductID
GROUP BY OrderID
)UNION(
SELECT OrderID, SUM(BuyPrice * tblOrderPart.Quantity) as BuyPrice,  SUM(SellPrice * tblOrderPart.Quantity) as SellPrice
FROM tblOrderPart
GROUP BY OrderID
)UNION(
SELECT OrderID, SUM(BuyPrice * tblOrderProduct.Quantity) as BuyPrice,  SUM(SellPrice * tblOrderProduct.Quantity) as SellPrice
FROM tblOrderProduct
GROUP BY OrderID
)
-------------------------------------------
SELECT OrderID, SUM(BuyPrice) as BuyPrice, SUM(SellPrice)as SellPrice
INTO #temp2
FROM #temp1
GROUP BY OrderID
-----------------------------------------------

SELECT DISTINCT
TBL_TEMP_RESULTS.OrderID,
TBL_TEMP_RESULTS.Invoiced,
TBL_TEMP_RESULTS.ExportedToSage
INTO #INVOICE_STATUS
FROM 
(
	SELECT
	tblOrder.OrderID,
	CASE ISNULL(tblInvoiced.InvoicedID,0)
		WHEN 0 THEN 0
		ELSE 1 
	END AS Invoiced,
	ISNULL(tblInvoiced.ExportedToSage,0) AS ExportedToSage
	FROM tblOrder 
	LEFT JOIN tblInvoiceToBeRaised ON tblOrder.OrderID = tblInvoiceToBeRaised.LinkID
	LEFT JOIN tblInvoicedLines ON tblInvoiceToBeRaised.InvoiceToBeRaisedID = tblInvoicedLines.InvoiceToBeRaisedID
	LEFT JOIN tblInvoiced ON tblInvoicedLines.InvoicedID = tblInvoiced.InvoicedID
	WHERE tblOrder.OrderTypeID = 1
	AND tblInvoiceToBeRaised.InvoiceTypeID = @OrderInvoiceTypeID
	UNION ALL
	SELECT
	tblOrder.OrderID,
	CASE ISNULL(tblInvoiced.InvoicedID,0)
		WHEN 0 THEN 0
		ELSE 1 
	END AS Invoiced,
	ISNULL(tblInvoiced.ExportedToSage,0) AS ExportedToSage
	FROM tblOrder 
	INNER JOIN tblOrderPart ON tblOrder.OrderID = tblOrderPart.OrderID 
	INNER JOIN tblEngineerVisitPartAllocated ON tblOrderPart.OrderPartID = tblEngineerVisitPartAllocated.OrderPartID
	INNER JOIN tblEngineerVisitCharge ON tblEngineerVisitPartAllocated.EngineerVisitID = tblEngineerVisitCharge.EngineerVisitID 
	LEFT JOIN tblInvoiceToBeRaised ON tblEngineerVisitCharge.EngineerVisitChargeID = tblInvoiceToBeRaised.LinkID
	LEFT JOIN tblInvoicedLines ON tblInvoiceToBeRaised.InvoiceToBeRaisedID = tblInvoicedLines.InvoiceToBeRaisedID
	LEFT JOIN tblInvoiced ON tblInvoicedLines.InvoicedID = tblInvoiced.InvoicedID
	WHERE tblOrder.OrderTypeID = 4
	AND tblInvoiceToBeRaised.InvoiceTypeID = @VisitInvoiceTypeID
	UNION ALL
	SELECT
	tblOrder.OrderID,
	CASE ISNULL(tblInvoiced.InvoicedID,0)
		WHEN 0 THEN 0
		ELSE 1 
	END AS Invoiced,
	ISNULL(tblInvoiced.ExportedToSage,0) AS ExportedToSage
	FROM tblOrder 
	INNER JOIN tblOrderProduct ON tblOrder.OrderID = tblOrderProduct.OrderID 
	INNER JOIN tblEngineerVisitProductAllocated ON tblOrderProduct.OrderProductID = tblEngineerVisitProductAllocated.OrderProductID
	INNER JOIN tblEngineerVisitCharge ON tblEngineerVisitProductAllocated.EngineerVisitID = tblEngineerVisitCharge.EngineerVisitID 
	LEFT JOIN tblInvoiceToBeRaised ON tblEngineerVisitCharge.EngineerVisitChargeID = tblInvoiceToBeRaised.LinkID
	LEFT JOIN tblInvoicedLines ON tblInvoiceToBeRaised.InvoiceToBeRaisedID = tblInvoicedLines.InvoiceToBeRaisedID
	LEFT JOIN tblInvoiced ON tblInvoicedLines.InvoicedID = tblInvoiced.InvoicedID
	WHERE tblOrder.OrderTypeID = 4
	AND tblInvoiceToBeRaised.InvoiceTypeID = @VisitInvoiceTypeID
) TBL_TEMP_RESULTS


		SELECT DISTINCT 
                      tblOrder.OrderID, ISNULL(tblCustomer.Name + ' (' + tblCustomer.AccountNumber + ')', JOBCUSTOMER.Name + ' (' + JOBCUSTOMER.AccountNumber + ')') AS Customer, 
                      ISNULL(tblSite.Address1 + ' (' + tblSite.Postcode + ')', JOBSITE.Address1 + ' (' + JOBSITE.Postcode + ')') AS Site, ISNULL(tblVan.Registration, ISNULL(PartVan.Registration, ProductVan.Registration)) 
                      AS Registration, ISNULL(tblWarehouse.Name, ISNULL(PartWare.Name, ProductWare.Name)) AS Warehouse, tblOrderType.Name AS Type, tblOrderStatus.Name AS OrderStatus, 
                      ISNULL(tblSite.SiteID, JOBSITE.SiteID) AS SiteID, tblVan.VanID, tblWarehouse.WarehouseID, tblOrder.OrderID AS Expr1, tblOrder.DatePlaced, tblOrder.OrderTypeID, CASE tblOrder.OrderStatusID WHEN 1 THEN 'N/A' WHEN 2 THEN tblOrder.OrderReference WHEN 3 THEN tblOrder.OrderReference WHEN 4 THEN tblOrder.OrderReference END AS OrderReference, 
                      tblOrder.UserID, tblOrder.OrderStatusID, CAST(tblOrder.ReasonForReject AS nvarchar(200)) AS Expr2, tblOrder.DeliveryDeadline, tblUser.Fullname AS CreatedBy, tblJob.JobID, 
                      tblEngineerVisitOrder.EngineerVisitID, tblJob.JobNumber, [#temp2].BuyPrice, [#temp2].SellPrice, tblOrder.Deleted,
                          (SELECT     TOP (1) SupplierInvoiceReference
                            FROM          tblOrderSupplierInvoices
                            WHERE      (OrderID = tblOrder.OrderID)
                            GROUP BY SupplierInvoiceReference, SupplierInvoiceDate
                            ORDER BY SupplierInvoiceDate DESC) AS Expr3,
                          (SELECT     MAX(SupplierInvoiceDate) AS SupplierInvoiceDate
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_6
                            WHERE      (OrderID = tblOrder.OrderID)) AS Expr4,
                          (SELECT     SUM(SupplierInvoiceAmount) AS SupplierInvoiceAmount
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_5
                            WHERE      (OrderID = tblOrder.OrderID)) AS Expr5, CASE WHEN
                          (SELECT     COUNT(*) AS Results
                            FROM          tblOrderSupplierInvoices
                            WHERE      (OrderID = tblOrder.OrderID) AND (SentToSage = 1)) = 0 THEN 0 ELSE 1 END AS SentToSage, CASE COALESCE (tblOrderPart.ChildSupplierID, 0) 
                      WHEN 0 THEN tblSupplier.SupplierID ELSE tblOrderPart.ChildSupplierID END AS SupplierID, CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.Name ELSE
                          (SELECT     Name
                            FROM          tblsupplier AS a
                            WHERE      supplierID = tblOrderPart.ChildSupplierID) END AS Supplier, CAST(tblOrder.SpecialInstructions AS nvarchar(200)) AS Expr6, tblOrder.ContactID, tblOrder.InvoiceAddressID, 
                      tblOrder.AllocatedToUser,
                          (SELECT     TOP (1) NominalCode
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_4
                            WHERE      (OrderID = tblOrder.OrderID)
                            GROUP BY NominalCode, SupplierInvoiceDate
                            ORDER BY SupplierInvoiceDate DESC) AS Expr7, tblOrder.DepartmentRef,
                          (SELECT     TOP (1) ExtraRef
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_3
                            WHERE      (OrderID = tblOrder.OrderID)
                            GROUP BY ExtraRef, SupplierInvoiceDate
                            ORDER BY SupplierInvoiceDate DESC) AS Expr8,
                          (SELECT     TOP (1) TaxCodeID
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_2
                            WHERE      (OrderID = tblOrder.OrderID)
                            GROUP BY TaxCodeID, SupplierInvoiceDate
                            ORDER BY SupplierInvoiceDate DESC) AS Expr9, 0 AS Expr10, CASE ISNULL(#INVOICE_STATUS.Invoiced, 0) 
                      WHEN 0 THEN tblOrderStatus.[Name] ELSE CASE ISNULL(#INVOICE_STATUS.ExportedToSage, 0) WHEN 0 THEN 'Invoiced' ELSE 'Sent to Sage' END END AS DisplayStatus, 
                      CASE ISNULL(#INVOICE_STATUS.Invoiced, 0) WHEN 0 THEN tblOrderStatus.[OrderStatusID] ELSE CASE ISNULL(#INVOICE_STATUS.ExportedToSage, 0) 
                      WHEN 0 THEN 5 ELSE 6 END END AS DisplayStatusID, CASE WHEN
                          (SELECT     COUNT(*) AS Results
                            FROM          tblOrderSupplierInvoices
                            WHERE      (OrderID = tblOrder.OrderID) AND (ReadyToSendToSage = 1)) = 0 THEN 0 ELSE 1 END AS ReadyToSendToSage, CASE WHEN
                          (SELECT     COUNT(*) AS Results
                            FROM          tblOrderSupplierInvoices
                            WHERE      (OrderID = tblOrder.OrderID) AND (SentToSage = 1)) = 0 THEN 'No' ELSE 'Yes' END AS SupplierExported,
                          (SELECT     SUM(SupplierVATAmount) AS VATAmount
                            FROM          tblOrderSupplierInvoices AS tblOrderSupplierInvoices_1
                            WHERE      (OrderID = tblOrder.OrderID)) AS Expr11, tblOrderConsolidation.ConsolidationRef, tblOrder.OrderConsolidationID, 
                      CAST(CASE WHEN #PartsNotReceived.PartsNotReceived = 0 THEN 0 ELSE 1 END AS bit) AS PartsNotReceived, tblOrder.DoNotConsolidated
                      
FROM         tblOrder INNER JOIN
                      tblOrderType ON tblOrder.OrderTypeID = tblOrderType.OrderTypeID INNER JOIN
                      tblOrderStatus ON tblOrder.OrderStatusID = tblOrderStatus.OrderStatusID INNER JOIN
                      tblUser ON tblOrder.UserID = tblUser.UserID LEFT OUTER JOIN
                      tblSiteOrder ON tblOrder.OrderID = tblSiteOrder.OrderID LEFT OUTER JOIN
                      tblEngineerVisitOrder ON tblOrder.OrderID = tblEngineerVisitOrder.OrderID LEFT OUTER JOIN
                      tblEngineerVisit ON tblEngineerVisitOrder.EngineerVisitID = tblEngineerVisit.EngineerVisitID LEFT OUTER JOIN
                      tblJobOfWork ON tblJobOfWork.JobOfWorkID = tblEngineerVisit.JobOfWorkID LEFT OUTER JOIN
                      tblJob ON tblJob.JobID = tblJobOfWork.JobID LEFT OUTER JOIN
                      tblSite AS JOBSITE ON tblJob.SiteID = JOBSITE.SiteID LEFT OUTER JOIN
                      tblCustomer AS JOBCUSTOMER ON JOBSITE.CustomerID = JOBCUSTOMER.CustomerID LEFT OUTER JOIN
                      tblOrderLocation ON tblOrder.OrderID = tblOrderLocation.OrderID LEFT OUTER JOIN
                      tblSite ON tblSiteOrder.SiteID = tblSite.SiteID LEFT OUTER JOIN
                      tblCustomer ON tblSite.CustomerID = tblCustomer.CustomerID LEFT OUTER JOIN
                      tblLocations ON tblOrderLocation.LocationID = tblLocations.LocationID LEFT OUTER JOIN
                      tblVan ON tblLocations.VanID = tblVan.VanID LEFT OUTER JOIN
                      tblWarehouse ON tblLocations.WarehouseID = tblWarehouse.WarehouseID LEFT OUTER JOIN
                      tblOrderPart ON tblOrder.OrderID = tblOrderPart.OrderID LEFT OUTER JOIN
                      tblOrderProduct ON tblOrder.OrderID = tblOrderProduct.OrderID LEFT OUTER JOIN
                      tblPartSupplier ON tblOrderPart.PartSupplierID = tblPartSupplier.PartSupplierID LEFT OUTER JOIN
                      tblProductSupplier ON tblOrderProduct.ProductSupplierID = tblProductSupplier.ProductSupplierID LEFT OUTER JOIN
                      tblSupplier ON tblSupplier.SupplierID = tblProductSupplier.SupplierID OR tblSupplier.SupplierID = tblPartSupplier.SupplierID LEFT OUTER JOIN
                      [#temp2] ON [#temp2].OrderID = tblOrder.OrderID LEFT OUTER JOIN
                      [#INVOICE_STATUS] ON [#INVOICE_STATUS].OrderID = tblOrder.OrderID LEFT OUTER JOIN
                      tblOrderConsolidation ON tblOrder.OrderConsolidationID = tblOrderConsolidation.OrderConsolidationID LEFT OUTER JOIN
                      tblOrderLocationPart ON tblOrderLocationPart.OrderID = tblOrder.OrderID LEFT OUTER JOIN
                      tblOrderLocationProduct ON tblOrderLocationProduct.OrderID = tblOrder.OrderID LEFT OUTER JOIN
                      tblLocations AS LocPart ON LocPart.LocationID = tblOrderLocationPart.LocationID LEFT OUTER JOIN
                      tblLocations AS LocProduct ON LocProduct.LocationID = tblOrderLocationProduct.LocationID LEFT OUTER JOIN
                      tblWarehouse AS PartWare ON LocPart.WarehouseID = PartWare.WarehouseID LEFT OUTER JOIN
                      tblWarehouse AS ProductWare ON LocProduct.WarehouseID = ProductWare.WarehouseID LEFT OUTER JOIN
                      [#PartsNotReceived] ON tblOrder.OrderID = [#PartsNotReceived].OrderID LEFT OUTER JOIN
                      tblVan AS PartVan ON LocPart.VanID = PartVan.VanID LEFT OUTER JOIN
                      tblVan AS ProductVan ON LocProduct.VanID = ProductVan.VanID
WHERE     (tblOrder.Deleted = 0) AND (tblOrder.OrderID IN
                          (SELECT     tblOrder.OrderID
                            FROM          [#FILTERIDs])) AND (@PartsNotReceived = 0 OR
                      (CASE WHEN #PartsNotReceived.PartsNotReceived = 0 THEN 0 ELSE 1 END) = @PartsNotReceived) AND (@OrderSiteID = 0 OR
                      ISNULL(tblSite.SiteID, JOBSITE.SiteID) = @OrderSiteID) AND (@OrderVanID = 0 OR
                      tblVan.VanID = @OrderVanID) AND (@OrderWarehouseID = 0 OR
                      tblWarehouse.WarehouseID = @OrderWarehouseID) AND (@OrderJobID = 0 OR
                      tblJob.JobID = @OrderJobID) AND (@OrderTypeID = 0 OR
                      tblOrder.OrderTypeID = @OrderTypeID) AND (tblOrder.OrderReference LIKE @OrderReference) AND (ISNULL(tblOrderConsolidation.ConsolidationRef, N'') LIKE @OrderConsolidationRef) AND 
                      (@OrderStatus = 0 OR
                      (CASE ISNULL(#INVOICE_STATUS.Invoiced, 0) WHEN 0 THEN tblOrderStatus.[OrderStatusID] ELSE CASE ISNULL(#INVOICE_STATUS.ExportedToSage, 0) WHEN 0 THEN 5 ELSE 6 END END) 
                      = @OrderStatus) AND (@OrderSupplierExported = 0 OR
                      (CASE WHEN
                          (SELECT     COUNT(*) AS Results
                            FROM          tblOrderSupplierInvoices
                            WHERE      (OrderID = tblOrder.OrderID) AND (SentToSage = 1)) = 0 THEN 2 ELSE 1 END) = @OrderSupplierExported) AND (@OrderSupplierID = 0 OR
                      CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.SupplierID ELSE tblOrderPart.ChildSupplierID END = @OrderSupplierID) AND (@OrderDatePlacedFrom IS NULL OR
                      tblOrder.DatePlaced >= @OrderDatePlacedFrom) AND (@OrderDatePlacedTo IS NULL OR
                      tblOrder.DatePlaced <= @OrderDatePlacedTo) AND (@OrderDeliveryDeadlineFrom IS NULL OR
                      tblOrder.DeliveryDeadline >= @OrderDeliveryDeadlineFrom) AND (@OrderDeliveryDeadlineTo IS NULL OR
                      tblOrder.DeliveryDeadline <= @OrderDeliveryDeadlineTo) AND (@OrderDepartment IS NULL OR
                      tblOrder.DepartmentRef LIKE @OrderDepartment)
	
	
DROP TABLE #temp1
DROP TABLE #temp2
DROP TABLE #INVOICE_STATUS
DROP TABLE #FILTERIDs
DROP TABLE #PartsNotReceived
DROP TABLE #TempPartPrices
DROP TABLE #TempProductPrices
