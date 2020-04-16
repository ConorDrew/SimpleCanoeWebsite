// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobs.QuoteJobsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.QuoteEngineerVisits;
using FSM.Entity.QuoteJobAssets;
using FSM.Entity.QuoteJobItems;
using FSM.Entity.QuoteJobOfWorks;
using FSM.Entity.QuoteJobPartss;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobs
{
  public class QuoteJobsSQL
  {
    private Database _database;

    public QuoteJobsSQL(Database database)
    {
      this._database = database;
    }

    public void DeleteReservedQuoteNumber(int JobNumber)
    {
      string sql = "DELETE FROM tblQuoteNumber WHERE QuoteNumber = " + Conversions.ToString(JobNumber);
      App.DB.ExecuteWithOutReturn(sql, true);
    }

    public JobNumber GetNextQuoteNumber()
    {
      int jobNumberIn = 0;
      string sql = "SELECT QuoteNumber FROM tblQuoteNumber ORDER BY QuoteNumber ASC";
      DataTable dataTable = App.DB.ExecuteWithReturn(sql, true);
      if (dataTable.Rows.Count > 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[checked (dataTable.Rows.Count - 1)]["QuoteNumber"], (object) dataTable.Rows.Count, false))
        {
          jobNumberIn = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataTable.Rows[checked (dataTable.Rows.Count - 1)]["QuoteNumber"], (object) 1));
        }
        else
        {
          int num = checked (dataTable.Rows.Count - 1);
          int index = 0;
          while (index <= num)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[index]["QuoteNumber"], (object) checked (index + 1), false))
            {
              jobNumberIn = checked (index + 1);
              break;
            }
            checked { ++index; }
          }
        }
      }
      else
        jobNumberIn = 1;
      string str;
      switch (Conversions.ToString(jobNumberIn).Length)
      {
        case 1:
          str = "0000";
          break;
        case 2:
          str = "000";
          break;
        case 3:
          str = "00";
          break;
        case 4:
          str = "0";
          break;
        default:
          str = "";
          break;
      }
      App.DB.ExecuteWithOutReturn("INSERT INTO tblQuoteNumber (QuoteNumber, Prefix) VALUES(" + Conversions.ToString(jobNumberIn) + ", 'Q')", true);
      return new JobNumber(jobNumberIn, "Q" + str);
    }

    public QuoteJob Get(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteJob_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (QuoteJob) null;
      QuoteJob quoteJob = new QuoteJob();
      quoteJob.IgnoreExceptionsOnSetMethods = true;
      quoteJob.SetQuoteJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteJobID)]);
      quoteJob.SetReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reference"]);
      quoteJob.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      quoteJob.SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]);
      quoteJob.SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]);
      quoteJob.SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]);
      quoteJob.DateCreated = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateCreated"]));
      quoteJob.SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]);
      quoteJob.SetPartsAndProductsTotal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsAndProductsTotal"]);
      quoteJob.SetGrandTotal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GrandTotal"]);
      quoteJob.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
      quoteJob.SetReasonForRejectID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForRejectID"]);
      quoteJob.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      quoteJob.SetPartsAndProductsMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsAndProductsMarkup"]);
      quoteJob.SetScheduleOfRatesMarkup = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ScheduleOfRatesMarkup"]);
      quoteJob.SetScheduleOfRatesTotal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ScheduleOfRatesTotal"]);
      quoteJob.SetEstimatedMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EstimatedMileage"]);
      quoteJob.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NotesToEngineer"]);
      quoteJob.SetNotesToElectrician = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NotesToElectrician"]);
      quoteJob.SetNotesToBuilder = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NotesToBuilder"]);
      quoteJob.SetEngineerLabourHrs = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerLabourHrs"]);
      quoteJob.SetElectricianLabourHrs = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianLabourHrs"]);
      quoteJob.SetBuilderLabourHrs = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuilderLabourHrs"]);
      quoteJob.SetEngineerMarkUp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerMarkUp"]);
      quoteJob.SetElectricianMarkUp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianMarkUp"]);
      quoteJob.SetBuilderMarkUp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuilderMarkUp"]);
      quoteJob.SetElectricianArrivalDayNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianArrivalDayNo"]);
      quoteJob.SetElectricianArrivalHour = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianArrivalHour"]);
      quoteJob.SetBuilderArrivalDayNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuilderArrivalDayNo"]);
      quoteJob.SetBuilderArrivalHour = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuilderArrivalHour"]);
      quoteJob.SetPartsCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsCost"]);
      quoteJob.SetEngineerCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerCost"]);
      quoteJob.SetBuilderCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuilderCost"]);
      quoteJob.SetElectricianCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianCost"]);
      quoteJob.SetQuotedAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuotedAmount"]);
      quoteJob.SetDepositAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DepositAmount"]);
      quoteJob.SetVatRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VatRateID"]);
      quoteJob.ChangedDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ChangedDateTime"]));
      quoteJob.SetChangedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ChangedByUserID"]);
      quoteJob.SetOriginalQuotedAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OriginalQuotedAmount"]);
      quoteJob.SetElectricianPackTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ElectricianPackTypeID"]);
      quoteJob.SetSORCharge = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SORCharge"]);
      quoteJob.SetAccessEquipmentID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccessEquipmentID"]);
      quoteJob.SetAsbestosID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AsbestosID"]);
      quoteJob.SetAdditionalCosts = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdditionalCosts"]);
      quoteJob.SetAsbestosComment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AsbestosComment"]);
      quoteJob.EstStartDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EstStartDate"]));
      quoteJob.SetSurveyVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SurveyVisitID"]);
      if (dataTable.Columns.Contains("Department"))
        quoteJob.SetDepartment = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Department"]));
      quoteJob.QuoteJobOfWorks = this._database.QuoteJobOfWorks.QuoteJobOfWork_Get_For_QuoteJob_As_Objects(quoteJob.QuoteJobID);
      quoteJob.QuoteJobPartsAndProducts = this.Get_Parts_And_Products_For_QuoteJobID(QuoteJobID);
      quoteJob.ScheduleOfRates = this.GetQuoteJobScheduleOfRate(QuoteJobID);
      quoteJob.Exists = true;
      return quoteJob;
    }

    public DataView Get_Parts_And_Products_For_QuoteJobID(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, false);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteJob_GetAll_Parts_And_Products_For_QuoteJobID", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      return new DataView(table);
    }

    public string QuoteJob_Create_Install(
      int SiteID,
      string Surveyor,
      string NotesToengineer,
      string NotesToBuilder,
      string NotesToElectrician,
      string Department,
      int QuoteJobID,
      bool Electrician,
      bool Builder,
      bool Service,
      bool HandOver,
      double ElectricianCost,
      double builderCost)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, false);
      this._database.AddParameter("@Surveyor", (object) Surveyor, false);
      this._database.AddParameter("@NotesToengineer", (object) NotesToengineer, true);
      this._database.AddParameter("@NotesToBuilder", (object) NotesToBuilder, true);
      this._database.AddParameter("@NotesToElectrician", (object) NotesToElectrician, true);
      this._database.AddParameter("@Department", (object) Department, false);
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, false);
      this._database.AddParameter("@Electrician", (object) Electrician, false);
      this._database.AddParameter("@Builder", (object) Builder, false);
      this._database.AddParameter("@Service", (object) Service, false);
      this._database.AddParameter("@HandOver", (object) HandOver, false);
      this._database.AddParameter("@ElectricianCost", (object) ElectricianCost, false);
      this._database.AddParameter("@BuilderCost", (object) builderCost, false);
      return Conversions.ToString(this._database.ExecuteSP_OBJECT(nameof (QuoteJob_Create_Install), true));
    }

    public QuoteJob Insert(QuoteJob qJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Reference", (object) qJob.Reference, true);
      this._database.AddParameter("@SiteID", (object) qJob.SiteID, true);
      this._database.AddParameter("@JobDefinitionEnumID", (object) qJob.JobDefinitionEnumID, true);
      this._database.AddParameter("@JobTypeID", (object) qJob.JobTypeID, true);
      this._database.AddParameter("@StatusEnumID", (object) qJob.StatusEnumID, true);
      this._database.AddParameter("@DateCreated", (object) qJob.DateCreated, true);
      this._database.AddParameter("@CreatedByUserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@PartsAndProductsTotal", (object) qJob.PartsAndProductsTotal, true);
      this._database.AddParameter("@GrandTotal", (object) qJob.GrandTotal, true);
      this._database.AddParameter("@PartsAndProductsMarkup", (object) qJob.PartsAndProductsMarkup, true);
      this._database.AddParameter("@ScheduleOfRatesMarkup", (object) qJob.ScheduleOfRatesMarkup, true);
      this._database.AddParameter("@ScheduleOfRatesTotal", (object) qJob.ScheduleOfRatesTotal, true);
      this._database.AddParameter("@EstimatedMileage", (object) qJob.EstimatedMileage, true);
      this._database.AddParameter("@MileageRate", (object) qJob.MileageRate, true);
      this._database.AddParameter("@NotesToEngineer", (object) qJob.NotesToEngineer, true);
      this._database.AddParameter("@NotesToElectrician", (object) qJob.NotesToElectrician, true);
      this._database.AddParameter("@NotesToBuilder", (object) qJob.NotesToBuilder, true);
      this._database.AddParameter("@EngineerLabourHrs", (object) qJob.EngineerLabourHrs, true);
      this._database.AddParameter("@ElectricianLabourHrs", (object) qJob.ElectricianLabourHrs, true);
      this._database.AddParameter("@BuilderLabourHrs", (object) qJob.BuilderLabourHrs, true);
      this._database.AddParameter("@EngineerMarkUp", (object) qJob.EngineerMarkUp, true);
      this._database.AddParameter("@ElectricianMarkUp", (object) qJob.ElectricianMarkUp, true);
      this._database.AddParameter("@BuilderMarkUp", (object) qJob.BuilderMarkUp, true);
      this._database.AddParameter("@ElectricianArrivalDayNo", (object) qJob.ElectricianArrivalDayNo, true);
      this._database.AddParameter("@ElectricianArrivalHour", (object) qJob.ElectricianArrivalHour, true);
      this._database.AddParameter("@BuilderArrivalDayNo", (object) qJob.BuilderArrivalDayNo, true);
      this._database.AddParameter("@BuilderArrivalHour", (object) qJob.BuilderArrivalHour, true);
      this._database.AddParameter("@PartsCost", (object) qJob.PartsCost, true);
      this._database.AddParameter("@EngineerCost", (object) qJob.EngineerCost, true);
      this._database.AddParameter("@BuilderCost", (object) qJob.BuilderCost, true);
      this._database.AddParameter("@ElectricianCost", (object) qJob.ElectricianCost, true);
      this._database.AddParameter("@QuotedAmount", (object) qJob.QuotedAmount, true);
      this._database.AddParameter("@DepositAmount", (object) qJob.DepositAmount, true);
      this._database.AddParameter("@VATRateID", (object) qJob.VatRateID, true);
      this._database.AddParameter("@ChangedDateTime", (object) qJob.ChangedDateTime, true);
      this._database.AddParameter("@ChangedByUserID", (object) qJob.ChangedByUserID, true);
      this._database.AddParameter("@OriginalQuotedAmount", (object) qJob.OriginalQuotedAmount, true);
      this._database.AddParameter("@ElectricianPackTypeID", (object) qJob.ElectricianPackTypeID, true);
      this._database.AddParameter("@SORCharge", (object) qJob.SORCharge, true);
      this._database.AddParameter("@AccessEquipmentID", (object) qJob.AccessEquipmentID, true);
      this._database.AddParameter("@AsbestosID", (object) qJob.AsbestosID, true);
      this._database.AddParameter("@AdditionalCosts", (object) qJob.AdditionalCosts, true);
      this._database.AddParameter("@AsbestosComment", (object) qJob.AsbestosComment, true);
      this._database.AddParameter("@EstStartDate", (object) qJob.EstStartDate, true);
      this._database.AddParameter("@SurveyVisitID", (object) qJob.SurveyVisitID, true);
      this._database.AddParameter("@Department", (object) qJob.Department, true);
      qJob.SetQuoteJobID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJob_Insert2", true)));
      qJob.Exists = true;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = qJob.QuoteAssets.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          QuoteJobAsset current = (QuoteJobAsset) enumerator1.Current;
          current.SetQuoteJobID = (object) qJob.QuoteJobID;
          this._database.QuoteJobAsset.Insert(current);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = qJob.QuoteJobOfWorks.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          QuoteJobOfWork current1 = (QuoteJobOfWork) enumerator2.Current;
          current1.SetQuoteJobID = (object) qJob.QuoteJobID;
          QuoteJobOfWork quoteJobOfWork = this._database.QuoteJobOfWorks.Insert(current1);
          IEnumerator enumerator3;
          try
          {
            enumerator3 = quoteJobOfWork.QuoteJobItems.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              QuoteJobItem current2 = (QuoteJobItem) enumerator3.Current;
              current2.SetQuoteJobOfWorkID = (object) quoteJobOfWork.QuoteJobOfWorkID;
              this._database.QuoteJobItems.Insert(current2);
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          IEnumerator enumerator4;
          try
          {
            enumerator4 = quoteJobOfWork.QuoteEngineerVisits.GetEnumerator();
            while (enumerator4.MoveNext())
            {
              QuoteEngineerVisit current2 = (QuoteEngineerVisit) enumerator4.Current;
              current2.SetQuoteJobOfWorkID = (object) quoteJobOfWork.QuoteJobOfWorkID;
              this._database.QuoteEngineerVisits.Insert(current2);
            }
          }
          finally
          {
            if (enumerator4 is IDisposable)
              (enumerator4 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator5;
      try
      {
        enumerator5 = qJob.QuoteJobPartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator5.MoveNext())
        {
          DataRow current = (DataRow) enumerator5.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
            this._database.QuoteJobParts.Insert(new QuoteJobParts()
            {
              SetQuoteJobID = (object) qJob.QuoteJobID,
              SetPartID = RuntimeHelpers.GetObjectValue(current["ID"]),
              SetQuantity = RuntimeHelpers.GetObjectValue(current["Quantity"]),
              SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]),
              SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]),
              SetExtra = RuntimeHelpers.GetObjectValue(current["Extra"]),
              SetPartSupplierID = RuntimeHelpers.GetObjectValue(current["PartSupplierID"]),
              SetSpecialDescription = RuntimeHelpers.GetObjectValue(current["SpecialDescription"]),
              SetSpecialCost = RuntimeHelpers.GetObjectValue(current["SpecialCost"])
            });
        }
      }
      finally
      {
        if (enumerator5 is IDisposable)
          (enumerator5 as IDisposable).Dispose();
      }
      qJob.QuoteJobPartsAndProducts = this.Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID);
      this.SaveRates(qJob);
      return qJob;
    }

    private void SaveRates(QuoteJob oQuoteJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) oQuoteJob.QuoteJobID, true);
      this._database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Delete", true);
      IEnumerator enumerator;
      try
      {
        enumerator = oQuoteJob.ScheduleOfRates.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this._database.ClearParameter();
          this._database.AddParameter("@QuoteJobID", (object) oQuoteJob.QuoteJobID, true);
          this._database.AddParameter("@ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]), true);
          this._database.AddParameter("@Code", RuntimeHelpers.GetObjectValue(current["Code"]), true);
          this._database.AddParameter("@Description", RuntimeHelpers.GetObjectValue(current["Description"]), true);
          this._database.AddParameter("@Price", RuntimeHelpers.GetObjectValue(current["Price"]), true);
          this._database.AddParameter("@Quantity", RuntimeHelpers.GetObjectValue(current["Quantity"]), true);
          this._database.AddParameter("@RateID", RuntimeHelpers.GetObjectValue(current["RateID"]), true);
          this._database.AddParameter("@TimeInMins", RuntimeHelpers.GetObjectValue(current["TimeInMins"]), true);
          this._database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Insert", true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private DataView GetQuoteJobScheduleOfRate(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteJobScheduleOfRate_Get", true);
      table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
      return new DataView(table);
    }

    public QuoteJob Update(QuoteJob qJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Reference", (object) qJob.Reference, true);
      this._database.AddParameter("@SiteID", (object) qJob.SiteID, true);
      this._database.AddParameter("@JobDefinitionEnumID", (object) qJob.JobDefinitionEnumID, true);
      this._database.AddParameter("@JobTypeID", (object) qJob.JobTypeID, true);
      this._database.AddParameter("@StatusEnumID", (object) qJob.StatusEnumID, true);
      this._database.AddParameter("@DateCreated", (object) qJob.DateCreated, true);
      this._database.AddParameter("@CreatedByUserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@PartsAndProductsTotal", (object) qJob.PartsAndProductsTotal, true);
      this._database.AddParameter("@GrandTotal", (object) qJob.GrandTotal, true);
      this._database.AddParameter("@ReasonForReject", (object) qJob.ReasonForReject, true);
      this._database.AddParameter("@ReasonForRejectID", (object) qJob.ReasonForRejectID, true);
      this._database.AddParameter("@QuoteJobID", (object) qJob.QuoteJobID, true);
      this._database.AddParameter("@PartsAndProductsMarkup", (object) qJob.PartsAndProductsMarkup, true);
      this._database.AddParameter("@ScheduleOfRatesMarkup", (object) qJob.ScheduleOfRatesMarkup, true);
      this._database.AddParameter("@ScheduleOfRatesTotal", (object) qJob.ScheduleOfRatesTotal, true);
      this._database.AddParameter("@EstimatedMileage", (object) qJob.EstimatedMileage, true);
      this._database.AddParameter("@MileageRate", (object) qJob.MileageRate, true);
      this._database.AddParameter("@NotesToEngineer", (object) qJob.NotesToEngineer, true);
      this._database.AddParameter("@NotesToElectrician", (object) qJob.NotesToElectrician, true);
      this._database.AddParameter("@NotesToBuilder", (object) qJob.NotesToBuilder, true);
      this._database.AddParameter("@EngineerLabourHrs", (object) qJob.EngineerLabourHrs, true);
      this._database.AddParameter("@ElectricianLabourHrs", (object) qJob.ElectricianLabourHrs, true);
      this._database.AddParameter("@BuilderLabourHrs", (object) qJob.BuilderLabourHrs, true);
      this._database.AddParameter("@EngineerMarkUp", (object) qJob.EngineerMarkUp, true);
      this._database.AddParameter("@ElectricianMarkUp", (object) qJob.ElectricianMarkUp, true);
      this._database.AddParameter("@BuilderMarkUp", (object) qJob.BuilderMarkUp, true);
      this._database.AddParameter("@ElectricianArrivalDayNo", (object) qJob.ElectricianArrivalDayNo, true);
      this._database.AddParameter("@ElectricianArrivalHour", (object) qJob.ElectricianArrivalHour, true);
      this._database.AddParameter("@BuilderArrivalDayNo", (object) qJob.BuilderArrivalDayNo, true);
      this._database.AddParameter("@BuilderArrivalHour", (object) qJob.BuilderArrivalHour, true);
      this._database.AddParameter("@PartsCost", (object) qJob.PartsCost, true);
      this._database.AddParameter("@EngineerCost", (object) qJob.EngineerCost, true);
      this._database.AddParameter("@BuilderCost", (object) qJob.BuilderCost, true);
      this._database.AddParameter("@ElectricianCost", (object) qJob.ElectricianCost, true);
      this._database.AddParameter("@QuotedAmount", (object) qJob.QuotedAmount, true);
      this._database.AddParameter("@DepositAmount", (object) qJob.DepositAmount, true);
      this._database.AddParameter("@VATRateID", (object) qJob.VatRateID, true);
      this._database.AddParameter("@ChangedDateTime", (object) qJob.ChangedDateTime, true);
      this._database.AddParameter("@ChangedByUserID", (object) qJob.ChangedByUserID, true);
      this._database.AddParameter("@OriginalQuotedAmount", (object) qJob.OriginalQuotedAmount, true);
      this._database.AddParameter("@ElectricianPackTypeID", (object) qJob.ElectricianPackTypeID, true);
      this._database.AddParameter("@SORCharge", (object) qJob.SORCharge, true);
      this._database.AddParameter("@AccessEquipmentID", (object) qJob.AccessEquipmentID, true);
      this._database.AddParameter("@AsbestosID", (object) qJob.AsbestosID, true);
      this._database.AddParameter("@AdditionalCosts", (object) qJob.AdditionalCosts, true);
      this._database.AddParameter("@AsbestosComment", (object) qJob.AsbestosComment, true);
      this._database.AddParameter("@Department", (object) qJob.Department, true);
      if (DateTime.Compare(qJob.EstStartDate, DateTime.MinValue) == 0)
        this._database.AddParameter("@EstStartDate", (object) DBNull.Value, true);
      else
        this._database.AddParameter("@EstStartDate", (object) Helper.MakeDateTimeValid((object) qJob.EstStartDate), true);
      this._database.AddParameter("@SurveyVisitID", (object) qJob.SurveyVisitID, true);
      this._database.ExecuteSP_NO_Return("QuoteJob_Update", true);
      this._database.QuoteJobAsset.Delete(qJob.QuoteJobID);
      IEnumerator enumerator1;
      try
      {
        enumerator1 = qJob.QuoteAssets.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          QuoteJobAsset current = (QuoteJobAsset) enumerator1.Current;
          current.SetQuoteJobID = (object) qJob.QuoteJobID;
          this._database.QuoteJobAsset.Insert(current);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = qJob.QuoteJobOfWorks.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          QuoteJobOfWork current1 = (QuoteJobOfWork) enumerator2.Current;
          current1.SetQuoteJobID = (object) qJob.QuoteJobID;
          if (!current1.Exists)
          {
            QuoteJobOfWork quoteJobOfWork = this._database.QuoteJobOfWorks.Insert(current1);
            IEnumerator enumerator3;
            try
            {
              enumerator3 = quoteJobOfWork.QuoteJobItems.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                QuoteJobItem current2 = (QuoteJobItem) enumerator3.Current;
                current2.SetQuoteJobOfWorkID = (object) quoteJobOfWork.QuoteJobOfWorkID;
                this._database.QuoteJobItems.Insert(current2);
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
          }
          else
          {
            this._database.QuoteJobItems.Delete(current1.QuoteJobOfWorkID);
            IEnumerator enumerator3;
            try
            {
              enumerator3 = current1.QuoteJobItems.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                QuoteJobItem current2 = (QuoteJobItem) enumerator3.Current;
                current2.SetQuoteJobOfWorkID = (object) current1.QuoteJobOfWorkID;
                this._database.QuoteJobItems.Insert(current2);
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this._database.QuoteJobParts.Delete(qJob.QuoteJobID);
      this._database.QuoteJobProducts.Delete(qJob.QuoteJobID);
      IEnumerator enumerator4;
      try
      {
        enumerator4 = qJob.QuoteJobPartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          DataRow current = (DataRow) enumerator4.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
            this._database.QuoteJobParts.Insert(new QuoteJobParts()
            {
              SetQuoteJobID = (object) qJob.QuoteJobID,
              SetPartID = RuntimeHelpers.GetObjectValue(current["ID"]),
              SetQuantity = RuntimeHelpers.GetObjectValue(current["Quantity"]),
              SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]),
              SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]),
              SetExtra = RuntimeHelpers.GetObjectValue(current["Extra"]),
              SetPartSupplierID = RuntimeHelpers.GetObjectValue(current["PartSupplierID"]),
              SetSpecialDescription = RuntimeHelpers.GetObjectValue(current["SpecialDescription"]),
              SetSpecialCost = RuntimeHelpers.GetObjectValue(current["SpecialCost"])
            });
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      qJob.QuoteJobPartsAndProducts = this.Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID);
      this.SaveRates(qJob);
      this._database.QuoteJobParts.DeleteAll(qJob.QuoteJobID);
      return qJob;
    }

    public void Delete(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, true);
      this._database.ExecuteSP_NO_Return("QuoteJob_Delete", true);
    }
  }
}
