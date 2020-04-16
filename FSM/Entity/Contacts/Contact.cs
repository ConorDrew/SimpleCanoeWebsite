// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Contacts.Contact
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Contacts
{
  public class Contact
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ContactID;
    private string _Salutation;
    private string _FirstName;
    private string _Surname;
    private string _TelephoneNum;
    private string _MobileNo;
    private string _EmailAddress;
    private string _FaxNum;
    private int _PropertyID;
    private int _LinkID;
    private int _LinkRef;
    private bool _NoMarketing;
    private string _PortalUserName;
    private string _PortalPassword;
    private bool _PortalGSRPrint;
    private int _EID;
    private bool _onContract;
    private bool _pointOfContact;
    private int _relationshipID;
    private string _relationship;
    private string _Address1;
    private string _Address2;
    private string _Address3;
    private string _Postcode;

    public Contact()
    {
      this._exists = false;
      this._deleted = false;
      this._ContactID = 0;
      this._Salutation = string.Empty;
      this._FirstName = string.Empty;
      this._Surname = string.Empty;
      this._TelephoneNum = string.Empty;
      this._MobileNo = string.Empty;
      this._EmailAddress = string.Empty;
      this._FaxNum = string.Empty;
      this._PropertyID = 0;
      this._LinkID = 0;
      this._LinkRef = 0;
      this._NoMarketing = false;
      this._PortalUserName = string.Empty;
      this._PortalPassword = string.Empty;
      this._PortalGSRPrint = false;
      this._EID = 0;
      this._onContract = false;
      this._pointOfContact = false;
      this._Address1 = string.Empty;
      this._Address2 = string.Empty;
      this._Address3 = string.Empty;
      this._Postcode = string.Empty;
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

    public int ContactID
    {
      get
      {
        return this._ContactID;
      }
    }

    public object SetContactID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContactID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Salutation
    {
      get
      {
        return this._Salutation;
      }
    }

    public object SetSalutation
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Salutation", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string FirstName
    {
      get
      {
        return this._FirstName;
      }
    }

    public object SetFirstName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FirstName", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Surname
    {
      get
      {
        return this._Surname;
      }
    }

    public object SetSurname
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Surname", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string TelephoneNum
    {
      get
      {
        return this._TelephoneNum;
      }
    }

    public object SetTelephoneNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string MobileNo
    {
      get
      {
        return this._MobileNo;
      }
    }

    public object SetMobileNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MobileNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string EmailAddress
    {
      get
      {
        return this._EmailAddress;
      }
    }

    public object SetEmailAddress
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EmailAddress", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string FaxNum
    {
      get
      {
        return this._FaxNum;
      }
    }

    public object SetFaxNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FaxNum", RuntimeHelpers.GetObjectValue(value));
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

    public int LinkID
    {
      get
      {
        return this._LinkID;
      }
    }

    public object SetLinkID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LinkID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int LinkRef
    {
      get
      {
        return this._LinkRef;
      }
    }

    public object SetLinkRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LinkRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool NoMarketing
    {
      get
      {
        return this._NoMarketing;
      }
    }

    public bool SetNoMarketing
    {
      set
      {
        this._NoMarketing = value;
      }
    }

    public string PortalUserName
    {
      get
      {
        return this._PortalUserName;
      }
    }

    public object SetPortalUserName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PortalUserName", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string PortalPassword
    {
      get
      {
        return this._PortalPassword;
      }
    }

    public object SetPortalPassword
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PortalPassword", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool PortalGSRPrint
    {
      get
      {
        return this._PortalGSRPrint;
      }
    }

    public object SetPortalGSRPrint
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PortalGSRPrint", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EID
    {
      get
      {
        return this._EID;
      }
    }

    public object SetEID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool OnContract
    {
      get
      {
        return this._onContract;
      }
    }

    public bool SetOnContract
    {
      set
      {
        this._onContract = value;
      }
    }

    public bool PointOfContact
    {
      get
      {
        return this._pointOfContact;
      }
    }

    public bool SetPointOfContact
    {
      set
      {
        this._pointOfContact = value;
      }
    }

    public int RelationshipID
    {
      get
      {
        return this._relationshipID;
      }
    }

    public int SetRelationshipID
    {
      set
      {
        this._relationshipID = value;
      }
    }

    public int Relationship
    {
      get
      {
        return Conversions.ToInteger(this._relationship);
      }
    }

    public int SetRelationship
    {
      set
      {
        this._relationship = Conversions.ToString(value);
      }
    }

    public string Address1
    {
      get
      {
        return this._Address1;
      }
    }

    public object SetAddress1
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address1", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address2
    {
      get
      {
        return this._Address2;
      }
    }

    public object SetAddress2
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address2", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address3
    {
      get
      {
        return this._Address3;
      }
    }

    public object SetAddress3
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address3", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Postcode
    {
      get
      {
        return this._Postcode;
      }
    }

    public object SetPostcode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Postcode", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
