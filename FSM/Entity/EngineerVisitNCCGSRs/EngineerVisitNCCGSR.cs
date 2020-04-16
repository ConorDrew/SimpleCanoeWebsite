// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitNCCGSRs
{
  public class EngineerVisitNCCGSR
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitNCCGSRID;
    private int _EngineerVisitID;
    private int _CorrectMaterialsUsedID;
    private int _InstallationPipeWorkCorrectID;
    private int _InstallationSafeToUseID;
    private int _StrainerFittedID;
    private int _StrainerInspectedID;
    private int _HeatingSystemTypeID;
    private int _PartialHeatingID;
    private int _CylinderTypeID;
    private int _JacketID;
    private int _ImmersionID;
    private int _Radiators;
    private int _CODetectorFittedID;
    private int _ApproxAgeOfBoiler;
    private int _CertificateTypeID;
    private int _VisualInspectionSatisfactoryID;
    private int _SITimerID;
    private int _FillDiscID;
    private string _VisualInspectionReason;

    public EngineerVisitNCCGSR()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitNCCGSRID = 0;
      this._EngineerVisitID = 0;
      this._CorrectMaterialsUsedID = 0;
      this._InstallationPipeWorkCorrectID = 0;
      this._InstallationSafeToUseID = 0;
      this._StrainerFittedID = 0;
      this._StrainerInspectedID = 0;
      this._HeatingSystemTypeID = 0;
      this._PartialHeatingID = 0;
      this._CylinderTypeID = 0;
      this._JacketID = 0;
      this._ImmersionID = 0;
      this._Radiators = 0;
      this._CODetectorFittedID = 0;
      this._ApproxAgeOfBoiler = 0;
      this._CertificateTypeID = 0;
      this._VisualInspectionSatisfactoryID = 0;
      this._SITimerID = 0;
      this._FillDiscID = 0;
      this._VisualInspectionReason = string.Empty;
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

    public int EngineerVisitNCCGSRID
    {
      get
      {
        return this._EngineerVisitNCCGSRID;
      }
    }

    public object SetEngineerVisitNCCGSRID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitNCCGSRID", RuntimeHelpers.GetObjectValue(value));
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

    public int CorrectMaterialsUsedID
    {
      get
      {
        return this._CorrectMaterialsUsedID;
      }
    }

    public object SetCorrectMaterialsUsedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CorrectMaterialsUsedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int InstallationPipeWorkCorrectID
    {
      get
      {
        return this._InstallationPipeWorkCorrectID;
      }
    }

    public object SetInstallationPipeWorkCorrectID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InstallationPipeWorkCorrectID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int InstallationSafeToUseID
    {
      get
      {
        return this._InstallationSafeToUseID;
      }
    }

    public object SetInstallationSafeToUseID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InstallationSafeToUseID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int StrainerFittedID
    {
      get
      {
        return this._StrainerFittedID;
      }
    }

    public object SetStrainerFittedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_StrainerFittedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int StrainerInspectedID
    {
      get
      {
        return this._StrainerInspectedID;
      }
    }

    public object SetStrainerInspectedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_StrainerInspectedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int HeatingSystemTypeID
    {
      get
      {
        return this._HeatingSystemTypeID;
      }
    }

    public object SetHeatingSystemTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_HeatingSystemTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PartialHeatingID
    {
      get
      {
        return this._PartialHeatingID;
      }
    }

    public object SetPartialHeatingID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartialHeatingID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CylinderTypeID
    {
      get
      {
        return this._CylinderTypeID;
      }
    }

    public object SetCylinderTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CylinderTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JacketID
    {
      get
      {
        return this._JacketID;
      }
    }

    public object SetJacketID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JacketID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ImmersionID
    {
      get
      {
        return this._ImmersionID;
      }
    }

    public object SetImmersionID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ImmersionID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Radiators
    {
      get
      {
        return this._Radiators;
      }
    }

    public object SetRadiators
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Radiators", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CODetectorFittedID
    {
      get
      {
        return this._CODetectorFittedID;
      }
    }

    public object SetCODetectorFittedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CODetectorFittedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ApproxAgeOfBoiler
    {
      get
      {
        return this._ApproxAgeOfBoiler;
      }
    }

    public object SetApproxAgeOfBoiler
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ApproxAgeOfBoiler", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CertificateTypeID
    {
      get
      {
        return this._CertificateTypeID;
      }
    }

    public object SetCertificateTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CertificateTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VisualInspectionSatisfactoryID
    {
      get
      {
        return this._VisualInspectionSatisfactoryID;
      }
    }

    public object SetVisualInspectionSatisfactoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VisualInspectionSatisfactoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SITimerID
    {
      get
      {
        return this._SITimerID;
      }
    }

    public object SetSITimerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SITimerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int FillDiscID
    {
      get
      {
        return this._FillDiscID;
      }
    }

    public object SetFillDiscID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FillDiscID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string VisualInspectionReason
    {
      get
      {
        return this._VisualInspectionReason;
      }
    }

    public object SetVisualInspectionReason
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VisualInspectionReason", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
