UPDATE tbluser
SET
Fullname = ?Fullname,
UserName = ?UserName, 
RegionID = ?RegionID,
Enabled = ?Enabled,
Admin = ?Admin,
EmailAddress = ?EmailAddress,
SchedulerDayView  = ?SchedulerDayView,
DefaultSchedulerEngineerGroup = ?DefaultSchedulerEngineerGroup
WHERE UserID = ?UserID