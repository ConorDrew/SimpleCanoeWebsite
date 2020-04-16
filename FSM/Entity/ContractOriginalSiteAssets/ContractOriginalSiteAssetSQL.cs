// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSiteAssets.ContractOriginalSiteAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSiteAssets
{
    public class ContractOriginalSiteAssetSQL
    {
        private Database _database;

        public ContractOriginalSiteAssetSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll_ContractSiteID(int ContractSiteID, int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteID", (object)ContractSiteID, true);
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalSiteAsset_GetAll_ContractSiteID", true);
            table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
            return new DataView(table);
        }

        public ContractOriginalSiteAsset Insert(
          ContractOriginalSiteAsset oContractSiteAsset)
        {
            this._database.ClearParameter();
            this.AddContractSiteAssetParametersToCommand(ref oContractSiteAsset);
            oContractSiteAsset.SetContractSiteAssetID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalSiteAsset_Insert", true)));
            oContractSiteAsset.Exists = true;
            return oContractSiteAsset;
        }

        public void Delete(int ContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteID", (object)ContractSiteID, true);
            this._database.ExecuteSP_NO_Return("ContractOriginalSiteAsset_Delete", true);
        }

        private void AddContractSiteAssetParametersToCommand(
          ref ContractOriginalSiteAsset oContractSiteAsset)
        {
            Database database = this._database;
            database.AddParameter("@ContractSiteID", (object)oContractSiteAsset.ContractSiteID, true);
            database.AddParameter("@AssetID", (object)oContractSiteAsset.AssetID, true);
            database.AddParameter("@PricePerVisit", (object)oContractSiteAsset.PricePerVisit, true);
            database.AddParameter("@PrimaryAsset", (object)oContractSiteAsset.PrimaryAsset, true);
            database.AddParameter("@Type", (object)oContractSiteAsset.Type, true);
            database.AddParameter("@Product", (object)oContractSiteAsset.Product, true);
        }
    }
}