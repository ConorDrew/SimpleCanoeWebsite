// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CostCentres.CostCentreSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CostCentres.Enums;
using FSM.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CostCentres
{
    public class CostCentreSql
    {
        private Database _database;

        public CostCentreSql(Database database)
        {
            this._database = database;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            return new DataView(this._database.ExecuteSP_DataTable("CostCentre_GetAll", true));
        }

        public List<CostCentre> Get(int @ref, int ref2, GetBy getBy)
        {
            this._database.ClearParameter();
            DataTable table;
            switch (getBy)
            {
                case GetBy.Id:
                    this._database.AddParameter("@Id", (object)@ref, true);
                    table = this._database.ExecuteSP_DataTable("CostCentre_Get_ById", true);
                    break;

                case GetBy.JobTypeId:
                    this._database.AddParameter("@JobTypeId", (object)@ref, true);
                    table = this._database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeId", true);
                    break;

                case GetBy.JobTypeIdAndCutomerId:
                    this._database.AddParameter("@JobTypeId", (object)@ref, true);
                    this._database.AddParameter("@CustomerId", (object)ref2, true);
                    table = this._database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeIdAndCustomerId", true);
                    break;

                case GetBy.JobId:
                    this._database.AddParameter("@JobID", (object)@ref, true);
                    table = this._database.ExecuteSP_DataTable("CostCentre_Get_ByJobId", true);
                    break;

                default:
                    this._database.AddParameter("@Id", (object)@ref, true);
                    table = this._database.ExecuteSP_DataTable("CostCentre_Get_ById", true);
                    break;
            }
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<CostCentre>(table) : (List<CostCentre>)null;
        }

        public CostCentre Insert(CostCentre ccm)
        {
            this.AddParameters(ccm);
            ccm.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CostCentre_Insert", true)));
            return ccm;
        }

        private void AddParameters(CostCentre ccm)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CostCentre", (object)ccm.Name, false);
            this._database.AddParameter("@JobTypeId", (object)ccm.JobTypeId, false);
            this._database.AddParameter("@LinkId", (object)ccm.LinkId, false);
            this._database.AddParameter("@LinkTypeId", (object)ccm.LinkTypeId, false);
            this._database.AddParameter("@JobSpendLimit", RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Decimal.Compare(ccm.JobSpendLimit, Decimal.Zero) > 0 ? (object)ccm.JobSpendLimit : (object)DBNull.Value)), true);
        }

        public CostCentre Update(CostCentre ccm)
        {
            this.AddParameters(ccm);
            this._database.AddParameter("@Id", (object)ccm.Id, false);
            ccm.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CostCentre_Update", true)));
            return ccm;
        }

        public bool Delete(int Id)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Id", (object)Id, false);
            return this._database.ExecuteSP_ReturnRowsAffected("CostCentre_Delete") == 1;
        }
    }
}