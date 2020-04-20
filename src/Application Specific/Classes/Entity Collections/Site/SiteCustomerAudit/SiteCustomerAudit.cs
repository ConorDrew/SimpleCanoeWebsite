using System;
using System.Collections;

namespace FSM.Entity
{
    namespace SiteCustomerAudits
    {
        public class SiteCustomerAudit
        {
            private DataTypeValidator _dataTypeValidator;

            public SiteCustomerAudit()
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

            private int _SiteCustomerAuditID = 0;

            public int SiteCustomerAuditID
            {
                get
                {
                    return _SiteCustomerAuditID;
                }
            }

            public object SetSiteCustomerAuditID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteCustomerAuditID", value);
                }
            }

            private int _SiteID = 0;

            public int SiteID
            {
                get
                {
                    return _SiteID;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteID", value);
                }
            }

            private int _PreviousCustomerID = 0;

            public int PreviousCustomerID
            {
                get
                {
                    return _PreviousCustomerID;
                }
            }

            public object SetPreviousCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PreviousCustomerID", value);
                }
            }

            private DateTime _DateChanged = default;

            public DateTime DateChanged
            {
                get
                {
                    return _DateChanged;
                }

                set
                {
                    _DateChanged = value;
                }
            }

            private int _userID = 0;

            public int UserID
            {
                get
                {
                    return _userID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_userID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}