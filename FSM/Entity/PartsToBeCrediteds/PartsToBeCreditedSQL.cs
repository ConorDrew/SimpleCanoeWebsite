// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartsToBeCrediteds.PartsToBeCreditedSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartsToBeCrediteds
{
    public class PartsToBeCreditedSQL
    {
        private Database _database;

        public PartsToBeCreditedSQL(Database database)
        {
            this._database = database;
        }

        public PartsToBeCredited PartsToBeCredited_Get(int PartsToBeCreditedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartsToBeCreditedID", (object)PartsToBeCreditedID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(PartsToBeCredited_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (PartsToBeCredited)null;
            PartsToBeCredited partsToBeCredited1 = new PartsToBeCredited();
            PartsToBeCredited partsToBeCredited2 = partsToBeCredited1;
            partsToBeCredited2.IgnoreExceptionsOnSetMethods = true;
            partsToBeCredited2.SetPartsToBeCreditedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(PartsToBeCreditedID)]);
            partsToBeCredited2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
            partsToBeCredited2.SetSupplierID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]));
            partsToBeCredited2.SetPartID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]));
            partsToBeCredited2.SetQty = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Qty"]);
            partsToBeCredited2.SetManuallyAdded = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ManuallyAdded"]));
            partsToBeCredited2.SetStatusID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusID"]));
            partsToBeCredited2.SetCreditReceived = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditReceived"]));
            partsToBeCredited2.SetOrderReference = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderReference"]));
            partsToBeCredited1.Exists = true;
            return partsToBeCredited1;
        }

        public DataView PartsToBeCredited_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartsToBeCredited_GetAll), true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public DataView PartsToBeCredited_Get_PartsCreditID(int PartCreditID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartCreditID", (object)PartCreditID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartsToBeCredited_Get_PartsCreditID), true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public DataView PartsToBeCredited_Get_OrderID(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order", true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public DataView PartsToBeCredited_Get_OrderPartID(int OrderPartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderPartID", (object)OrderPartID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart", true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public PartsToBeCredited Insert(PartsToBeCredited oPartsToBeCredited)
        {
            this._database.ClearParameter();
            this.AddPartsToBeCreditedParametersToCommand(ref oPartsToBeCredited);
            this._database.AddParameter("@AddedByUserID", (object)App.loggedInUser.UserID, true);
            this._database.AddParameter("@OrderPartID", (object)oPartsToBeCredited.PartOrderID, true);
            oPartsToBeCredited.SetPartsToBeCreditedID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartsToBeCredited_Insert", true)));
            oPartsToBeCredited.Exists = true;
            return oPartsToBeCredited;
        }

        public void Update(PartsToBeCredited oPartsToBeCredited)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartsToBeCreditedID", (object)oPartsToBeCredited.PartsToBeCreditedID, true);
            this.AddPartsToBeCreditedParametersToCommand(ref oPartsToBeCredited);
            this._database.ExecuteSP_NO_Return("PartsToBeCredited_Update", true);
        }

        private void AddPartsToBeCreditedParametersToCommand(ref PartsToBeCredited oPartsToBeCredited)
        {
            Database database = this._database;
            database.AddParameter("@OrderID", (object)oPartsToBeCredited.OrderID, true);
            database.AddParameter("@SupplierID", (object)oPartsToBeCredited.SupplierID, true);
            database.AddParameter("@PartID", (object)oPartsToBeCredited.PartID, true);
            database.AddParameter("@Qty", (object)oPartsToBeCredited.Qty, true);
            database.AddParameter("@ManuallyAdded", (object)oPartsToBeCredited.ManuallyAdded, true);
            database.AddParameter("@StatusID", (object)oPartsToBeCredited.StatusID, true);
            database.AddParameter("@CreditReceived", (object)oPartsToBeCredited.CreditReceived, true);
            database.AddParameter("@OrderReference", (object)oPartsToBeCredited.OrderReference, true);
        }

        public int PartCredits_Insert(
          double AmountReceived,
          string Notes,
          DateTime DateReceived,
          DateTime DateExportedToSage,
          int TaxCodeID,
          string NominalCode,
          string DepartmentRef,
          string ExtraRef,
          string SupplierCreditRef)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@AmountReceived", (object)AmountReceived, true);
            this._database.AddParameter("@Notes", (object)Notes, true);
            this._database.AddParameter("@DateReceived", (object)DateReceived, true);
            if (DateTime.Compare(DateExportedToSage, DateTime.MinValue) == 0)
                this._database.AddParameter("@DateExportedToSage", (object)DBNull.Value, true);
            else
                this._database.AddParameter("@DateExportedToSage", (object)DateExportedToSage, true);
            this._database.AddParameter("@TaxCodeID", (object)TaxCodeID, true);
            this._database.AddParameter("@NominalCode", (object)NominalCode, true);
            this._database.AddParameter("@DepartmentRef", (object)DepartmentRef, true);
            this._database.AddParameter("@ExtraRef", (object)ExtraRef, true);
            this._database.AddParameter("@SupplierCreditRef", (object)SupplierCreditRef, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(PartCredits_Insert), true)));
        }

        public int PartCredits_Update(
          int PartCreditsID,
          double AmountReceived,
          string Notes,
          DateTime DateReceived,
          DateTime DateExportedToSage,
          int TaxCodeID,
          string NominalCode,
          string DepartmentRef,
          string ExtraRef,
          string SupplierCreditRef)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartCreditsID", (object)PartCreditsID, true);
            this._database.AddParameter("@AmountReceived", (object)AmountReceived, true);
            this._database.AddParameter("@Notes", (object)Notes, true);
            this._database.AddParameter("@DateReceived", (object)DateReceived, true);
            if (DateTime.Compare(DateExportedToSage, DateTime.MinValue) == 0)
                this._database.AddParameter("@DateExportedToSage", (object)DBNull.Value, true);
            else
                this._database.AddParameter("@DateExportedToSage", (object)DateExportedToSage, true);
            this._database.AddParameter("@TaxCodeID", (object)TaxCodeID, true);
            this._database.AddParameter("@NominalCode", (object)NominalCode, true);
            this._database.AddParameter("@DepartmentRef", (object)DepartmentRef, true);
            this._database.AddParameter("@ExtraRef", (object)ExtraRef, true);
            this._database.AddParameter("@SupplierCreditRef", (object)SupplierCreditRef, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(PartCredits_Update), true)));
        }

        public int PartCredits_Update_SageDate(int PartCreditsID, DateTime DateExportedToSage)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartCreditsID", (object)PartCreditsID, true);
            if (DateTime.Compare(DateExportedToSage, DateTime.MinValue) == 0)
                this._database.AddParameter("@DateExportedToSage", (object)DBNull.Value, true);
            else
                this._database.AddParameter("@DateExportedToSage", (object)DateExportedToSage, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(PartCredits_Update_SageDate), true)));
        }

        public void PartCreditParts_Insert(int PartCreditID, int PartsToBeCreditedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartCreditID", (object)PartCreditID, true);
            this._database.AddParameter("@PartsToBeCreditedID", (object)PartsToBeCreditedID, true);
            this._database.ExecuteSP_NO_Return(nameof(PartCreditParts_Insert), true);
        }

        public DataView Order_GetCredit(int PartCreditID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CreditID", (object)PartCreditID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID", true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public void Delete(int CreditID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CreditID", (object)CreditID, true);
            this._database.ExecuteSP_NO_Return("PartsToBeCredited_Delete", true);
        }

        public DataView PartsToBeCredited_Get_Parts_For_CreditID(int PartCreditID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CreditID", (object)PartCreditID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID", true);
            table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
            return new DataView(table);
        }

        public int PartsToBeCredited_Insert(
          int SupplierID,
          int OrderID,
          int PartID,
          int Quantity,
          string OrderRef,
          int EngineerID,
          int OrderPArtID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@Qty", (object)Quantity, true);
            this._database.AddParameter("@ManuallyAdded", (object)0, true);
            this._database.AddParameter("@StatusID", (object)1, true);
            this._database.AddParameter("@CreditReceived", (object)0.0, true);
            this._database.AddParameter("@AddedByUserID", (object)2, true);
            this._database.AddParameter("@OrderReference", (object)OrderRef, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.AddParameter("@DatePartReturned", (object)DBNull.Value, true);
            this._database.AddParameter("@OrderPartID", (object)OrderPArtID, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(PartsToBeCredited_Insert), true)));
        }
    }
}