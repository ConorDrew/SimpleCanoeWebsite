﻿// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Authority.SiteAuthority
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Authority
{
  public class SiteAuthority
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _siteAuthorityID;
    private int _siteId;
    private int _authorityID;

    public SiteAuthority()
    {
      this._exists = false;
      this._deleted = false;
      this._siteAuthorityID = 0;
      this._siteId = 0;
      this._authorityID = 0;
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

    public int SiteAuthorityID
    {
      get
      {
        return this._siteAuthorityID;
      }
    }

    public object SetSiteAuthorityID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_siteAuthorityID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SiteID
    {
      get
      {
        return this._siteId;
      }
    }

    public object SetSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_siteId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AuthorityID
    {
      get
      {
        return this._authorityID;
      }
    }

    public object SetAuthorityID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_authorityID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
