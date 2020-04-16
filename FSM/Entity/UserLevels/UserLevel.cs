// Decompiled with JetBrains decompiler
// Type: FSM.Entity.UserLevels.UserLevel
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.UserLevels
{
  public class UserLevel
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _UserLevelID;
    private int _LevelID;
    private int _UserID;

    public UserLevel()
    {
      this._exists = false;
      this._deleted = false;
      this._UserLevelID = 0;
      this._LevelID = 0;
      this._UserID = 0;
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

    public DataTypeValidator DTValidator
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

    public int UserLevelID
    {
      get
      {
        return this._UserLevelID;
      }
    }

    public object SetUserLevelID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_UserLevelID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int LevelID
    {
      get
      {
        return this._LevelID;
      }
    }

    public object SetLevelID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LevelID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int UserID
    {
      get
      {
        return this._UserID;
      }
    }

    public object SetUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_UserID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
