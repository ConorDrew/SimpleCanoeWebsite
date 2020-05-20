using System.Collections;

namespace FSM.Entity
{
    namespace QuoteEngineerVisits
    {
        public class QuoteEngineerVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteEngineerVisit()
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

            
            

            private int _QuoteEngineerVisitID = 0;

            public int QuoteEngineerVisitID
            {
                get
                {
                    return _QuoteEngineerVisitID;
                }
            }

            public object SetQuoteEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteEngineerVisitID", value);
                }
            }

            private int _QuoteJobOfWorkID = 0;

            public int QuoteJobOfWorkID
            {
                get
                {
                    return _QuoteJobOfWorkID;
                }
            }

            public object SetQuoteJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobOfWorkID", value);
                }
            }

            private int _StatusEnumID = 0;

            public int StatusEnumID
            {
                get
                {
                    return _StatusEnumID;
                }
            }

            public object SetStatusEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StatusEnumID", value);
                }
            }

            private string _NotesToEngineer = string.Empty;

            public string NotesToEngineer
            {
                get
                {
                    return _NotesToEngineer;
                }
            }

            public object SetNotesToEngineer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesToEngineer", value);
                }
            }



            
        }
    }
}