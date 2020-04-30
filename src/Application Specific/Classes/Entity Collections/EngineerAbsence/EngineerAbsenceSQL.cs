using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.EngineerAbsence
{
    public class EngineerAbsenceSQL
    {
        private Sys.Database _database;

        public EngineerAbsenceSQL(Sys.Database database)
        {
            _database = database;
        }

        

        public void Delete(int EngineerAbsenceID)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerAbsenceID", EngineerAbsenceID);
            _database.ExecuteSP_NO_Return("EngineerAbsence_Delete");
        }

        public EngineerAbsence EngineerAbsence_Get(int EngineerAbsenceID)
        {
            var dt = new DataTable();
            var oEngineerAbsence = new EngineerAbsence();
            var pEngineerAbsenceID = new SqlParameter("@EngineerAbsenceID", EngineerAbsenceID);

            // Get the datatable from the database store in dt
            dt = _database.ExecuteSP_DataTable("EngineerAbsence_Get", pEngineerAbsenceID);
            if (dt is object && dt.Rows.Count > 0)
            {
                oEngineerAbsence.SetEngineerAbsenceID = dt.Rows[0]["EngineerAbsenceID"];
                oEngineerAbsence.SetEngineerID = dt.Rows[0]["EngineerID"];
                oEngineerAbsence.SetAbsenceTypeID = dt.Rows[0]["AbsenceTypeID"];
                oEngineerAbsence.DateFrom = Conversions.ToDate(dt.Rows[0]["DateFrom"]);
                oEngineerAbsence.DateTo = Conversions.ToDate(dt.Rows[0]["DateTo"]);
                oEngineerAbsence.SetComments = dt.Rows[0]["Comments"];
                oEngineerAbsence.Exists = true;
                return oEngineerAbsence;
            }
            else
            {
                return null;
            }
        }

        public DataTable EngineerAbsence_GetAll()
        {
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("EngineerAbsence_GetAll");
            dt.TableName = "tblEngineerAbsence";
            return dt;
        }

        public EngineerAbsence Insert(EngineerAbsence oEngineerAbsence)
        {
            AddEngineerAbsenceParameters(ref oEngineerAbsence);
            oEngineerAbsence.Exists = true;
            oEngineerAbsence.SetEngineerAbsenceID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerAbsence_Insert"));
            return oEngineerAbsence;
        }

        public void Update(EngineerAbsence oEngineerAbsence)
        {
            _database.ClearParameter();
            AddEngineerAbsenceParameters(ref oEngineerAbsence);
            _database.AddParameter("@EngineerAbsenceID", oEngineerAbsence.EngineerAbsenceID, true);
            _database.ExecuteSP_NO_Return("EngineerAbsence_Update");
        }

        private void AddEngineerAbsenceParameters(ref EngineerAbsence oEngineerAbsence)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", oEngineerAbsence.EngineerID);
            _database.AddParameter("@AbsenceTypeID", oEngineerAbsence.AbsenceTypeID);
            _database.AddParameter("@DateFrom", Strings.Format(oEngineerAbsence.DateFrom, "yyyy-MM-dd HH:mm"));
            _database.AddParameter("@DateTo", Strings.Format(oEngineerAbsence.DateTo, "yyyy-MM-dd HH:mm"));
            _database.AddParameter("@Comments", oEngineerAbsence.Comments);
        }

        public DataTable EngineerAbsenceTypes_GetAll()
        {
            var dt = new DataTable();
            _database.ClearParameter();
            dt = _database.ExecuteSP_DataTable("EngineerAbsenceTypes_GetAll");
            dt.TableName = "tblEngineerAbsenceTypes";
            return dt;
        }

        public DataTable AbsenceSearch(string sql)
        {
            var dt = new DataTable();
            dt = _database.ExecuteWithReturn(sql);
            dt.TableName = "tblEngineerAbsence";
            return dt;
        }

        public DataTable GetAbsencesForEngineer(int engineerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", engineerID);
            return _database.ExecuteSP_DataTable("Engineer_Absences_Get");
        }


        
    }
}