UPDATE    tblPartCategoryMappings
SET              ManagerID = ?ManagerID, PartMapMatch = ?PartMapMatch
WHERE     (PartMapID = ?PartMapID)