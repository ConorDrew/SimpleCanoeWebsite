// Decompiled with JetBrains decompiler
// Type: FSM.Entity.VATRatess.VATRatesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.VATRatess
{
    public class VATRatesSQL
    {
        private Database _database;

        public VATRatesSQL(Database database)
        {
            this._database = database;
        }

        public VATRates VATRates_Get(int VATRateID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VATRateID", (object)VATRateID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(VATRates_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (VATRates)null;
            VATRates vatRates1 = new VATRates();
            VATRates vatRates2 = vatRates1;
            vatRates2.IgnoreExceptionsOnSetMethods = true;
            vatRates2.SetVATRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(VATRateID)]);
            vatRates2.SetVATRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATRate"]);
            vatRates2.DateIntroduced = Conversions.ToDate(dataTable.Rows[0]["DateIntroduced"]);
            vatRates2.SetVATRateCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATRateCode"]);
            vatRates1.Exists = true;
            return vatRates1;
        }

        public DataView VATRates_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(VATRates_GetAll), true);
            table.TableName = Enums.TableNames.tblVATRates.ToString();
            return new DataView(table);
        }

        public DataView VATRates_GetAll_InputOrOutput(char inputOrOutput)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InputOrOutput", (object)inputOrOutput, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(VATRates_GetAll_InputOrOutput), true);
            table.TableName = Enums.TableNames.tblVATRates.ToString();
            return new DataView(table);
        }

        public DataView VATRates_GetAll_Valid()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(VATRates_GetAll_Valid), true);
            table.TableName = Enums.TableNames.tblVATRates.ToString();
            return new DataView(table);
        }

        public int VATRates_Get_ByDate(DateTime InvoiceDate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceDate", (object)InvoiceDate, true);
            return checked((int)Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(VATRates_Get_ByDate), true)))));
        }

        public VATRates Insert(VATRates oVATRates)
        {
            this._database.ClearParameter();
            this.AddVATRatesParametersToCommand(ref oVATRates);
            oVATRates.SetVATRateID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("VATRates_Insert", true)));
            oVATRates.Exists = true;
            return oVATRates;
        }

        public void Update(VATRates oVATRates)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VATRateID", (object)oVATRates.VATRateID, true);
            this.AddVATRatesParametersToCommand(ref oVATRates);
            this._database.ExecuteSP_NO_Return("VATRates_Update", true);
        }

        private void AddVATRatesParametersToCommand(ref VATRates oVATRates)
        {
            Database database = this._database;
            database.AddParameter("@VATRate", (object)oVATRates.VATRate, true);
            database.AddParameter("@DateIntroduced", (object)oVATRates.DateIntroduced, true);
            database.AddParameter("@VATRateCode", (object)oVATRates.VATRateCode, true);
        }
    }
}