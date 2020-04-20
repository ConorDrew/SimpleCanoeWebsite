INSERT INTO tbluser
(
Fullname,
UserName, 
Password, 
RegionID,
Enabled,
Admin,
EmailAddress,
SchedulerDayView,
DefaultSchedulerEngineerGroup
)
VALUES
(
?Fullname,
?UserName, 
?Password, 
?RegionID,
?Enabled,
?Admin,
?EmailAddress,
?SchedulerDayView,
?DefaultSchedulerEngineerGroup
)
;

SELECT @@IDENTITY;