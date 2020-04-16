// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Vans.Equipments.EquipmentSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Vans.Equipments
{
    public class EquipmentSql
    {
        private Database _database;

        public EquipmentSql(Database database)
        {
            this._database = database;
        }

        public DataView Get(int vanId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanId", (object)vanId, false);
            DataTable table = this._database.ExecuteSP_DataTable("VanEquipment_Get", true);
            table.TableName = Enums.TableNames.tblVan.ToString();
            return new DataView(table);
        }

        public int Insert(int VanId, string equipment)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanId", (object)VanId, false);
            this._database.AddParameter("@Equipment", (object)equipment, false);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("VanEquipment_Insert", true)));
        }

        public int Delete(int Id)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Id", (object)Id, false);
            return Helper.MakeIntegerValid((object)this._database.ExecuteSP_ReturnRowsAffected("VanEquipment_Delete"));
        }
    }
}