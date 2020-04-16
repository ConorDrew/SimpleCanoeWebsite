// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Subcontractors.SubcontractorSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Subcontractors
{
    public class SubcontractorSQL
    {
        private Database _database;

        public SubcontractorSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int SubcontractorID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubcontractorID", (object)SubcontractorID, true);
            this._database.ExecuteSP_NO_Return("Subcontractor_Delete", true);
        }

        public Subcontractor Subcontractor_Get(int SubcontractorID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubcontractorID", (object)SubcontractorID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Subcontractor_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Subcontractor)null;
            Subcontractor subcontractor1 = new Subcontractor();
            Subcontractor subcontractor2 = subcontractor1;
            subcontractor2.IgnoreExceptionsOnSetMethods = true;
            subcontractor2.SetSubcontractorID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(SubcontractorID)]);
            subcontractor2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
            subcontractor2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            subcontractor2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
            subcontractor2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
            subcontractor2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
            subcontractor2.SetAddress4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]);
            subcontractor2.SetAddress5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]);
            subcontractor2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
            subcontractor2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
            subcontractor2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
            subcontractor2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
            subcontractor2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            subcontractor2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            subcontractor2.SetLinkToSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LinkToSupplierID"]);
            if (dataTable.Rows[0].Table.Columns.Contains("TaxRate"))
                subcontractor2.SetTaxRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaxRate"]);
            subcontractor1.Exists = true;
            return subcontractor1;
        }

        public DataView Subcontractor_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Subcontractor_GetAll), true);
            table.TableName = Enums.TableNames.tblSubcontractor.ToString();
            return new DataView(table);
        }

        public Subcontractor Insert(Subcontractor oSubcontractor)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)oSubcontractor.EngineerID, true);
            this.AddSubcontractorParametersToCommand(ref oSubcontractor);
            oSubcontractor.SetSubcontractorID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Subcontractor_Insert", true)));
            oSubcontractor.Exists = true;
            return oSubcontractor;
        }

        public DataView Subcontractor_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Subcontractor_Search), true);
            table.TableName = Enums.TableNames.tblSubcontractor.ToString();
            return new DataView(table);
        }

        public void Update(Subcontractor oSubcontractor)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubcontractorID", (object)oSubcontractor.SubcontractorID, true);
            this.AddSubcontractorParametersToCommand(ref oSubcontractor);
            this._database.ExecuteSP_NO_Return("Subcontractor_Update", true);
        }

        private void AddSubcontractorParametersToCommand(ref Subcontractor oSubcontractor)
        {
            Database database = this._database;
            database.AddParameter("@Name", (object)oSubcontractor.Name, true);
            database.AddParameter("@Address1", (object)oSubcontractor.Address1, true);
            database.AddParameter("@Address2", (object)oSubcontractor.Address2, true);
            database.AddParameter("@Address3", (object)oSubcontractor.Address3, true);
            database.AddParameter("@Address4", (object)oSubcontractor.Address4, true);
            database.AddParameter("@Address5", (object)oSubcontractor.Address5, true);
            database.AddParameter("@Postcode", (object)oSubcontractor.Postcode, true);
            database.AddParameter("@TelephoneNum", (object)oSubcontractor.TelephoneNum, true);
            database.AddParameter("@FaxNum", (object)oSubcontractor.FaxNum, true);
            database.AddParameter("@EmailAddress", (object)oSubcontractor.EmailAddress, true);
            database.AddParameter("@Notes", (object)oSubcontractor.Notes, true);
            database.AddParameter("@LinkToSupplierID", (object)oSubcontractor.LinkToSupplierID, true);
            database.AddParameter("@TaxRate", (object)oSubcontractor.TaxRate, true);
        }
    }
}