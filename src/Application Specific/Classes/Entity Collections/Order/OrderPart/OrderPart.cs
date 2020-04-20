using System.Collections;

namespace FSM.Entity
{
    namespace OrderParts
    {
        public class OrderPart
        {
            private DataTypeValidator _dataTypeValidator;

            public OrderPart()
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

            private int _ChildSupplierID = 0;

            public int ChildSupplierID
            {
                get
                {
                    return _ChildSupplierID;
                }
            }

            public object SetChildSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ChildSupplierID", value);
                }
            }

            private string _spn = "";

            public string SpecialPartNumber
            {
                get
                {
                    return _spn;
                }
            }

            public object SetSpecialPartNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_spn", value);
                }
            }

            private string _specialDescription = "";

            public string SpecialDescription
            {
                get
                {
                    return _specialDescription;
                }
            }

            public object SetSpecialDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_specialDescription", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}