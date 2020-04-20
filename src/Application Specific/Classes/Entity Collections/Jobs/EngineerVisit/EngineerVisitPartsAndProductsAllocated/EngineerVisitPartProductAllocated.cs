using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitPartProductAllocateds
    {
        public class EngineerVisitPartProductAllocated
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitPartProductAllocated()
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
            private string _Type = string.Empty;

            public string Type
            {
                get
                {
                    return _Type;
                }
            }

            public object SetType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Type", value);
                }
            }

            private int _ID = 0;

            public int ID
            {
                get
                {
                    return _ID;
                }
            }

            public object SetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _PartProductID = 0;

            public int PartProductID
            {
                get
                {
                    return _PartProductID;
                }
            }

            public object SetPartProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartProductID", value);
                }
            }

            private string _Name = string.Empty;

            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Name", value);
                }
            }

            private string _Number = string.Empty;

            public string Number
            {
                get
                {
                    return _Number;
                }
            }

            public object SetNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Number", value);
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

            private int _orderItemID = 0;

            public int OrderItemID
            {
                get
                {
                    return _orderItemID;
                }
            }

            public object SetOrderItemID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_orderItemID", value);
                }
            }

            private int _orderLocationTypeID = 0;

            public int OrderLocationTypeID
            {
                get
                {
                    return _orderLocationTypeID;
                }
            }

            public object SetOrderLocationTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_orderLocationTypeID", value);
                }
            }


            // THIS ISN'T IN THE TABLE - IT MAY NOT NEED TO BE HERE! -A L P
            private double _sellPrice = 0;

            public double SellPrice
            {
                get
                {
                    return _sellPrice;
                }
            }

            public object SetSellPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_sellPrice", value);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}