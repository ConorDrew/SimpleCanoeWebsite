using System;
using System.Data;

namespace FSM
{
    public class SOROverloadCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "SOR Overload";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)
        {
            if (day != default)
            {
                int freeMins = 0;
                var maxTimes = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(engineerID);
                if (maxTimes is object)
                {
                    var switchExpr = day.DayOfWeek;
                    switch (switchExpr)
                    {
                        case DayOfWeek.Monday:
                            {
                                freeMins = maxTimes.MondayValue;
                                break;
                            }

                        case DayOfWeek.Tuesday:
                            {
                                freeMins = maxTimes.TuesdayValue;
                                break;
                            }

                        case DayOfWeek.Wednesday:
                            {
                                freeMins = maxTimes.WednesdayValue;
                                break;
                            }

                        case DayOfWeek.Thursday:
                            {
                                freeMins = maxTimes.ThursdayValue;
                                break;
                            }

                        case DayOfWeek.Friday:
                            {
                                freeMins = maxTimes.FridayValue;
                                break;
                            }

                        case DayOfWeek.Saturday:
                            {
                                freeMins = maxTimes.SaturdayValue;
                                break;
                            }

                        case DayOfWeek.Sunday:
                            {
                                freeMins = maxTimes.SundayValue;
                                break;
                            }
                    }
                }

                var dtSOR = App.DB.Scheduler.SORTime_GetForEngineerAndDay(engineerID, day);
                int totalDaySOR = 0;
                if (dtSOR.Rows.Count > 0)
                {
                    totalDaySOR = Entity.Sys.Helper.MakeIntegerValid(dtSOR.Rows[0]["TotalDaySOR"]);
                }

                if (totalDaySOR + Entity.Sys.Helper.MakeIntegerValid(testRow["summedSOR"]) > freeMins)
                {
                    return new TestResult(string.Format("The SOR time total will overload this engineers time for the day"), false, true);
                }
                else
                {
                    return new TestResult();
                }
            }
            else
            {
                return new TestResult();
            }
        }
    }
}