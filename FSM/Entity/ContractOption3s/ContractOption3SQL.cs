// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3s.ContractOption3SQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3s
{
    public class ContractOption3SQL
    {
        private Database _database;

        public ContractOption3SQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int ContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractID", (object)ContractID, true);
            this._database.ExecuteSP_NO_Return("ContractOption3_Delete", true);
        }

        public ContractOption3 ContractOption3_Get(int ContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractID", (object)ContractID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ContractOption3_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ContractOption3)null;
            ContractOption3 contractOption3_1 = new ContractOption3();
            ContractOption3 contractOption3_2 = contractOption3_1;
            contractOption3_2.IgnoreExceptionsOnSetMethods = true;
            contractOption3_2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(ContractID)]);
            contractOption3_2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            contractOption3_2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
            contractOption3_2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
            contractOption3_2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
            contractOption3_2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
            contractOption3_1.Exists = true;
            return contractOption3_1;
        }

        public double ContractCalculatedTotal(int ContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractID", (object)ContractID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOptionCalculatedTotal", true)));
        }

        public ContractOption3 ContractOption3_Get_For_Quote_ID(int QuoteContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(ContractOption3_Get_For_Quote_ID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (ContractOption3)null;
            ContractOption3 contractOption3_1 = new ContractOption3();
            ContractOption3 contractOption3_2 = contractOption3_1;
            contractOption3_2.IgnoreExceptionsOnSetMethods = true;
            contractOption3_2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
            contractOption3_2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            contractOption3_2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
            contractOption3_2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
            contractOption3_2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
            contractOption3_2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteContractID)]);
            contractOption3_1.Exists = true;
            return contractOption3_1;
        }

        public DataView ContractOption3_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ContractOption3_GetAll), true);
            table.TableName = Enums.TableNames.tblContractOption3.ToString();
            return new DataView(table);
        }

        public ContractOption3 Insert(ContractOption3 oContractOption3)
        {
            this._database.ClearParameter();
            this.AddContractOption3ParametersToCommand(ref oContractOption3);
            oContractOption3.SetContractID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOption3_Insert", true)));
            oContractOption3.Exists = true;
            return oContractOption3;
        }

        public void Update(ContractOption3 oContractOption3)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractID", (object)oContractOption3.ContractID, true);
            this.AddContractOption3ParametersToCommand(ref oContractOption3);
            this._database.ExecuteSP_NO_Return("ContractOption3_Update", true);
        }

        private void AddContractOption3ParametersToCommand(ref ContractOption3 oContractOption3)
        {
            Database database = this._database;
            database.AddParameter("@CustomerID", (object)oContractOption3.CustomerID, true);
            database.AddParameter("@ContractReference", (object)oContractOption3.ContractReference, true);
            database.AddParameter("@ContractStatusID", (object)oContractOption3.ContractStatusID, true);
            database.AddParameter("@ContractPrice", (object)oContractOption3.ContractPrice, true);
            database.AddParameter("@QuoteContractID", (object)oContractOption3.QuoteContractID, true);
        }

        public DataTable ContractReference_Get(string prefix, string postfix)
        {
            int num1 = 0;
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("REF");
            this._database.ClearParameter();
            this._database.AddParameter("@PREFIX", (object)prefix, true);
            this._database.AddParameter("@POSTFIX", (object)postfix, true);
            DataTable dataTable2 = this._database.ExecuteSP_DataTable(nameof(ContractReference_Get), true);
            if (dataTable2.Rows.Count > 0)
                num1 = Conversions.ToInteger(dataTable2.Rows[0]["Numpart"]);
            int num2 = 0;
            int num3 = checked(num1 - 1);
            int num4 = 1;
            while (num4 <= num3)
            {
                if (dataTable2.Select("Numpart=" + Conversions.ToString(num4)).Length == 0)
                {
                    DataRow row = dataTable1.NewRow();
                    row["REF"] = (object)num4;
                    dataTable1.Rows.Add(row);
                    checked { ++num2; }
                    if (num2 >= 10)
                        break;
                }
                checked { ++num4; }
            }
            DataRow row1 = dataTable1.NewRow();
            row1["REF"] = (object)checked(num1 + 1);
            dataTable1.Rows.Add(row1);
            dataTable1.TableName = Enums.TableNames.tblContractOption3.ToString();
            return dataTable1;
        }

        public bool ContractReference_CheckUnique(string ContractReference, int customerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractReference", (object)ContractReference, true);
            this._database.AddParameter("@customerID", (object)customerID, true);
            return this._database.ExecuteSP_DataTable(nameof(ContractReference_CheckUnique), true).Rows.Count <= 0;
        }
    }
}