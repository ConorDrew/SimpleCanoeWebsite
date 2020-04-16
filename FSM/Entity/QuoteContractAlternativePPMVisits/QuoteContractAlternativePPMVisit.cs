// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativePPMVisits.QuoteContractAlternativePPMVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativePPMVisits
{
  public class QuoteContractAlternativePPMVisit
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private int _QuoteContractPPMVisitID;
    private int _QuoteContractSiteJobOfWorkID;
    private DateTime _EstimatedVisitDate;

    public QuoteContractAlternativePPMVisit()
    {
      this._exists = false;
      this._QuoteContractPPMVisitID = 0;
      this._QuoteContractSiteJobOfWorkID = 0;
      this._EstimatedVisitDate = DateTime.MinValue;
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

    public int QuoteContractPPMVisitID
    {
      get
      {
        return this._QuoteContractPPMVisitID;
      }
    }

    public object SetQuoteContractPPMVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteContractPPMVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteContractSiteJobOfWorkID
    {
      get
      {
        return this._QuoteContractSiteJobOfWorkID;
      }
    }

    public object SetQuoteContractSiteJobOfWorkID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteContractSiteJobOfWorkID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime EstimatedVisitDate
    {
      get
      {
        return this._EstimatedVisitDate;
      }
      set
      {
        this._EstimatedVisitDate = value;
      }
    }
  }
}
