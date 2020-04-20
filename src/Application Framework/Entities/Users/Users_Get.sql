SELECT 
tblUser.UserID, 
tblUser.Fullname,
tblUser.UserName, 
tblUser.Password, 
tblUser.Enabled,
tblUser.RegionID,
tblUser.Admin,
CASE tblUser.RegionID WHEN 0 THEN 'All' ELSE tblPicklists.Name END AS RegionName,
tblUser.Deleted,
tblUser.EmailAddress,
tblUser.SchedulerDayView,
tblUser.DefaultSchedulerEngineerGroup,
tblUser.SchedulerTextSize
FROM tblUser
LEFT OUTER JOIN tblPicklists ON tblPicklists.ManagerID = tblUser.RegionID 
WHERE tblUser.UserID = ?UserID