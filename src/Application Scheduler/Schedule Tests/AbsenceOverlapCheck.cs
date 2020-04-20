using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class AbsenceOverlapCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Absence Overlap";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)

        {
            if (Entity.Sys.Helper.MakeDateTimeValid(day) == default)
            {
                if (Entity.Sys.Helper.MakeDateTimeValid(testRow["StartDateTime"]) != default)
                {
                    day = Conversions.ToDate(testRow["StartDateTime"]);
                }
            }

            if (Entity.Sys.Helper.MakeDateTimeValid(day) != default)
            {
                if (App.DB.Scheduler.AbsenceOverlap(engineerID.ToString(), day) == true)
                {
                    return new TestResult(string.Format("WARNING: This visit may overlap an absence in the schedule"));
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