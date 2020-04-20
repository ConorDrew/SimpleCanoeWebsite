using System;
using System.Collections;

namespace FSM.Entity
{
    namespace JobContacts
    {
        public class JobContact
        {
            private DataTypeValidator _dataTypeValidator;

            public JobContact()
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _jobContactID = 0;

            public int jobContactID
            {
                get
                {
                    return _jobContactID;
                }
            }

            public object SetjobContactID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobContactID", value);
                }
            }

            private int _jobID = 0;

            public int JobID
            {
                get
                {
                    return _jobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobID", value);
                }
            }

            private string _contactType = "";

            public string contactType
            {
                get
                {
                    return _contactType;
                }
            }

            public object SetcontactType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_contactType", value);
                }
            }

            private DateTime _dateActioned = DateTime.MinValue;

            public DateTime dateActioned
            {
                get
                {
                    return _dateActioned;
                }

                set
                {
                    _dateActioned = value;
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}