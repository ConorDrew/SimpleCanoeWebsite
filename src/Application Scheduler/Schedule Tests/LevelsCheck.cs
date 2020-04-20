using System;
using System.Collections;
using System.Data;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class LevelsCheck : ScheduleTest
    {
        protected override string TestName
        {
            get
            {
                return "Levels";
            }
        }

        public override TestResult Test(DataRow testRow, int engineerID, DateTime day)
        {
            bool cancelSchedule = false;
            var levels = App.DB.EngineerLevel.Get(engineerID).Table;
            var levelsGot = levels.Select("Tick = 1 AND Mandatory = 1").ToList();
            var levelsNeeded = App.DB.Job.JobQualificationsLevels_Get(Conversions.ToInteger(testRow["JobID"])).Table.Select("Tick = 1");
            var levelMessages = new ArrayList();
            foreach (DataRow levelNeeded in levelsNeeded)
            {
                bool found = false;
                foreach (DataRow levelGot in levelsGot)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(levelNeeded["ManagerID"], levelGot["ManagerID"], false)))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    levelMessages.Add("This Engineer has not got the qualification '" + levelNeeded["Name"] + "' which is needed");
                }
            }

            if (Entity.Sys.Helper.MakeIntegerValid(testRow["JobTypeID"]) == Conversions.ToInteger(Entity.Sys.Enums.JobTypes.QualityControl))
            {
                var levelAuditor = levels.Select("ManagerID =" + Conversions.ToInteger(Entity.Sys.Enums.EngineerQual.AUDITOR) + " AND Tick = 1").FirstOrDefault();
                if (levelAuditor is null)
                {
                    cancelSchedule = true;
                    levelMessages.Add("This is a QC Job, and Engineer does not have qualification");
                    goto failure;
                }
                else
                {
                    levelsGot.Add(levelAuditor);
                }
            }

            foreach (DataRow levelGot in levelsGot)
            {
                DateTime expDate = Conversions.ToDate(Interaction.IIf(Information.IsDBNull(levelGot["DateExpires"]), DateAndTime.Now.AddMinutes(1), Conversions.ToDate(levelGot["DateExpires"])));
                if (expDate < Conversions.ToDate(DateAndTime.Today))
                {
                    cancelSchedule = true;
                    levelMessages.Add("One or more mandatory qualifications have expired");
                    break;
                }
            }

        failure:
            ;
            if (levelMessages.Count == 0)
            {
                return new TestResult();
            }
            else
            {
                return new TestResult(levelMessages, cancelSchedule);
            }
        }
    }
}