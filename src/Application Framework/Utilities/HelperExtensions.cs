using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.Entity.Sys
{
    public static class HelperExtensions
    {
        public static T GetValue<T>(this DataRow dr, string columnName, T defaultValue = default(T)) where T : struct
        {
            if (!IsParamsValid(dr, columnName, typeof(T)))
            {
                return defaultValue;
            }

            var columnValue = dr.Field<T?>(columnName);
            if (!columnValue.HasValue || dr[columnName] == DBNull.Value)
            {
                return defaultValue;
            }

            return columnValue.Value;
        }

        public static T GetValue<T>(this DataTable dt, int rowIndex, string columnName, T defaultValue = default(T)) where T : struct
        {
            if (!IsParamsValid(dt, rowIndex))
            {
                return defaultValue;
            }

            return dt.Rows[rowIndex].GetValue<T>(columnName, defaultValue);
        }

        public static T GetValue<T>(this DataRow dr, string columnName, T defaultValue = default(T), int _ = 0) where T : class
        {
            if (!IsParamsValid(dr, columnName, typeof(T)))
            {
                return defaultValue;
            }
            var columnValue = dr.Field<T>(columnName);
            if (columnValue == null || dr[columnName] == DBNull.Value)
            {
                return defaultValue;
            }

            return columnValue;
        }

        public static T GetValue<T>(this DataTable dt, int rowIndex, string columnName, T defaultValue = default(T), int _ = 0) where T : class
        {
            if (!IsParamsValid(dt, rowIndex))
            {
                return defaultValue;
            }

            return dt.Rows[rowIndex].GetValue<T>(columnName, defaultValue, _);
        }

        public static T GetNullableValue<T>(this DataRow dr, string columnName, T defaultValue = default(T))
        {
            if (!IsParamsValid(dr, columnName, typeof(T)))
            {
                return defaultValue;
            }
            return dr.Field<T>(columnName);
        }

        public static T GetNullableValue<T>(this DataTable dt, int rowIndex, string columnName, T defaultValue = default(T))
        {
            if (!IsParamsValid(dt, rowIndex))
            {
                return defaultValue;
            }

            return dt.Rows[rowIndex].GetNullableValue<T>(columnName, defaultValue);
        }

        private static bool IsParamsValid(DataTable dt, int rowIndex)
        {
            if (rowIndex < 0)
            {
                throw new Exception("Invalid row index value.");
            }
            if (dt == null)
            {
                return false;
            }

            if (rowIndex > (dt.Rows.Count - 1))
            {
                return false;
            }
            return true;
        }

        private static bool IsParamsValid(DataRow dr, string columnName, Type paramType)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new Exception("Column name must be provided");
            }
            if (dr == null)
            {
                return false;
            }

            var dataType = dr[columnName].GetType();
            if (dataType != paramType.GetType())
            {
                return false;
            }
            return true;
        }
    }
}