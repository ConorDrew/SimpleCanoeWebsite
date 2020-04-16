// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Authority.Authority
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Authority
{
  public class Authority
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _authorityId;
    private string _notes;
    private DateTime _dateAdded;
    private int _addedById;
    private DateTime _lastChanged;
    private int _lastChangedById;

    public Authority()
    {
      this._exists = false;
      this._deleted = false;
      this._authorityId = 0;
      this._notes = string.Empty;
      this._dateAdded = DateTime.MinValue;
      this._addedById = 0;
      this._lastChanged = DateTime.MinValue;
      this._lastChangedById = 0;
      this._dataTypeValidator = new DataTypeValidator();
    }

    public bool IgnoreExceptionsOnSetMethods
    {
      get
      {
        return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
      }
      set
      {
        this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
      }
    }

    public Hashtable Errors
    {
      get
      {
        return this._dataTypeValidator.Errors;
      }
    }

    public DataTypeValidator DTValIdator
    {
      get
      {
        return this._dataTypeValidator;
      }
    }

    public bool Exists
    {
      get
      {
        return this._exists;
      }
      set
      {
        this._exists = value;
      }
    }

    public bool Deleted
    {
      get
      {
        return this._deleted;
      }
    }

    public bool SetDeleted
    {
      set
      {
        this._deleted = value;
      }
    }

    public int AuthorityId
    {
      get
      {
        return this._authorityId;
      }
    }

    public object SetAuthorityId
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_authorityId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Notes
    {
      get
      {
        return this._notes;
      }
    }

    public object SetNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_notes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateAdded
    {
      get
      {
        return this._dateAdded;
      }
      set
      {
        this._dateAdded = value;
      }
    }

    public int AddedById
    {
      get
      {
        return this._addedById;
      }
    }

    public object SetAddedById
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_addedById", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime LastChanged
    {
      get
      {
        return this._lastChanged;
      }
      set
      {
        this._lastChanged = value;
      }
    }

    public int LastChangedById
    {
      get
      {
        return this._lastChangedById;
      }
    }

    public object SetLastChangedById
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_lastChangedById", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string GetChanges(FSM.Entity.Authority.Authority oldAuthority)
    {
      string str1 = string.Empty;
      try
      {
        PropertyInfo[] properties = oldAuthority.GetType().GetProperties();
        int index = 0;
        while (index < properties.Length)
        {
          PropertyInfo propertyInfo = properties[index];
          object objectValue1 = RuntimeHelpers.GetObjectValue(propertyInfo.GetValue((object) oldAuthority));
          object objectValue2 = RuntimeHelpers.GetObjectValue(propertyInfo.GetValue((object) this));
          if (!object.Equals(RuntimeHelpers.GetObjectValue(objectValue1), RuntimeHelpers.GetObjectValue(objectValue2)))
          {
            string str2 = objectValue1 == null ? "null" : objectValue1.ToString();
            string str3 = objectValue2 == null ? "null" : objectValue2.ToString();
            str1 = str1 + "Property " + propertyInfo.Name + " was: " + str2 + "; is: " + str3;
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        str1 += exception.Message;
        ProjectData.ClearProjectError();
      }
      return str1;
    }
  }
}
