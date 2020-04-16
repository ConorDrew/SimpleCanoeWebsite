// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.ObjectMap
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sys
{
  public class ObjectMap
  {
    public static List<T> DataTableToList<T>(DataTable table) where T : class, new()
    {
      List<T> objList1;
      try
      {
        List<T> objList2 = new List<T>();
        try
        {
          foreach (DataRow dataRow in table.AsEnumerable())
          {
            T obj = new T();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            int index = 0;
            while (index < properties.Length)
            {
              PropertyInfo propertyInfo = properties[index];
              try
              {
                PropertyInfo property = obj.GetType().GetProperty(propertyInfo.Name);
                property.SetValue((object) obj, RuntimeHelpers.GetObjectValue(Convert.ChangeType(RuntimeHelpers.GetObjectValue(dataRow[propertyInfo.Name]), property.PropertyType)), (object[]) null);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              checked { ++index; }
            }
            objList2.Add(obj);
          }
        }
        finally
        {
          IEnumerator<DataRow> enumerator;
          enumerator?.Dispose();
        }
        objList1 = objList2;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        objList1 = (List<T>) null;
        ProjectData.ClearProjectError();
      }
      return objList1;
    }
  }
}
