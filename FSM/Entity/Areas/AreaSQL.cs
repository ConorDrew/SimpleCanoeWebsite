// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Areas.AreaSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Areas
{
    public class AreaSQL
    {
        private Database _database;

        public AreaSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int AreaID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AreaID", (object)AreaID, true);
            this._database.ExecuteSP_NO_Return("Area_Delete", true);
        }

        public Area Area_Get(int AreaID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AreaID", (object)AreaID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Area_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Area)null;
            Area area1 = new Area();
            Area area2 = area1;
            area2.IgnoreExceptionsOnSetMethods = true;
            area2.SetAreaID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(AreaID)]);
            area2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
            area2.SetSectionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SectionID"]);
            area2.SetOrderNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderNumber"]);
            area2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            area1.Exists = true;
            return area1;
        }

        public DataView Area_Get_For_Section(int SectionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SectionID", (object)SectionID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Area_Get_For_Section), true);
            table.TableName = Enums.TableNames.tblArea.ToString();
            return new DataView(table);
        }

        public DataView Area_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Area_GetAll), true);
            table.TableName = Enums.TableNames.tblArea.ToString();
            return new DataView(table);
        }

        public Area Insert(Area oArea)
        {
            this._database.ClearParameter();
            if (oArea.OrderNumber == 0)
                oArea.SetOrderNumber = (object)this.Area_getNextOrderNumber(oArea.SectionID);
            this._database.ClearParameter();
            this.AddAreaParametersToCommand(ref oArea);
            oArea.SetAreaID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Area_Insert", true)));
            oArea.Exists = true;
            return oArea;
        }

        public void Area_AdjustOrderNumber(
          int AreaID,
          int OldOrderNumber,
          int NewOrderNumber,
          int SectionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AreaID", (object)AreaID, true);
            this._database.AddParameter("@oldOrderNumber", (object)OldOrderNumber, true);
            this._database.AddParameter("@NewOrderNumber", (object)NewOrderNumber, true);
            this._database.AddParameter("@SectionID", (object)SectionID, true);
            this._database.ExecuteSP_NO_Return(nameof(Area_AdjustOrderNumber), true);
        }

        public void Update(Area oArea)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AreaID", (object)oArea.AreaID, true);
            this.AddAreaParametersToCommand(ref oArea);
            this._database.ExecuteSP_NO_Return("Area_Update", true);
        }

        private void AddAreaParametersToCommand(ref Area oArea)
        {
            Database database = this._database;
            database.AddParameter("@Description", (object)oArea.Description, true);
            database.AddParameter("@SectionID", (object)oArea.SectionID, true);
            database.AddParameter("@OrderNumber", (object)oArea.OrderNumber, true);
        }

        private int Area_getNextOrderNumber(int SectionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SectionID", (object)SectionID, true);
            int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(Area_getNextOrderNumber), true)));
            return num == 0 ? 1 : checked(num + 1);
        }
    }
}