using System;
using System.Collections;
using System.Data;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class PriorityCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Priority Check";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)
        {
            var errorMsg = new ArrayList();
            if (Helper.MakeDateTimeValid(day) == default)
            {
                if (Helper.MakeDateTimeValid(testRow["StartDateTime"]) != default)
                {
                    day = Conversions.ToDate(testRow["StartDateTime"]);
                }
            }

            if (day != default)
            {
                var visitDate = Helper.MakeDateTimeValid(day);
                var dtJobOfWork = App.DB.JobOfWorks.JobOfWork_Get_ForEngineerVisitID(Conversions.ToInteger(testRow["EngineerVisitID"]));
                if (dtJobOfWork.Rows.Count > 0)
                {
                    int priority = Helper.MakeIntegerValid(dtJobOfWork.Rows[0]["Priority"]);
                    var jobCreatedDateTime = Helper.MakeDateTimeValid(dtJobOfWork.Rows[0]["JobCreatedDateTime"]);
                    DateTime lastVisitDate = default;
                    var switchExpr = (Enums.JobPriority)Conversions.ToInteger(priority);
                    switch (switchExpr)
                    {
                        case Enums.JobPriority.PriortyOneFiveDays:
                            {
                                lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 5);
                                break;
                            }

                        case Enums.JobPriority.EMTwentyFourHours:
                        case Enums.JobPriority.EMTwentyFourHoursOOH:
                            {
                                lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 1);
                                break;
                            }

                        case Enums.JobPriority.RoutineOneTwentyDays:
                            {
                                lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 20);
                                break;
                            }

                        case Enums.JobPriority.PriortyThreeDays:
                            {
                                lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 3);
                                break;
                            }

                        case Enums.JobPriority.ApptTwentyEightDays:
                            {
                                lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 28);
                                break;
                            }
                    }

                    if (lastVisitDate != default && visitDate > lastVisitDate)
                    {
                        errorMsg.Add("Visit date outside of priority, please change priority or create new job!");
                    }
                }
            }

            if (errorMsg.Count == 0)
            {
                return new TestResult();
            }
            else
            {
                return new TestResult(errorMsg, true, false);
            }
        }
    }
}