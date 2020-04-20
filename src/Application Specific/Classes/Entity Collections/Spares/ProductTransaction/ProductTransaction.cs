using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ProductTransactions
    {
        public class ProductTransaction
        {
            private DataTypeValidator _dataTypeValidator;

            public ProductTransaction()
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

            private int _ProductTransactionID = 0;

            public int ProductTransactionID
            {
                get
                {
                    return _ProductTransactionID;
                }
            }

            public object SetProductTransactionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductTransactionID", value);
                }
            }

            private int _ProductID = 0;

            public int ProductID
            {
                get
                {
                    return _ProductID;
                }
            }

            public object SetProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductID", value);
                }
            }

            private int _Amount = 0;

            public int Amount
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

            private DateTime _TransactionDate = default;

            public DateTime TransactionDate
            {
                get
                {
                    return _TransactionDate;
                }

                set
                {
                    _TransactionDate = value;
                }
            }

            private int _UserID = 0;

            public int UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserID", value);
                }
            }

            private int _TransactionTypeID = 0;

            public int TransactionTypeID
            {
                get
                {
                    return _TransactionTypeID;
                }
            }

            public object SetTransactionTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TransactionTypeID", value);
                }
            }

            private int _LocationID = 0;

            public int LocationID
            {
                get
                {
                    return _LocationID;
                }
            }

            public object SetLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LocationID", value);
                }
            }

            private int _OrderProductID = 0;

            public int OrderProductID
            {
                get
                {
                    return _OrderProductID;
                }
            }

            public object SetOrderProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderProductID", value);
                }
            }

            private int _OrderLocationProductID = 0;

            public int OrderLocationProductID
            {
                get
                {
                    return _OrderLocationProductID;
                }
            }

            public object SetOrderLocationProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderLocationProductID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}