// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWorkSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSiteJobOfWorks
{
    public class ContractAlternativeSiteJobOfWorkSQL
    {
        private Database _database;

        public ContractAlternativeSiteJobOfWorkSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int ContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteJobOfWorkID", (object)ContractSiteJobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Delete", true);
        }

        public ContractAlternativeSiteJobOfWork ContractAlternativeSiteJobOfWork_Get(
          int ContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteJobOfWorkID", (object)ContractSiteJobOfWorkID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ContractAlternativeSiteJobOfWork_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ContractAlternativeSiteJobOfWork)null;
            ContractAlternativeSiteJobOfWork alternativeSiteJobOfWork1 = new ContractAlternativeSiteJobOfWork();
            ContractAlternativeSiteJobOfWork alternativeSiteJobOfWork2 = alternativeSiteJobOfWork1;
            alternativeSiteJobOfWork2.IgnoreExceptionsOnSetMethods = true;
            alternativeSiteJobOfWork2.SetContractSiteJobOfWorkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(ContractSiteJobOfWorkID)]);
            alternativeSiteJobOfWork2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteID"]);
            alternativeSiteJobOfWork2.FirstVisitDate = Conversions.ToDate(dataTable.Rows[0]["FirstVisitDate"]);
            alternativeSiteJobOfWork2.SetAverageMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AverageMileage"]);
            alternativeSiteJobOfWork2.SetIncludeMileagePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeMileagePrice"]);
            alternativeSiteJobOfWork2.SetIncludeRates = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeRates"]);
            alternativeSiteJobOfWork2.SetPricePerMile = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerMile"]);
            alternativeSiteJobOfWork2.SetPricePerVisit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerVisit"]);
            alternativeSiteJobOfWork2.SetTotalSitePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TotalSitePrice"]);
            alternativeSiteJobOfWork1.Exists = true;
            return alternativeSiteJobOfWork1;
        }

        public ArrayList Get_For_ContractSite_As_Objects(int ContractSiteID)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dr in this.JobOfWork_Get_For_Contract(ContractSiteID).Table.Rows)
            {
                arrayList.Add((object)new ContractAlternativeSiteJobOfWork()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    Exists = true,
                    SetContractSiteID = RuntimeHelpers.GetObjectValue(dr[nameof(ContractSiteID)]),
                    SetContractSiteJobOfWorkID = RuntimeHelpers.GetObjectValue(dr["ContractSiteJobOfWorkID"]),
                    FirstVisitDate = Conversions.ToDate(dr["FirstVisitDate"]),
                    SetAverageMileage = RuntimeHelpers.GetObjectValue(dr["AverageMileage"]),
                    SetIncludeMileagePrice = RuntimeHelpers.GetObjectValue(dr["IncludeMileagePrice"]),
                    SetIncludeRates = RuntimeHelpers.GetObjectValue(dr["IncludeRates"]),
                    SetPricePerMile = RuntimeHelpers.GetObjectValue(dr["PricePerMile"]),
                    SetPricePerVisit = RuntimeHelpers.GetObjectValue(dr["PricePerVisit"]),
                    SetTotalSitePrice = RuntimeHelpers.GetObjectValue(dr["TotalSitePrice"])
                });
            }
            return arrayList;
        }

        public DataView JobOfWork_Get_For_Contract(int ContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteID", (object)ContractSiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_Get_For_ContractSiteID", true);
            table.TableName = Enums.TableNames.tblJobOfWork.ToString();
            return new DataView(table);
        }

        public DataView ContractAlternativeSiteJobOfWork_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ContractAlternativeSiteJobOfWork_GetAll), true);
            table.TableName = Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString();
            return new DataView(table);
        }

        public ContractAlternativeSiteJobOfWork Insert(
          ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork)
        {
            this._database.ClearParameter();
            this.AddContractAlternativeSiteJobOfWorkParametersToCommand(ref oContractAlternativeSiteJobOfWork);
            oContractAlternativeSiteJobOfWork.SetContractSiteJobOfWorkID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternativeSiteJobOfWork_Insert", true)));
            oContractAlternativeSiteJobOfWork.Exists = true;
            return oContractAlternativeSiteJobOfWork;
        }

        public void Update(
          ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork,
          DataView oRates)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteJobOfWorkID", (object)oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID, true);
            this.AddContractAlternativeSiteJobOfWorkParametersToCommand(ref oContractAlternativeSiteJobOfWork);
            this._database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Update", true);
            this.SaveRates(oRates, oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID);
        }

        private void AddContractAlternativeSiteJobOfWorkParametersToCommand(
          ref ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork)
        {
            Database database = this._database;
            database.AddParameter("@ContractSiteID", (object)oContractAlternativeSiteJobOfWork.ContractSiteID, true);
            database.AddParameter("@FirstVisitDate", (object)oContractAlternativeSiteJobOfWork.FirstVisitDate, true);
            database.AddParameter("@PricePerVisit", (object)oContractAlternativeSiteJobOfWork.PricePerVisit, true);
            database.AddParameter("@AverageMileage", (object)oContractAlternativeSiteJobOfWork.AverageMileage, true);
            database.AddParameter("@IncludeMileagePrice", (object)oContractAlternativeSiteJobOfWork.IncludeMileagePrice, true);
            database.AddParameter("@IncludeRates", (object)oContractAlternativeSiteJobOfWork.IncludeRates, true);
            database.AddParameter("@PricePerMile", (object)oContractAlternativeSiteJobOfWork.PricePerMile, true);
            database.AddParameter("@TotalSitePrice", (object)oContractAlternativeSiteJobOfWork.TotalSitePrice, true);
        }

        public DataView GetJobOfWorkScheduleOfRates(int ContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteJobOfWorkID", (object)ContractSiteJobOfWorkID, true);
            DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeJobOfWorkScheduleOfRate_Get", true);
            table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return new DataView(table);
        }

        public void SaveRates(DataView oRates, int ContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteJobOfWorkID", (object)ContractSiteJobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Delete", true);

            foreach (DataRow dr in oRates.Table.Rows)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@ContractSiteJobOfWorkID", (object)ContractSiteJobOfWorkID, true);
                this._database.AddParameter("@ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(dr["ScheduleOfRatesCategoryID"]), true);
                this._database.AddParameter("@Code", RuntimeHelpers.GetObjectValue(dr["Code"]), true);
                this._database.AddParameter("@Description", RuntimeHelpers.GetObjectValue(dr["Description"]), true);
                this._database.AddParameter("@Price", RuntimeHelpers.GetObjectValue(dr["Price"]), true);
                this._database.AddParameter("@QtyPerVisit", RuntimeHelpers.GetObjectValue(dr["QtyPerVisit"]), true);
                this._database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Insert", true);
            }
        }
    }
}