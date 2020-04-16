// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteEngineerVisits.QuoteEngineerVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteEngineerVisits
{
  public class QuoteEngineerVisit
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _QuoteEngineerVisitID;
    private int _QuoteJobOfWorkID;
    private int _StatusEnumID;
    private string _NotesToEngineer;

    public QuoteEngineerVisit()
    {
      this._exists = false;
      this._deleted = false;
      this._QuoteEngineerVisitID = 0;
      this._QuoteJobOfWorkID = 0;
      this._StatusEnumID = 0;
      this._NotesToEngineer = string.Empty;
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

    public int QuoteEngineerVisitID
    {
      get
      {
        return this._QuoteEngineerVisitID;
      }
    }

    public object SetQuoteEngineerVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteEngineerVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteJobOfWorkID
    {
      get
      {
        return this._QuoteJobOfWorkID;
      }
    }

    public object SetQuoteJobOfWorkID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobOfWorkID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int StatusEnumID
    {
      get
      {
        return this._StatusEnumID;
      }
    }

    public object SetStatusEnumID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_StatusEnumID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NotesToEngineer
    {
      get
      {
        return this._NotesToEngineer;
      }
    }

    public object SetNotesToEngineer
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_NotesToEngineer", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
