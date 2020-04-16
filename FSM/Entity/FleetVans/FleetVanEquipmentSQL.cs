// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanEquipmentSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;

namespace FSM.Entity.FleetVans
{
    public class FleetVanEquipmentSQL
    {
        private Database _database;

        public FleetVanEquipmentSQL(Database database)
        {
            this._database = database;
        }

        public DataView Get(int vanEquipmentID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanEquipmentID", (object)vanEquipmentID, false);
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanEquipment_Get", true);
            table.TableName = Enums.TableNames.tblFleetVanEquipment.ToString();
            return new DataView(table);
        }

        public DataView Get_ByVanID(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanEquipment_Get_ForVan", true);
            table.TableName = Enums.TableNames.tblFleetVanEquipment.ToString();
            return new DataView(table);
        }

        public int Insert(int vanID, int equipmentID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            this._database.AddParameter("@EquipmentID", (object)equipmentID, false);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("FleetVanEquipment_Insert", true));
        }

        public int Check(int vanID, int equipmentID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            this._database.AddParameter("@EquipmentID", (object)equipmentID, false);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("FleetVanEquipment_Check", true));
        }

        public void Update(int vanEquipmentID, int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanEquipmentID", (object)vanEquipmentID, false);
            this._database.AddParameter("@VanID", (object)vanID, false);
            this._database.ExecuteSP_NO_Return("FleetVanEquipment_Update", true);
        }

        public void Delete(int vanEquipmentID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanEquipmentID", (object)vanEquipmentID, false);
            this._database.ExecuteSP_NO_Return("FleetVanEquipment_Delete", true);
        }
    }
}