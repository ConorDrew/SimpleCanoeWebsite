using System;
using System.Collections;

namespace FSM.Entity.EngineerAbsence
{
    public class EngineerAbsence
    {
        private DataTypeValidator _dataTypeValidator;

        public EngineerAbsence()
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
        private int _EngineerAbsenceID = 0;

        public int EngineerAbsenceID
        {
            get
            {
                return _EngineerAbsenceID;
            }
        }

        public object SetEngineerAbsenceID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_EngineerAbsenceID", value);
            }
        }

        private string _EngineerID = string.Empty;

        public string EngineerID
        {
            get
            {
                return _EngineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_EngineerID", value);
            }
        }

        private int _AbsenceTypeID = 0;

        public int AbsenceTypeID
        {
            get
            {
                return _AbsenceTypeID;
            }
        }

        public object SetAbsenceTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AbsenceTypeID", value);
            }
        }

        private DateTime _DateFrom = default;

        public DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }

            set
            {
                _DateFrom = value;
            }
        }

        private DateTime _DateTo = default;

        public DateTime DateTo
        {
            get
            {
                return _DateTo;
            }

            set
            {
                _DateTo = value;
            }
        }

        private int _MorningSlots = 0;

        public int MorningSlots
        {
            get
            {
                return _MorningSlots;
            }
        }

        public object SetMorningSlots
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_MorningSlots", value);
            }
        }

        private int _AfternoonSlots = 0;

        public int AfternoonSlots
        {
            get
            {
                return _AfternoonSlots;
            }
        }

        public object SetAfternoonSlots
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AfternoonSlots", value);
            }
        }

        private string _Comments = string.Empty;

        public string Comments
        {
            get
            {
                return _Comments;
            }
        }

        public object SetComments
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Comments", value);
            }
        }




        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}