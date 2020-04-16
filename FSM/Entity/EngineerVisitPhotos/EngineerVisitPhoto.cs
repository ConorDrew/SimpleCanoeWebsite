// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitPhotos.EngineerVisitPhoto
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitPhotos
{
  public class EngineerVisitPhoto
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitPhotoID;
    private int _EngineerVisitID;
    private byte[] _Photo;
    private string _Caption;

    public EngineerVisitPhoto()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitPhotoID = 0;
      this._EngineerVisitID = 0;
      this._Photo = (byte[]) null;
      this._Caption = string.Empty;
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

    public int EngineerVisitPhotoID
    {
      get
      {
        return this._EngineerVisitPhotoID;
      }
    }

    public object SetEngineerVisitPhotoID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitPhotoID", RuntimeHelpers.GetObjectValue(value));
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

    public byte[] Photo
    {
      get
      {
        return this._Photo;
      }
    }

    public object SetPhoto
    {
      set
      {
        this._Photo = (byte[]) value;
      }
    }

    public string Caption
    {
      get
      {
        return this._Caption;
      }
    }

    public object SetCaption
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Caption", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
