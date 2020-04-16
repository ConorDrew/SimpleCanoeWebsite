// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductAssociatedParts.ProductAssociatedPartSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.ProductAssociatedParts
{
  public class ProductAssociatedPartSQL
  {
    private Database _database;

    public ProductAssociatedPartSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_For_ProductID(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ProductAssociatedPart_GetAll_For_ProductID", true);
      table.TableName = Enums.TableNames.tblProductAssociatedPart.ToString();
      return new DataView(table);
    }

    public void Insert(ProductAssociatedPart oProductAssociatedPart)
    {
      this._database.ClearParameter();
      this.AddProductAssociatedPartParametersToCommand(ref oProductAssociatedPart);
      this._database.ExecuteSP_NO_Return("ProductAssociatedPart_Insert", true);
    }

    public void Delete(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, true);
      this._database.ExecuteSP_NO_Return("ProductAssociatedPart_Delete", true);
    }

    private void AddProductAssociatedPartParametersToCommand(
      ref ProductAssociatedPart oProductAssociatedPart)
    {
      Database database = this._database;
      database.AddParameter("@ProductID", (object) oProductAssociatedPart.ProductID, true);
      database.AddParameter("@PartID", (object) oProductAssociatedPart.PartID, true);
    }
  }
}
