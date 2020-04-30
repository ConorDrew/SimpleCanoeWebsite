using System.Collections;

namespace FSM.Entity
{
    namespace ProductSuppliers
    {
        public class ProductSupplier
        {
            private DataTypeValidator _dataTypeValidator;

            public ProductSupplier()
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

            
            

            private int _ProductSupplierID = 0;

            public int ProductSupplierID
            {
                get
                {
                    return _ProductSupplierID;
                }
            }

            public object SetProductSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductSupplierID", value);
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

            private string _ProductCode = string.Empty;

            public string ProductCode
            {
                get
                {
                    return _ProductCode;
                }
            }

            public object SetProductCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductCode", value);
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


            
        }
    }
}