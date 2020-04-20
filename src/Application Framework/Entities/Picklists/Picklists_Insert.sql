INSERT INTO tblpicklists 
(
EnumTypeID, 
`Name`, 
Description,
PercentageRate,
Mandatory
) 
VALUES 
(
?EnumTypeID,
?Name,
?Description,
?PercentageRate,
?Mandatory
)
;
SELECT @@IDENTITY