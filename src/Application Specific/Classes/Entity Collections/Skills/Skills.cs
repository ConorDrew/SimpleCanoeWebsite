using System.Collections;

namespace FSM.Entity.Skills
{
    public class Skill
    {
        private DataTypeValidator _dataTypeValidator;

        public Skill()
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

        
    }

    public class SkillType
    {
        private DataTypeValidator _dataTypeValidator;

        public SkillType()
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

        
        
        private int _skillTypeId = 0;

        public int SkillTypeID
        {
            get
            {
                return _skillTypeId;
            }
        }

        public object SetSkillTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_skillTypeId", value);
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
        
    }
}