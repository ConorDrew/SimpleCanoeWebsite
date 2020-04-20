using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class PostcodeRegionCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Postcode region";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)
        {
            if (Conversions.ToInteger(App.DB.EngineerPostalRegion.Check(engineerID, Conversions.ToString(testRow["Postcode1"]))) == 0)
            {
                return new TestResult(string.Format("This Engineer is not associated with the Postcode: {0}", testRow["Postcode1"]));
            }
            else
            {
                return new TestResult();
            }
        }
    }
}