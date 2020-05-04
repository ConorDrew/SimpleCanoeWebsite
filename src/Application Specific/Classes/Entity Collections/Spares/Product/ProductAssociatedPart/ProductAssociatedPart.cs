﻿using System.Collections;

namespace FSM.Entity
{
    namespace ProductAssociatedParts
    {
        public class ProductAssociatedPart
        {
            private DataTypeValidator _dataTypeValidator;

            public ProductAssociatedPart()
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
        }
    }
}