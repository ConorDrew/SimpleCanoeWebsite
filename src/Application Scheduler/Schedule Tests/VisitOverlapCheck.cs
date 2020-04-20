using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class VisitOverlapCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Visit Overlap";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)

        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(testRow["EngineerID"], 0, false) | Operators.ConditionalCompareObjectEqual(testRow["EngineerID"], engineerID, false)))
            {
                if (Information.IsDBNull(testRow["StartDateTime"]) == false && Information.IsDBNull(testRow["EndDateTime"]) == false && App.DB.Scheduler.VisitOverlaps(engineerID.ToString(), Conversions.ToDate(testRow["StartDateTime"]), Conversions.ToDate(testRow["EndDateTime"])) == true)
                {
                    return new TestResult(string.Format("This visit would overlap an existing visit in the schedule"));
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