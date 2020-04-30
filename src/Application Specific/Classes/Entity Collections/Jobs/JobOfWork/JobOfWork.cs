using System;
using System.Collections;

namespace FSM.Entity
{
    namespace JobOfWorks
    {
        public class JobOfWork
        {
            private DataTypeValidator _dataTypeValidator;

            public JobOfWork()
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

            
            
            private int _JobOfWorkID = 0;

            public int JobOfWorkID
            {
                get
                {
                    return _JobOfWorkID;
                }
            }

            public object SetJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobOfWorkID", value);
                }
            }

            private int _JobID = 0;

            public int JobID
            {
                get
                {
                    return _JobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobID", value);
                }
            }

            private string _PONumber;

            public string PONumber
            {
                get
                {
                    return _PONumber;
                }
            }

            public object SetPONumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PONumber", value);
                }
            }

            private int _Priority = 0;

            public int Priority
            {
                get
                {
                    return _Priority;
                }
            }

            public object SetPriority
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Priority", value);
                }
            }

            private int _Status = 1; // Open

            public int Status
            {
                get
                {
                    return _Status;
                }
            }

            public object SetStatus
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Status", value);
                }
            }

            private DateTime _PriorityDateSet = default;

            public DateTime PriorityDateSet
            {
                get
                {
                    return _PriorityDateSet;
                }

                set
                {
                    _PriorityDateSet = value;
                }
            }

            private int _qualificationId = 0;

            public int QualificationID
            {
                get
                {
                    return _qualificationId;
                }
            }

            public object SetQualificationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_qualificationId", value);
                }
            }

            
            
            private ArrayList _jobItems = new ArrayList();

            public ArrayList JobItems
            {
                get
                {
                    return _jobItems;
                }

                set
                {
                    _jobItems = value;
                }
            }

            private ArrayList _engineerVisits = new ArrayList();

            public ArrayList EngineerVisits
            {
                get
                {
                    return _engineerVisits;
                }

                set
                {
                    _engineerVisits = value;
                }
            }

            
        }
    }
}