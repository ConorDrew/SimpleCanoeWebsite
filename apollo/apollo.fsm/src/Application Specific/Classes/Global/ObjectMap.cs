using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FSM.Entity.Sys
{
    public class ObjectMap
    {
        public static List<T> DataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                var list = new List<T>();
                foreach (DataRow row in table.AsEnumerable())
                {
                    var obj = new T();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            var propertyInfo = obj.GetType().GetProperty(prop.Name);
                            // propertyInfo.SetValue(instanceOfT, dataRow[properties.Name], null);

                            object value = row[prop.Name];
                            object safeValue = value == null || DBNull.Value.Equals(value) ? null : Convert.ChangeType(value, propertyInfo.PropertyType);
                            propertyInfo.SetValue(obj, safeValue);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}