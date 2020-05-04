using System;
using System.Collections;

namespace FSM.Entity.JobImport
{
    public class JobImport
    {
        private DataTypeValidator _dataTypeValidator;

        public JobImport()
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

        private int _jobImportId = 0;

        public int JobImportID
        {
            get
            {
                return _jobImportId;
            }
        }

        public object SetJobImportID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobImportId", value);
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

        private string _uprn = string.Empty;

        public string UPRN
        {
            get
            {
                return _uprn;
            }
        }

        public object SetUPRN
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_uprn", value);
            }
        }

        private int _jobImportTypeId = 0;

        public int JobImportTypeID
        {
            get
            {
                return _jobImportTypeId;
            }
        }

        public object SetJobImportTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobImportTypeId", value);
            }
        }

        private DateTime _dateAdded = default;

        public DateTime DateAdded
        {
            get { return _dateAdded; }

            set { _dateAdded = value; }
        }

        private int _status = 0;

        public int Status
        {
            get
            {
                return _status;
            }
        }

        public object SetStatus
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_status", value);
            }
        }

        private DateTime _bookedVisit = default;

        public DateTime BookedVisit
        {
            get
            {
                return _bookedVisit;
            }

            set
            {
                _bookedVisit = value;
            }
        }

        private DateTime _letter1 = default;

        public DateTime Letter1
        {
            get
            {
                return _letter1;
            }

            set
            {
                _letter1 = value;
            }
        }

        private DateTime _letter2 = default;

        public DateTime Letter2
        {
            get
            {
                return _letter2;
            }

            set
            {
                _letter2 = value;
            }
        }

        private bool _report = false;

        public bool Report
        {
            get
            {
                return _report;
            }
        }

        public bool SetReport
        {
            set
            {
                _report = value;
            }
        }
    }

    public class JobImportType
    {
        private DataTypeValidator _dataTypeValidator;

        public JobImportType()
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

        private int _jobImportTypeId = 0;

        public int JobImportTypeID
        {
            get
            {
                return _jobImportTypeId;
            }
        }

        public object SetJobImportTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobImportTypeId", value);
            }
        }

        private string _name = string.Empty;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public object SetName
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_name", value);
            }
        }

        private int _jobTypeID = 0;

        public int JobTypeID
        {
            get
            {
                return _jobTypeID;
            }
        }

        public object SetJobTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobTypeID", value);
            }
        }

        private string _jobTypeName = string.Empty;

        public string JobTypeName
        {
            get
            {
                return _jobTypeName;
            }
        }

        public object SetJobTypeName
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobTypeName", value);
            }
        }

        private int _engineerQualID = 0;

        public int EngineerQualID
        {
            get
            {
                return _engineerQualID;
            }
        }

        public object SetEngineerQualID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_engineerQualID", value);
            }
        }

        private int _cycle = 0;

        public int Cycle
        {
            get
            {
                return _cycle;
            }
        }

        public object SetCycle
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_cycle", value);
            }
        }
    }
}