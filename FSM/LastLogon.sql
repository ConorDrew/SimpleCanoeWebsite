SELECT 
MAX(AccessDate) AS 'LastLogon' 
FROM tblhistory 
WHERE UserID = ?UserID 
AND AccessType = 'LOGON'