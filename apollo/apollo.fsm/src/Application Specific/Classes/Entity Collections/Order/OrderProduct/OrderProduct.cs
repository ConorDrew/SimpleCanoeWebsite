using System.Collections;

namespace FSM.Entity
{
    namespace OrderProducts
    {
        public class OrderProduct
        {
            private DataTypeValidator _dataTypeValidator;

            public OrderProduct()
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

            private int _Quantity = 0;

            public int Quantity
            {
                get
                {
                    return _Quantity;
                }
            }

            public object SetQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Quantity", value);
                }
            }

            private int _QuantityReceived = 0;

            public int QuantityReceived
            {
                get
                {
                    return _QuantityReceived;
                }
            }

            public object SetQuantityReceived
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuantityReceived", value);
                }
            }

            private double _BuyPrice = 0;

            public double BuyPrice
            {
                get
                {
                    return _BuyPrice;
                }
            }

            public object SetBuyPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuyPrice", value);
                }
            }

            private double _SellPrice = 0;

            public double SellPrice
            {
                get
                {
                    return _SellPrice;
                }
            }

            public object SetSellPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SellPrice", value);
                }
            }

            private int _OrderID = 0;

            public int OrderID
            {
                get
                {
                    return _OrderID;
                }
            }

            public object SetOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderID", value);
                }
            }

            private int _DispatchSiteID = 0;

            public int DispatchSiteID
            {
                get
                {
                    return _DispatchSiteID;
                }
            }

            public object SetDispatchSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DispatchSiteID", value);
                }
            }

            private int _DispatchWarehouseID = 0;

            public int DispatchWarehouseID
            {
                get
                {
                    return _DispatchWarehouseID;
                }
            }

            public object SetDispatchWarehouseID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DispatchWarehouseID", value);
                }
            }




            
        }
    }
}