SELECT 
UserID, 
Fullname,
UserName, 
Password, 
Enabled,
RegionID,
Deleted,
Admin,
EmailAddress,
SchedulerDayView,
ISNULL(DefaultSchedulerEngineerGroup,0) as DefaultSchedulerEngineerGroup
FROM tblUser
WHERE Deleted = 0
ORDER BY Deleted ASC, Fullname