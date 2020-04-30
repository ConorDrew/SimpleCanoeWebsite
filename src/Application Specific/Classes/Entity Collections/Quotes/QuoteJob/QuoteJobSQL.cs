using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteJobs
    {
        public class QuoteJobsSQL
        {
            private Sys.Database _database;

            public QuoteJobsSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void DeleteReservedQuoteNumber(int JobNumber)
            {
                string sql;
                sql = "DELETE FROM tblQuoteNumber WHERE QuoteNumber = " + JobNumber;
                App.DB.ExecuteWithOutReturn(sql);
            }

            public JobNumber GetNextQuoteNumber() // I used the job number class coz its the same fields - alp
            {
                int nextQuoteNumber = 0;
                string sql;
                string preceedingZeros = "";
                sql = "SELECT QuoteNumber FROM tblQuoteNumber ORDER BY QuoteNumber ASC";
                var dt = App.DB.ExecuteWithReturn(sql);
                if (dt.Rows.Count > 0)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dt.Rows[dt.Rows.Count - 1]["QuoteNumber"], dt.Rows.Count, false)))
                    {
                        nextQuoteNumber = Conversions.ToInteger((int)dt.Rows[dt.Rows.Count - 1]["QuoteNumber"] + 1);
                    }
                    else
                    {
                        for (int i = 0, loopTo = dt.Rows.Count - 1; i <= loopTo; i++)
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dt.Rows[i]["QuoteNumber"], i + 1, false)))
                            {
                                nextQuoteNumber = i + 1;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    nextQuoteNumber = 1;
                }

                var switchExpr = Conversions.ToString(nextQuoteNumber).Length;
                switch (switchExpr)
                {
                    case 1:
                        {
                            preceedingZeros = "0000";
                            break;
                        }

                    case 2:
                        {
                            preceedingZeros = "000";
                            break;
                        }

                    case 3:
                        {
                            preceedingZeros = "00";
                            break;
                        }

                    case 4:
                        {
                            preceedingZeros = "0";
                            break;
                        }

                    default:
                        {
                            preceedingZeros = "";
                            break;
                        }
                }

                App.DB.ExecuteWithOutReturn("INSERT INTO tblQuoteNumber (QuoteNumber, Prefix) VALUES(" + nextQuoteNumber + ", 'Q')");
                var oQuoteNumber = new JobNumber(nextQuoteNumber, "Q" + preceedingZeros);
                return oQuoteNumber;
            }

            public QuoteJob Get(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteJob_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteJob = new QuoteJob();
                        oQuoteJob.IgnoreExceptionsOnSetMethods = true;
                        oQuoteJob.SetQuoteJobID = dt.Rows[0]["QuoteJobID"];
                        oQuoteJob.SetReference = dt.Rows[0]["Reference"];
                        oQuoteJob.SetSiteID = dt.Rows[0]["SiteID"];
                        oQuoteJob.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                        oQuoteJob.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                        oQuoteJob.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                        oQuoteJob.DateCreated = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateCreated"]);
                        oQuoteJob.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                        oQuoteJob.SetPartsAndProductsTotal = dt.Rows[0]["PartsAndProductsTotal"];
                        oQuoteJob.SetGrandTotal = dt.Rows[0]["GrandTotal"];
                        oQuoteJob.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        oQuoteJob.SetReasonForRejectID = dt.Rows[0]["ReasonForRejectID"];
                        oQuoteJob.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteJob.SetPartsAndProductsMarkup = dt.Rows[0]["PartsAndProductsMarkup"];
                        oQuoteJob.SetScheduleOfRatesMarkup = dt.Rows[0]["ScheduleOfRatesMarkup"];
                        oQuoteJob.SetScheduleOfRatesTotal = dt.Rows[0]["ScheduleOfRatesTotal"];
                        oQuoteJob.SetEstimatedMileage = dt.Rows[0]["EstimatedMileage"];
                        // oQuoteJob.SetMileageRate = dt.Rows(0).Item("MileageRate")
                        oQuoteJob.SetNotesToEngineer = dt.Rows[0]["NotesToEngineer"];
                        oQuoteJob.SetNotesToElectrician = dt.Rows[0]["NotesToElectrician"];
                        oQuoteJob.SetNotesToBuilder = dt.Rows[0]["NotesToBuilder"];
                        oQuoteJob.SetEngineerLabourHrs = dt.Rows[0]["EngineerLabourHrs"];
                        oQuoteJob.SetElectricianLabourHrs = dt.Rows[0]["ElectricianLabourHrs"];
                        oQuoteJob.SetBuilderLabourHrs = dt.Rows[0]["BuilderLabourHrs"];
                        oQuoteJob.SetEngineerMarkUp = dt.Rows[0]["EngineerMarkUp"];
                        oQuoteJob.SetElectricianMarkUp = dt.Rows[0]["ElectricianMarkUp"];
                        oQuoteJob.SetBuilderMarkUp = dt.Rows[0]["BuilderMarkUp"];
                        oQuoteJob.SetElectricianArrivalDayNo = dt.Rows[0]["ElectricianArrivalDayNo"];
                        oQuoteJob.SetElectricianArrivalHour = dt.Rows[0]["ElectricianArrivalHour"];
                        oQuoteJob.SetBuilderArrivalDayNo = dt.Rows[0]["BuilderArrivalDayNo"];
                        oQuoteJob.SetBuilderArrivalHour = dt.Rows[0]["BuilderArrivalHour"];
                        oQuoteJob.SetPartsCost = dt.Rows[0]["PartsCost"];
                        oQuoteJob.SetEngineerCost = dt.Rows[0]["EngineerCost"];
                        oQuoteJob.SetBuilderCost = dt.Rows[0]["BuilderCost"];
                        oQuoteJob.SetElectricianCost = dt.Rows[0]["ElectricianCost"];
                        oQuoteJob.SetQuotedAmount = dt.Rows[0]["QuotedAmount"];
                        oQuoteJob.SetDepositAmount = dt.Rows[0]["DepositAmount"];
                        oQuoteJob.SetVatRateID = dt.Rows[0]["VatRateID"];
                        oQuoteJob.ChangedDateTime = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["ChangedDateTime"]);
                        oQuoteJob.SetChangedByUserID = dt.Rows[0]["ChangedByUserID"];
                        oQuoteJob.SetOriginalQuotedAmount = dt.Rows[0]["OriginalQuotedAmount"];
                        oQuoteJob.SetElectricianPackTypeID = dt.Rows[0]["ElectricianPackTypeID"];
                        oQuoteJob.SetSORCharge = dt.Rows[0]["SORCharge"];
                        oQuoteJob.SetAccessEquipmentID = dt.Rows[0]["AccessEquipmentID"];
                        oQuoteJob.SetAsbestosID = dt.Rows[0]["AsbestosID"];
                        oQuoteJob.SetAdditionalCosts = dt.Rows[0]["AdditionalCosts"];
                        oQuoteJob.SetAsbestosComment = dt.Rows[0]["AsbestosComment"];
                        oQuoteJob.EstStartDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EstStartDate"]);
                        oQuoteJob.SetSurveyVisitID = dt.Rows[0]["SurveyVisitID"];
                        if (dt.Columns.Contains("Department"))
                            oQuoteJob.SetDepartment = Sys.Helper.MakeStringValid(dt.Rows[0]["Department"]);
                        // oQuoteJob.QuoteAssets = _database.QuoteJobAsset.QuoteJobAsset_Get_For_QuoteJob_As_Objects(oQuoteJob.QuoteJobID)
                        oQuoteJob.QuoteJobOfWorks = _database.QuoteJobOfWorks.QuoteJobOfWork_Get_For_QuoteJob_As_Objects(oQuoteJob.QuoteJobID);
                        oQuoteJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(QuoteJobID);
                        oQuoteJob.ScheduleOfRates = GetQuoteJobScheduleOfRate(QuoteJobID);
                        oQuoteJob.Exists = true;
                        return oQuoteJob;
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

            public DataView Get_Parts_And_Products_For_QuoteJobID(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID);
                var dt = _database.ExecuteSP_DataTable("QuoteJob_GetAll_Parts_And_Products_For_QuoteJobID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                return new DataView(dt);
            }

            public string QuoteJob_Create_Install(int SiteID, string Surveyor, string NotesToengineer, string NotesToBuilder, string NotesToElectrician, string Department, int QuoteJobID, bool Electrician, bool Builder, bool Service, bool HandOver, double ElectricianCost, double builderCost)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID);
                _database.AddParameter("@Surveyor", Surveyor);
                _database.AddParameter("@NotesToengineer", NotesToengineer, true);
                _database.AddParameter("@NotesToBuilder", NotesToBuilder, true);
                _database.AddParameter("@NotesToElectrician", NotesToElectrician, true);
                _database.AddParameter("@Department", Department);
                _database.AddParameter("@QuoteJobID", QuoteJobID);
                _database.AddParameter("@Electrician", Electrician);
                _database.AddParameter("@Builder", Builder);
                _database.AddParameter("@Service", Service);
                _database.AddParameter("@HandOver", HandOver);
                _database.AddParameter("@ElectricianCost", ElectricianCost);
                _database.AddParameter("@BuilderCost", builderCost);
                return Conversions.ToString(_database.ExecuteSP_OBJECT("QuoteJob_Create_Install"));
            }

            public QuoteJob Insert(QuoteJob qJob)
            {
                _database.ClearParameter();
                _database.AddParameter("@Reference", qJob.Reference, true);
                _database.AddParameter("@SiteID", qJob.SiteID, true);
                _database.AddParameter("@JobDefinitionEnumID", qJob.JobDefinitionEnumID, true);
                _database.AddParameter("@JobTypeID", qJob.JobTypeID, true);
                _database.AddParameter("@StatusEnumID", qJob.StatusEnumID, true);
                _database.AddParameter("@DateCreated", qJob.DateCreated, true);
                _database.AddParameter("@CreatedByUserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@PartsAndProductsTotal", qJob.PartsAndProductsTotal, true);
                _database.AddParameter("@GrandTotal", qJob.GrandTotal, true);
                _database.AddParameter("@PartsAndProductsMarkup", qJob.PartsAndProductsMarkup, true);
                _database.AddParameter("@ScheduleOfRatesMarkup", qJob.ScheduleOfRatesMarkup, true);
                _database.AddParameter("@ScheduleOfRatesTotal", qJob.ScheduleOfRatesTotal, true);
                _database.AddParameter("@EstimatedMileage", qJob.EstimatedMileage, true);
                _database.AddParameter("@MileageRate", qJob.MileageRate, true);
                _database.AddParameter("@NotesToEngineer", qJob.NotesToEngineer, true);
                _database.AddParameter("@NotesToElectrician", qJob.NotesToElectrician, true);
                _database.AddParameter("@NotesToBuilder", qJob.NotesToBuilder, true);
                _database.AddParameter("@EngineerLabourHrs", qJob.EngineerLabourHrs, true);
                _database.AddParameter("@ElectricianLabourHrs", qJob.ElectricianLabourHrs, true);
                _database.AddParameter("@BuilderLabourHrs", qJob.BuilderLabourHrs, true);
                _database.AddParameter("@EngineerMarkUp", qJob.EngineerMarkUp, true);
                _database.AddParameter("@ElectricianMarkUp", qJob.ElectricianMarkUp, true);
                _database.AddParameter("@BuilderMarkUp", qJob.BuilderMarkUp, true);
                _database.AddParameter("@ElectricianArrivalDayNo", qJob.ElectricianArrivalDayNo, true);
                _database.AddParameter("@ElectricianArrivalHour", qJob.ElectricianArrivalHour, true);
                _database.AddParameter("@BuilderArrivalDayNo", qJob.BuilderArrivalDayNo, true);
                _database.AddParameter("@BuilderArrivalHour", qJob.BuilderArrivalHour, true);
                _database.AddParameter("@PartsCost", qJob.PartsCost, true);
                _database.AddParameter("@EngineerCost", qJob.EngineerCost, true);
                _database.AddParameter("@BuilderCost", qJob.BuilderCost, true);
                _database.AddParameter("@ElectricianCost", qJob.ElectricianCost, true);
                _database.AddParameter("@QuotedAmount", qJob.QuotedAmount, true);
                _database.AddParameter("@DepositAmount", qJob.DepositAmount, true);
                _database.AddParameter("@VATRateID", qJob.VatRateID, true);
                _database.AddParameter("@ChangedDateTime", qJob.ChangedDateTime, true);
                _database.AddParameter("@ChangedByUserID", qJob.ChangedByUserID, true);
                _database.AddParameter("@OriginalQuotedAmount", qJob.OriginalQuotedAmount, true);
                _database.AddParameter("@ElectricianPackTypeID", qJob.ElectricianPackTypeID, true);
                _database.AddParameter("@SORCharge", qJob.SORCharge, true);
                _database.AddParameter("@AccessEquipmentID", qJob.AccessEquipmentID, true);
                _database.AddParameter("@AsbestosID", qJob.AsbestosID, true);
                _database.AddParameter("@AdditionalCosts", qJob.AdditionalCosts, true);
                _database.AddParameter("@AsbestosComment", qJob.AsbestosComment, true);
                _database.AddParameter("@EstStartDate", qJob.EstStartDate, true);
                _database.AddParameter("@SurveyVisitID", qJob.SurveyVisitID, true);
                _database.AddParameter("@Department", qJob.Department, true);
                qJob.SetQuoteJobID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJob_Insert2"));
                qJob.Exists = true;
                foreach (QuoteJobAssets.QuoteJobAsset qasset in qJob.QuoteAssets)
                {
                    qasset.SetQuoteJobID = qJob.QuoteJobID;
                    _database.QuoteJobAsset.Insert(qasset);
                }

                foreach (QuoteJobOfWorks.QuoteJobOfWork qjobOfWork in qJob.QuoteJobOfWorks)
                {
                    qjobOfWork.SetQuoteJobID = qJob.QuoteJobID;
                    _database.QuoteJobOfWorks.Insert(qjobOfWork);
                    foreach (QuoteJobItems.QuoteJobItem qjobItem in qjobOfWork.QuoteJobItems)
                    {
                        qjobItem.SetQuoteJobOfWorkID = qjobOfWork.QuoteJobOfWorkID;
                        _database.QuoteJobItems.Insert(qjobItem);
                    }

                    foreach (QuoteEngineerVisits.QuoteEngineerVisit qengineerVisit in qjobOfWork.QuoteEngineerVisits)
                    {
                        qengineerVisit.SetQuoteJobOfWorkID = qjobOfWork.QuoteJobOfWorkID;
                        _database.QuoteEngineerVisits.Insert(qengineerVisit);
                    }
                }

                foreach (DataRow row in qJob.QuoteJobPartsAndProducts.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Part", false)))
                    {
                        var oQuoteJobPart = new QuoteJobPartss.QuoteJobParts();
                        oQuoteJobPart.SetQuoteJobID = qJob.QuoteJobID;
                        oQuoteJobPart.SetPartID = row["ID"];
                        oQuoteJobPart.SetQuantity = row["Quantity"];
                        oQuoteJobPart.SetSellPrice = row["SellPrice"];
                        oQuoteJobPart.SetBuyPrice = row["BuyPrice"];
                        oQuoteJobPart.SetExtra = row["Extra"];
                        oQuoteJobPart.SetPartSupplierID = row["PartSupplierID"];
                        oQuoteJobPart.SetSpecialDescription = row["SpecialDescription"];
                        oQuoteJobPart.SetSpecialCost = row["SpecialCost"];
                        _database.QuoteJobParts.Insert(oQuoteJobPart);
                    }
                }

                qJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID);
                SaveRates(qJob);
                return qJob;
            }

            private void SaveRates(QuoteJob oQuoteJob)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", oQuoteJob.QuoteJobID, true);
                _database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Delete");
                foreach (DataRow r in oQuoteJob.ScheduleOfRates.Table.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@QuoteJobID", oQuoteJob.QuoteJobID, true);
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r["ScheduleOfRatesCategoryID"], true);
                    _database.AddParameter("@Code", r["Code"], true);
                    _database.AddParameter("@Description", r["Description"], true);
                    _database.AddParameter("@Price", r["Price"], true);
                    _database.AddParameter("@Quantity", r["Quantity"], true);
                    _database.AddParameter("@RateID", r["RateID"], true);
                    _database.AddParameter("@TimeInMins", r["TimeInMins"], true);
                    _database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Insert");
                }
            }

            private DataView GetQuoteJobScheduleOfRate(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteJobScheduleOfRate_Get");
                dt.TableName = Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public QuoteJob Update(QuoteJob qJob)
            {
                _database.ClearParameter();
                _database.AddParameter("@Reference", qJob.Reference, true);
                _database.AddParameter("@SiteID", qJob.SiteID, true);
                _database.AddParameter("@JobDefinitionEnumID", qJob.JobDefinitionEnumID, true);
                _database.AddParameter("@JobTypeID", qJob.JobTypeID, true);
                _database.AddParameter("@StatusEnumID", qJob.StatusEnumID, true);
                _database.AddParameter("@DateCreated", qJob.DateCreated, true);
                _database.AddParameter("@CreatedByUserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@PartsAndProductsTotal", qJob.PartsAndProductsTotal, true);
                _database.AddParameter("@GrandTotal", qJob.GrandTotal, true);
                _database.AddParameter("@ReasonForReject", qJob.ReasonForReject, true);
                _database.AddParameter("@ReasonForRejectID", qJob.ReasonForRejectID, true);
                _database.AddParameter("@QuoteJobID", qJob.QuoteJobID, true);
                _database.AddParameter("@PartsAndProductsMarkup", qJob.PartsAndProductsMarkup, true);
                _database.AddParameter("@ScheduleOfRatesMarkup", qJob.ScheduleOfRatesMarkup, true);
                _database.AddParameter("@ScheduleOfRatesTotal", qJob.ScheduleOfRatesTotal, true);
                _database.AddParameter("@EstimatedMileage", qJob.EstimatedMileage, true);
                _database.AddParameter("@MileageRate", qJob.MileageRate, true);
                _database.AddParameter("@NotesToEngineer", qJob.NotesToEngineer, true);
                _database.AddParameter("@NotesToElectrician", qJob.NotesToElectrician, true);
                _database.AddParameter("@NotesToBuilder", qJob.NotesToBuilder, true);
                _database.AddParameter("@EngineerLabourHrs", qJob.EngineerLabourHrs, true);
                _database.AddParameter("@ElectricianLabourHrs", qJob.ElectricianLabourHrs, true);
                _database.AddParameter("@BuilderLabourHrs", qJob.BuilderLabourHrs, true);
                _database.AddParameter("@EngineerMarkUp", qJob.EngineerMarkUp, true);
                _database.AddParameter("@ElectricianMarkUp", qJob.ElectricianMarkUp, true);
                _database.AddParameter("@BuilderMarkUp", qJob.BuilderMarkUp, true);
                _database.AddParameter("@ElectricianArrivalDayNo", qJob.ElectricianArrivalDayNo, true);
                _database.AddParameter("@ElectricianArrivalHour", qJob.ElectricianArrivalHour, true);
                _database.AddParameter("@BuilderArrivalDayNo", qJob.BuilderArrivalDayNo, true);
                _database.AddParameter("@BuilderArrivalHour", qJob.BuilderArrivalHour, true);
                _database.AddParameter("@PartsCost", qJob.PartsCost, true);
                _database.AddParameter("@EngineerCost", qJob.EngineerCost, true);
                _database.AddParameter("@BuilderCost", qJob.BuilderCost, true);
                _database.AddParameter("@ElectricianCost", qJob.ElectricianCost, true);
                _database.AddParameter("@QuotedAmount", qJob.QuotedAmount, true);
                _database.AddParameter("@DepositAmount", qJob.DepositAmount, true);
                _database.AddParameter("@VATRateID", qJob.VatRateID, true);
                _database.AddParameter("@ChangedDateTime", qJob.ChangedDateTime, true);
                _database.AddParameter("@ChangedByUserID", qJob.ChangedByUserID, true);
                _database.AddParameter("@OriginalQuotedAmount", qJob.OriginalQuotedAmount, true);
                _database.AddParameter("@ElectricianPackTypeID", qJob.ElectricianPackTypeID, true);
                _database.AddParameter("@SORCharge", qJob.SORCharge, true);
                _database.AddParameter("@AccessEquipmentID", qJob.AccessEquipmentID, true);
                _database.AddParameter("@AsbestosID", qJob.AsbestosID, true);
                _database.AddParameter("@AdditionalCosts", qJob.AdditionalCosts, true);
                _database.AddParameter("@AsbestosComment", qJob.AsbestosComment, true);
                _database.AddParameter("@Department", qJob.Department, true);
                if (qJob.EstStartDate == DateTime.MinValue)
                {
                    _database.AddParameter("@EstStartDate", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@EstStartDate", Sys.Helper.MakeDateTimeValid(qJob.EstStartDate), true);
                }

                _database.AddParameter("@SurveyVisitID", qJob.SurveyVisitID, true);
                _database.ExecuteSP_NO_Return("QuoteJob_Update");
                _database.QuoteJobAsset.Delete(qJob.QuoteJobID);
                foreach (QuoteJobAssets.QuoteJobAsset qAsset in qJob.QuoteAssets)
                {
                    qAsset.SetQuoteJobID = qJob.QuoteJobID;
                    _database.QuoteJobAsset.Insert(qAsset);
                }

                foreach (QuoteJobOfWorks.QuoteJobOfWork qJobOfWork in qJob.QuoteJobOfWorks)
                {
                    qJobOfWork.SetQuoteJobID = qJob.QuoteJobID;
                    if (!qJobOfWork.Exists)
                    {
                        _database.QuoteJobOfWorks.Insert(qJobOfWork);
                        foreach (QuoteJobItems.QuoteJobItem qJobItem in qJobOfWork.QuoteJobItems)
                        {
                            qJobItem.SetQuoteJobOfWorkID = qJobOfWork.QuoteJobOfWorkID;
                            _database.QuoteJobItems.Insert(qJobItem);
                        }
                    }
                    else
                    {
                        _database.QuoteJobItems.Delete(qJobOfWork.QuoteJobOfWorkID);
                        foreach (QuoteJobItems.QuoteJobItem qJobItem in qJobOfWork.QuoteJobItems)
                        {
                            qJobItem.SetQuoteJobOfWorkID = qJobOfWork.QuoteJobOfWorkID;
                            _database.QuoteJobItems.Insert(qJobItem);
                        }
                    }
                }

                _database.QuoteJobParts.Delete(qJob.QuoteJobID);
                _database.QuoteJobProducts.Delete(qJob.QuoteJobID);
                foreach (DataRow row in qJob.QuoteJobPartsAndProducts.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Part", false)))
                    {
                        var oQuoteJobPart = new QuoteJobPartss.QuoteJobParts();
                        oQuoteJobPart.SetQuoteJobID = qJob.QuoteJobID;
                        oQuoteJobPart.SetPartID = row["ID"];
                        oQuoteJobPart.SetQuantity = row["Quantity"];
                        oQuoteJobPart.SetSellPrice = row["SellPrice"];
                        oQuoteJobPart.SetBuyPrice = row["BuyPrice"];
                        oQuoteJobPart.SetExtra = row["Extra"];
                        oQuoteJobPart.SetPartSupplierID = row["PartSupplierID"];
                        oQuoteJobPart.SetSpecialDescription = row["SpecialDescription"];
                        oQuoteJobPart.SetSpecialCost = row["SpecialCost"];
                        _database.QuoteJobParts.Insert(oQuoteJobPart);
                    }
                }

                qJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID);
                SaveRates(qJob);
                _database.QuoteJobParts.DeleteAll(qJob.QuoteJobID);
                return qJob;
            }

            public void Delete(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                _database.ExecuteSP_NO_Return("QuoteJob_Delete");
            }

            
        }
    }
}