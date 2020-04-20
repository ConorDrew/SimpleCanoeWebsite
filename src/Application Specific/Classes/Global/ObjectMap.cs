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
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
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