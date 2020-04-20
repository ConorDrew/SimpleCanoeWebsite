// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3Sites.QuoteContractOption3SiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOption3Sites
{
    public class QuoteContractOption3SiteSQL
    {
        private Database _database;

        public QuoteContractOption3SiteSQL(Database database)
        {
            this._database = database;
        }

        public int Delete(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, true);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("QuoteContractOption3Site_Delete", true));
        }

        public QuoteContractOption3Site QuoteContractOption3Site_Get(
          int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(QuoteContractOption3Site_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteContractOption3Site)null;
            QuoteContractOption3Site contractOption3Site1 = new QuoteContractOption3Site();
            QuoteContractOption3Site contractOption3Site2 = contractOption3Site1;
            contractOption3Site2.IgnoreExceptionsOnSetMethods = true;
            contractOption3Site2.SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteContractSiteID)]);
            contractOption3Site2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
            contractOption3Site2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            contractOption3Site2.SetQuoteContractSiteReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractSiteReference"]);
            contractOption3Site2.StartDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDate"]));
            contractOption3Site2.EndDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDate"]));
            contractOption3Site2.FirstVisitDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstVisitDate"]));
            contractOption3Site2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
            contractOption3Site2.SetSitePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SitePrice"]);
            contractOption3Site1.Exists = true;
            return contractOption3Site1;
        }

        public DataView QuoteContractOption3Site_GetAll_ForQuoteContract(
          int QuoteContractID,
          int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, false);
            this._database.AddParameter("@CustomerID", (object)CustomerID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteContractOption3Site_GetAll_ForQuoteContract), true);
            table.TableName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
            return new DataView(table);
        }

        public DataView QuoteContractOption3Site_GetSelected_ForQuoteContract(
          int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteContractOption3Site_GetSelected_ForQuoteContract), true);
            table.TableName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
            return new DataView(table);
        }

        public QuoteContractOption3Site Insert(
          QuoteContractOption3Site oQuoteContractOption3Site)
        {
            this._database.ClearParameter();
            this.AddContractOption3SiteParametersToCommand(ref oQuoteContractOption3Site);
            oQuoteContractOption3Site.SetQuoteContractSiteID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOption3Site_Insert", true)));
            oQuoteContractOption3Site.Exists = true;
            return oQuoteContractOption3Site;
        }

        public void Update(QuoteContractOption3Site oQuoteContractOption3Site)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractOption3Site.QuoteContractSiteID, true);
            this.AddContractOption3SiteParametersToCommand(ref oQuoteContractOption3Site);
            this._database.ExecuteSP_NO_Return("QuoteContractOption3Site_Update", true);
        }

        private void AddContractOption3SiteParametersToCommand(
          ref QuoteContractOption3Site oQuoteContractOption3Site)
        {
            Database database = this._database;
            database.AddParameter("@QuoteContractID", (object)oQuoteContractOption3Site.QuoteContractID, true);
            database.AddParameter("@SiteID", (object)oQuoteContractOption3Site.SiteID, true);
            database.AddParameter("@QuoteContractSiteReference", (object)oQuoteContractOption3Site.QuoteContractSiteReference, true);
            if (DateTime.Compare(oQuoteContractOption3Site.StartDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
                database.AddParameter("@StartDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@StartDate", (object)oQuoteContractOption3Site.StartDate, true);
            if (DateTime.Compare(oQuoteContractOption3Site.EndDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
                database.AddParameter("@EndDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@EndDate", (object)oQuoteContractOption3Site.EndDate, true);
            if (DateTime.Compare(oQuoteContractOption3Site.FirstVisitDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
                database.AddParameter("@FirstVisitDate", (object)DBNull.Value, true);
            else
                database.AddParameter("@FirstVisitDate", (object)oQuoteContractOption3Site.FirstVisitDate, true);
            database.AddParameter("@VisitFrequencyID", (object)oQuoteContractOption3Site.VisitFrequencyID, true);
            database.AddParameter("@SitePrice", (object)oQuoteContractOption3Site.SitePrice, true);
        }

        public string GetNextSiteReference(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractOption3Site_GetLastSiteReference", true);
            string str1;
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteLetter"])))
            {
                str1 = "-A";
            }
            else
            {
                string str2 = Strings.Right(Conversions.ToString(dataTable.Rows[0]["SiteLetter"]), 1);
                string str3 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "Z", false) != 0 ? Conversions.ToString(Strings.Chr(checked(Strings.Asc(str2) + 1))) : "AA";
                str1 = "-" + Strings.Replace(Strings.Left(Conversions.ToString(dataTable.Rows[0]["SiteLetter"]), checked(Strings.Len(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteLetter"])) - 1)), "Z", "A", 1, -1, CompareMethod.Binary) + str3;
            }
            return Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataTable.Rows[0]["QuoteContractReference"], (object)str1));
        }
    }
}