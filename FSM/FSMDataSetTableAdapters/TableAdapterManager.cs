// Decompiled with JetBrains decompiler
// Type: FSM.FSMDataSetTableAdapters.TableAdapterManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace FSM.FSMDataSetTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapterManager")]
  public class TableAdapterManager : Component
  {
    private TableAdapterManager.UpdateOrderOption _updateOrder;
    private bool _backupDataSetBeforeUpdate;
    private IDbConnection _connection;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public TableAdapterManager.UpdateOrderOption UpdateOrder
    {
      get
      {
        return this._updateOrder;
      }
      set
      {
        this._updateOrder = value;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public bool BackupDataSetBeforeUpdate
    {
      get
      {
        return this._backupDataSetBeforeUpdate;
      }
      set
      {
        this._backupDataSetBeforeUpdate = value;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    public IDbConnection Connection
    {
      get
      {
        return this._connection != null ? this._connection : (IDbConnection) null;
      }
      set
      {
        this._connection = value;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    [Browsable(false)]
    public int TableAdapterInstanceCount
    {
      get
      {
        return 0;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private int UpdateUpdatedRows(
      FSMDataSet dataSet,
      List<DataRow> allChangedRows,
      List<DataRow> allAddedRows)
    {
      return 0;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private int UpdateInsertedRows(FSMDataSet dataSet, List<DataRow> allAddedRows)
    {
      return 0;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private int UpdateDeletedRows(FSMDataSet dataSet, List<DataRow> allChangedRows)
    {
      return 0;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
    {
      if (updatedRows == null || updatedRows.Length < 1 || (allAddedRows == null || allAddedRows.Count < 1))
        return updatedRows;
      List<DataRow> dataRowList = new List<DataRow>();
      int index = 0;
      while (index < updatedRows.Length)
      {
        DataRow updatedRow = updatedRows[index];
        if (!allAddedRows.Contains(updatedRow))
          dataRowList.Add(updatedRow);
        checked { ++index; }
      }
      return dataRowList.ToArray();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public virtual int UpdateAll(FSMDataSet dataSet)
    {
      if (dataSet == null)
        throw new ArgumentNullException(nameof (dataSet));
      if (!dataSet.HasChanges())
        return 0;
      IDbConnection connection = this.Connection;
      if (connection == null)
        throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
      bool flag = false;
      if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
        connection.Close();
      if (connection.State == ConnectionState.Closed)
      {
        connection.Open();
        flag = true;
      }
      IDbTransaction dbTransaction = connection.BeginTransaction();
      if (dbTransaction == null)
        throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
      List<DataRow> allChangedRows = new List<DataRow>();
      List<DataRow> allAddedRows = new List<DataRow>();
      List<DataAdapter> dataAdapterList = new List<DataAdapter>();
      Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
      int num = 0;
      DataSet dataSet1 = (DataSet) null;
      if (this.BackupDataSetBeforeUpdate)
      {
        dataSet1 = new DataSet();
        dataSet1.Merge((DataSet) dataSet);
      }
      try
      {
        if (this.UpdateOrder == TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
        {
          checked { num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows); }
          checked { num += this.UpdateInsertedRows(dataSet, allAddedRows); }
        }
        else
        {
          checked { num += this.UpdateInsertedRows(dataSet, allAddedRows); }
          checked { num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows); }
        }
        checked { num += this.UpdateDeletedRows(dataSet, allChangedRows); }
        dbTransaction.Commit();
        if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[checked (allAddedRows.Count - 1 + 1)];
          allAddedRows.CopyTo(array);
          int index = 0;
          while (index < array.Length)
          {
            array[index].AcceptChanges();
            checked { ++index; }
          }
        }
        if (0 < allChangedRows.Count)
        {
          DataRow[] array = new DataRow[checked (allChangedRows.Count - 1 + 1)];
          allChangedRows.CopyTo(array);
          int index = 0;
          while (index < array.Length)
          {
            array[index].AcceptChanges();
            checked { ++index; }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        dbTransaction.Rollback();
        if (this.BackupDataSetBeforeUpdate)
        {
          Debug.Assert(dataSet1 != null);
          dataSet.Clear();
          dataSet.Merge(dataSet1);
        }
        else if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[checked (allAddedRows.Count - 1 + 1)];
          allAddedRows.CopyTo(array);
          int index = 0;
          while (index < array.Length)
          {
            DataRow dataRow = array[index];
            dataRow.AcceptChanges();
            dataRow.SetAdded();
            checked { ++index; }
          }
        }
        throw exception;
      }
      finally
      {
        if (flag)
          connection.Close();
        if (0 < dataAdapterList.Count)
        {
          DataAdapter[] array = new DataAdapter[checked (dataAdapterList.Count - 1 + 1)];
          dataAdapterList.CopyTo(array);
          int index = 0;
          while (index < array.Length)
          {
            array[index].AcceptChangesDuringUpdate = true;
            checked { ++index; }
          }
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected virtual void SortSelfReferenceRows(
      DataRow[] rows,
      DataRelation relation,
      bool childFirst)
    {
      Array.Sort<DataRow>(rows, (IComparer<DataRow>) new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection)
    {
      return this._connection != null || (this.Connection == null || inputConnection == null || string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal));
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    public enum UpdateOrderOption
    {
      InsertUpdateDelete,
      UpdateInsertDelete,
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
    private class SelfReferenceComparer : IComparer<DataRow>
    {
      private DataRelation _relation;
      private int _childFirst;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      internal SelfReferenceComparer(DataRelation relation, bool childFirst)
      {
        this._relation = relation;
        if (childFirst)
          this._childFirst = -1;
        else
          this._childFirst = 1;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      private DataRow GetRoot(DataRow row, ref int distance)
      {
        Debug.Assert(row != null);
        DataRow dataRow = row;
        distance = 0;
        IDictionary<DataRow, DataRow> dictionary = (IDictionary<DataRow, DataRow>) new Dictionary<DataRow, DataRow>();
        dictionary[row] = row;
        for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Default); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default))
        {
          checked { ++distance; }
          dataRow = parentRow;
          dictionary[parentRow] = parentRow;
        }
        if (distance == 0)
        {
          dictionary.Clear();
          dictionary[row] = row;
          for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Original); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original))
          {
            checked { ++distance; }
            dataRow = parentRow;
            dictionary[parentRow] = parentRow;
          }
        }
        return dataRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
      public int Compare(DataRow row1, DataRow row2)
      {
        if (object.ReferenceEquals((object) row1, (object) row2))
          return 0;
        if (row1 == null)
          return -1;
        if (row2 == null)
          return 1;
        int distance1 = 0;
        DataRow root1 = this.GetRoot(row1, ref distance1);
        int distance2 = 0;
        DataRow root2 = this.GetRoot(row2, ref distance2);
        if (object.ReferenceEquals((object) root1, (object) root2))
          return checked (this._childFirst * distance1.CompareTo(distance2));
        Debug.Assert(root1.Table != null && root2.Table != null);
        return root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2) ? -1 : 1;
      }
    }
  }
}
