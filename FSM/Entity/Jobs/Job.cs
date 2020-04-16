// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Jobs.Job
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Jobs
{
  public class Job
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _JobID;
    private int _PropertyID;
    private int _JobDefinitionEnumID;
    private int _JobTypeID;
    private int _StatusEnumID;
    private DateTime _DateCreated;
    private int _CreatedByUserID;
    private string _JobNumber;
    private string _PONumber;
    private int _QuoteID;
    private int _ContractID;
    private bool _ToBePartPaid;
    private double _retention;
    private bool _CollectPayment;
    private bool _POC;
    private bool _OTI;
    private bool _fOC;
    private int _salesRepUserID;
    private int _jobCreationType;
    private string _Headline;
    private ArrayList _assets;
    private ArrayList _jobOfWorks;
    private DataView _JobQualificationsLevels;
    private DataView _JobSheets;

    public Job()
    {
      this._exists = false;
      this._deleted = false;
      this._JobID = 0;
      this._PropertyID = 0;
      this._JobDefinitionEnumID = 0;
      this._JobTypeID = 0;
      this._StatusEnumID = 0;
      this._DateCreated = DateTime.MinValue;
      this._CreatedByUserID = 0;
      this._JobNumber = string.Empty;
      this._PONumber = string.Empty;
      this._QuoteID = 0;
      this._ContractID = 0;
      this._ToBePartPaid = false;
      this._retention = 0.0;
      this._CollectPayment = false;
      this._POC = false;
      this._OTI = false;
      this._fOC = false;
      this._salesRepUserID = 0;
      this._jobCreationType = 0;
      this._Headline = string.Empty;
      this._assets = new ArrayList();
      this._jobOfWorks = new ArrayList();
      this._JobQualificationsLevels = new DataView();
      this._JobSheets = new DataView();
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

    public int JobID
    {
      get
      {
        return this._JobID;
      }
    }

    public object SetJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PropertyID
    {
      get
      {
        return this._PropertyID;
      }
    }

    public object SetPropertyID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PropertyID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobDefinitionEnumID
    {
      get
      {
        return this._JobDefinitionEnumID;
      }
    }

    public object SetJobDefinitionEnumID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobDefinitionEnumID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobTypeID
    {
      get
      {
        return this._JobTypeID;
      }
    }

    public object SetJobTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobTypeID", RuntimeHelpers.GetObjectValue(value));
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

    public DateTime DateCreated
    {
      get
      {
        return this._DateCreated;
      }
      set
      {
        this._DateCreated = value;
      }
    }

    public int CreatedByUserID
    {
      get
      {
        return this._CreatedByUserID;
      }
    }

    public object SetCreatedByUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CreatedByUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string JobNumber
    {
      get
      {
        return this._JobNumber;
      }
    }

    public object SetJobNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string PONumber
    {
      get
      {
        return this._PONumber;
      }
    }

    public object SetPONumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PONumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteID
    {
      get
      {
        return this._QuoteID;
      }
    }

    public object SetQuoteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ContractID
    {
      get
      {
        return this._ContractID;
      }
    }

    public object SetContractID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool ToBePartPaid
    {
      get
      {
        return this._ToBePartPaid;
      }
    }

    public object SetToBePartPaid
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ToBePartPaid", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double Retention
    {
      get
      {
        return this._retention;
      }
    }

    public object SetRetention
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_retention", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool CollectPayment
    {
      get
      {
        return this._CollectPayment;
      }
    }

    public object SetCollectPayment
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CollectPayment", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool POC
    {
      get
      {
        return this._POC;
      }
    }

    public object SetPOC
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_POC", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool OTI
    {
      get
      {
        return this._OTI;
      }
    }

    public object SetOTI
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OTI", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool FOC
    {
      get
      {
        return this._fOC;
      }
    }

    public object SetFOC
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_fOC", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SalesRepUserID
    {
      get
      {
        return this._salesRepUserID;
      }
    }

    public object SetSalesRepUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_salesRepUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobCreationType
    {
      get
      {
        return this._jobCreationType;
      }
    }

    public object SetJobCreationType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobCreationType", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Headline
    {
      get
      {
        return this._Headline;
      }
    }

    public object SetHeadline
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Headline", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public ArrayList Assets
    {
      get
      {
        return this._assets;
      }
      set
      {
        this._assets = value;
      }
    }

    public ArrayList JobOfWorks
    {
      get
      {
        return this._jobOfWorks;
      }
      set
      {
        this._jobOfWorks = value;
      }
    }

    public DataView JobQualificationsLevels
    {
      get
      {
        return this._JobQualificationsLevels;
      }
      set
      {
        this._JobQualificationsLevels = value;
        this._JobQualificationsLevels.AllowEdit = true;
        this._JobQualificationsLevels.AllowNew = false;
        this._JobQualificationsLevels.AllowDelete = false;
      }
    }

    public DataView JobSheets
    {
      get
      {
        return this._JobSheets;
      }
      set
      {
        this._JobSheets = value;
        this._JobSheets.AllowEdit = true;
        this._JobSheets.AllowNew = false;
        this._JobSheets.AllowDelete = false;
      }
    }
  }
}
