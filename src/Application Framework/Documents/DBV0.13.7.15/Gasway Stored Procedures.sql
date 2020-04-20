USE [FSM]
GO
/****** Object:  StoredProcedure [dbo].[Part_SearchList]    Script Date: 12/08/2014 11:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Part_SearchList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Part_SearchList] AS' 
END
GO




ALTER                  PROCEDURE [dbo].[Part_SearchList]
		(	@SearchString nvarchar(255) = ' ', @SearchOnField as nvarchar(255) = '')
AS
	--[GAB_AUTO_GENERATED_GET]
	--[GAB_ENTITY_PART]
if @SearchOnField = ''
begin			
		SELECT DISTINCT tblPart.[PartID],
	tblPart.[Name],
	tblPart.[Number],
	tblPart.[Reference],
	tblPart.[Deleted],
	tblPart.[UnitTypeID],
	tblPickLists.[name] as [UnitType],
	tblPart.SellPrice,
	tblPart.RecommendedQuantity,
	tblPart.MinimumQuantity,
	tblPart.[CategoryID],
		tblPart.WarehouseID,
		tblPart.ShelfID,
	tblPart.BinID,
		ISNULL(tblWarehouse.Name,'N/A') AS Warehouse,
		ISNULL(TBLSHELF.Name,'N/A') AS Shelf,
	ISNULL(TBLBIN.Name,'N/A') AS Bin,
		ISNULL(TBLWAREHOUSEALTERNATIVE.Name,'N/A') AS WarehouseAlternative,
		ISNULL(TBLSHELFALTERNATIVE.Name,'N/A') AS ShelfAlternative,
		ISNULL(TBLBINALTERNATIVE.Name,'N/A') AS BinAlternative,
	tblPart.EndFlagged,
ISNULL(
		(
			SELECT
			ISNULL(SUM(ISNULL(currentPartStockLevels.Amount,0)),0)
			FROM currentPartStockLevels
			INNER JOIN tblLocations on currentPartStockLevels.locationID = tblLocations.LocationID
			WHERE tblLocations.WarehouseID = 
				(
				CASE tblPart.WarehouseID
					WHEN 0 THEN
						(
							SELECT TOP 1
							tblWarehouse.WarehouseID
							FROM tblWarehouse
							WHERE tblWarehouse.Deleted = 0
							ORDER BY tblWarehouse.WarehouseID DESC
						)
					ELSE tblPart.WarehouseID
				END
				)
			AND currentPartStockLevels.PartID = tblPart.[PartID]
		),0) AS WarehouseQuantity,
	'0' AS [Selected],
	'' AS QuantityHolder,
	tblPart.Equipment
		FROM tblPart
		INNER JOIN tblPickLists
		ON tblPickLists.ManagerID = tblPart.UnitTypeID
		LEFT JOIN tblWarehouse ON tblPart.WarehouseID = tblWarehouse.WarehouseID 
		LEFT JOIN tblPickLists TBLSHELF ON TBLSHELF.ManagerID = tblPart.BinID
		LEFT JOIN tblPickLists TBLBIN ON TBLBIN.ManagerID = tblPart.BinID
		LEFT JOIN tblWarehouse TBLWAREHOUSEALTERNATIVE ON TBLWAREHOUSEALTERNATIVE.WarehouseID = tblPart.WarehouseIDAlternative 
		LEFT JOIN tblPickLists TBLSHELFALTERNATIVE ON TBLSHELFALTERNATIVE.ManagerID = tblPart.BinIDAlternative
		LEFT JOIN tblPickLists TBLBINALTERNATIVE ON TBLBINALTERNATIVE.ManagerID = tblPart.BinIDAlternative
		LEFT JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID 
		WHERE
		tblPart.Deleted = 0 AND
		(tblPart.[Name] LIKE '%' + @searchString + '%'
		OR tblPart.[Number] LIKE '%' + @searchString + '%'
		OR tblPart.Reference LIKE '%' + @searchString + '%'
		OR tblPartSupplier.PartCode LIKE '%' + @searchString + '%')
		--tblPartSupplier.Deleted = 0 AND
end
else
begin
DECLARE @Statement as varchar(4000)
SET @Statement = 'SELECT DISTINCT tblPart.[PartID],
	tblPart.[Name],
	tblPart.[Number],
	tblPart.[Reference],
	tblPart.[Deleted],
	tblPart.[UnitTypeID],
	tblPickLists.[name] as [UnitType],
	tblPart.SellPrice,
	tblPart.RecommendedQuantity,
	tblPart.MinimumQuantity,
	tblPart.[CategoryID],
	tblPart.WarehouseID,
	tblPart.ShelfID,
	tblPart.BinID,
	ISNULL(tblWarehouse.Name,''N/A'') AS Warehouse,
	ISNULL(TBLSHELF.Name,''N/A'') AS Shelf,
	ISNULL(TBLBIN.Name,''N/A'') AS Bin,
	ISNULL(TBLWAREHOUSEALTERNATIVE.Name,''N/A'') AS WarehouseAlternative,
	ISNULL(TBLSHELFALTERNATIVE.Name,''N/A'') AS ShelfAlternative,
	ISNULL(TBLBINALTERNATIVE.Name,''N/A'') AS BinAlternative,
	tblPart.EndFlagged,
	ISNULL(
		(
			SELECT
			ISNULL(SUM(ISNULL(currentPartStockLevels.Amount,0)),0)
			FROM currentPartStockLevels
			INNER JOIN tblLocations on currentPartStockLevels.locationID = tblLocations.LocationID
			WHERE tblLocations.WarehouseID = 
				(
				CASE tblPart.WarehouseID
					WHEN 0 THEN
						(
							SELECT TOP 1
							tblWarehouse.WarehouseID
							FROM tblWarehouse
							WHERE tblWarehouse.Deleted = 0
							ORDER BY tblWarehouse.WarehouseID DESC
						)
					ELSE tblPart.WarehouseID
				END
				)
			AND currentPartStockLevels.PartID = tblPart.[PartID]
		),0) AS WarehouseQuantity,
	''0'' AS [Selected],
	'''' AS QuantityHolder,
	tblPart.Equipment
		FROM tblPart
		INNER JOIN tblPickLists
		ON tblPickLists.ManagerID = tblPart.UnitTypeID
		INNER JOIN tblpicklists Category ON tblPart.CategoryID = Category.managerid
		LEFT JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID
		LEFT JOIN tblSupplier ON tblSupplier.SupplierID = tblPartSupplier.SupplierID
		LEFT JOIN tblWarehouse ON tblPart.WarehouseID = tblWarehouse.WarehouseID 
		LEFT JOIN tblPickLists TBLSHELF ON TBLSHELF.ManagerID = tblPart.BinID
		LEFT JOIN tblPickLists TBLBIN ON TBLBIN.ManagerID = tblPart.BinID
		LEFT JOIN tblWarehouse TBLWAREHOUSEALTERNATIVE ON TBLWAREHOUSEALTERNATIVE.WarehouseID = tblPart.WarehouseIDAlternative 
		LEFT JOIN tblPickLists TBLSHELFALTERNATIVE ON TBLSHELFALTERNATIVE.ManagerID = tblPart.BinIDAlternative
		LEFT JOIN tblPickLists TBLBINALTERNATIVE ON TBLBINALTERNATIVE.ManagerID = tblPart.BinIDAlternative
		WHERE
		tblPart.Deleted = 0 AND'
SET @Statement = @Statement + @SearchOnField + ' LIKE ' + @searchString
EXECUTE(@Statement)
end
	--AND tblPartSupplier.Deleted = 0








GO
/****** Object:  StoredProcedure [dbo].[Site_UpdateLastServiceDate]    Script Date: 12/08/2014 11:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Site_UpdateLastServiceDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Site_UpdateLastServiceDate] AS' 
END
GO
 
ALTER PROCEDURE [dbo].[Site_UpdateLastServiceDate]
		(	@SiteID int,
			@LastServiceDate datetime )
AS


 

UPDATE tblSite
SET Prev_LastServiceDate = case when lastservicedate >= CONVERT(nvarchar(11), @LastServiceDate, 113) + ' 00:00:00' then Prev_LastServiceDate else  LastServiceDate end, 
  LastServiceDate = CONVERT(nvarchar(11), @LastServiceDate, 113) + ' 00:00:00' 
    --LastServiceDate = case when lastservicedate >= CONVERT(nvarchar(11), @LastServiceDate, 113) + ' 00:00:00' then lastservicedate else CONVERT(nvarchar(11), @LastServiceDate, 113) + ' 00:00:00' end
WHERE SiteID =@SiteID
GO
/****** Object:  StoredProcedure [dbo].[Site_UpdateLastServiceDateForJobOfWork]    Script Date: 12/08/2014 11:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Site_UpdateLastServiceDateForJobOfWork]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Site_UpdateLastServiceDateForJobOfWork] AS' 
END
GO
 
ALTER PROCEDURE [dbo].[Site_UpdateLastServiceDateForJobOfWork]
		(	@SiteID int,
			@JobOfWorkID int,
			@LastServiceDate datetime)
AS


UPDATE tblSite
SET LastServiceDate = CONVERT(nvarchar(11), @LastServiceDate, 113) + ' 00:00:00'
from tblSite INNER JOIN tblJob ON tblSite.SiteID = tblJob.JobID
INNER JOIN tblJobOfWork ON tblJobOfWork.JobID = tblJob.JobID
INNER JOIN tblLettersGenerated ON tblJob.JobID = tblLettersGenerated.JobID
WHERE tblSite.SiteID = @SiteID AND tblJobOfWork.JobOfWorkID = @JobOfWorkID
GO
