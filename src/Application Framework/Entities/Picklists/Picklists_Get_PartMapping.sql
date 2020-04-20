SELECT     tblPicklists.ManagerID, tblPicklists.EnumTypeID, tblPicklists.Name, tblPicklists.Description, tblPicklists.Deleted, tblPicklists.PercentageRate, 
                      tblPartCategoryMappings.PartMapMatch, tblPartCategoryMappings.PartMapID, tblPicklists.Mandatory
FROM         tblPicklists LEFT OUTER JOIN
                      tblPartCategoryMappings ON tblPicklists.ManagerID = tblPartCategoryMappings.ManagerID
WHERE     (tblPicklists.Deleted = 0) AND (tblPicklists.EnumTypeID = ?EnumTypeID) AND (NOT (tblPartCategoryMappings.PartMapMatch IS NULL))
ORDER BY tblPicklists.Deleted, tblPicklists.Name