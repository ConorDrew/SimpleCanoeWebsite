// Decompiled with JetBrains decompiler
// Type: FSM.FSMDataSetTableAdapters.EngineerVisitTimeSheet_Get_For_EngineerVisitIDTableAdapter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FSM.FSMDataSetTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class EngineerVisitTimeSheet_Get_For_EngineerVisitIDTableAdapter : Component
  {
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    private virtual SqlDataAdapter _adapter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public EngineerVisitTimeSheet_Get_For_EngineerVisitIDTableAdapter()
    {
      this.ClearBeforeFill = true;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected internal SqlDataAdapter Adapter
    {
      get
      {
        if (this._adapter == null)
          this.InitAdapter();
        return this._adapter;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    internal SqlConnection Connection
    {
      get
      {
        if (this._connection == null)
          this.InitConnection();
        return this._connection;
      }
      set
      {
        this._connection = value;
        if (this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Connection = value;
        if (this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Connection = value;
        if (this.Adapter.UpdateCommand != null)
          this.Adapter.UpdateCommand.Connection = value;
        int index = 0;
        while (index < this.CommandCollection.Length)
        {
          if (this.CommandCollection[index] != null)
            this.CommandCollection[index].Connection = value;
          checked { ++index; }
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    internal SqlTransaction Transaction
    {
      get
      {
        return this._transaction;
      }
      set
      {
        this._transaction = value;
        int index = 0;
        while (index < this.CommandCollection.Length)
        {
          this.CommandCollection[index].Transaction = this._transaction;
          checked { ++index; }
        }
        if (this.Adapter != null && this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Transaction = this._transaction;
        if (this.Adapter == null || this.Adapter.UpdateCommand == null)
          return;
        this.Adapter.UpdateCommand.Transaction = this._transaction;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected SqlCommand[] CommandCollection
    {
      get
      {
        if (this._commandCollection == null)
          this.InitCommandCollection();
        return this._commandCollection;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public bool ClearBeforeFill
    {
      get
      {
        return this._clearBeforeFill;
      }
      set
      {
        this._clearBeforeFill = value;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private void InitAdapter()
    {
      this._adapter = new SqlDataAdapter();
      this._adapter.TableMappings.Add((object) new DataTableMapping()
      {
        SourceTable = "Table",
        DataSetTable = "EngineerVisitTimeSheet_Get_For_EngineerVisitID",
        ColumnMappings = {
          {
            "EngineerVisitTimeSheetID",
            "EngineerVisitTimeSheetID"
          },
          {
            "EngineerVisitID",
            "EngineerVisitID"
          },
          {
            "StartDateTime",
            "StartDateTime"
          },
          {
            "EndDateTime",
            "EndDateTime"
          },
          {
            "Comments",
            "Comments"
          },
          {
            "TimeSheetType",
            "TimeSheetType"
          },
          {
            "TimesheetTypeID",
            "TimesheetTypeID"
          }
        }
      });
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private void InitConnection()
    {
      this._connection = new SqlConnection();
      this._connection.ConnectionString = "";
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new SqlCommand[1];
      this._commandCollection[0] = new SqlCommand();
      this._commandCollection[0].Connection = this.Connection;
      this._commandCollection[0].CommandText = "dbo.EngineerVisitTimeSheet_Get_For_EngineerVisitID";
      this._commandCollection[0].CommandType = CommandType.StoredProcedure;
      this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@EngineerVisitID", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable dataTable,
      int? EngineerVisitID)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      this.Adapter.SelectCommand.Parameters[1].Value = !EngineerVisitID.HasValue ? (object) DBNull.Value : (object) EngineerVisitID.Value;
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable GetData(
      int? EngineerVisitID)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      this.Adapter.SelectCommand.Parameters[1].Value = !EngineerVisitID.HasValue ? (object) DBNull.Value : (object) EngineerVisitID.Value;
      FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable visitIdDataTable = new FSMDataSet.EngineerVisitTimeSheet_Get_For_EngineerVisitIDDataTable();
      this.Adapter.Fill((DataTable) visitIdDataTable);
      return visitIdDataTable;
    }
  }
}
