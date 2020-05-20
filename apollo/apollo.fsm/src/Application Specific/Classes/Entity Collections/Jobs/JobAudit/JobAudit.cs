using System.Collections;

namespace FSM.Entity
{
    namespace JobAudits
    {
        public class JobAudit
        {
            private DataTypeValidator _dataTypeValidator;

            public JobAudit()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

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

            private int _jobAuditID = 0;

            public object SetJobAuditID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobAuditID", value);
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

            private string _actionChange = "";

            public string ActionChange
            {
                get
                {
                    return _actionChange;
                }
            }

            public object SetActionChange
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_actionChange", value);
                }
            }
        }
    }
}