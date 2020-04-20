using System.Data;

namespace FSM.Entity
{
    namespace Appointments
    {
        public class AppointmentsSQL
        {
            private Sys.Database _database;

            public AppointmentsSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Appointments_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblAppointments.ToString();
                return new DataView(dt);
            }

            public Appointment Get(int AppointmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AppointmentID", AppointmentID);
                var dt = _database.ExecuteSP_DataTable("Appointments_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var appointment = new Appointment();
                        appointment.SetAppointmentID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["AppointmentID"]);
                        appointment.SetName = Sys.Helper.MakeStringValid(dt.Rows[0]["Name"]);
                        appointment.SetStartTime = Sys.Helper.MakeTimeValid(dt.Rows[0]["StartTime"]);
                        appointment.SetEndTime = Sys.Helper.MakeTimeValid(dt.Rows[0]["EndTime"]);
                        return appointment;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}