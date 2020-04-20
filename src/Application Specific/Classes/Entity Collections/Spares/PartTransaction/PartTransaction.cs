using System;
using System.Collections;

namespace FSM.Entity
{
    namespace PartTransactions
    {
        public class PartTransaction
        {
            private DataTypeValidator _dataTypeValidator;

            public PartTransaction()
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

            private int _PartTransactionID = 0;

            public int PartTransactionID
            {
                get
                {
                    return _PartTransactionID;
                }
            }

            public object SetPartTransactionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartTransactionID", value);
                }
            }

            private int _PartID = 0;

            public int PartID
            {
                get
                {
                    return _PartID;
                }
            }

            public object SetPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartID", value);
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

            private int _OrderPartID = 0;

            public int OrderPartID
            {
                get
                {
                    return _OrderPartID;
                }
            }

            public object SetOrderPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderPartID", value);
                }
            }

            private int _OrderLocationPartID = 0;

            public int OrderLocationPartID
            {
                get
                {
                    return _OrderLocationPartID;
                }
            }

            public object SetOrderLocationPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderLocationPartID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}