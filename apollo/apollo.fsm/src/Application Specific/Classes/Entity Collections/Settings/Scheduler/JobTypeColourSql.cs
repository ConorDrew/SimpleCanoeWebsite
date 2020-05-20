using System.Collections.Generic;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Settings.Scheduler
{
    public class JobTypeColourSql
    {
        private Database _database;

        public JobTypeColourSql(Database database)
        {
            _database = database;
        }

        public List<JobTypeColour> Get_All()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("JobTypeColour_Get_All");
            if (dt is object && dt.Rows.Count > 0)
            {
                var jobTypeColours = ObjectMap.DataTableToList<JobTypeColour>(dt);
                return jobTypeColours;
            }
            else
            {
                return null;
            }
        }

        public JobTypeColour Insert(JobTypeColour userJobTypeColour)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobTypeId", userJobTypeColour.JobTypeId);
            _database.AddParameter("@Colour", userJobTypeColour.Colour);
            userJobTypeColour.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobTypeColour_Insert"));
            return userJobTypeColour;
        }

        public bool Delete(int Id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", Id);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("JobTypeColour_Delete") == 1);
        }
    }
}