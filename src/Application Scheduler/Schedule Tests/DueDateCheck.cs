using System;
using System.Data;
using Microsoft.VisualBasic;

namespace FSM
{
    public class DueDateCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Due date";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)

        {
            if (testRow.Table.Columns.Contains("DueDate"))
            {
                if (Entity.Sys.Helper.MakeDateTimeValid(day).Date == default)
                {
                    return new TestResult();
                }
                else if (Entity.Sys.Helper.MakeDateTimeValid(testRow["DueDate"]) == default)
                {
                    return new TestResult();
                }
                else if (Entity.Sys.Helper.MakeDateTimeValid(testRow["DueDate"]).Date == Entity.Sys.Helper.MakeDateTimeValid(day).Date)
                {
                    return new TestResult();
                }
                else
                {
                    return new TestResult(string.Format("You are about to schedule the visit on a different date to the due date: " + Strings.Format(Entity.Sys.Helper.MakeDateTimeValid(testRow["DueDate"]).Date, "dd/MM/yyyy")));
                }
            }
            else
            {
                return new TestResult();
            }
        }
    }
}