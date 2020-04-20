using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class RegionCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Region";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)

        {
            var engineer = App.DB.Engineer.Engineer_Get(engineerID);
            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(engineer.RegionID, testRow["RegionID"], false)))
            {
                return new TestResult(string.Format("This Engineer is not associated with the region: {0}", testRow["Region"]));
            }
            else
            {
                return new TestResult();
            }
        }
    }
}