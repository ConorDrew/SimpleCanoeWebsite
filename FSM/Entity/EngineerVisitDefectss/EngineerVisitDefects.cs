// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitDefectss.EngineerVisitDefects
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitDefectss
{
  public class EngineerVisitDefects
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitDefectID;
    private int _CategoryID;
    private string _Reason;
    private string _ActionTaken;
    private bool _WarningNoticeIssued;
    private bool _Disconnected;
    private string _Comments;
    private int _AssetID;
    private int _EngineerVisitID;

    public EngineerVisitDefects()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitDefectID = 0;
      this._CategoryID = 0;
      this._Reason = string.Empty;
      this._ActionTaken = string.Empty;
      this._WarningNoticeIssued = false;
      this._Disconnected = false;
      this._Comments = string.Empty;
      this._AssetID = 0;
      this._EngineerVisitID = 0;
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

    public int EngineerVisitDefectID
    {
      get
      {
        return this._EngineerVisitDefectID;
      }
    }

    public object SetEngineerVisitDefectID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitDefectID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CategoryID
    {
      get
      {
        return this._CategoryID;
      }
    }

    public object SetCategoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CategoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Reason
    {
      get
      {
        return this._Reason;
      }
    }

    public object SetReason
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Reason", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ActionTaken
    {
      get
      {
        return this._ActionTaken;
      }
    }

    public object SetActionTaken
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ActionTaken", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool WarningNoticeIssued
    {
      get
      {
        return this._WarningNoticeIssued;
      }
    }

    public object SetWarningNoticeIssued
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WarningNoticeIssued", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Disconnected
    {
      get
      {
        return this._Disconnected;
      }
    }

    public object SetDisconnected
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Disconnected", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Comments
    {
      get
      {
        return this._Comments;
      }
    }

    public object SetComments
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Comments", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AssetID
    {
      get
      {
        return this._AssetID;
      }
    }

    public object SetAssetID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
    }

    public object SetEngineerVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
