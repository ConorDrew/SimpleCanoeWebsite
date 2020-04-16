// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWorkSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSiteJobOfWorks
{
    public class QuoteContractAlternativeSiteJobOfWorkSQL
    {
        private Database _database;

        public QuoteContractAlternativeSiteJobOfWorkSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)QuoteContractSiteJobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Delete", true);
        }

        public QuoteContractAlternativeSiteJobOfWork ContractAlternativeSiteJobOfWork_Get(
          int QuoteContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)QuoteContractSiteJobOfWorkID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteContractAlternativeSiteJobOfWork)null;
            QuoteContractAlternativeSiteJobOfWork alternativeSiteJobOfWork1 = new QuoteContractAlternativeSiteJobOfWork();
            QuoteContractAlternativeSiteJobOfWork alternativeSiteJobOfWork2 = alternativeSiteJobOfWork1;
            alternativeSiteJobOfWork2.IgnoreExceptionsOnSetMethods = true;
            alternativeSiteJobOfWork2.SetQuoteContractSiteJobOfWorkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteContractSiteJobOfWorkID)]);
            alternativeSiteJobOfWork2.SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractSiteID"]);
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

        public ArrayList Get_For_QuoteContractSite_As_Objects(int QuoteContractSiteID)
        {
            ArrayList arrayList = new ArrayList();

            foreach (DataRow current in this.JobOfWork_Get_For_QuoteContract(QuoteContractSiteID).Table.Rows)
            {
                QuoteContractAlternativeSiteJobOfWork alternativeSiteJobOfWork = new QuoteContractAlternativeSiteJobOfWork()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    Exists = true,
                    SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(current[nameof(QuoteContractSiteID)]),
                    SetQuoteContractSiteJobOfWorkID = RuntimeHelpers.GetObjectValue(current["QuoteContractSiteJobOfWorkID"]),
                    FirstVisitDate = Conversions.ToDate(current["FirstVisitDate"]),
                    SetAverageMileage = RuntimeHelpers.GetObjectValue(current["AverageMileage"]),
                    SetIncludeMileagePrice = RuntimeHelpers.GetObjectValue(current["IncludeMileagePrice"]),
                    SetIncludeRates = RuntimeHelpers.GetObjectValue(current["IncludeRates"]),
                    SetPricePerMile = RuntimeHelpers.GetObjectValue(current["PricePerMile"]),
                    SetPricePerVisit = RuntimeHelpers.GetObjectValue(current["PricePerVisit"]),
                    SetTotalSitePrice = RuntimeHelpers.GetObjectValue(current["TotalSitePrice"])
                };
                alternativeSiteJobOfWork.ScheduledOfRates_UsedForConvertOnly = this.GetJobOfWorkScheduleOfRates(alternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID);
                arrayList.Add((object)alternativeSiteJobOfWork);
            }
            return arrayList;
        }

        public DataView JobOfWork_Get_For_QuoteContract(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get_For_QuoteContractSiteID", true);
            table.TableName = Enums.TableNames.tblJobOfWork.ToString();
            return new DataView(table);
        }

        public DataView QuoteContractAlternativeSiteJobOfWork_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteContractAlternativeSiteJobOfWork_GetAll), true);
            table.TableName = Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString();
            return new DataView(table);
        }

        public QuoteContractAlternativeSiteJobOfWork Insert(
          QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork)
        {
            this._database.ClearParameter();
            this.AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ref oQuoteContractAlternativeSiteJobOfWork);
            oQuoteContractAlternativeSiteJobOfWork.SetQuoteContractSiteJobOfWorkID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobOfWork_Insert", true)));
            oQuoteContractAlternativeSiteJobOfWork.Exists = true;
            return oQuoteContractAlternativeSiteJobOfWork;
        }

        public void Update(
          QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork,
          DataView oRates)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID, true);
            this.AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ref oQuoteContractAlternativeSiteJobOfWork);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Update", true);
            this.SaveRates(oRates, oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID);
        }

        private void AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(
          ref QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork)
        {
            Database database = this._database;
            database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteID, true);
            database.AddParameter("@FirstVisitDate", (object)oQuoteContractAlternativeSiteJobOfWork.FirstVisitDate, true);
            database.AddParameter("@PricePerVisit", (object)oQuoteContractAlternativeSiteJobOfWork.PricePerVisit, true);
            database.AddParameter("@AverageMileage", (object)oQuoteContractAlternativeSiteJobOfWork.AverageMileage, true);
            database.AddParameter("@IncludeMileagePrice", (object)oQuoteContractAlternativeSiteJobOfWork.IncludeMileagePrice, true);
            database.AddParameter("@IncludeRates", (object)oQuoteContractAlternativeSiteJobOfWork.IncludeRates, true);
            database.AddParameter("@PricePerMile", (object)oQuoteContractAlternativeSiteJobOfWork.PricePerMile, true);
            database.AddParameter("@TotalSitePrice", (object)oQuoteContractAlternativeSiteJobOfWork.TotalSitePrice, true);
        }

        public DataView GetJobOfWorkScheduleOfRates(int QuoteContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)QuoteContractSiteJobOfWorkID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorkScheduleOfRate_Get", true);
            table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return new DataView(table);
        }

        private void SaveRates(DataView oRates, int QuoteContractSiteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)QuoteContractSiteJobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Delete", true);

            foreach (DataRow current in oRates.Table.Rows)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@QuoteContractSiteJobOfWorkID", (object)QuoteContractSiteJobOfWorkID, true);
                this._database.AddParameter("@ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]), true);
                this._database.AddParameter("@Code", RuntimeHelpers.GetObjectValue(current["Code"]), true);
                this._database.AddParameter("@Description", RuntimeHelpers.GetObjectValue(current["Description"]), true);
                this._database.AddParameter("@Price", RuntimeHelpers.GetObjectValue(current["Price"]), true);
                this._database.AddParameter("@QtyPerVisit", RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]), true);
                this._database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Insert", true);
            }
        }

        public DataView JobOfWorks_For_QuoteContractID(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorks_For_QuoteContractID", true);
            table.TableName = Enums.TableNames.NO_TABLE.ToString();
            return new DataView(table);
        }
    }
}