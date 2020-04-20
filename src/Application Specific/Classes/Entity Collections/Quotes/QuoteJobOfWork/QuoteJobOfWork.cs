using System.Collections;

namespace FSM.Entity
{
    namespace QuoteJobOfWorks
    {
        public class QuoteJobOfWork
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteJobOfWork()
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

            private int _QuoteJobID = 0;

            public int QuoteJobID
            {
                get
                {
                    return _QuoteJobID;
                }
            }

            public object SetQuoteJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobID", value);
                }
            }




            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private ArrayList _QuotejobItems = new ArrayList();

            public ArrayList QuoteJobItems
            {
                get
                {
                    return _QuotejobItems;
                }

                set
                {
                    _QuotejobItems = value;
                }
            }

            private ArrayList _QuoteengineerVisits = new ArrayList();

            public ArrayList QuoteEngineerVisits
            {
                get
                {
                    return _QuoteengineerVisits;
                }

                set
                {
                    _QuoteengineerVisits = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}