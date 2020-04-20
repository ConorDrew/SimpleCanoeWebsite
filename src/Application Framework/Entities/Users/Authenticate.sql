SELECT 
UserID 
FROM tblUser
WHERE Deleted = 0 
AND Enabled = 1 
AND UserName = ?UserName
AND Password = ?Password
