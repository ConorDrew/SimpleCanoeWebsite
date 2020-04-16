// Decompiled with JetBrains decompiler
// Type: FSM.DataTypeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class DataTypeValidator
  {
    private bool _ignoreExceptionsOnSetMethods;
    private Hashtable _errorTable;

    public bool IgnoreExceptionsOnSetMethods
    {
      get
      {
        return this._ignoreExceptionsOnSetMethods;
      }
      set
      {
        this._ignoreExceptionsOnSetMethods = value;
      }
    }

    public Hashtable Errors
    {
      get
      {
        return this._errorTable;
      }
    }

    public DataTypeValidator()
    {
      this._ignoreExceptionsOnSetMethods = false;
      this._errorTable = new Hashtable();
    }

    public void SetValue(object sender, string variableName, object value)
    {
      if (value == null)
        return;
      if (!(value.GetType().IsPrimitive | Operators.CompareString(value.GetType().FullName, "System.String", false) == 0 | Operators.CompareString(value.GetType().FullName, "System.DBNull", false) == 0 | Operators.CompareString(value.GetType().FullName, "System.Decimal", false) == 0))
        throw new Exception("SetValue() can only be used with primitive & string types.");
      FieldInfo field;
      string associatedSetPropertyName;
      try
      {
        Type type = sender.GetType();
        while ((object) field == null)
        {
          field = type.GetField(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
          if ((object) field == null && sender.GetType().BaseType != null)
            type = type.BaseType;
          else
            break;
        }
        associatedSetPropertyName = this.GetAssociatedSetPropertyName(variableName);
        bool flag = true;
        if (Operators.CompareString(value.GetType().FullName, "System.DBNull", false) == 0)
          flag = false;
        if (flag)
        {
          string fullName = field.FieldType.FullName;
          if ((Operators.CompareString(fullName, "System.Int16", false) == 0 || Operators.CompareString(fullName, "System.Int32", false) == 0 || (Operators.CompareString(fullName, "System.Int64", false) == 0 || Operators.CompareString(fullName, "System.Integer", false) == 0) || (Operators.CompareString(fullName, "System.Decimal", false) == 0 || Operators.CompareString(fullName, "System.Double", false) == 0)) && Conversions.ToString(value).Trim().Length == 0)
            flag = true;
        }
        if (flag)
          field.SetValue(RuntimeHelpers.GetObjectValue(sender), RuntimeHelpers.GetObjectValue(Convert.ChangeType(RuntimeHelpers.GetObjectValue(value), field.FieldType)));
        this.RemoveError(associatedSetPropertyName);
      }
      catch (NullReferenceException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        this.RemoveError(associatedSetPropertyName);
        throw new NullReferenceException(string.Format("Field name '{0}' could not be found in class '{1}'.", (object) variableName, (object) sender.GetType().Name));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RemoveError(associatedSetPropertyName);
        string str = string.Format("*'{0}' could not be set because the input was not of type {1}.", (object) associatedSetPropertyName, (object) field.FieldType.Name);
        if (!this.IgnoreExceptionsOnSetMethods)
          throw new Exception(str);
        this.AddError(associatedSetPropertyName, str);
        ProjectData.ClearProjectError();
      }
    }

    private string GetAssociatedSetPropertyName(string fieldName)
    {
      string str = fieldName.Substring(checked (fieldName.IndexOf("_") + 1));
      return Conversions.ToString(char.ToUpper(str[0])) + str.Substring(1);
    }

    private void AddError(string propertyName, string errorMessage)
    {
      this._errorTable.Add((object) propertyName, (object) errorMessage);
    }

    private void RemoveError(string propertyName)
    {
      this._errorTable.Remove((object) propertyName);
    }
  }
}
