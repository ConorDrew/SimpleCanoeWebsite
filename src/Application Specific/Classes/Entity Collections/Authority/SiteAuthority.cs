using System.Collections;

namespace FSM.Entity
{
    namespace Authority
    {
        public class SiteAuthority
        {
            private DataTypeValidator _dataTypeValidator;

            public SiteAuthority()
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
            private int _siteAuthorityID = 0;

            public int SiteAuthorityID
            {
                get
                {
                    return _siteAuthorityID;
                }
            }

            public object SetSiteAuthorityID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_siteAuthorityID", value);
                }
            }

            private int _siteId = 0;

            public int SiteID
            {
                get
                {
                    return _siteId;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_siteId", value);
                }
            }

            private int _authorityID = 0;

            public int AuthorityID
            {
                get
                {
                    return _authorityID;
                }
            }

            public object SetAuthorityID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_authorityID", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}