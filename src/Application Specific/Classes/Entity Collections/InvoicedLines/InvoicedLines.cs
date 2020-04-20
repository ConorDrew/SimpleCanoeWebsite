using System.Collections;

namespace FSM.Entity
{
    namespace InvoicedLiness
    {
        public class InvoicedLines
        {
            private DataTypeValidator _dataTypeValidator;

            public InvoicedLines()
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

            private int _InvoicedLineID = 0;

            public int InvoicedLineID
            {
                get
                {
                    return _InvoicedLineID;
                }
            }

            public object SetInvoicedLineID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoicedLineID", value);
                }
            }

            private int _InvoicedID = 0;

            public int InvoicedID
            {
                get
                {
                    return _InvoicedID;
                }
            }

            public object SetInvoicedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoicedID", value);
                }
            }

            private int _InvoiceToBeRaisedID = 0;

            public int InvoiceToBeRaisedID
            {
                get
                {
                    return _InvoiceToBeRaisedID;
                }
            }

            public object SetInvoiceToBeRaisedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceToBeRaisedID", value);
                }
            }

            private double _Amount = 0;

            public double Amount
            {
                get
                {
                    return _Amount;
                }
            }

            public object SetAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Amount", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}