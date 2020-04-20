using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Users
    {
        public class User
        {
            private DataTypeValidator _dataTypeValidator;

            public User()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _UserID = 0;

            public int UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserID", value);
                }
            }

            private string _Fullname = string.Empty;

            public string Fullname
            {
                get
                {
                    return _Fullname;
                }
            }

            public object SetFullname
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Fullname", value);
                }
            }

            private string _Username = string.Empty;

            public string Username
            {
                get
                {
                    return _Username;
                }
            }

            public object SetUsername
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Username", value);
                }
            }

            private string _Password = string.Empty;

            public string Password
            {
                get
                {
                    return _Password;
                }
            }

            public object SetPassword
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Password", value);
                }
            }

            private bool _Enabled = false;

            public bool Enabled
            {
                get
                {
                    return _Enabled;
                }
            }

            public bool SetEnabled
            {
                set
                {
                    _Enabled = value;
                }
            }

            private bool _Admin = false;

            public bool Admin
            {
                get
                {
                    return _Admin;
                }
            }

            public bool SetAdmin
            {
                set
                {
                    _Admin = value;
                }
            }

            private string _EmailAddress = string.Empty;

            public string EmailAddress
            {
                get
                {
                    return _EmailAddress;
                }
            }

            public object SetEmailAddress
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EmailAddress", value);
                }
            }

            private bool _SchedulerDayView = false;

            public bool SchedulerDayView
            {
                get
                {
                    return _SchedulerDayView;
                }
            }

            public bool SetSchedulerDayView
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SchedulerDayView", value);
                }
            }

            private int _DefaultEngineerGroup = Conversions.ToInteger(false);

            public int DefaultEngineerGroup
            {
                get
                {
                    return _DefaultEngineerGroup;
                }
            }

            public object SetDefaultEngineerGroup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DefaultEngineerGroup", value);
                }
            }

            private int _ManagerUserID = 0;

            public int ManagerUserID
            {
                get
                {
                    return _ManagerUserID;
                }
            }

            public object SetManagerUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ManagerUserID", value);
                }
            }

            private int _SchedulerTextSize = 0;

            public int SchedulerTextSize
            {
                get
                {
                    return _SchedulerTextSize;
                }
            }

            public object SetSchedulerTextSize
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SchedulerTextSize", value);
                }
            }

            private DateTime _expiryDate = default;

            public DateTime PasswordExpiryDate
            {
                get
                {
                    return _expiryDate;
                }

                set
                {
                    _expiryDate = value;
                }
            }

            private bool _UpdateAtLogon = false;

            public bool UpdateAtLogon
            {
                get
                {
                    return _UpdateAtLogon;
                }
            }

            public bool SetUpdateAtLogon
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UpdateAtLogon", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private DataView _securityUserModules = null;

            public DataView SecurityUserModules
            {
                get
                {
                    if (_securityUserModules is null)
                    {
                        // return a valid table structure
                        _securityUserModules = App.DB.User.GetSecurityUserModulesDefaults();
                        _securityUserModules.AllowEdit = true;
                        _securityUserModules.AllowNew = false;
                        _securityUserModules.AllowDelete = false;
                    }

                    if (_securityUserModules is object)
                    {
                        if (_securityUserModules.Table.Rows.Count == 0)
                        {
                            _securityUserModules = App.DB.User.GetSecurityUserModulesDefaults();
                            _securityUserModules.AllowEdit = true;
                            _securityUserModules.AllowNew = false;
                            _securityUserModules.AllowDelete = false;
                        }
                    }

                    return _securityUserModules;
                }

                set
                {
                    _securityUserModules = value;
                    if (_securityUserModules is object)
                    {
                        _securityUserModules.AllowEdit = true;
                        _securityUserModules.AllowNew = false;
                        _securityUserModules.AllowDelete = false;
                    }
                }
            }

            private DataView _userRegions = null;

            public DataView UserRegions
            {
                get
                {
                    return _userRegions;
                }

                set
                {
                    _userRegions = value;
                    if (_userRegions is object)
                    {
                        _userRegions.Table.TableName = Sys.Enums.TableNames.tblRegion.ToString();
                        _userRegions.AllowNew = false;
                        _userRegions.AllowEdit = false;
                        _userRegions.AllowDelete = false;
                    }
                }
            }

            public bool HasAccessToModule(Sys.Enums.SecuritySystemModules ssm = Sys.Enums.SecuritySystemModules.FSMAdmin)
            {
                bool access = false;
                if (ssm == Sys.Enums.SecuritySystemModules.None)
                {
                    access = true;
                }
                else
                {
                    string selectStatement = string.Format("SystemModuleID IN ({0}, {1}) and AccessPermitted = 1", Conversions.ToInteger(ssm), Conversions.ToInteger(Sys.Enums.SecuritySystemModules.FSMAdmin));
                    var rows = SecurityUserModules.Table.Select(selectStatement);
                    if (rows.Length >= 1)
                    {
                        access = true;
                    }
                }

                return access;
            }

            public bool HasAccessToMulitpleModules(List<Sys.Enums.SecuritySystemModules> ssm)
            {
                bool access = false;
                if (!ssm.Contains(Sys.Enums.SecuritySystemModules.FSMAdmin))
                    ssm.Add(Sys.Enums.SecuritySystemModules.FSMAdmin);
                if (ssm.Contains(Sys.Enums.SecuritySystemModules.None))
                {
                    access = true;
                }
                else
                {
                    var dvSSM = (from row in SecurityUserModules.Table.AsEnumerable()
                                 where ssm.Contains((Sys.Enums.SecuritySystemModules)row.Field<int>("SystemModuleID")) & row.Field<bool>("AccessPermitted") == true
                                 select row).AsDataView();
                    if (dvSSM.Count >= 1)
                    {
                        access = true;
                    }
                }

                return access;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}