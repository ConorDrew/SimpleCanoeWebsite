SELECT     tblPicklists.ManagerID, tblPicklists.EnumTypeID, tblPicklists.Name, tblPicklists.Description, tblPicklists.Deleted, tblPicklists.PercentageRate, tblPicklists.Name + ' ' + tblPicklists.Description as combo, tblPicklists.Mandatory
FROM         tblPicklists 
WHERE     (tblPicklists.Deleted = 0) AND (tblPicklists.EnumTypeID = ?EnumTypeID)
ORDER BY tblPicklists.Deleted, tblPicklists.Name