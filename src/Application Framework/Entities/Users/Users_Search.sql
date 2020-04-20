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
DefaultSchedulerEngineerGroup,
SchedulerDayView
FROM tbluser
WHERE Deleted = 0
?SearchFilter
ORDER BY Deleted ASC, Fullname