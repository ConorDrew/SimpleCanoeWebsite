using System.Collections;

namespace FSM.Entity
{
    namespace PartSuppliers
    {
        public class PartSupplier
        {
            private DataTypeValidator _dataTypeValidator;

            public PartSupplier()
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

            private int _PartSupplierID = 0;

            public int PartSupplierID
            {
                get
                {
                    return _PartSupplierID;
                }
            }

            public object SetPartSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartSupplierID", value);
                }
            }

            private string _PartCode = string.Empty;

            public string PartCode
            {
                get
                {
                    return _PartCode;
                }
            }

            public object SetPartCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartCode", value);
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

            private int _SupplierID = 0;

            public int SupplierID
            {
                get
                {
                    return _SupplierID;
                }
            }

            public object SetSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SupplierID", value);
                }
            }

            private double _Price = 0;

            public double Price
            {
                get
                {
                    return _Price;
                }
            }

            public object SetPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Price", value);
                }
            }

            private double _SecondaryPrice = 0;

            public double SecondaryPrice
            {
                get
                {
                    return _SecondaryPrice;
                }
            }

            public object SetSecondaryPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SecondaryPrice", value);
                }
            }

            private double _QuantityInPack = 0;

            public double QuantityInPack
            {
                get
                {
                    return _QuantityInPack;
                }
            }

            public object SetQuantityInPack
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuantityInPack", value);
                }
            }

            private bool _preferred = false;

            public bool Preferred
            {
                get
                {
                    return _preferred;
                }
            }

            public bool SetPreferred
            {
                set
                {
                    _preferred = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}