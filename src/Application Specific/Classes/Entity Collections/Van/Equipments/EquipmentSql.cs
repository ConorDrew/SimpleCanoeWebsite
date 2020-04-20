using System.Data;
using FSM.Entity.Sys;

namespace FSM.Entity.Vans.Equipments
{
    public class EquipmentSql
    {
        private Database _database;

        public EquipmentSql(Database database)
        {
            _database = database;
        }

        public DataView Get(int vanId)
        {
            _database.ClearParameter();
            _database.AddParameter("@VanId", vanId);

            // Get the datatable from the database store in dt
            var dt = _database.ExecuteSP_DataTable("VanEquipment_Get");
            dt.TableName = Enums.TableNames.tblVan.ToString();
            return new DataView(dt);
        }

        public int Insert(int VanId, string equipment)
        {
            _database.ClearParameter();
            _database.AddParameter("@VanId", VanId);
            _database.AddParameter("@Equipment", equipment);
            return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("VanEquipment_Insert"));
        }

        public int Delete(int Id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", Id);
            return Helper.MakeIntegerValid(_database.ExecuteSP_ReturnRowsAffected("VanEquipment_Delete"));
        }
    }
}