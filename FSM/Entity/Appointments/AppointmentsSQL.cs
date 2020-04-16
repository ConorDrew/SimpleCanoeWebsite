// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Appointments.AppointmentsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Appointments
{
    public class AppointmentsSQL
    {
        private Database _database;

        public AppointmentsSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("Appointments_GetAll", true);
            table.TableName = Enums.TableNames.tblAppointments.ToString();
            return new DataView(table);
        }

        public Appointment Get(int AppointmentID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AppointmentID", (object)AppointmentID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("Appointments_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Appointment)null;
            Appointment appointment1 = new Appointment();
            Appointment appointment2 = appointment1;
            appointment2.SetAppointmentID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(AppointmentID)]));
            appointment2.SetName = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]));
            appointment2.SetStartTime = (object)Helper.MakeTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartTime"]));
            appointment2.SetEndTime = (object)Helper.MakeTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndTime"]));
            return appointment1;
        }
    }
}