SELECT 
ManagerID,
EnumTypeID,
`Name`,
Description,
Deleted,
PercentageRate,
Mandatory
FROM tblpicklists
WHERE ManagerID = ?ManagerID 