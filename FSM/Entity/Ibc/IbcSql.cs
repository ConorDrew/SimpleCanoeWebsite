﻿// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Ibc.IbcSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.Ibc
{
    public class IbcSql
    {
        private Database _database;

        public IbcSql(Database database)
        {
            this._database = database;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            return new DataView(this._database.ExecuteSP_DataTable("Ibc_GetAll", true));
        }
    }
}