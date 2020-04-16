// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItemsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSiteJobItems
{
    public class QuoteContractAlternativeSiteJobItemsSQL
    {
        private Database _database;

        public QuoteContractAlternativeSiteJobItemsSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteContractSiteJobItemID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobItemID", (object)QuoteContractSiteJobItemID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Delete", true);
        }

        public FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems Get(
          int QuoteContractSiteJobItemID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobItemID", (object)QuoteContractSiteJobItemID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems)null;
            FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems alternativeSiteJobItems1 = new FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems();
            FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems alternativeSiteJobItems2 = alternativeSiteJobItems1;
            alternativeSiteJobItems2.IgnoreExceptionsOnSetMethods = true;
            alternativeSiteJobItems2.SetQuoteContractSiteJobItemID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteJobItemID"]);
            alternativeSiteJobItems2.SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteID"]);
            alternativeSiteJobItems2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
            alternativeSiteJobItems2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
            alternativeSiteJobItems2.SetVisitDuration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitDuration"]);
            alternativeSiteJobItems2.SetItemPricePerVisit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerVisit"]);
            alternativeSiteJobItems2.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobOfWorkID"]);
            alternativeSiteJobItems2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            alternativeSiteJobItems1.Exists = true;
            return alternativeSiteJobItems1;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll", true);
            table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
            return new DataView(table);
        }

        public DataView GetAll_For_QuoteContractSiteID(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, false);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_QuoteContractSiteID", true);
            table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
            return new DataView(table);
        }

        public DataView GetAll_For_JobOfWorkID(int JobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object)JobOfWorkID, false);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID", true);
            table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
            return new DataView(table);
        }

        public FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems Insert(
          FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
        {
            this._database.ClearParameter();
            this.AddContractAlternativeSiteJobItemsParametersToCommand(ref oQuoteContractAlternativeSiteJobItems);
            oQuoteContractAlternativeSiteJobItems.SetQuoteContractSiteJobItemID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobItems_Insert", true)));
            oQuoteContractAlternativeSiteJobItems.Exists = true;
            return oQuoteContractAlternativeSiteJobItems;
        }

        public void Update(int QuoteContractSiteJobItemID, int JobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteJobItemID", (object)QuoteContractSiteJobItemID, true);
            this._database.AddParameter("@JobOfWorkID", (object)JobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Update", true);
        }

        private void AddContractAlternativeSiteJobItemsParametersToCommand(
          ref FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
        {
            Database database = this._database;
            database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractAlternativeSiteJobItems.QuoteContractSiteID, true);
            database.AddParameter("@Description", (object)oQuoteContractAlternativeSiteJobItems.Description, true);
            database.AddParameter("@VisitFrequencyID", (object)oQuoteContractAlternativeSiteJobItems.VisitFrequencyID, true);
            database.AddParameter("@VisitDuration", (object)oQuoteContractAlternativeSiteJobItems.VisitDuration, true);
            database.AddParameter("@ItemPricePerVisit", (object)oQuoteContractAlternativeSiteJobItems.ItemPricePerVisit, true);
            database.AddParameter("@JobOfWorkID", (object)oQuoteContractAlternativeSiteJobItems.JobOfWorkID, true);
        }
    }
}