// Decompiled with JetBrains decompiler
// Type: FSM.Entity.UserAbsence.UserAbsenceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.UserAbsence
{
    public class UserAbsenceSQL
    {
        private Database _database;

        public UserAbsenceSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int UserAbsenceID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserAbsenceID", (object)UserAbsenceID, false);
            this._database.ExecuteSP_NO_Return("UserAbsence_Delete", true);
        }

        public FSM.Entity.UserAbsence.UserAbsence UserAbsence_Get(int UserAbsenceID)
        {
            DataTable dataTable1 = new DataTable();
            FSM.Entity.UserAbsence.UserAbsence userAbsence1 = new FSM.Entity.UserAbsence.UserAbsence();
            DataTable dataTable2 = this._database.ExecuteSP_DataTable(nameof(UserAbsence_Get), new SqlParameter("@UserAbsenceID", (object)UserAbsenceID));
            if (dataTable2 == null)
                return (FSM.Entity.UserAbsence.UserAbsence)null;
            if (dataTable2.Rows.Count > 0)
            {
                FSM.Entity.UserAbsence.UserAbsence userAbsence2 = userAbsence1;
                userAbsence2.SetUserAbsenceID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0][nameof(UserAbsenceID)]);
                userAbsence2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["UserID"]);
                userAbsence2.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["AbsenceTypeID"]);
                userAbsence2.DateFrom = Conversions.ToDate(dataTable2.Rows[0]["DateFrom"]);
                userAbsence2.DateTo = Conversions.ToDate(dataTable2.Rows[0]["DateTo"]);
                userAbsence2.SetComments = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["Comments"]);
            }
            userAbsence1.Exists = true;
            return userAbsence1;
        }

        public DataTable UserAbsence_GetAll()
        {
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(UserAbsence_GetAll), true);
            dataTable.TableName = "tblUserAbsence";
            return dataTable;
        }

        public DataTable UserAbsence_GetAll_ByDates(DateTime startDate, DateTime endDate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)Helper.MakeDateTimeValid((object)(Strings.Format((object)startDate, "dd/MMM/yyyy") + " 00:00:00")), true);
            this._database.AddParameter("@EndDate", (object)Helper.MakeDateTimeValid((object)(Strings.Format((object)endDate, "dd/MMM/yyyy") + " 23:59:59")), true);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(UserAbsence_GetAll_ByDates), true);
            dataTable.TableName = "tblUserAbsence";
            return dataTable;
        }

        public FSM.Entity.UserAbsence.UserAbsence Insert(FSM.Entity.UserAbsence.UserAbsence oUserAbsence)
        {
            this.AddUserAbsenceParameters(ref oUserAbsence);
            oUserAbsence.Exists = true;
            oUserAbsence.SetUserAbsenceID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("UserAbsence_Insert", true)));
            return oUserAbsence;
        }

        public void Update(FSM.Entity.UserAbsence.UserAbsence oUserAbsence)
        {
            this._database.ClearParameter();
            this.AddUserAbsenceParameters(ref oUserAbsence);
            this._database.AddParameter("@UserAbsenceID", (object)oUserAbsence.UserAbsenceID, true);
            this._database.ExecuteSP_NO_Return("UserAbsence_Update", true);
        }

        private void AddUserAbsenceParameters(ref FSM.Entity.UserAbsence.UserAbsence oUserAbsence)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)oUserAbsence.UserID, false);
            this._database.AddParameter("@AbsenceTypeID", (object)oUserAbsence.AbsenceTypeID, false);
            this._database.AddParameter("@DateFrom", (object)Strings.Format((object)oUserAbsence.DateFrom, "yyyy-MM-dd HH:mm"), false);
            this._database.AddParameter("@DateTo", (object)Strings.Format((object)oUserAbsence.DateTo, "yyyy-MM-dd HH:mm"), false);
            this._database.AddParameter("@Comments", (object)oUserAbsence.Comments, false);
        }

        public DataTable UserAbsenceTypes_GetAll()
        {
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = this._database.ExecuteSP_DataTable(nameof(UserAbsenceTypes_GetAll), true);
            dataTable2.TableName = "tblUserAbsenceTypes";
            return dataTable2;
        }

        public DataTable AbsenceSearch(string sql)
        {
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = this._database.ExecuteWithReturn(sql, true);
            dataTable2.TableName = "tblUserAbsence";
            return dataTable2;
        }
    }
}