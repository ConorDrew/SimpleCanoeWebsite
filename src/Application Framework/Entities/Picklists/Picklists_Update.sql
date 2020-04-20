UPDATE tblpicklists SET 
`Name` = ?Name,
Description = ?Description,
PercentageRate = ?PercentageRate,
Mandatory = ?Mandatory
WHERE ManagerID = ?ManagerID