// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Users.User
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Users
{
  public class User
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _UserID;
    private string _Fullname;
    private string _Username;
    private string _Password;
    private bool _Enabled;
    private bool _Admin;
    private string _EmailAddress;
    private bool _SchedulerDayView;
    private int _DefaultEngineerGroup;
    private int _ManagerUserID;
    private int _SchedulerTextSize;
    private DateTime _expiryDate;
    private bool _UpdateAtLogon;
    private DataView _securityUserModules;
    private DataView _userRegions;

    public User()
    {
      this._exists = false;
      this._deleted = false;
      this._UserID = 0;
      this._Fullname = string.Empty;
      this._Username = string.Empty;
      this._Password = string.Empty;
      this._Enabled = false;
      this._Admin = false;
      this._EmailAddress = string.Empty;
      this._SchedulerDayView = false;
      this._DefaultEngineerGroup = 0;
      this._ManagerUserID = 0;
      this._SchedulerTextSize = 0;
      this._expiryDate = DateTime.MinValue;
      this._UpdateAtLogon = false;
      this._securityUserModules = (DataView) null;
      this._userRegions = (DataView) null;
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

    public string Fullname
    {
      get
      {
        return this._Fullname;
      }
    }

    public object SetFullname
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Fullname", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Username
    {
      get
      {
        return this._Username;
      }
    }

    public object SetUsername
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Username", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Password
    {
      get
      {
        return this._Password;
      }
    }

    public object SetPassword
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Password", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Enabled
    {
      get
      {
        return this._Enabled;
      }
    }

    public bool SetEnabled
    {
      set
      {
        this._Enabled = value;
      }
    }

    public bool Admin
    {
      get
      {
        return this._Admin;
      }
    }

    public bool SetAdmin
    {
      set
      {
        this._Admin = value;
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

    public bool SchedulerDayView
    {
      get
      {
        return this._SchedulerDayView;
      }
    }

    public bool SetSchedulerDayView
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SchedulerDayView", (object) value);
      }
    }

    public int DefaultEngineerGroup
    {
      get
      {
        return this._DefaultEngineerGroup;
      }
    }

    public object SetDefaultEngineerGroup
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DefaultEngineerGroup", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ManagerUserID
    {
      get
      {
        return this._ManagerUserID;
      }
    }

    public object SetManagerUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ManagerUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SchedulerTextSize
    {
      get
      {
        return this._SchedulerTextSize;
      }
    }

    public object SetSchedulerTextSize
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SchedulerTextSize", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime PasswordExpiryDate
    {
      get
      {
        return this._expiryDate;
      }
      set
      {
        this._expiryDate = value;
      }
    }

    public bool UpdateAtLogon
    {
      get
      {
        return this._UpdateAtLogon;
      }
    }

    public bool SetUpdateAtLogon
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_UpdateAtLogon", (object) value);
      }
    }

    public DataView SecurityUserModules
    {
      get
      {
        if (this._securityUserModules == null)
        {
          this._securityUserModules = App.DB.User.GetSecurityUserModulesDefaults();
          this._securityUserModules.AllowEdit = true;
          this._securityUserModules.AllowNew = false;
          this._securityUserModules.AllowDelete = false;
        }
        if (this._securityUserModules != null && this._securityUserModules.Table.Rows.Count == 0)
        {
          this._securityUserModules = App.DB.User.GetSecurityUserModulesDefaults();
          this._securityUserModules.AllowEdit = true;
          this._securityUserModules.AllowNew = false;
          this._securityUserModules.AllowDelete = false;
        }
        return this._securityUserModules;
      }
      set
      {
        this._securityUserModules = value;
        if (this._securityUserModules == null)
          return;
        this._securityUserModules.AllowEdit = true;
        this._securityUserModules.AllowNew = false;
        this._securityUserModules.AllowDelete = false;
      }
    }

    public DataView UserRegions
    {
      get
      {
        return this._userRegions;
      }
      set
      {
        this._userRegions = value;
        if (this._userRegions == null)
          return;
        this._userRegions.Table.TableName = Enums.TableNames.tblRegion.ToString();
        this._userRegions.AllowNew = false;
        this._userRegions.AllowEdit = false;
        this._userRegions.AllowDelete = false;
      }
    }

    public bool HasAccessToModule(Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.FSMAdmin)
    {
      bool flag = false;
      if (ssm == Enums.SecuritySystemModules.None)
        flag = true;
      else if (this.SecurityUserModules.Table.Select(string.Format("SystemModuleID IN ({0}, {1}) and AccessPermitted = 1", (object) (int) ssm, (object) 23)).Length >= 1)
        flag = true;
      return flag;
    }

    public bool HasAccessToMulitpleModules(List<Enums.SecuritySystemModules> ssm)
    {
      bool flag = false;
      if (!ssm.Contains(Enums.SecuritySystemModules.FSMAdmin))
        ssm.Add(Enums.SecuritySystemModules.FSMAdmin);
      if (ssm.Contains(Enums.SecuritySystemModules.None))
      {
        flag = true;
      }
      else
      {
        EnumerableRowCollection<DataRow> source = this.SecurityUserModules.Table.AsEnumerable().Where<DataRow>((Func<DataRow, bool>) (row => ssm.Contains((Enums.SecuritySystemModules) row.Field<int>("SystemModuleID")) & row.Field<bool>("AccessPermitted")));
        Func<DataRow, DataRow> selector;
        // ISSUE: reference to a compiler-generated field
        if (User._Closure\u0024__.\u0024I91\u002D1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = User._Closure\u0024__.\u0024I91\u002D1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          User._Closure\u0024__.\u0024I91\u002D1 = selector = (Func<DataRow, DataRow>) (row => row);
        }
        if (source.Select<DataRow, DataRow>(selector).AsDataView<DataRow>().Count >= 1)
          flag = true;
      }
      return flag;
    }
  }
}
